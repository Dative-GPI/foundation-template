export class EntityPropertyInfos {
    id: string;
    code: string;
    entityType: string;

    labelDefault: string;
    categoryLabelDefault: string;

    parentCode: string;

    value: string;

    constructor(params: EntityPropertyDTO) {
        this.id = params.id;
        this.code = params.code;
        this.entityType = params.entityType;
        this.labelDefault = params.labelDefault;
        this.categoryLabelDefault = params.categoryLabelDefault;
        this.value = params.value;
        this.parentCode = params.parentCode;
    }
}

export interface EntityPropertyDTO {
    id: string;
    code: string;
    entityType: string;

    parentCode: string;
    labelDefault: string;
    categoryLabelDefault: string;

    value: string;
}