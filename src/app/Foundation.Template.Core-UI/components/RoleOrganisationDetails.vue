<template>
  <FSCol :gap="24">
    <FSRow :gap="36">
      <FSCol style="max-width: 300px">
        <FSTextField label="" prepend-inner-icon="mdi-magnify" v-model="search" width="fill" clearable></FSTextField>
      </FSCol>
      <FSCheckbox
        class="align-self-end"
        v-model="enabledAll"
        label="Enable/disable all"
        v-if="editMode"
        @click="updatedAll"
      >
      </FSCheckbox>
    </FSRow>
    <FSRow>
      <FSCol>
        <FSSpan font="text-button"> XXXXX </FSSpan>
      </FSCol>
    </FSRow>
    <FSRow v-for="permission in filteredPermissionOrganisations" :key="permission.id">
      <FSCol style="max-width: 30%">
        <FSRow>
          <FSSpan font="text-body align-self-center"> {{ permission.code }} </FSSpan>
          <v-spacer></v-spacer>
          <FSSwitch
            v-if="editMode"
            ref="element"
            :modelValue="permissionIds.includes(permission.id)"
            @update:modelValue="updatePermission(permission.id)"
            color="success"
          />
          <template v-else>
            <FSIcon v-if="permissionIds.includes(permission.id)" color="success"> mdi-checkbox-marked-circle</FSIcon>
            <FSIcon v-else color="error"> mdi-close-circle</FSIcon>
          </template>
          <v-divider></v-divider>
        </FSRow>
      </FSCol>
    </FSRow>
  </FSCol>
</template>
<script lang="ts">
import { defineComponent, ref, onMounted, computed } from "vue";
import { useRouter, useRoute } from "vue-router";
import {
  usePermissions,
  usePermissionOrganisations,
  useRoleOrganisation,
  useUpdateRoleOrganisation,
} from "../composables";
import { useExtensionCommunicationBridge } from "@dative-gpi/foundation-template-shared-ui";
export default defineComponent({
  name: "RoleOrganisationDetails",
  props: {
    editMode: {
      type: Boolean,
      default: true,
    },
    roleId: {
      type: String,
      required: true,
      default: "",
    },
  },
  setup(props) {
    const { setTitle, setCrumbs } = useExtensionCommunicationBridge();
    const { getAll, categories } = usePermissions();
    const { getMany: getPermissionOrganisations, entities: permissionOrganisations } = usePermissionOrganisations();
    const { get, entity: roleOrganisation } = useRoleOrganisation();
    const { update, updating } = useUpdateRoleOrganisation();
    const route = useRoute();

    const element = ref<HTMLElement | null>(null);

    const search = ref("");
    const enabledAll = ref<boolean>(false);

    const permissionIds = ref<string[]>([]);

    const init = async () => {
      setTitle("Permissions");
      setCrumbs([
        {
          to: route.path,
          text: "Permissions",
          disabled: true,
        },
      ]);

      await getAll().then(() => {});

      fetchPermissionOrganisations();

      fetchRoleOrganisation();
    };

    const fetchPermissionOrganisations = async () => {
      getPermissionOrganisations({ search: search.value }).then(() => {});
    };

    const fetchRoleOrganisation = async () => {
      get(route.params.roleId.toString()).then(() => {
        permissionIds.value = roleOrganisation.value?.permissionIds;
      });
    };

    const filteredPermissionOrganisations = computed(() => {
      if (search.value == null || search.value === "") return permissionOrganisations.value;
      return permissionOrganisations.value.filter((p) => {
        return (
          p.code.toLowerCase().includes(search.value.toLowerCase()) ||
          p.label.toLowerCase().includes(search.value.toLowerCase())
        );
      });
    });

    onMounted(init);

    const updatedAll = (ev: Event) => {
      if (enabledAll.value) {
        permissionIds.value = filteredPermissionOrganisations.value.map((p) => p.id);
      } else {
        permissionIds.value = [];
      }
      console.log(enabledAll.value);
      update(props.roleId, { permissionIds: permissionIds.value });
    };

    const hasPermission = (permissionId: string) => {
      if (!roleOrganisation.value) return false;
      if (!roleOrganisation.value.permissionIds) return false;
      return roleOrganisation.value.permissionIds.includes(permissionId);
    };

    const updatePermissionIds = (permissionId: string) => {
      if (permissionIds.value.includes(permissionId)) {
        permissionIds.value = permissionIds.value.filter((p) => p !== permissionId);
      } else {
        permissionIds.value = [...permissionIds.value, permissionId];
      }
    };

    const updatePermission = (permissionId: string) => {
      updatePermissionIds(permissionId);
      update(props.roleId, { permissionIds: permissionIds.value });
    };

    return {
      permissionOrganisations,
      search,
      permissionIds,
      updating,
      enabledAll,
      element,
      filteredPermissionOrganisations,
      updatePermissionIds,
      updatePermission,
      hasPermission,
      fetchPermissionOrganisations,
      updatedAll,
    };
  },
});
</script>
<style scoped>
tbody tr {
  cursor: pointer;
}
tbody tr:hover {
  background-color: #e6efff;
}
</style>
