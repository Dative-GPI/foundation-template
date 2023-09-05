import { ref } from "vue";
import { ServiceFactory } from "@dative-gpi/bones-ui";

import { PERMISSIONS_URL, PERMISSION_CATEGORIES_URL } from "../config";

import { PermissionCategory, PermissionInfos, PermissionInfosDTO } from "../domain";

const PermissionServiceFactory = ServiceFactory.create("permissions", f => {

    const { getMany: getCategories } = f.addGetMany(PERMISSION_CATEGORIES_URL, PermissionCategory)

    return f.build(
        f.addGetMany<PermissionInfosDTO, PermissionInfos, void>(PERMISSIONS_URL, PermissionInfos),
        {
            getCategories
        }
    )
});

export const usePermissions = () => {
    const fetching = ref(false);
    const permissions = ref<PermissionInfos[]>([]);
    const categories = ref<PermissionCategory[]>([]);

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
