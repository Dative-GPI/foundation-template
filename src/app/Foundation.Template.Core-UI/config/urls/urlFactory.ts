import { Ref, inject, ref } from "vue";
import { useRoute } from "vue-router";

import { ORGANISATION_ID } from "../literals";

export function urlFactory(url: (organisationId: string) => string) {
    return () => {
        let result: string | null = null;

        let organisationId: Ref<string | null> = inject(ORGANISATION_ID, ref<string | null>(null));

        result = organisationId.value;

        if (!result) {
            const route = useRoute();

            if ((!route || !route.params)) {
                console.warn("You are trying to get organisationId without providing it nor in your route params. Please add it.", route, route.params)
            }
            else {
                result = route.params[ORGANISATION_ID] as string;
            }
        }

        if (!organisationId) throw new Error("Organisation ID is not defined");

        return url(result);
    }
}