<template>
  <Drawer
    :width="601"
    :title="$tr('ui.admin.translations.update-translation-drawer', 'Update entity property')"
    v-model:value="drawer"
  >
    <v-skeleton-loader type="article" v-if="!entityProperty || !entityProtertyTranslations" />

    <template v-else>
      <FSCol :gap="12">
        <FSRow>
          <FSCol :items="items" class="mt-5">
            <FSSpan font="text-button"> Default label: {{ entityProperty.labelDefault }} </FSSpan><br />
            <FSSpan font="text-button"> Default category : {{ entityProperty.categoryLabelDefault }} </FSSpan>
          </FSCol>
        </FSRow>

        <FSRow>
          <FSCol v-if="fetchingLanguages">
            <v-skeleton-loader type="paragraph" />
          </FSCol>
          <FSCol width="fill" v-else>
            <FSCol v-for="l in languages" :key="l.code">
              <FSTextArea
                rows="2"
                color="primary"
                :modelValue="getLabel(l.code)"
                @input="setLabelCategory(l.code, $event.target.value, null)"
                :key="l.code + '-' + l.code"
                :label="l.label"
                style="width: 97%"
              />
              <FSTextArea
                rows="2"
                color="primary"
                :modelValue="getCategory(l.code)"
                @input="setLabelCategory(l.code, null, $event.target.value)"
                :key="l.code"
                :label="l.label"
                style="width: 97%"
              />
            </FSCol>
          </FSCol>
        </FSRow>
      </FSCol>
    </template>

    <template #actions>
      <v-spacer />
      <FSButtonCancel @click="close(true)" :loading="updating" label="Cancel"> </FSButtonCancel>
      <FSButtonSave
        class="ml-3 justify-content-end"
        @click="updateTranslations"
        :loading="updating"
        label="Save"
      ></FSButtonSave>
    </template>
  </Drawer>
</template>

<script lang="ts">
import _ from "lodash";
import { defineComponent, ref, computed, onMounted } from "vue";

import { useRoute } from "vue-router";

import { useExtensionCommunicationBridge } from "@dative-gpi/foundation-template-shared-ui";

import {
  useEntityProterties,
  useUpdateEntityPropertyTranslation,
  useApplicationLanguages,
  useEntityProtertyTranslations,
} from "../../../composables";

import {
  Translation,
  ApplicationTranslation,
  UpdateApplicationTranslationLanguage,
  EntityPropertyInfos,
  UpdateEntityPropertyTranslation,
  EntityPropertyTranslationInfos,
} from "../../../domain";

import Drawer from "../../shared/Drawer.vue";

export default defineComponent({
  name: "UpdateTranslationDrawer",
  components: {
    Drawer,
  },
  setup(props, { emit }) {
    const route = useRoute();
    const extension = useExtensionCommunicationBridge();

    const {
      getMany: getEntityProperties,
      entities: entityProperties,
      fetching: fetchingEntityProperties,
    } = useEntityProterties();

    const drawer = ref<boolean>(true);

    const newTranslations = ref<EntityPropertyTranslationInfos[]>([]);

    const { updated, update, updating } = useUpdateEntityPropertyTranslation();

    const {
      getMany: getEntityProtertyTranslations,
      entities: entityProtertyTranslations,
      fetching: fetchingEntityProtertyTranslations,
    } = useEntityProtertyTranslations();

    const { getMany: getManyLanguages, entities: languages, fetching: fetchingLanguages } = useApplicationLanguages();

    const items = [
      {
        key: "Code",
        code: "code",
      },
      {
        key: "Default translation",
        code: "default",
      },
    ];

    const entityPropId = route.params.entitypropertytranslationid.toString();

    const entityProperty = computed(() => {
      return entityProperties.value.find((x) => x.id == entityPropId);
    });

    const close = (success: boolean) => {
      extension.closeDrawer(location.pathname, success);
    };

    const setLabelCategory = (languageCode: string, label: string, category: string) => {
      let index = newTranslations.value.findIndex(
        (t) => t.languageCode == languageCode && t.entityPropertyId == entityPropId
      );

      if ((!label || label.length == 0) && (!category || category.length == 0)) {
        if (index != -1) newTranslations.value.splice(index, 1);
      } else if (
        index != -1 &&
        (newTranslations.value[index].label != label || newTranslations.value[index].categoryLabel != category)
      ) {
        const lab = newTranslations.value[index].label;
        const cat = newTranslations.value[index].categoryLabel;
        newTranslations.value.splice(index, 1);
        pushTranslation(languageCode, lab, cat);
      } else {
        pushTranslation(languageCode, label, category);
      }
      emit("input", newTranslations);
    };

    const pushTranslation = (lang: string, lab: string, categoryLab: string) => {
      newTranslations.value.push(
        new EntityPropertyTranslationInfos({
          languageCode: lang,
          label: lab,
          categoryLabel: categoryLab,
          entityPropertyId: entityPropId,
        })
      );
    };

    const updateTranslations = () => {
      update(entityPropId, newTranslations.value).then(() => {
        close(true);
      });
    };

    const getLabel = (languageCode: string): string | null | undefined => {
      const lab = entityProtertyTranslations.value.find(
        (x) => x.languageCode === languageCode && x.entityPropertyId == entityPropId
      );

      if (lab) return lab.label;
      else return "";
    };

    const getCategory = (languageCode: string): string | null | undefined => {
      const lab = entityProtertyTranslations.value.find(
        (x) => x.languageCode === languageCode && x.entityPropertyId == entityPropId
      );

      if (lab) return lab.categoryLabel;
      else return "";
    };

    const fetch = async () => {
      getManyLanguages();
      getEntityProperties();
      await getEntityProtertyTranslations();
      newTranslations.value = entityProtertyTranslations.value.map((at) => new EntityPropertyTranslationInfos(at));
    };

    onMounted(fetch);

    return {
      drawer,
      updating,
      entityProperty,
      items,
      fetchingLanguages,
      languages,
      entityProtertyTranslations,
      updateTranslations,
      close,
      getLabel,
      getCategory,
      setLabelCategory,
    };
  },
});
</script>

<style scoped></style>
