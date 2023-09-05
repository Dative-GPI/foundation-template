import { ServiceFactory } from "@dative-gpi/bones-ui";
import { ComposableFactory } from "@dative-gpi/bones-ui";

import { CURRENT_USER_PERMISSIONS_URL } from "../config";

const CurrentPermissionServiceFactory = ServiceFactory.create("permissions", f => f.build(
    f.addGetMany(CURRENT_USER_PERMISSIONS_URL, String),
    f.addNotify<string>()
));

const useCurrentPermissions = ComposableFactory.getMany(CurrentPermissionServiceFactory);

const { entities: permissions, getMany, fetching } = useCurrentPermissions()

export const usePermissionsProvider = () => {
    const has = (code: string) => {
        return !!permissions.value.includes(code);
    }

    return {
        has,
        init: getMany,
        initializing: fetching
    }
}

