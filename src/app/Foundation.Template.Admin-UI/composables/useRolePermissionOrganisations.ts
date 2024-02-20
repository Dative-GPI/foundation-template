import { ComposableFactory, ServiceFactory, onCollectionChanged, onEntityChanged } from "@dative-gpi/bones-ui";

import { RolePermissionOrganisationDetails, RolePermissionOrganisationDetailsDTO, UpdateRolePermissionOrganisation } from "../domain";
import { Ref, onUnmounted, readonly, ref } from "vue";
import { ROLE_PERMISSION_ORGANISATION_URL } from "../config/urls/RolePermissionOrganisations";

const RolePermissionServiceFactory = new ServiceFactory("role-permission-organisation-type", RolePermissionOrganisationDetails)
    .create(f => f.build(
        f.addGet(ROLE_PERMISSION_ORGANISATION_URL, RolePermissionOrganisationDetails),
        f.addNotify(
            notifier => ({
                update: async (roleId: string, payload: UpdateRolePermissionOrganisation) => {
                    const response = await ServiceFactory.http.post(ROLE_PERMISSION_ORGANISATION_URL(roleId), payload);
                    const dto: RolePermissionOrganisationDetailsDTO = response.data;
                    const result = new RolePermissionOrganisationDetails(dto);

                    notifier.notify("update", result);
                }
            })
        )
    ));

export const useRolePermissionOrganisations = ComposableFactory.get(RolePermissionServiceFactory);

export const useUpdateRolePermissionOrganisations = () => {
    const service = RolePermissionServiceFactory();

    const updating = ref(false);
    const updated = ref<RolePermissionOrganisationDetails>() as Ref<RolePermissionOrganisationDetails>;

    const update = async (roleId: string, payload: UpdateRolePermissionOrganisation) => {
        updating.value = true;
        try {
            updated.value = await service.update(roleId, payload);
        }
        finally {
            updating.value = false;
        }

        const subscriberId = service.subscribe("all", onEntityChanged(updated))
        onUnmounted(() => service.unsubscribe(subscriberId));

        return readonly(updated.value);
    }

    return {
        upserting: readonly(updating),
        update,
        updated: readonly(updated)
    }
}

