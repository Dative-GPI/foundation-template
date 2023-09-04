import { computed } from "vue"

import { useRoute } from "vue-router/types/composables";

export const useOrganisationId = () => {
    const route = useRoute();

    const organisationId = computed((): string | null => {
        return route.params.organisationId ?? new URL(window.location.toString()).searchParams.get(
            "userOrganisationId"
        );
    });

    return {
        organisationId
    }
}