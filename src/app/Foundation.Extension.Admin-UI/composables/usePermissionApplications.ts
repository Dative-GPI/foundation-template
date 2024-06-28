import { ref } from "vue";
import { ServiceFactory } from "@dative-gpi/bones-ui";

import { PERMISSION_APPLICATION_CATEGORIES_URL, PERMISSION_APPLICATIONS_URL } from "../config";

import { PermissionApplicationCategory, PermissionApplicationInfos } from "../domain";

const PermissionApplicationServiceFactory = new ServiceFactory("permission-application", PermissionApplicationInfos)
    .create(f => {
        const { getMany: getCategories } = f.addGetMany(PERMISSION_APPLICATION_CATEGORIES_URL, PermissionApplicationCategory)
        const { getMany } = f.addGetMany(PERMISSION_APPLICATIONS_URL, PermissionApplicationInfos)

        return f.build(
            {
                getMany,
                getCategories
            }
        )
    });

export const usePermissionApplications = () => {
    const fetching = ref(false);
    const permissionApplications = ref<PermissionApplicationInfos[]>([]);
    const categories = ref<PermissionApplicationCategory[]>([]);

    const service = PermissionApplicationServiceFactory();

    const getAll = async () => {
        fetching.value = true;

        try {
            const [p, c] = await Promise.all([
                service.getMany(),
                service.getCategories()
            ]);

            permissionApplications.value = p;
            categories.value = c;

        } finally {
            fetching.value = false;
        }

        return {
            permissionApplications,
            categories
        }
    }

    return {
        getAll,
        permissionApplications,
        categories,
        fetching
    }
}
