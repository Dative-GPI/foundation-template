// Composables
import { RouteRecordRaw } from 'vue-router'
import drawersRoutes from "./drawers"


export const routes: RouteRecordRaw[] = [
    {
        path: "/admin/v1/application-translations",
        name: "application-translations",
        component: () => import('../views/Translations.vue'),
    },
    ...drawersRoutes,
]


