// Composables
import { RouteRecordRaw } from 'vue-router'
import drawersRoutes from "./drawers"


export const routes: RouteRecordRaw[] = [
    {
        path: "/admin/v1/application-translations",
        name: "application-translations",
        component: () => import('../views/Translations.vue'),
    },
    {  // TO REMOVE AFTER CHANGEfor admin -> application
        path: "/admin/v1/role-admins/:roleId",
        name: "permissions-application-role-admin",
        component: () => import('../views/RolePermissionApplications.vue'),
    },
    {
        path: "/admin/v1/role-applications/:roleId",
        name: "permissions-application-role-application",
        component: () => import('../views/RolePermissionApplications.vue'),
    },
    {
        path: "/admin/v1/organisation-types/:organisationTypeId/permissions",
        name: "permissions-organisation-type",
        component: () => import('../views/PermissionOrganisationTypes.vue'),
    },
    {
        path: "/admin/v1/role-organisation-types/:roleId",
        name: "role-permission-organisations",
        component: () => import('../views/RolePermissionOrganisations.vue'),
    },
    ...drawersRoutes,
]