export class PermissionAdminInfos {
    id: string;
    code: string;
    label: string;

    constructor(params: PermissionAdminInfosDTO) {
        this.id = params.id;
        this.code = params.code;
        this.label = params.label;
    }
}

export interface PermissionAdminInfosDTO {
    id: string;
    code: string;
    label: string;
}

export interface PermissionAdminFilter {
    search?: string
}