import { onMounted, ref } from "vue";
import { useExtensionHost, useTranslationsProvider } from "@dative-gpi/foundation-template-shared-ui";

import { useOrganisationId } from "./useOrganisationId";
import { usePermissionsProvider } from "./usePermissionsProvider";

let called = false;
const ready = ref(false);

export function useCoreTemplate() {
    if (called) return { ready };

    called = true;

    useExtensionHost();

    const { ready: initialized } = useOrganisationId();

    const { init: initPermissions } = usePermissionsProvider();
    const { init: initTranslations } = useTranslationsProvider();

    onMounted(async () => {
        await initialized
        await initTranslations();
        await initPermissions();

        ready.value = true;
    });

    return {
        ready
    };
}