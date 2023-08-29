import { JTDSchemaType } from "ajv/dist/core"

export interface IExtensionCommunicationBridge {
    goTo(path: string): Promise<void>
    setTitle(title: string): void
    setCrumbs(crumbs: any[]): void
    setHeight(height: number, path: string): void
    setWidth(width: number, path: string): void
    openDialog(path: string): Promise<void>
    closeDialog(path: string): Promise<void>
    openDrawer(path: string): Promise<void>
    closeDrawer(path: string, success: boolean): Promise<void>
}