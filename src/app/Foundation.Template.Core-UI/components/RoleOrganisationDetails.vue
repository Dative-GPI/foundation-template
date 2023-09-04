<template>
  <d-switch-grid class="mt-4"
    :categories="categoriesAndPermissions"
    v-model="selectedPermissions"
    :editable="editMode"
    select-all-btns
    select-by-category-btns />
</template>

<script lang="ts">
import _ from "lodash";

import {
  computed,
  defineComponent,
  onMounted,
  ref,
  watch,
} from "vue";

import { usePermissions, useRoleOrganisation, useUpdateRoleOrganisation } from "../composables";

export default defineComponent({
  props: {
    roleId: {
      type: String,
      required: true,
    },
    editMode: {
      type: Boolean,
      required: false,
      default: false,
    },
  },
  setup(props) {
    const { get, entity: roleOrganisation } = useRoleOrganisation();
    const { update } = useUpdateRoleOrganisation();

    const { permissions, categories, getAll } = usePermissions();

    const selectedPermissions = ref<string[]>([]);

    const reset = () => {
      if (!roleOrganisation.value) return;

      selectedPermissions.value = roleOrganisation.value.permissions.map(
        (p) => p.id
      );
    };

    const debouncedUpdate = _.debounce(update, 1000);

    watch(() => selectedPermissions, () => {
      if (!props.editMode) return;
      debouncedUpdate(props.roleId, { permissions: selectedPermissions.value });
    });

    onMounted(async () => {
      await Promise.all([getAll(), get(props.roleId)]);
      reset();
    });

    const categoriesAndPermissions = computed(() => {
      return categories.value.map((cat, index) => ({
        id: index.toString(),
        label: cat.label,
        options: permissions.value
          .filter((p) => p.code.startsWith(cat.prefix))
          .map((p) => ({
            id: p.id,
            label: p.label,
          })),
      }));
    });

    return {
      categoriesAndPermissions,
      selectedPermissions
    }
  }
});
</script>
