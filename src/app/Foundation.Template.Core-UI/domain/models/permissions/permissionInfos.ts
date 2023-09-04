export class PermissionInfos {
    id: string;
    code: string;
    label: string;

    constructor(params: PermissionInfosDTO) {
        this.id = params.id;
        this.code = params.code;
        this.label = params.label;
    }
}

export interface PermissionInfosDTO {
    id: string;
    code: string;
    label: string;
}