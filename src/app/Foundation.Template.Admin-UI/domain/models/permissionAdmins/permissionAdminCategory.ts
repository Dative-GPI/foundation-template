export class PermissionAdminCategory {
    label: string;
    prefix: string;

    constructor(params: PermissionAdminCategoryDTO) {
        this.label = params.label;
        this.prefix = params.prefix;
    }
}

export interface PermissionAdminCategoryDTO {
    label: string;
    prefix: string;
}