// Composables
import { RouteRecordRaw } from 'vue-router'
import drawersRoutes from "./drawers"


export const routes: RouteRecordRaw[] = [
    {
        path: "/admin/v1/application-translations",
        name: "application-translations",
        component: () => import('../views/Translations.vue'),
    },
    {
        path: "/admin/v1/role-applications/:roleId",
        name: "application-role-application-permissions",
        component: () => import('../views/ApplicationRolePermissions.vue'),
    },
    {
        path: "/admin/v1/permissions-organisations",
        name: "permission-organisations",
        component: () => import('../views/PermissionOrganisations.vue'),
    },
    {
        path: "/admin/v1/organisation-types/:organisationTypeId/permissions",
        name: "organisation-type-permissions",
        component: () => import('../views/PermissionOrganisationTypes.vue'),
    },
    ...drawersRoutes,
]


