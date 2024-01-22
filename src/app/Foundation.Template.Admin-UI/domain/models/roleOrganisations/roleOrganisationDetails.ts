import { PermissionOrganisationInfos, PermissionOrganisationInfosDTO } from "../permissions";

export class RoleOrganisationDetails {
    id: string;
    permissions: PermissionOrganisationInfos[];

    constructor(payload: RoleOrganisationDetailsDTO) {
        this.id = payload.id;
        this.permissions = payload.permissions.map(p => new PermissionOrganisationInfos(p));
    }
}

export interface RoleOrganisationDetailsDTO {
    id: string;
    permissions: PermissionOrganisationInfosDTO[];
}

export interface UpdateRoleOrganisationDTO {
    permissions: string[];
}
