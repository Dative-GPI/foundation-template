import { ORGANISATION_URL } from "./organisation";

export const ROLE_ORGANISATIONS_URL = (organisationId: string) => `${ORGANISATION_URL(organisationId)}/roles`;
export const ROLE_ORGANISATION_URL = (organisationId: string, roleId: string) => `${ROLE_ORGANISATIONS_URL(organisationId)}/${encodeURIComponent(roleId)}`;
