<template>
  <FSCol :gap="24">
    <FSSpan font="text-h2">{{ $tr("ui.extension.title", "Title") }}</FSSpan>
    <FSSpan font="text-body">{{ $tr("ui.extension.body", "Body") }}</FSSpan>
    <FSSpan font="text-button">{{ $tr("ui.commmon.label", "Label") }}</FSSpan>
    <FSSpan font="text-h1">Table Test</FSSpan>
    <v-data-table
      :headers="headers"
      :items="items"
      :items-per-page="5"
      class="elevation-1"
    ></v-data-table>
  </FSCol>
</template>

<script lang="ts">
import { defineComponent, ref, computed } from "vue";
import { useTranslationsProvider } from "@dative-gpi/foundation-template-shared-ui";
import { useTable } from "@dative-gpi/foundation-template-core-ui";

export default defineComponent({
  name: "ExampleComponent",
  setup(props) {
    const { $tr } = useTranslationsProvider();

    const { get, getting } = useTable();

    const tableCode = "ui.tables.test";
    const items = ref<any>([
      {
        key: "1",
        label: "label",
        keyLabel: "keyLabel",
        value: "value",
        id: "id",
        valueLabel: "valueLabel",
      },
    ]);

    const headers = computed(() => {
      return [
        {
          title: $tr("ui.example.key", "Key"),
          value: "key",
        },
        {
          title: $tr("ui.example.label", "Label"),
          value: "label",
        },
        {
          title: $tr("ui.example.keyLabel", "KeyLabel"),
          value: "keyLabel",
        },
        {
          title: $tr("ui.example.value", "Value"),
          value: "value",
        },
        {
          title: $tr("ui.example.id", "Id"),
          value: "id",
        },
        {
          title: $tr("ui.example.valueLabel", "ValueLabel"),
          value: "valueLabel",
        },
      ];
    });

    return {
      headers,
      items,
    };
  },
});
</script>

<style scoped></style>
