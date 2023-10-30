import { ref, watch } from "vue";
import { useRouter } from "vue-router";

export const useOrganisationId = () => {

    const router = useRouter();
    const organisationId = ref<string | null>(null);

    watch(router.currentRoute, () => {
        console.log("current route changed");
        organisationId.value = router.currentRoute.value.params.organisationId as string | null;
    })

    return {
        organisationId
    }
}