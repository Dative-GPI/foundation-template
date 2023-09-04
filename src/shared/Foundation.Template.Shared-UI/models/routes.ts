import { RouteConfig } from "vue-router";
import Vue, { AsyncComponent } from "vue";
import { ComponentOptions } from "vue/types/umd";

type Component = ComponentOptions<Vue> | typeof Vue | AsyncComponent

interface CustomRoute {
    components: {
        crumbs?: Component;
        pageInformation?: Component;
        default: Component;
    },
    props?: {
        crumbs?: any
        default?: any,
        title?: any,
        pageInformation?: any
    }
}

interface SimpleRoute {
    components: {
        crumbs?: Component;
        pageInformation?: Component;
        default: Component;
    },
    props: {
        crumbs?: any
        default?: any,
        title: {
            codeLabel: string,
            defaultLabel: string
        },
        pageInformation?: {
            code: string;
        }
    }
}

export type CustomRouteConfig = (CustomRoute | SimpleRoute) & Omit<RouteConfig, "props">

interface DrawerRouteMeta {
    meta: {
        codeHeader?: string;
        disabled?: boolean;
        drawerCodeLabel: string;
        drawerDefaultLabel: string;
        exact?: boolean;
        icon: string;
        defaultParams?: (params: any) => any;
    }
}

export type DrawerRouteConfig = (SimpleRoute | CustomRoute) & DrawerRouteMeta & Omit<RouteConfig, "meta" | "props">;
