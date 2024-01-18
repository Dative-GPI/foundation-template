<template>
  <Drawer
    :width="601"
    :title="$tr('ui.admin.translations.update-translation-drawer', 'Update translation')"
    v-model:value="drawer"
  >
    <v-skeleton-loader type="article" v-if="!translation || !applicationTranslationCodes" />

    <template v-else>
      <FSCol :gap="12">
        <FSRow>
          <FSCol :items="items" class="mt-5">
            <FSSpan font="text-button"> {{ translation.code }} : {{ translation.value }} </FSSpan>
          </FSCol>
        </FSRow>

        <FSRow>
          <FSCol v-if="fetchingLanguages">
            <v-skeleton-loader type="paragraph" />
          </FSCol>
          <FSCol width="fill" v-else>
            <FSTextArea
              rows="2"
              v-for="l in languages"
              color="primary"
              :modelValue="getValue(l.code)"
              @input="setValue(l.code, $event.target.value)"
              :key="translation.code + '-' + l.code"
              :label="l.label"
              style="width: 97%"
            />
          </FSCol>
        </FSRow>
      </FSCol>

      <!-- <LanguageTranslationInputs
        class="mt-6"
        v-model:value="applicationTranslations"
        :code="translation.code"
      /> -->
    </template>

    <template #actions>
      <v-spacer />
      <FSButtonCancel @click="close(true)" :loading="upserting" label="Cancel"> </FSButtonCancel>
      <FSButtonSave
        class="ml-3 justify-content-end"
        @click="updateTranslations"
        :loading="upserting"
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

import { useApplicationTranslations, useUpsertApplicationTranslation, useApplicationLanguages } from "../composables";

import { Translation, ApplicationTranslation, UpdateApplicationTranslationLanguage } from "../domain";

import Drawer from "./shared/Drawer.vue";

export default defineComponent({
  name: "UpdateTranslationDrawer",
  components: {
    Drawer,
  },
  setup(props, { emit }) {
    const route = useRoute();
    const extension = useExtensionCommunicationBridge();

    const drawer = ref<boolean>(true);

    const newTranslations = ref<UpdateApplicationTranslationLanguage[]>([]);

    const applicationTranslationCodes = ref<ApplicationTranslation[]>([]);

    const { upserted, upsert, upserting } = useUpsertApplicationTranslation();

    const {
      getMany: getManyApplicationTranslations,
      entities: applicationTranslations,
      fetching: fetchingApplicationTranslations,
    } = useApplicationTranslations();

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

    const params = route.params.translation.toString().split(";") as string[];

    const translation = computed((): Translation => {
      return { id: params[0], code: params[1], value: atob(params[2]) };
    });

    const close = (success: boolean) => {
      extension.closeDrawer(location.pathname, success);
    };

    const setValue = (languageCode: string, ev: string) => {
      let index = newTranslations.value.findIndex((t) => t.languageCode == languageCode);

      if (!ev || ev.length == 0) {
        if (index != -1) newTranslations.value.splice(index, 1);
      } else if (index != -1 && newTranslations.value[index].value != ev) {
        newTranslations.value.splice(index, 1);
        pushTranslation(languageCode, ev);
      } else {
        pushTranslation(languageCode, ev);
      }
      emit("input", newTranslations);
    };

    const pushTranslation = (languageCode: string, ev: string) => {
      newTranslations.value.push({
        languageCode: languageCode,
        translationCode: translation.value.code,
        value: ev,
      } as UpdateApplicationTranslationLanguage);
    };

    const updateTranslations = () => {
      // removeRange(applicationTranslationCodes);
      // addRange
      upsert(translation.value.code, {
        translations: newTranslations.value,
      }).then(() => {
        close(true);
      });
    };

    const getValue = (languageCode: string): string | null | undefined => {
      const transl = applicationTranslations.value.find(
        (x) => x.languageCode === languageCode && x.translationCode == translation.value.code
      );

      if (transl) return transl.value;
      else return "";
    };

    const fetch = async () => {
      await getManyLanguages();
      await getManyApplicationTranslations();
      applicationTranslationCodes.value = _.filter(
        applicationTranslations.value,
        (x) => x.translationCode == translation.value.code
      );
      newTranslations.value = applicationTranslationCodes.value.map((at) => new ApplicationTranslation(at));
    };

    onMounted(fetch);

    return {
      drawer,
      upserting,
      translation,
      items,
      fetchingLanguages,
      languages,
      applicationTranslationCodes,
      updateTranslations,
      close,
      getValue,
      setValue,
    };
  },
});
</script>

<style scoped></style>
