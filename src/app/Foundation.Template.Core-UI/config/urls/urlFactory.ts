import { useOrganisationId } from "../../composables/useOrganisationId";

export function urlFactory(url: (organisationId: string) => string) {
    return () => {
        const { organisationId } = useOrganisationId();
        if (!organisationId.value) throw new Error("Organisation ID is not defined");
        return url(organisationId.value);
    }
}