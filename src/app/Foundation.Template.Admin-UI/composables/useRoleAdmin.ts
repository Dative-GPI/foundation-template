import { ComposableFactory, ServiceFactory } from "@dative-gpi/bones-ui";

import { ROLE_ADMIN_URL } from "../config";

import { RoleAdminDetails, RoleAdminDetailsDTO, UpdateRoleAdminDTO } from "../domain";

const RoleAdminServiceFactory = new ServiceFactory<RoleAdminDetailsDTO, RoleAdminDetails>("role-admin-permissions", RoleAdminDetails)
    .create(f => f.build(
        f.addGet(ROLE_ADMIN_URL),
        f.addUpdate<UpdateRoleAdminDTO>(ROLE_ADMIN_URL),
        f.addNotify()
    ));

export const useUpdateRoleAdmin = ComposableFactory.update(RoleAdminServiceFactory);
export const useRoleAdmin = ComposableFactory.get(RoleAdminServiceFactory);
