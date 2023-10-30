import { useOrganisationId } from "../../composables";

export function urlFactory(url: (orgId: string) => string) {
    return () => {
        const { organisationId } = useOrganisationId();

        if (!organisationId.value)
            throw new Error("OrganisationId is not set");

        return url(organisationId.value);
    }
}