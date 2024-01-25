import { ref } from "vue";
import { ServiceFactory } from "@dative-gpi/bones-ui";

import { PERMISSIONS_ADMIN_CATEGORIES_URL, PERMISSIONS_URL } from "../config";

import { PermissionAdminCategory, PermissionAdminInfos, PermissionOrganisationInfos } from "../domain";

const PermissionServiceFactory = new ServiceFactory("permission-organisation", PermissionOrganisationInfos)
    .create(f => {
        const { getMany: getCategories } = f.addGetMany(PERMISSIONS_ADMIN_CATEGORIES_URL, PermissionAdminCategory)
        const { getMany } = f.addGetMany(PERMISSIONS_URL, PermissionAdminInfos)

        return f.build(
            {
                getMany,
                getCategories
            }
        )
    });

export const usePermissions = () => {
    const fetching = ref(false);
    const permissions = ref<PermissionAdminInfos[]>([]);
    const categories = ref<PermissionAdminCategory[]>([]);

    const service = PermissionServiceFactory();

    const getAll = async () => {
        fetching.value = true;

        try {
            const [p, c] = await Promise.all([
                service.getMany(),
                service.getCategories()
            ]);

            permissions.value = p;
            categories.value = c;

        } finally {
            fetching.value = false;
        }

        return {
            permissions,
            categories
        }
    }

    return {
        getAll,
        permissions,
        categories,
        fetching
    }
}
