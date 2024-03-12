import { ComposableFactory, buildURL, ServiceFactory, onCollectionChanged } from "@dative-gpi/bones-ui";

import { ENTITYPROPERTY_TRANSLATIONS_URL, ENTITYPROPERTY_TRANSLATION_URL, ENTITYPROPERTY_TRANSLATIONS_WORKBOOK_URL } from "../config";

import { EntityPropertyTranslationInfos, EntityPropertyTranslationDTO, DownloadEntityPropertyTranslations, UpdateEntityPropertyTranslation, UploadEntityPropertyTranslations } from "../domain";

import { Ref, onUnmounted, readonly, ref } from "vue";

const EntityPropertyTranslationServiceFactory = new ServiceFactory<EntityPropertyTranslationInfos, EntityPropertyTranslationDTO>("entity-property-translation", EntityPropertyTranslationInfos)
    .create(f => f.build(
        f.addGetMany(ENTITYPROPERTY_TRANSLATIONS_URL, EntityPropertyTranslationInfos),
        f.addNotify(notifier => ({
            update: async (id: string, payload: UpdateEntityPropertyTranslation[]) => {
                const response = await ServiceFactory.http.put(ENTITYPROPERTY_TRANSLATION_URL(id), payload);
                const dtos: EntityPropertyTranslationDTO[] = response.data;
                const results = dtos.map(d => new EntityPropertyTranslationInfos(d));

                for (const result of results) {
                    notifier.notify("update", result);
                }

                return results;
            },
            upload: async (payload: UploadEntityPropertyTranslations) => {
                const data = new FormData();
                data.append('file', payload.file);

                for (let i = 0; i < payload.labels.length; i++) {
                    data.append(`labels[${i}].index`, payload.labels[i].index.toString());
                    data.append(`labels[${i}].languageCode`, payload.labels[i].languageCode);
                }

                for (let i = 0; i < payload.categories.length; i++) {
                    data.append(`categories[${i}].index`, payload.categories[i].index.toString());
                    data.append(`categories[${i}].languageCode`, payload.categories[i].languageCode);
                }

                const response = await ServiceFactory.http.put(ENTITYPROPERTY_TRANSLATIONS_WORKBOOK_URL, data, { headers: { 'Content-Type': 'multipart/form-data' } });
                const dtos: EntityPropertyTranslationDTO[] = response.data;

                const entityPropertyTranslations = dtos.map(d => new EntityPropertyTranslationInfos(d));

                return entityPropertyTranslations;
            },
            download: async (payload: DownloadEntityPropertyTranslations) => {
                const response = await ServiceFactory.http.get(buildURL(ENTITYPROPERTY_TRANSLATIONS_WORKBOOK_URL, payload), { responseType: 'blob' });

                const file = new File([response.data], payload.fileName, { type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" });

                return file;
            },
        }))
    ));


export const useEntityProtertyTranslations = ComposableFactory.getMany(EntityPropertyTranslationServiceFactory);

export const useUpdateEntityPropertyTranslation = () => {
    const service = EntityPropertyTranslationServiceFactory();

    const updating = ref(false);
    const updated = ref<EntityPropertyTranslationInfos[]>([]) as Ref<EntityPropertyTranslationInfos[]>;

    const update = async (id: string, payload: UpdateEntityPropertyTranslation[]) => {
        updating.value = true;
        try {
            updated.value = await service.update(id, payload);
        }
        finally {
            updating.value = false;
        }

        const subscriberId = service.subscribe("all", onCollectionChanged(updated))
        onUnmounted(() => service.unsubscribe(subscriberId));

        return readonly(updated.value);
    }

    return {
        updating: readonly(updating),
        update,
        updated: readonly(updated)
    }
}

export const useUploadEntityPropertyTranslation = () => {
    const service = EntityPropertyTranslationServiceFactory();

    const uploading = ref(false);
    const uploaded = ref<EntityPropertyTranslationInfos[]>([]) as Ref<EntityPropertyTranslationInfos[]>;

    const upload = async (payload: UploadEntityPropertyTranslations) => {
        uploading.value = true;
        try {
            uploaded.value = await service.upload(payload);
        }
        finally {
            uploading.value = false;
        }

        const subscriberId = service.subscribe("all", onCollectionChanged(uploaded))
        onUnmounted(() => service.unsubscribe(subscriberId));

        return readonly(uploaded.value);
    }

    return {
        uploading: readonly(uploading),
        upload,
        uploaded: readonly(uploaded)
    }
}

export const useDownloadEntityPropertyTranslation = () => {
    const service = EntityPropertyTranslationServiceFactory();

    const downloading = ref(false);
    const downloaded = ref<File>() as Ref<File>;

    const download = async (payload: DownloadEntityPropertyTranslations) => {
        downloading.value = true;
        try {
            downloaded.value = await service.download(payload);
        }
        finally {
            downloading.value = false;
        }
    }

    return {
        downloading: readonly(downloading),
        download,
        downloaded: downloaded
    }
}