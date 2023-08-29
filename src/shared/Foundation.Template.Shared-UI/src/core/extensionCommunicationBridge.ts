import _ from "lodash";

import { IExtensionCommunicationBridge } from "../abstractions";

export class ExtensionCommunicationBridge implements IExtensionCommunicationBridge {
  title: string;
  height: number;
  counter = 0;
  crumbs: any[] = [];

  constructor() {
    this.height = 0;
    this.title = "";
  }

  async goTo(path: string): Promise<void> {
    await this.notifyPath(path);
  }

  setTitle(title: string): void {
    // if (this.title != title) {
    this.title = title;
    this.notifyTitle();
    // }
  }

  setCrumbs(crumbs: any[]) {
    if (this.crumbs != crumbs) {
      this.crumbs = crumbs;
      this.notifyCrumbs();
    }
  }

  setHeight(height: number, path: string): void {
    if (this.height != height) {
      this.height = height;
      this.notifyHeight(path);
    }
  }

  setWidth(width: number, path: string): void {
    const payload = {
      width,
      path,
    };
    this.notify(payload);
  }

  openDialog(path: string): Promise<void> {
    throw new Error("Method not implemented.");
  }

  closeDialog(path: string): Promise<void> {
    throw new Error("Method not implemented.");
  }

  async openDrawer(path: string): Promise<void> {
    const payload = {
      path,
      drawer: true,
    };
    await this.notify(payload);
  }

  async closeDrawer(path: string, success: boolean = false): Promise<void> {
    const payload = {
      path,
      success,
      drawer: false,
    };
    await this.notify(payload);
  }

  notifyHeight = _.debounce((path) => {
    const payload = {
      height: this.height,
      path: path,
    };
    this.notify(payload);
  }, 50);

  notifyTitle = _.debounce(() => {
    const payload = {
      title: this.title,
    };
    this.notify(payload);
  }, 50);

  notifyCrumbs = _.debounce(() => {
    const payload = {
      crumbs: this.crumbs,
    };
    this.notify(payload);
  }, 50);

  notifyPath = _.debounce((path) => {
    const payload = {
      path: path,
    };
    this.notify(payload);
  }, 50);

  notify(payload: any) {
    if (window.top) {
      window.top.postMessage(JSON.stringify(payload), "*");
    }
  }
}
