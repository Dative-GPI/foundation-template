import { onMounted, ref } from "vue";
import { useExtensionHost, useTranslationsProvider } from "@dative-gpi/foundation-template-shared-ui";

import { usePermissionsProvider } from "./usePermissionsProvider";

let called = false;
const ready = ref(false);

export function useAdminExtension() {
    if (called) return { ready };

    called = true;

    useExtensionHost();

    const { init: initPermissions } = usePermissionsProvider();
    const { init: initTranslations } = useTranslationsProvider();

    onMounted(async () => {
        await initTranslations();
        await initPermissions();

        ready.value = true;
    });

    return {
        ready
    };
}