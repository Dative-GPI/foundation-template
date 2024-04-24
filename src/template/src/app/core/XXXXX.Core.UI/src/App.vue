<template>
  <v-app style="background-color: transparent;">
    <v-main>
      <router-view v-if="ready" />
    </v-main>
  </v-app>
</template>

<script lang="ts">
import { defineComponent, watch, computed } from "vue";

import { useCoreTemplate, useOrganisationId as useTemplateOrganisationId } from "@dative-gpi/foundation-template-core-ui";
import { useAppOrganisationId, useFoundationCore } from "@dative-gpi/foundation-core-services/composables";


export default defineComponent({
  setup(_props) {
    const { ready: coreTemplateReady } = useCoreTemplate();
    const { ready: foundationCoreReady } = useFoundationCore();
    const { organisationId } = useTemplateOrganisationId();

    watch(organisationId, (newOrganisationId) => {
      if (newOrganisationId) useAppOrganisationId().setAppOrganisationId(newOrganisationId);
    });

    const ready = computed(() => coreTemplateReady.value && foundationCoreReady.value);

    return {
      ready
    }
  }
});
</script>
