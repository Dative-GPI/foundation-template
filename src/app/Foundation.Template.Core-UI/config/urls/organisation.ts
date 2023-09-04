import { API_URL } from "./application";

export const ORGANISATIONS_URL = `${API_URL}/organisations`;
export const ORGANISATION_URL = (organisationId: string) => `${ORGANISATIONS_URL}/${encodeURIComponent(organisationId)}`; 
