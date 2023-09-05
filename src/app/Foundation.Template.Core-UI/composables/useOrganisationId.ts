import { computed } from "vue"

import { useRoute } from "vue-router/composables";

export const useOrganisationId = () => {
    const route = useRoute();

    const organisationId = computed((): string | null => {
        return route.params.organisationId
    });

    return {
        organisationId
    }
}