import { ComposableFactory, ServiceFactory } from "@dative-gpi/bones-ui";

import { ORGANISATION_TYPE_TABLE_URL } from "../config";

import { OrganisationTypeTableDetails, OrganisationTypeTableDetailsDTO, TableDetails, UpdateOrganisationTypeTableDTO } from "../domain";
import { ref } from "vue";
import axios from "axios";


const OrganisationTypeTableServiceFactory = new ServiceFactory<OrganisationTypeTableDetails, OrganisationTypeTableDetailsDTO>("organisation-type-table", OrganisationTypeTableDetails)
    .create(f => f.build(
        f.addNotify(
            notifier => ({
                get: async (organisationTypeId: string, tableId: string) => {
                    const response = await axios.get(ORGANISATION_TYPE_TABLE_URL(organisationTypeId, tableId));
                    const data: OrganisationTypeTableDetailsDTO = response.data;
                    return new OrganisationTypeTableDetails(data);
                },
                update: async (organisationTypeId: string, tableId: string, payload: UpdateOrganisationTypeTableDTO) => {
                    const response = await axios.post(ORGANISATION_TYPE_TABLE_URL(organisationTypeId, tableId), payload);
                    const data: OrganisationTypeTableDetailsDTO = response.data;
                    const result = new OrganisationTypeTableDetails(data);

                    notifier.notify("update", result);

                    return result;
                }
            })
        )
    ));


export const useOrganisationTypeTable = () => {
    const service = OrganisationTypeTableServiceFactory();
    const entity = ref<OrganisationTypeTableDetails | undefined>(undefined);

    const fetching = ref(false);
    const fetched = ref(false);

    const get = async (organisationTypeId: string,tableId: string) => {
        fetching.value = true;
        try {
            entity.value = await service.get(organisationTypeId, tableId);
            fetched.value = true;
        }
        finally {
            fetching.value = false;
        }

        return {
            entity
        }
    }

    return {
        get,
        entity,
        fetched,
        fetching
    }
}
export const useUpdateOrganisationTypeTable = () => {
    const service = OrganisationTypeTableServiceFactory();

    const uptading = ref(false);
    const updated = ref(false);

    const update = async (organisationTypeId: string, tableId: string, payload: UpdateOrganisationTypeTableDTO) => {
        uptading.value = true;
        try {
            await service.update(organisationTypeId, tableId, payload);
            updated.value = true;
        }
        finally {
            uptading.value = false;
        }
    }

    return {
        update,
        uptading,
        updated
    }
}