import { RoleOrganisationDetails, UpdateRoleOrganisationDTO } from "../domain";

export interface IRoleOrganisationService {
    get(organisationId: string, roleId: string): Promise<RoleOrganisationDetails>;
    update(organisationId: string, roleId: string, payload: UpdateRoleOrganisationDTO): Promise<RoleOrganisationDetails>;
}