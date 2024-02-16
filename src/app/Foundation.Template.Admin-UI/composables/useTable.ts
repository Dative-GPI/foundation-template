import { ComposableFactory, ServiceFactory } from "@dative-gpi/bones-ui";

import { TABLES_URL, TABLE_PROPERTIES_URL, TABLE_URL } from "../config";

import { Column, TableDetails, TableDetailsDTO, TableInfos } from "../domain";
import { ref } from "vue";


const TableServiceFactory = new ServiceFactory<TableDetails, TableDetailsDTO>("disposition", TableDetails)
    .create(f => f.build(
        f.addGet(TABLE_URL),
        f.addGetMany(TABLES_URL, TableInfos),
        f.addUpdate(TABLE_URL),
        f.addNotify(notifier => ({
            synchronizeColumns: async (tableId: string) => {
                const response = await ServiceFactory.http.patch(TABLE_PROPERTIES_URL(tableId));
                const dto: TableDetailsDTO = response.data;
                const result = new TableDetails(dto);
                
                notifier.notify("update", result);
            }
        }))));


export const useTable = ComposableFactory.get(TableServiceFactory);
export const useTables = ComposableFactory.getMany(TableServiceFactory);
export const useUpdateTable = ComposableFactory.update(TableServiceFactory);
export const useSynchronizeTable = () => {
    const service = TableServiceFactory();

    const synchronizing = ref(false);
    const synchronized = ref(false);

    const synchronize = async (tableId: string) => {
        synchronizing.value = true;
        try {
            await service.synchronizeColumns(tableId);
            synchronized.value = true;
        }
        finally {
            synchronizing.value = false;
        }
    }

    return {
        synchronizing,
        synchronize,
        synchronized
    }
}