import _ from "lodash"

import { IEventQueue } from "../abstractions";
import { GlobalQueue } from "./globalEventQueue";

export class EventQueue<TMessage> implements IEventQueue<TMessage> {
    counter;
    subscribers: Subscriber<TMessage>[];

    topics: Set<string>;

    constructor() {
        this.counter = 0;
        this.subscribers = [];
        this.topics = new Set();
    }

    publish(topic: any, payload: TMessage): void {
        GlobalQueue.instance.publish(topic, payload);
    }

    subscribe(topic: string, callback: (payload: TMessage) => void): number {
        if (!this.topics.has(topic)) {
            this.topics.add(topic);
            GlobalQueue.instance.subscribe(topic, this.onMessage);
        }

        this.counter++;

        this.subscribers.push({
            id: this.counter,
            topic,
            callback
        });

        return this.counter;
    }

    onMessage(topic: string, payload: any) {
        _(this.subscribers)
            .filter((s) => s.topic === topic)
            .forEach((s) => {
                try {
                    s.callback(payload as TMessage);
                } catch (error) {
                    console.error(error);
                }
            });
    }

    unsubscribe(id: number): void {
        const index = _.findIndex(this.subscribers, (s) => s.id == id);
        if (index != -1) {
            this.subscribers.splice(index, 1);
        }
    }
}

interface Subscriber<TMessage> {
    id: number;
    topic: string;
    callback: (msg: TMessage) => void;
}