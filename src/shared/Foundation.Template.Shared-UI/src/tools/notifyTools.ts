import { AddOrUpdateCallback, AllCallback } from "../abstractions/inotifyService";

export function onCollectionChanged<TInfos, TDetails extends TInfos>(
    accessor: () => TInfos[],
    filter: (el: TDetails) => boolean = (el: TDetails) => true,
    identifier: (e1: TInfos) => any = e1 => (e1 as any).id): AllCallback<TDetails> {

    const result: AllCallback<TDetails> = (ev, payload) => {
        if ((ev === "add" || ev === "update") && !filter(payload as TDetails)) return;

        switch (ev) {
            case "add":
                add(accessor, payload as TDetails, identifier);
                return;
            case "update":
                update(accessor, payload as TDetails, identifier);
                return;
            case "delete":
                remove(accessor, item => item.id === payload, identifier);
                return;
        }
    }

    return result;
}

export function onEntityChanged<TDetails>(
    accessor: () => TDetails,
    setter: (payload: TDetails) => void,
    identifier: (e1: TDetails) => any = e1 => (e1 as any).id): AddOrUpdateCallback<TDetails> {

    const result: AddOrUpdateCallback<TDetails> = (ev, payload) => {
        if (ev === "add" || ev === "update") {
            if (identifier(accessor()) === identifier(payload)) {
                setter(payload);
            }
        }
    }

    return result;
}

function add<TInfos, TDetails extends TInfos>(
    accessor: () => TInfos[],
    payload: TDetails,
    identifier: (e1: TInfos) => any
) {
    const collection = accessor();
    const payloadId = identifier(payload);
    const index = collection.findIndex(el => identifier(el) === payloadId);
    if (index == -1) {
        collection.push(payload);
    }
    else {
        collection.splice(index, 1, payload);
    }
}

function update<TInfos, TDetails extends TInfos>(
    accessor: () => TInfos[],
    payload: TDetails,
    identifier: (e1: TInfos) => any
) {
    const collection = accessor();
    const payloadId = identifier(payload);
    const index = collection.findIndex(el => identifier(el) === payloadId);
    if (index != -1) {
        collection.splice(index, 1, payload);
    }
    else {
        collection.push(payload);
    }
}

function remove<TInfos>(
    accessor: () => TInfos[],
    payload: any,
    identifier: (e1: TInfos) => any
) {
    const collection = accessor();
    const index = collection.findIndex(el => identifier(el) === payload);
    if (index != -1) {
        collection.splice(index, 1);
    }
}

