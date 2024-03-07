<template>
  <FSCol :gap="24">
    <FSSpan font="text-h2">{{ $tr("ui.extension.title", "Title") }}</FSSpan>
    <FSSpan font="text-body">{{ $tr("ui.extension.body", "Body") }}</FSSpan>
    <FSSpan font="text-button">{{ $tr("ui.commmon.label", "Label") }}</FSSpan>
    <FSSpan font="text-h1">Table Test</FSSpan>
    <FSDataTable :headers="headers"
      :items="items"
      tableCode="ui.tables.test"
      mode="table"></FSDataTable>
  </FSCol>
</template>

<script lang="ts">
import { defineComponent, ref, computed } from "vue";
import { useTranslationsProvider } from "@dative-gpi/foundation-template-shared-ui";
import { useUpdateRolePermissionOrganisation, useGetTable } from "@dative-gpi/foundation-template-core-ui";




export default defineComponent({
  name: "ExampleComponent",
  setup(props) {
    const { $tr } = useTranslationsProvider();

    const { getting, get, getted } = useGetTable();
    const { updating, update } = useUpdateRolePermissionOrganisation();


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
