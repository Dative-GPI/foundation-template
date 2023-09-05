import { RouteRecordRaw } from "vue-router";

export const routes: RouteRecordRaw[] = [
    {
        path: "/organisations/:organisation-id/role-organisations/:roleId",
        name: "organisation-role-permissions",
        components: {
            default: () => import("../views/RoleOrganisation.vue")
        },
    },
]