<template>
  <application-role-permissions-list :edit-mode="editMode" :role-id="roleId" />
</template>

<script lang="ts">
import { computed, defineComponent } from "vue";

import { useRoute } from "vue-router";

import ApplicationRolePermissionsList from "../components/ApplicationRolePermissionsList.vue";

export default defineComponent({
  components: {
    ApplicationRolePermissionsList,
  },
  setup(props) {
    const route = useRoute();

    const editMode = computed(() => route.hash.includes("editMode=true"));

    return {
      editMode,
      roleId: route.params.roleId as string,
    };
  },
});
</script>
