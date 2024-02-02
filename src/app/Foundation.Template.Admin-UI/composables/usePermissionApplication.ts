import { ComposableFactory, ServiceFactory } from "@dative-gpi/bones-ui";

import { PERMISSIONS_APPLICATION_URL, PERMISSIONS_URL, PERMISSION_CATEGORIES_URL } from "../config";

import { PermissionApplicationFilter, PermissionApplicationInfos, PermissionApplicationInfosDTO } from "../domain";

const PermissionServiceFactory = new ServiceFactory("permission-application", PermissionApplicationInfos)
    .create(f => f.build(
        f.addGetMany<PermissionApplicationInfosDTO, PermissionApplicationInfos, PermissionApplicationFilter>(PERMISSIONS_APPLICATION_URL, PermissionApplicationInfos),
        f.addNotify()
    ));

export const usePermissionApplications = ComposableFactory.getMany(PermissionServiceFactory);
