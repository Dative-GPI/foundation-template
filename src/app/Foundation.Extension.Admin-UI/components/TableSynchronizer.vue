<template>
  <v-spacer />
  <FSRow :gap="20">
    <FSButton variant="standard"
      color="primary"
      v-on:click="synchronize(tableId)">
      Synchronize Columns
    </FSButton>
  </FSRow>
</template>

<script lang="ts">
import { defineComponent, toRefs } from "vue";

import _ from "lodash";

import { useExtensionCommunicationBridge } from "@dative-gpi/foundation-template-shared-ui";
import { useSynchronizeTable } from "../composables";
import { useRouter } from "vue-router";

export default defineComponent({
  components: {},
  props: {
    editMode: {
      type: Boolean,
      required: true,
    },
    tableId: {
      type: String,
      required: true,
    },
  },
  setup(props) {
    const extension = useExtensionCommunicationBridge();
    const router = useRouter();
    const { synchronize, synchronizing, synchronized  } = useSynchronizeTable();

    return {
      synchronize
    };
  },
});
</script>
