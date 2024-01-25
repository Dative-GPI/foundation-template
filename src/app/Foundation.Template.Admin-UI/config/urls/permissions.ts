import { BASE_URL } from "./base";

export const PERMISSIONS_URL = () => `${BASE_URL}/permission-organisations`;

export const CURRENT_USER_PERMISSIONS_URL = () => `${PERMISSIONS_URL()}/current`;
export const PERMISSION_CATEGORIES_URL = () => `${BASE_URL}/permission-organisation-categories`;
