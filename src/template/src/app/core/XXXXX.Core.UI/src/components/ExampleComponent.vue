<template>
  <FSCol
    :gap="24"
  >
    <FSSpan
      font="text-h2"
    >{{ $tr("ui.extension.title", "Title") }}</FSSpan>
    <FSSpan
      font="text-body"
    >{{ $tr("ui.extension.body", "Body") }}</FSSpan>
    <FSSpan
      font="text-button"
    >{{ $tr("ui.commmon.label", "Label") }}</FSSpan>
    <FSSpan
      font="text-h1"
    >Table Test</FSSpan>
    <FEDataTable
      :tableCode="tableCode"
    />
  </FSCol>
</template>

<script lang="ts">
import { defineComponent } from "vue";

import FEDataTable from "@dative-gpi/foundation-extension-core-ui/components/FEDataTable.vue";

export default defineComponent({
  name: "ExampleComponent",
  components: {
    FEDataTable
  },
  setup() {
    const tableCode = "ui.tables.test";

    return {
      tableCode
    };
  },
});
</script>

<style scoped></style>
