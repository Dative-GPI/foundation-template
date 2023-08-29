import _ from "lodash";
import Ajv, { JSONSchemaType, ValidateFunction } from "ajv";

interface WindowsMessage {
    id: string;
    topic: string;
    payload: object;
}

const schema: JSONSchemaType<WindowsMessage> = {
    type: "object",
    properties: {
        id: { type: "string" },
        topic: { type: "string" },
        payload: { type: "object" }
    },
    required: ["id", "topic", "payload"],
    additionalProperties: false
}

const bufferSize = 100;

export class GlobalQueue {
    private static _instance: GlobalQueue;

    subscriptionCounter: number;
    messageCounter: number;
    buffer: string[];

    subscribers: GlobalSubscriber[];
    validator: ValidateFunction<WindowsMessage>;


    private constructor() {
        this.subscriptionCounter = 0;
        this.subscribers = [];

        this.validator = new Ajv().compile(schema);
        this.buffer = [...Array(bufferSize)];

        window.addEventListener(
            "message",
            this.onWindowsMessage.bind(this),
            false
        );
    }

    public static get instance(): GlobalQueue {
        if (!GlobalQueue._instance) {
            GlobalQueue._instance = new GlobalQueue();
        }

        return GlobalQueue._instance;
    }

    publish(topic: string, payload: any): void {
        _(this.subscribers)
            .filter((s) => s.topic === topic)
            .forEach((s) => {
                try {
                    s.callback(topic, payload);
                } catch (error) {
                    console.error(error);
                }
            });

        if (window.top) {
            const message: WindowsMessage = {
                id: _.uniqueId("remote_"),
                topic,
                payload
            };

            this.buffer[this.messageCounter % bufferSize] = message.id;
            window.top.postMessage(JSON.stringify(message), "*");
        }
    }

    subscribe(topic: string, callback: (topic: string, payload: any) => void): number {
        this.subscriptionCounter++;

        this.subscribers.push({
            id: this.subscriptionCounter,
            topic,
            callback
        });

        return this.subscriptionCounter;
    }

    unsubscribe(id: number): void {
        const index = _.findIndex(this.subscribers, (s: GlobalSubscriber) => s.id == id);
        if (index != -1) {
            this.subscribers.splice(index, 1);
        }
    }

    onWindowsMessage(event: MessageEvent) {
        let data;

        try {
            data = JSON.parse(event.data);
        } catch (error) {
            return;
        }

        // not with the expected format
        if (!this.validator(data)) {
            return;
        }

        // we already processed this message
        if (this.buffer.includes(data.id)) {
            return;
        }

        this.publish(data.topic, data.payload);
    }
}

interface GlobalSubscriber {
    id: number;
    topic: string;
    callback: (topic: string, msg: any) => void;
}