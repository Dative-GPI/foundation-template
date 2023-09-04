import axios from "axios";

import { buildURL } from "@dative-gpi/foundation-template-shared-ui";

import { IPermissionService } from '../abstractions';
import { CURRENT_USER_PERMISSIONS_URL, PERMISSIONS_URL, PERMISSION_CATEGORIES_URL } from '../config';
import { PermissionCategory, PermissionCategoryDTO, PermissionInfos, PermissionInfosDTO, PermissionsFilter } from "../domain";


export class PermissionService implements IPermissionService {
	async getCurrent(organisationId: string): Promise<string[]> {
		const response = await axios.get(CURRENT_USER_PERMISSIONS_URL(organisationId));
		const permissions: string[] = response.data;

		return permissions;
	}

	async getMany(organisationId: string, filter: PermissionsFilter): Promise<PermissionInfos[]> {
	  const response = await axios.get(
		buildURL(PERMISSIONS_URL(organisationId), filter)
	  );
	  const dto: PermissionInfosDTO[] = response.data;
  
	  const permissions = dto.map((o) => new PermissionInfos(o));
  
	  return permissions;
	}

	async getCategories(organisationId: string): Promise<PermissionCategory[]> {
		const response = await axios.get(PERMISSION_CATEGORIES_URL(organisationId));
		const dtos: PermissionCategoryDTO[] = response.data;

		const categories = dtos.map(dto => new PermissionCategory(dto));
		return categories;
	}
}