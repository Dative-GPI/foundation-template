import { ref } from "vue";
import { ServiceFactory } from "@dative-gpi/bones-ui";

import { PERMISSIONS_URL, PERMISSION_CATEGORIES_URL } from "../config";

import { PermissionOrganisationCategory, PermissionOrganisationInfos, PermissionOrganisationInfosDTO } from "../domain";

const PermissionServiceFactory = ServiceFactory.create("permissions", f => {

    const { getMany: getCategories } = f.addGetMany(PERMISSION_CATEGORIES_URL, PermissionOrganisationCategory)

    return f.build(
        f.addGetMany<PermissionOrganisationInfosDTO, PermissionOrganisationInfos, void>(PERMISSIONS_URL, PermissionOrganisationInfos),
        {
            getCategories
        }
    )
});

export const usePermissions = () => {
    const fetching = ref(false);
    const permissions = ref<PermissionOrganisationInfos[]>([]);
    const categories = ref<PermissionOrganisationCategory[]>([]);

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
