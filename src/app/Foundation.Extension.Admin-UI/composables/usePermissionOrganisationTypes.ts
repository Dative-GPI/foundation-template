import { ComposableFactory, ServiceFactory, onCollectionChanged } from "@dative-gpi/bones-ui";

import { PERMISSION_ORGANISATION_TYPES_URL } from "../config";

import { PermissionOrganisationTypeInfos, PermissionOrganisationTypeInfosDTO, UpsertPermissionOrganisation } from "../domain";
import { Ref, onUnmounted, readonly, ref } from "vue";

const PermissionServiceFactory = new ServiceFactory("permission-organisation-type", PermissionOrganisationTypeInfos)
    .create(f => f.build(
        f.addGetMany(PERMISSION_ORGANISATION_TYPES_URL, PermissionOrganisationTypeInfos),
        f.addNotify(
            notifier => ({
                upsert: async (payload: UpsertPermissionOrganisation[]) => {
                    const response = await ServiceFactory.http.patch(PERMISSION_ORGANISATION_TYPES_URL, payload);
                    const dtos: PermissionOrganisationTypeInfosDTO[] = response.data;
                    const results = dtos.map(d => new PermissionOrganisationTypeInfos(d));

                    for (const result of results) {
                        notifier.notify("update", result);
                    }

                    return results;
                }
            })
        )
    ));

export const usePermissionOrganisationTypes = ComposableFactory.getMany(PermissionServiceFactory);

export const useUpsertPermissionOrganisationTypes = () => {
    const service = PermissionServiceFactory();

    const upserting = ref(false);
    const upserted = ref<PermissionOrganisationTypeInfos[]>([]) as Ref<PermissionOrganisationTypeInfos[]>;

    const upsert = async (payload: UpsertPermissionOrganisation[]) => {
        upserting.value = true;
        try {
            upserted.value = await service.upsert(payload);
        }
        finally {
            upserting.value = false;
        }

        const subscriberId = service.subscribe("all", onCollectionChanged(upserted))
        onUnmounted(() => service.unsubscribe(subscriberId));

        return readonly(upserted.value);
    }

    return {
        upserting: readonly(upserting),
        upsert,
        upserted: readonly(upserted)
    }
}

