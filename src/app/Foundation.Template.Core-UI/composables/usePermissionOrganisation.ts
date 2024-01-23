import { ref } from "vue";
import { ComposableFactory, ServiceFactory } from "@dative-gpi/bones-ui";

import { PERMISSIONS_URL, PERMISSION_CATEGORIES_URL } from "../config";

import { PermissionOrganisationCategory, PermissionOrganisationInfos, PermissionOrganisationInfosDTO, PermissionsFilter } from "../domain";

const PermissionServiceFactory = new ServiceFactory("permission-organisation", PermissionOrganisationInfos)
    .create(f => f.build(
        f.addGetMany<PermissionOrganisationInfosDTO, PermissionOrganisationInfos, PermissionsFilter>(PERMISSIONS_URL, PermissionOrganisationInfos),
        f.addNotify()
    ));

export const usePermissionOrganisations = ComposableFactory.getMany(PermissionServiceFactory);
