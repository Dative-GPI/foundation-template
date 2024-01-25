export class PermissionOrganisationTypeInfos {
    id: string;
    organisationTypeId: string;
    permissionCode: string;
    permissionId: string;

    constructor(params: PermissionOrganisationTypeInfosDTO) {
        this.id = params.id;
        this.organisationTypeId = params.organisationTypeId;
        this.permissionCode = params.permissionCode;
        this.permissionId = params.permissionId;
    }
}

export interface PermissionOrganisationTypeInfosDTO {
    id: string;
    organisationTypeId: string;
    permissionCode: string;
    permissionId: string;
}