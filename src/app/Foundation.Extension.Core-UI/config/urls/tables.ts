import { BASE_URL } from "./base";

export const TABLE_URL = (tableCode: string) => `${BASE_URL}/tables/${encodeURIComponent(tableCode)}/dispositions`