import { ComposableFactory, ServiceFactory } from "@dative-gpi/bones-ui";

import { ROLE_ORGANISATION_URL } from "../config";

import { RoleOrganisationDetails, RoleOrganisationDetailsDTO, UpdateRoleOrganisationDTO } from "../domain";

const RoleOrganisationServiceFactory = ServiceFactory.create("permissions", f => f.build(
    f.addGet(ROLE_ORGANISATION_URL, RoleOrganisationDetails),
    f.addUpdate<UpdateRoleOrganisationDTO, RoleOrganisationDetailsDTO, RoleOrganisationDetails>(ROLE_ORGANISATION_URL, RoleOrganisationDetails),
    f.addNotify<RoleOrganisationDetails>()
));

export const useUpdateRoleOrganisation = ComposableFactory.update(RoleOrganisationServiceFactory);
export const useRoleOrganisation = ComposableFactory.get(RoleOrganisationServiceFactory);
