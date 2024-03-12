export class Table {
    table: UserOrganisationTable;
    columns: UserOrganisationColumn[];

    constructor(params: TableDTO) {
        this.table = params.table;
        this.columns = params.columns;
    }
}

export interface UpdateTable {
    tableCode: string;
    mode: string;
    sortBy: string;
    sortOrder: string;
    rowsPerPage: number;
    columns: UpdateUserOrganisationColumn[];
}


export interface TableDTO {
    table: UserOrganisationTable;
    columns: UserOrganisationColumn[];
}

export interface UserOrganisationColumn {
    columnId: string;
    label: string;
    value: string;
    index: number;
    hidden: boolean;
    sortable: boolean;
    filterable: boolean;
}

export interface UserOrganisationTable {
    id: string;
    tableCode: string;
    mode: string;
    sortBy: string;
    sortOrder: string;
    rowsPerPage: number;
}

export interface UpdateUserOrganisationColumn {
    columnId: string;
    hidden: boolean;
    index: number;
    sortable: boolean;
    filterable: boolean;
}

