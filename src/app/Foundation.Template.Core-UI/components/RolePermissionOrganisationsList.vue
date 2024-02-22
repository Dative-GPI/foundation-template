<template>
  <FSCol v-if="!fetching" :gap="24">
    <FSRow align="left-center">
      <FSCol style="max-width: 300px !important">
        <FSTextField v-model="search" label="" prepend-inner-icon="mdi-magnify" clearable></FSTextField>
      </FSCol>
      <FSButton label="Enable all" color="primary" v-if="editMode" @click="updateAll(true)" class="align-self-end">
      </FSButton>
      <FSButton label="Disable all" color="primary" v-if="editMode" @click="updateAll(false)" class="align-self-end">
      </FSButton>
    </FSRow>
    <FSRow v-for="category in categoriesAndPermissions" :key="category.id">
      <FSCol style="max-width: 30%">
        <FSRow font="text-title"> {{ category.label }} </FSRow>
        <FSRow>
          <FSButton label="Enable all" color="primary" v-if="editMode" @click="updateCategory(true, category.id)">
          </FSButton>
          <FSButton label="Disable all" color="primary" v-if="editMode" @click="updateCategory(false, category.id)">
          </FSButton>
        </FSRow>
        <FSRow v-for="permission in category.options" :key="permission.id">
          <FSSpan font="text-body align-self-center"> {{ permission.label }} </FSSpan>
          <v-spacer></v-spacer>
          <FSSwitch
            v-if="editMode"
            ref="element"
            :modelValue="permissionIds.includes(permission.id)"
            @update:modelValue="updatePermissionIds(permission.id)"
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
  usePermissionOrganisations,
  useRolePermissionOrganisation,
  useUpdateRolePermissionOrganisation,
} from "../composables";
import { useExtensionCommunicationBridge } from "@dative-gpi/foundation-template-shared-ui";
import { watch } from "vue";
import { toRefs } from "vue";
import _ from "lodash";
export default defineComponent({
  name: "RolePermissionOrganisationsList",
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
    const { getAll, permissions, categories } = usePermissionOrganisations();
    const { get: getRolePermissionOrganisations, entity: rolePermissionOrganisations } =
      useRolePermissionOrganisation();
    const { update } = useUpdateRolePermissionOrganisation();
    const route = useRoute();

    const { editMode, roleId } = toRefs(props);
    const element = ref<HTMLElement | null>(null);

    const search = ref("");
    const fetching = ref(true);

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

      fetchRoleOrganisation();
    };

    const fetchRoleOrganisation = async () => {
      fetching.value = true;
      await getRolePermissionOrganisations(roleId.value).then(() => {});
      permissionIds.value = rolePermissionOrganisations.value.permissionIds.map((p) => p);
      fetching.value = false;
    };

    const filteredPermissionOrganisations = computed(() => {
      if (search.value == null || search.value === "") return permissions.value;
      return permissions.value.filter((p) => {
        return (
          p.code.toLowerCase().includes(search.value.toLowerCase()) ||
          p.label.toLowerCase().includes(search.value.toLowerCase())
        );
      });
    });

    const categoriesAndPermissions = computed(() => {
      return categories.value.map((cat, index) => ({
        id: index.toString(),
        label: cat.label,
        options: filteredPermissionOrganisations.value
          .filter((p) => p.code.startsWith(cat.prefix))
          .map((p) => ({
            id: p.id,
            label: p.label,
          })),
      }));
    });

    const updateAll = (enableAll: boolean) => {
      if (enableAll) {
        permissionIds.value = filteredPermissionOrganisations.value.map((p) => p.id);
      } else {
        permissionIds.value = [];
      }
    };

    const updateCategory = (enabledAll: boolean, categoryId: string) => {
      let category = categoriesAndPermissions.value.find((c) => c.id === categoryId);
      if (!category) return;
      let permissions = category?.options.map((p) => p.id);
      if (enabledAll) {
        permissionIds.value = Array.from(new Set([...permissionIds.value, ...permissions]));
      } else {
        permissionIds.value = permissionIds.value.filter((p) => !permissions.includes(p));
      }
    };

    const updatePermissionIds = (permissionId: string) => {
      if (permissionIds.value.includes(permissionId)) {
        permissionIds.value = permissionIds.value.filter((p) => p !== permissionId);
      } else {
        permissionIds.value = [...permissionIds.value, permissionId];
      }
    };

    function save() {
      update(roleId.value, { permissionIds: permissionIds.value }).then(() => {});
    }

    const synchronizePermissions = async () => {
      if (!editMode.value) return;
      await save();
    };

    const debouncedsynchronizePermissions = _.debounce(synchronizePermissions, 500);

    watch(permissionIds, debouncedsynchronizePermissions);

    watch(editMode, () => {
      if (editMode.value == false) {
        save();
      }
    });

    onMounted(init);

    return {
      categoriesAndPermissions,
      search,
      fetching,
      permissionIds,
      element,
      updatePermissionIds,
      updateAll,
      updateCategory,
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
