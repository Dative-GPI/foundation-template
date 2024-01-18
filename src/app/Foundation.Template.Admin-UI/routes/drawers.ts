import { RouteRecordRaw } from "vue-router";
import SimpleTitle from "../components/shared/SimpleTitle.vue";
import { IMPORT_TRANSLATIONS_DRAWER_URL } from "../config";

const drawersRoutes: RouteRecordRaw[] = [
    {
        path: "/admin/translations/:translation/drawer",
        name: "update-translation-drawer",
        components: {
            default: () => import("../components/UpdateTranslationDrawer.vue"),
            title: SimpleTitle
        },
        meta: {
            exact: false,
            drawer: true
        }
    },
    {
        path: IMPORT_TRANSLATIONS_DRAWER_URL,
        name: "import-translations-drawer",
        components: {
            default: () => import("../components/ImportTranslationsDrawer.vue"),
            title: SimpleTitle
        },
        meta: {
            exact: false,
            drawer: true
        }
    }
]

export default drawersRoutes;