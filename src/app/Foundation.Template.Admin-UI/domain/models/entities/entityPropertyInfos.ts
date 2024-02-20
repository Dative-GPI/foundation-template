export class EntityPropertyInfos {
    id: string;
    code: string;
    entityType: string;

    labelDefault: string;
    categoryLabelDefault: string;

    value: string;

    constructor(params: EntityPropertyDTO) {
        this.id = params.id;
        this.code = params.code;
        this.entityType = params.entityType;
        this.labelDefault = params.labelDefault;
        this.categoryLabelDefault = params.categoryLabelDefault;
        this.value = params.value;
    }
}

export interface EntityPropertyDTO {
    id: string;
    code: string;
    entityType: string;

    labelDefault: string;
    categoryLabelDefault: string;

    value: string;
}