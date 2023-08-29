import _ from "lodash";

import { AddOrUpdateEvent, AllCallback, AllEvent, DeleteEvent, INotifyService, IEventQueue } from "../abstractions";

export abstract class NotifyService<TInfos, TDetails extends TInfos> implements INotifyService<TInfos, TDetails> {
  counter;
  topic: string;

  subscribers: Subscriber<TDetails>[];
  eventQueue: IEventQueue<EntityEvent<TDetails>>;

  constructor(eventQueue: IEventQueue<EntityEvent<TDetails>>, type: string) {
    this.topic = `entity.${type.toLowerCase()}`;
    this.counter = 0;
    this.subscribers = [];
    this.eventQueue = eventQueue;
    this.eventQueue.subscribe(this.topic, this.onEntityEvent);
  }

  onEntityEvent(msg: EntityEvent<TDetails>) {
    _(this.subscribers)
      .filter(
        (s) =>
          (s.ev === msg.action || s.ev == "all")
      )
      .forEach((s) => {
        try {
          s.callback(msg.action as never, msg.payload)
        } catch (error) {
          console.error(error);
        }
      });
  }

  subscribe(
    event: "add" | "update" | "delete" | "all",
    callback: AllCallback<TDetails>
  ): number {
    this.counter++;

    this.subscribers.push({
      ev: event,
      callback: callback,
      id: this.counter,
    });

    return this.counter;
  }

  unsubscribe(id: number): void {
    const index = _.findIndex(this.subscribers, (s) => s.id == id);
    if (index != -1) {
      this.subscribers.splice(index, 1);
    }
  }

  notify(event: AddOrUpdateEvent, payload: TDetails): void;
  notify(event: DeleteEvent, payload: any): void;

  notify(event: AddOrUpdateEvent | DeleteEvent, payload: any) {
    this.eventQueue.publish(this.topic, { action: event, payload })
  }
}

interface Subscriber<TDetails> {
  id: number;
  ev: AllEvent;
  callback: AllCallback<TDetails>;
}

type EntityEvent<TDetails> = AddEntityEvent<TDetails> | UpdateEntityEvent<TDetails> | DeleteEntityEvent;

interface AddEntityEvent<TDetails> {
  action: "add";
  payload: TDetails;
}

interface UpdateEntityEvent<TDetails> {
  action: "update";
  payload: TDetails;
}

interface DeleteEntityEvent {
  action: "delete";
  payload: any;
}