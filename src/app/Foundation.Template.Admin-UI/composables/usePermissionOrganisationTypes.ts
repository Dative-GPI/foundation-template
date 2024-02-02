import { ComposableFactory, ServiceFactory } from "@dative-gpi/bones-ui";

import { PERMISSION_ORGANISATION_TYPES_URL, PERMISSIONS_URL, PERMISSION_CATEGORIES_URL } from "../config";

import { PermissionOrganisationTypeFilter, PermissionOrganisationTypeInfos, PermissionOrganisationTypeInfosDTO } from "../domain";

const PermissionServiceFactory = new ServiceFactory("permission-organisation-type", PermissionOrganisationTypeInfos)
    .create(f => f.build(
        f.addGetMany<PermissionOrganisationTypeInfosDTO, PermissionOrganisationTypeInfos, PermissionOrganisationTypeFilter>(PERMISSION_ORGANISATION_TYPES_URL, PermissionOrganisationTypeInfos),
        f.addNotify()
    ));

export const usePermissionOrganisationTypes = ComposableFactory.getMany(PermissionServiceFactory);
