import { ORGANISATION_URL } from "./organisation";

export const PERMISSIONS_URL = (organisationId: string) => `${ORGANISATION_URL(organisationId)}/permissions`;

export const CURRENT_USER_PERMISSIONS_URL = (organisationId: string) => `${PERMISSIONS_URL(organisationId)}/current`;
export const PERMISSION_CATEGORIES_URL = (organisationId: string) => `${PERMISSIONS_URL(organisationId)}/categories`;
