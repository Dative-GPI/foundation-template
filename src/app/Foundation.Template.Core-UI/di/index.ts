import { container } from "tsyringe";

import { SERVICES as S } from "../config";

import {
    IApplicationTranslationService,
    IOrganisationPermissionService,
    IPermissionService,
    IRolePermissionService
} from "../abstractions";

import { 
    ExtensionCommunicationService,
    ApplicationTranslationService,
    OrganisationPermissionService,
    PermissionService,
    RolePermissionService
} from "../services";

container.registerSingleton<IPermissionService>(S.PERMISSIONSERVICE, PermissionService);
container.registerSingleton<IApplicationTranslationService>(S.APPLICATIONTRANSLATIONSERVICE, ApplicationTranslationService);
container.registerSingleton<IRolePermissionService>(S.ROLEPERMISSIONSERVICE, RolePermissionService);
container.registerSingleton<IOrganisationPermissionService>(S.ORGANISATIONPERMISSIONSERVICE, OrganisationPermissionService);

export { container };