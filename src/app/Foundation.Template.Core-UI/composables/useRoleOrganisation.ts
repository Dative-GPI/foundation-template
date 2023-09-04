import { ComposableFactory, ServiceFactory } from "@dative-gpi/bones-ui";

import { ROLE_ORGANISATION_URL } from "../config";

import { useOrganisationId } from "./useOrganisationId";
import { RoleOrganisationDetails, RoleOrganisationDetailsDTO, UpdateRoleOrganisationDTO } from "../domain";

const { organisationId } = useOrganisationId()

const RoleOrganisationServiceFactory = ServiceFactory.create("permissions", f => f.build(
    f.addGet(id => {
        if (organisationId.value) return `${ROLE_ORGANISATION_URL(organisationId.value, id)}`
        throw "No OrganisationId"
    }, RoleOrganisationDetails),
    f.addUpdate<UpdateRoleOrganisationDTO, RoleOrganisationDetailsDTO, RoleOrganisationDetails>(id => {
        if (organisationId.value) return `${ROLE_ORGANISATION_URL(organisationId.value, id)}`
        throw "No OrganisationId"
    }, RoleOrganisationDetails),
    f.addNotify<RoleOrganisationDetails>()
));

export const useUpdateRoleOrganisation = ComposableFactory.update(RoleOrganisationServiceFactory);
export const useRoleOrganisation = ComposableFactory.get(RoleOrganisationServiceFactory);