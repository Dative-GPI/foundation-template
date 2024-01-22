<template>
  <v-app style="background-color: transparent">
    <v-main>
      <router-view v-if="ready" />
    </v-main>
  </v-app>
</template>

<script lang="ts">
import { defineComponent } from "vue";

import { useCoreTemplate } from "@dative-gpi/foundation-template-core-ui";

export default defineComponent({
  setup(_props) {
    const { ready } = useCoreTemplate();

    return {
      ready
    }
  }
});

</script>
