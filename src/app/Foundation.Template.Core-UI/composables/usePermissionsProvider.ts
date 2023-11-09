import { ref } from "vue";
import { ServiceFactory } from "@dative-gpi/bones-ui";
import { ComposableFactory } from "@dative-gpi/bones-ui";

import { CURRENT_USER_PERMISSIONS_URL } from "../config";

const CurrentPermissionServiceFactory = ServiceFactory.create("permissions", f => f.build(
    f.addGetMany(CURRENT_USER_PERMISSIONS_URL, String),
    f.addNotify<String>()
));

const useCurrentPermissions = ComposableFactory.getMany(CurrentPermissionServiceFactory);

const { entities: permissions, getMany, fetching } = useCurrentPermissions()

const init = ref<Promise<any> | null>(null);

export const usePermissionsProvider = () => {
    const has = (code: string) => {
        return !!permissions.value.includes(code);
    }

    const some = (...permissionCodes: string[]) => {
        return permissionCodes.some(p => permissions.value.includes(p));
    }

    const every = (...permissionCodes: string[]) => {
        return permissionCodes.every(p => permissions.value.includes(p));
    }

    const fetch = () => {
        if (!init.value)
            init.value = getMany();
        return init.value;
    }

    return {
        has,
        some,
        every,
        init: fetch,
        initializing: fetching
    }
}

