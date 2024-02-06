import { ComposableFactory, ServiceFactory } from "@dative-gpi/bones-ui";

import { ROLE_PERMISSION_ORGANISATION_URL } from "../config";

import { RoleOrganisationDetails, RoleOrganisationDetailsDTO, UpdateRoleOrganisationDTO } from "../domain";

const RoleOrganisationServiceFactory = new ServiceFactory<RoleOrganisationDetailsDTO, RoleOrganisationDetails>("role-permissions", RoleOrganisationDetails)
    .create(f => f.build(
        f.addGet(ROLE_PERMISSION_ORGANISATION_URL),
        f.addUpdate<UpdateRoleOrganisationDTO>(ROLE_PERMISSION_ORGANISATION_URL),
        f.addNotify()
    ));

export const useUpdateRoleOrganisation = ComposableFactory.update(RoleOrganisationServiceFactory);
export const useRoleOrganisation = ComposableFactory.get(RoleOrganisationServiceFactory);
