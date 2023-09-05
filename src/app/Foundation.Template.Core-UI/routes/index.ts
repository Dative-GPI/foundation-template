import { CustomRouteConfig } from "@dative-gpi/foundation-template-shared-ui";

export * from "./paths";

export const routes: CustomRouteConfig[] = [
    {
        path: "/role-organisations/:roleId/permissions",
        name: "organisation-role-permissions",
        components: {
            default: () => import("../views/RoleOrganisation.vue")
        },
    },
]