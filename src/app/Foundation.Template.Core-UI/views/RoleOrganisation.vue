<template>
    <role-organisation-details :edit-mode="editMode"
        :role-id="roleId" />
</template>
  
<script lang="ts">
import {
    defineComponent,
} from "vue";

import { useRoute } from "vue-router/composables";

import RoleOrganisationDetails from "../components/RoleOrganisationDetails.vue";

export default defineComponent({
    components: {
        RoleOrganisationDetails
    },
    setup(props) {
        const route = useRoute();

        return {
            editMode: route.hash.includes("editMode=true"),
            roleId: route.params.roleId
        }
    }
});
</script>
  