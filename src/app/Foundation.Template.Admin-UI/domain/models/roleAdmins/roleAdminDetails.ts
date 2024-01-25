export class RoleAdminDetails {
    permissionIds: string[];

    constructor(params: RoleAdminDetailsDTO) {
        this.permissionIds = params.permissionIds;
    }
}

export interface RoleAdminDetailsDTO {
    permissionIds: string[];
}

export interface UpdateRoleAdminDTO {
    permissionIds: string[];
}
