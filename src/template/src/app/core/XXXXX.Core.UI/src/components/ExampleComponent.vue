<template>
  <FSCol :gap="24">
    <FSSpan font="text-h2">{{ $tr("ui.extension.title", "Title") }}</FSSpan>
    <FSSpan font="text-body">{{ $tr("ui.extension.body", "Body") }}</FSSpan>
    <FSSpan font="text-button">{{ $tr("ui.commmon.label", "Label") }}</FSSpan>
    <FSSpan font="text-h1">Table Test</FSSpan>
    <FSDataTable v-if="headers"
      :items="items"
      :headers="headers"
      :filter="innerFilters"
      mode="table"></FSDataTable>
  </FSCol>
</template>

<script lang="ts">
import { defineComponent, ref, computed, onMounted } from "vue";
import { useTranslationsProvider } from "@dative-gpi/foundation-template-shared-ui";
import { useUpdateRolePermissionOrganisation, useTable } from "@dative-gpi/foundation-template-core-ui";
import { FSDataTableColumn, FSDataTableFilter, FSDataTableOrder } from "@dative-gpi/foundation-shared-components/models";
import { on } from "events";
import { text } from "stream/consumers";


export default defineComponent({
  name: "ExampleComponent",
  setup(props) {
    const { $tr } = useTranslationsProvider();

    const { getting, get, getted } = useTable();
    const { updating, update } = useUpdateRolePermissionOrganisation();

    const innerFilters = ref<{ [key: string]: FSDataTableFilter[] }>({});

    const tableCode = "ui.tables.test";
    const items = ref<any>([
      {
        Category: "1",
        Code: "label",
        Label: "keyLabel",
        value: "q",
      },
      {
        Category: "1",
        Code: "label",
        Label: "keyLabel",
        value: "x",
      }
    ]);
    const headers = ref<any>();

    onMounted(() => {
      get("ui.tables.test").then((res) => {
        headers.value = getted.value.columns.map((column: any) => {
          return {
            title: column.label,
            text: column.label,
            value: column.label,
            sortable: column.sortable,
            filterable: column.filterable,
            width: column.width,
          };
        });
      })
    });


    return {
      headers,
      items,
      innerFilters
    };
  },
});
</script>

<style scoped></style>
