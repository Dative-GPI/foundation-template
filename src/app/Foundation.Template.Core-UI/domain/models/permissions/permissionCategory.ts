export class PermissionCategory {
    label: string;
    prefix: string;

    constructor(params: PermissionCategoryDTO) {
        this.label = params.label;
        this.prefix = params.prefix;
    }
}

export interface PermissionCategoryDTO {
    label: string;
    prefix: string;
}