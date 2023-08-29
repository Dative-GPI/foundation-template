import { DependencyContainer } from "tsyringe";

import { SERVICES as S } from "../config";
import { EventQueue, ExtensionCommunicationBridge } from "../core";
import { IEventQueue, IExtensionCommunicationBridge } from "../abstractions";

export function registerTemplateUI(container: DependencyContainer) {
    container.registerSingleton<IExtensionCommunicationBridge>(S.EXTENSION_COMMUNICATION_BRIDGE, ExtensionCommunicationBridge)
    container.register(S.EVENT_QUEUE, EventQueue);
}