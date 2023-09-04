import { ServiceFactory } from "@dative-gpi/bones-ui";

import { PERMISSIONS_URL, PERMISSION_CATEGORIES_URL } from "../config";

import { useOrganisationId } from "./useOrganisationId";
import { PermissionCategory, PermissionInfos, PermissionInfosDTO } from "../domain";
import { ref } from "vue";

const { organisationId } = useOrganisationId()

const PermissionServiceFactory = ServiceFactory.create("permissions", f => {

    const { getMany: getCategories } = f.addGetMany(() => {
        if (organisationId.value) return PERMISSION_CATEGORIES_URL(organisationId.value)
        throw "No OrganisationId"
    }, PermissionCategory)

    return f.build(
        f.addGetMany<PermissionInfosDTO, PermissionInfos, void>(() => {
            if (organisationId.value) return PERMISSIONS_URL(organisationId.value)
            throw "No OrganisationId"
        }, PermissionInfos),
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
