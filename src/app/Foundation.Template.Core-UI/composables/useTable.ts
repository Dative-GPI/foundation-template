import { ComposableFactory, ServiceFactory } from "@dative-gpi/bones-ui";

import { TABLE_URL } from "../config";

import { Table, UpdateTable, TableDTO } from "../domain";
import { Ref, readonly, ref } from "vue";

const TableServiceFactory = new ServiceFactory("user-organisation-disposition", Table)
    .create(f => f.build(
        f.addNotify(notifier => ({
            get: async (tableCode: string) => {
                const response = await ServiceFactory.http.get(TABLE_URL(tableCode));
                const dto: TableDTO = response.data;
                const result = new Table(dto);

                return result;
            },
            update: async (tableCode: string, payload: UpdateTable) => {
                await ServiceFactory.http.post(TABLE_URL(tableCode), payload);
            }
        })),
    ));


export const useGetTable = () => {
    const service = TableServiceFactory();

    const getting = ref(false);
    const getted = ref<Table>() as Ref<Table>;

    const get = async (tableCode: string) => {
        getting.value = true;
        try {
            getted.value = await service.get(tableCode);
        }
        finally {
            getting.value = false;
        }

        return getted.value;
    }

    return {
        getting,
        get,
        getted
    }
}

export const useUpdateTable = () => {
    const service = TableServiceFactory();

    const updating = ref(false);

    const update = async (tableCode: string, payload: UpdateTable) => {
        updating.value = true;
        try {
            await service.update(tableCode, payload);
        }
        finally {
            updating.value = false;
        }
    }

    return {
        updating,
        update
    }
}
