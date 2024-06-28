import { ref } from "vue";
import { ServiceFactory } from "@dative-gpi/bones-ui";

import { PERMISSION_ORGANISATION_CATEGORIES_URL, PERMISSION_ORGANISATIONS_URL } from "../config";

import { PermissionOrganisationCategory, PermissionOrganisationInfos } from "../domain";

const PermissionOrganisationServiceFactory = new ServiceFactory("permission-organisation", PermissionOrganisationInfos)
    .create(f => {
        const { getMany: getCategories } = f.addGetMany(PERMISSION_ORGANISATION_CATEGORIES_URL, PermissionOrganisationCategory)
        const { getMany } = f.addGetMany(PERMISSION_ORGANISATIONS_URL, PermissionOrganisationInfos)

        return f.build(
            {
                getMany,
                getCategories
            }
        )
    });

export const usePermissionOrganisations = () => {
    const fetching = ref(false);
    const permissionOrganisations = ref<PermissionOrganisationInfos[]>([]);
    const categories = ref<PermissionOrganisationCategory[]>([]);

    const service = PermissionOrganisationServiceFactory();

    const getAll = async () => {
        fetching.value = true;

        try {
            const [p, c] = await Promise.all([
                service.getMany(),
                service.getCategories()
            ]);

            permissionOrganisations.value = p;
            categories.value = c;

        } finally {
            fetching.value = false;
        }

        return {
            permissionOrganisations,
            categories
        }
    }

    return {
        getAll,
        permissionOrganisations,
        categories,
        fetching
    }
}
