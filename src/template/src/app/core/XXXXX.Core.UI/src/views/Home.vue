<template>
  <ExampleComponent />
</template>

<script lang="ts">
import { defineComponent } from "vue";
import ExampleComponent from "@/components/ExampleComponent.vue";
import ExampleDrawer from "@/components/ExampleDrawer.vue";

export default defineComponent({
  name: "Home",
  components: {
    ExampleComponent,
    ExampleDrawer,
  },
  setup(props) {
    return {};
  },
});
</script>

<style scoped></style>
