import { ComposableFactory, ServiceFactory } from "@dative-gpi/bones-ui";

import { ROLE_APPLICATION_URL } from "../config";

import { RoleApplicationDetails, RoleApplicationDetailsDTO, UpdateRoleApplicationDTO } from "../domain";

const RoleApplicationServiceFactory = new ServiceFactory<RoleApplicationDetailsDTO, RoleApplicationDetails>("role-application-permissions", RoleApplicationDetails)
    .create(f => f.build(
        f.addGet(ROLE_APPLICATION_URL),
        f.addUpdate<UpdateRoleApplicationDTO>(ROLE_APPLICATION_URL),
        f.addNotify()
    ));

export const useUpdateRoleApplication = ComposableFactory.update(RoleApplicationServiceFactory);
export const useRoleApplication = ComposableFactory.get(RoleApplicationServiceFactory);
