import { onMounted, onUnmounted, provide, ref, watch } from "vue";
import { useRouter } from "vue-router";
import { ORGANISATION_ID } from "../config/literals";

let initiliazed = false;
const organisationId = ref<string | null>(null);

export const useOrganisationId = () => {

    if (initiliazed) return {
        organisationId
    }

    initiliazed = true
    
    provide(ORGANISATION_ID, organisationId);

    const router = useRouter();

    watch(router.currentRoute, () => {
        organisationId.value = router.currentRoute.value.params.organisationId as string | null;
    })
    
    return {
        organisationId
    }
}