import { computed } from "vue"

import { useRoute } from "vue-router";

export const useOrganisationId = () => {
    const route = useRoute();

    const organisationId = computed((): string | null => {
        return route.params.organisationId as string | null;
    });

    return {
        organisationId
    }
}