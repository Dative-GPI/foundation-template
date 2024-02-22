<template>
  <Drawer
    class="pa-1"
    :width="800"
    v-bind="$attrs"
    :title="$tr('ui.admin.entity-property.import-drawer', 'Import entity property translations')"
    v-model:value="drawer"
  >
    <FSCol :gap="12" class="pa-2">
      <v-form v-model="valid" ref="form" lazy-validation>
        <FSCol :gap="12">
          <FSRow align="center-center">
            <v-divider class="" length="40%" />
            <FSSpan font="text-h3 mx-auto">
              {{ $tr("ui.admin.translations.workbook", "Workbook") }}
            </FSSpan>
            <v-divider class="" length="40%" />
          </FSRow>
          <FSSpan font="text-body text-wrap">
            {{
              $tr(
                "ui.admin.entity-property.workbook-description",
                "Please select a workbook from your device. The first column must include the entity properties codes"
              )
            }}
          </FSSpan>
          <FSRow class="align-center">
            <ButtonFile
              class="mr-2"
              prepend-icon="mdi-upload"
              accept="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel"
              :readFile="false"
              @input="onUpload"
              :label="$tr('ui.admin.translations.workbook', 'Upload workbook')"
            >
            </ButtonFile>
            <FSRow v-if="workbook != null">
              <FSSpan font="text-h3 mr-2">
                {{ workbook.name }}
              </FSSpan>
              <FSButton
                class="mr-2"
                variant="icon"
                color="error"
                icon="mdi-minus-circle-outline"
                @click="workbook = null"
              />
            </FSRow>
          </FSRow>
          <FSRow align="center-center">
            <v-divider length="40%" />
            <FSSpan font="text-h3 mx-auto">
              {{ $tr("ui.admin.translations.languages", "Languages") }}
            </FSSpan>
            <v-divider length="40%" />
          </FSRow>
          <FSRow class="align-center mb-5">
            <FSSpan font="text-body text-wrap">
              {{
                $tr("ui.admin.translations.add-a-column", "Click the plus button for each column containing a language")
              }}
            </FSSpan>
            <v-spacer />
            <FSButton
              variant="icon"
              icon="mdi-plus-circle-outline"
              @click="() => columns.push({ index: nextIndex(), languageCode: '' })"
            />
          </FSRow>
          <FSCol v-if="columns.length > 0">
            <FSRow v-for="(column, i) in columns" align="center-center">
              <FSButton
                class="mr-2"
                variant="icon"
                color="error"
                icon="mdi-minus-circle-outline"
                @click="() => columns.splice(i, 1)"
              />
              <span class="text-h6 mr-2">
                {{ $tr("ui.admin.entity-property.label-column", "Label column") }}
                {{ indexToColumn(column.index) }} /
                {{ $tr("ui.admin.entity-property.category-column", "Category column") }}
                {{ indexToColumn(column.index + 1) }}
              </span>
              <v-spacer />
              <FSButton
                class="mr-2"
                variant="icon"
                icon="mdi-menu-left-outline"
                :disabled="column.index < 2"
                @click="() => column.index--"
              />
              <FSButton class="mr-2" variant="icon" icon="mdi-menu-right-outline" @click="() => column.index++" />
              <LanguageSelector
                :rules="[(v : string) => !!v || $tr('ui.common.required', 'Required')]"
                style="width: 280px"
                @update:model-value="setLanguageCode(i, $event)"
              />
            </FSRow>
          </FSCol>
        </FSCol>
      </v-form>

      <FSRow>
        <FSButtonCancel @click="closeDrawer" class="mr-2" :label="$tr('ui.common.cancel', 'Cancel')"> </FSButtonCancel>
        <FSButtonSave
          prepend-icon="mdi-upload"
          :loading="uploading"
          variant="standard"
          @click="upload"
          :label="$tr('ui.common.import', 'Import')"
        />
      </FSRow>
    </FSCol>
  </Drawer>
</template>

<script lang="ts">
import { SpreadsheetColumnDefinition } from "../../../domain";
import { defineComponent, ref } from "vue";

import Drawer from "../..//shared/Drawer.vue";
import ButtonFile from "../../shared/ButtonFile.vue";
import LanguageSelector from "../../LanguageSelector.vue";

import { useUploadEntityPropertyTranslation } from "../../../composables";
import _ from "lodash";
import { useExtensionCommunicationBridge } from "@dative-gpi/foundation-template-shared-ui";

export default defineComponent({
  name: "ImportTranslationsDrawer",
  components: {
    ButtonFile,
    LanguageSelector,
    Drawer,
  },

  setup(props) {
    const drawer = ref<boolean>(true);
    const valid = ref<boolean>(false);

    const extension = useExtensionCommunicationBridge();

    const {
      upload: uploadEntityPropertyTranslations,
      uploaded: entityPropertyTranslations,
      uploading,
    } = useUploadEntityPropertyTranslation();

    const form = ref<any>();

    const workbook = ref<File | null>(null);
    const columns = ref<SpreadsheetColumnDefinition[]>([]);

    const onUpload = (payload: File) => {
      workbook.value = payload;
    };

    const closeDrawer = () => {
      extension.closeDrawer(location.pathname, false);
    };

    const indexToColumn = (index: number) => {
      const letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      let column = "";

      while (index >= 0) {
        column = letters[index % 26] + column;
        index = Math.floor(index / 26) - 1;
      }
      return column;
    };

    const nextIndex = () => {
      if (columns.value.length === 0) {
        return 2;
      }
      return _.maxBy(columns.value, "index")!.index + 1;
    };

    const upload = async () => {
      if (!form.value.validate() || workbook.value == null) {
        return;
      }

      await uploadEntityPropertyTranslations({
        file: workbook.value,
        labels: columns.value.map((c) => ({
          languageCode: c.languageCode,
          index: c.index,
        })),
        categories: columns.value.map((c) => ({
          languageCode: c.languageCode,
          index: c.index + 1,
        })),
      }).then(() => {
        extension.notify(entityPropertyTranslations.value);
        extension.closeDrawer(location.pathname, true);
      });
    };

    const setLanguageCode = (index: number, event: string) => {
      columns.value[index].languageCode = event;
    };

    return {
      valid,
      form,
      workbook,
      columns,
      uploading,
      drawer,
      indexToColumn,
      nextIndex,
      upload,
      onUpload,
      closeDrawer,
      setLanguageCode,
    };
  },
});
</script>

<style scoped></style>
