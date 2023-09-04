import axios from "axios";
import { buildURL } from "@dative-gpi/foundation-template-shared-ui";

import { ROLE_ORGANISATION_URL } from "../config";
import { IRoleOrganisationService } from "../abstractions";
import { RoleOrganisationDetails, UpdateRoleOrganisationDTO, RoleOrganisationDetailsDTO } from "../domain";


export class RoleOrganisationService implements IRoleOrganisationService {
    async get(organisationId: string, roleId: string): Promise<RoleOrganisationDetails> {
        const response = await axios.get(buildURL(ROLE_ORGANISATION_URL(organisationId, roleId)));
        const dto: RoleOrganisationDetailsDTO = response.data;

        return new RoleOrganisationDetails(dto);
    }

    async update(organisationId: string, roleId: string, payload: UpdateRoleOrganisationDTO): Promise<RoleOrganisationDetails> {
        const response = await axios.post(ROLE_ORGANISATION_URL(organisationId, roleId), payload);
        const dto: RoleOrganisationDetailsDTO = response.data;

        return new RoleOrganisationDetails(dto);
    }
}