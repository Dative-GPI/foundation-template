import { PermissionCategory, PermissionInfos, PermissionsFilter } from "../domain/models";


export interface IPermissionService {
    getCurrent(organisationId: string): Promise<string[]>;
    
    getMany(organisationId: string, filter?: PermissionsFilter): Promise<PermissionInfos[]>;
    getCategories(organisationId: string): Promise<PermissionCategory[]>;
}