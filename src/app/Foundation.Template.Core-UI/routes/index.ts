
export const routes = [
    {
        path: "/role-organisations/:roleId/permissions",
        name: "organisation-role-permissions",
        components: {
            default: () => import("../views/RoleOrganisation.vue")
        },
    },
]