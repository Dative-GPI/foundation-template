export class RoleOrganisationDetails {
    permissionIds: string[];

    constructor(params: RoleOrganisationDetailsDTO) {
        this.permissionIds = params.permissionIds;
    }
}

export interface RoleOrganisationDetailsDTO {
    permissionIds: string[];
}

export interface UpdateRoleOrganisation {
    permissionIds: string[];
}
