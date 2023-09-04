import { PermissionInfos, PermissionInfosDTO } from "../permissions";

export class RoleOrganisationDetails {
    id: string;
    permissions: PermissionInfos[];

    constructor(payload: RoleOrganisationDetailsDTO) {
        this.id = payload.id;
        this.permissions = payload.permissions.map(p => new PermissionInfos(p));
    }
}

export interface RoleOrganisationDetailsDTO {
    id: string;
    permissions: PermissionInfosDTO[];
}

export interface UpdateRoleOrganisationDTO {
    permissions: string[]; 
}
