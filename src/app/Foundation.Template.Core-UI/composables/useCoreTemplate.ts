import { onMounted, ref } from "vue";
import { useExtensionHost, useTranslationsProvider } from "@dative-gpi/foundation-template-shared-ui";
import { useAppTimeZone, useCurrentUser } from "@dative-gpi/foundation-shared-services/composables"

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
    const { fetch: fetchCurrentUser } = useCurrentUser()
    
    const { setAppTimeZone, getMachineOffset } = useAppTimeZone();

    onMounted(async () => {
        await initialized
        await initTranslations();
        await initPermissions();
        setAppTimeZone({
            id: Intl.DateTimeFormat().resolvedOptions().timeZone,
            offset: getMachineOffset()
        });

        const user = await fetchCurrentUser()
        if (user.value.timeZoneId && user.value.timeZoneOffset) {
            setAppTimeZone({
                id: user.value.timeZoneId,
                offset: user.value.timeZoneOffset
            });
        }

        ready.value = true;
    });

    return {
        ready
    };
}