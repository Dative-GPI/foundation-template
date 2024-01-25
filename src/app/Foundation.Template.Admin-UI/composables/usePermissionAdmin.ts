import { ComposableFactory, ServiceFactory } from "@dative-gpi/bones-ui";

import { PERMISSIONS_ADMIN_URL, PERMISSIONS_URL, PERMISSION_CATEGORIES_URL } from "../config";

import { PermissionAdminFilter, PermissionAdminInfos, PermissionAdminInfosDTO } from "../domain";

const PermissionServiceFactory = new ServiceFactory("permission-admin", PermissionAdminInfos)
    .create(f => f.build(
        f.addGetMany<PermissionAdminInfosDTO, PermissionAdminInfos, PermissionAdminFilter>(PERMISSIONS_ADMIN_URL, PermissionAdminInfos),
        f.addNotify()
    ));

export const usePermissionAdmins = ComposableFactory.getMany(PermissionServiceFactory);
