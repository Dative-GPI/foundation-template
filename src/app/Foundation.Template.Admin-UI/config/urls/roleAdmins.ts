import { BASE_URL } from "./base";

export const ROLES_ADMIN_URL = `${BASE_URL}/role-admins`;

export const ROLE_ADMIN_URL = (id: string) => `${ROLES_ADMIN_URL}/${encodeURIComponent(id)}`;

export const ROLE_ADMIN_PERMISSIONS_URL = (id: string) => ` ${ROLE_ADMIN_URL(id)}/permissions`;
