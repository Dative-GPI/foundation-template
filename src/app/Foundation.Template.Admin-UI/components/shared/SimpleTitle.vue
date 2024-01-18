<template>
  <FSSpan font="text-h2">{{ $tr(codeLabel, defaultLabel) }}</FSSpan>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "SimpleTitle",
  props: {
    codeLabel: {
      type: String,
      required: true,
    },
    defaultLabel: {
      type: String,
      required: true,
    },
  },
  setup(props) {
    return {};
  },
});
</script>

<style scoped></style>
