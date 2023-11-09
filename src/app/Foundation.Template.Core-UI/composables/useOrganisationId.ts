import { onMounted, provide, ref, watch } from "vue";
import { useRouter } from "vue-router";

import { ORGANISATION_ID } from "../config/literals";
import { initUrlFactory } from "../config/urls/urlFactory";

let initiliazed = false;

const organisationId = ref<string | null>(null);

export const useOrganisationId = () => {

    if (!initiliazed) {
        provide(ORGANISATION_ID, organisationId);

        const router = useRouter();

        watch(router.currentRoute, () => {
            organisationId.value = router.currentRoute.value.params[ORGANISATION_ID] as string | null;
        })

        onMounted(() => {
            if (organisationId.value) return;
            organisationId.value = router.currentRoute.value.params[ORGANISATION_ID] as string | null;
            initUrlFactory(organisationId);
        })
    }

    initiliazed = true

    return {
        organisationId
    }
}