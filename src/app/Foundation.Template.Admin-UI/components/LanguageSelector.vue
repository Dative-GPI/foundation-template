<template>
  <v-select
    v-bind="$attrs"
    dense
    variant="outlined"
    class="d-select"
    item-value="code"
    item-title="label"
    :label="trueLabel"
    :readonly="!editable"
    :clearable="editable"
    :items="languages"
    :item-props="languageProps"
    style="max-width: 300px; padding-top: 16px"
  >
  </v-select>
</template>

<script lang="ts">
import { defineComponent, computed, onMounted } from "vue";

import { useApplicationLanguages } from "../composables";
import { Language } from "../domain";

export default defineComponent({
  name: "LanguageSelector",
  props: {
    editable: {
      type: Boolean,
      required: false,
      default: true,
    },
    label: {
      type: String,
      required: false,
      default: null,
    },
  },
  setup(props, { emit }) {
    const { getMany, entities: languages } = useApplicationLanguages();

    const trueLabel = computed(() => {
      return props.label ?? "Language";
    });

    const fetch = () => {
      getMany();
    };

    const languageProps = (item: Language) => {
      return {
        title: item.label,
        icon: item.icon,
        code: item.code,
        id: item.id,
      };
    };

    onMounted(fetch);

    return {
      languages,
      trueLabel,
      languageProps,
    };
  },
});
</script>

<style scoped></style>
