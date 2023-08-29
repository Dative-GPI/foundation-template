export interface IEventQueue<T> {
    publish(topic, payload: T): void;
    subscribe(topic: string, callback: (event: T) => void): number;

    unsubscribe(id: number): void;
}
