<template>
  <v-app style="background-color: transparent">
    <v-main>
      <router-view v-if="ready" />
    </v-main>
  </v-app>
</template>

<script lang="ts">
import { defineComponent } from "vue";

import { useAdminTemplate } from "@dative-gpi/foundation-template-admin-ui";

export default defineComponent({
  setup(_props) {
    const { ready } = useAdminTemplate();

    return {
      ready
    }
  }
});

</script>
