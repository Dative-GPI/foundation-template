import { ComposableFactory, ServiceFactory, buildURL, onCollectionChanged, onEntityChanged } from "@dative-gpi/bones-ui";

import { APPLICATION_TRANSLATIONS_URL, APPLICATION_TRANSLATIONS_WORKBOOK_URL, APPLICATION_TRANSLATION_URL } from "../config";

import { ApplicationTranslation, ApplicationTranslationDTO, ApplicationTranslationsFilter, DownloadApplicationTranslations, UpdateApplicationTranslation, UploadApplicationTranslations } from "../domain";
import { Ref, onUnmounted, readonly, ref } from "vue";

const ApplicationTranslationServiceFactory = new ServiceFactory<ApplicationTranslation, ApplicationTranslationDTO>("application-translation", ApplicationTranslation)
    .create(f => f.build(
        f.addGetMany<ApplicationTranslationDTO, ApplicationTranslation, ApplicationTranslationsFilter>(APPLICATION_TRANSLATIONS_URL, ApplicationTranslation),
        f.addNotify(notifier => ({
            upsert: async (code: string, payload: UpdateApplicationTranslation) => {
                const response = await ServiceFactory.http.post(APPLICATION_TRANSLATION_URL(code), payload);
                const dtos: ApplicationTranslationDTO[] = response.data;
                const results = dtos.map(d => new ApplicationTranslation(d));

                console.log(results);

                for (const result of results) {
                    notifier.notify("update", result);
                }

                return results;
            },
            upload: async (payload: UploadApplicationTranslations) => {
                const data = new FormData();
                data.append('file', payload.file);
                for (let i = 0; i < payload.languagesCodes.length; i++) {
                    data.append(`languagesCodes[${i}].index`, payload.languagesCodes[i].index.toString());
                    data.append(`languagesCodes[${i}].languageCode`, payload.languagesCodes[i].languageCode);
                }

                const response = await ServiceFactory.http.put(APPLICATION_TRANSLATIONS_WORKBOOK_URL, data, { headers: { 'Content-Type': 'multipart/form-data' } });
                const dtos: ApplicationTranslationDTO[] = response.data;

                const applicationTranslations = dtos.map(d => new ApplicationTranslation(d));

                for (const result of applicationTranslations) {
                    notifier.notify("update", result);
                }

                return applicationTranslations;
            },
            download: async (payload: DownloadApplicationTranslations) => {
                const response = await ServiceFactory.http.get(buildURL(APPLICATION_TRANSLATIONS_WORKBOOK_URL, payload), { responseType: 'blob' });

                const file = new File([response.data], payload.fileName, { type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" });

                return file;
            },
            // notifyRemove: (id: string) => notifier.notify("delete", id)
        }))
    ));

export const useApplicationTranslations = ComposableFactory.getMany(ApplicationTranslationServiceFactory);
export const useUpsertApplicationTranslation = () => {
    const service = ApplicationTranslationServiceFactory();

    const upserting = ref(false);
    const upserted = ref<ApplicationTranslation[]>([]) as Ref<ApplicationTranslation[]>;

    const upsert = async (code: string, payload: UpdateApplicationTranslation) => {
        upserting.value = true;
        try {
            upserted.value = await service.upsert(code, payload);
        }
        finally {
            upserting.value = false;
        }

        const subscriberId = service.subscribe("all", onCollectionChanged(upserted))
        onUnmounted(() => service.unsubscribe(subscriberId));

        return readonly(upserted.value);
    }

    return {
        upserting: readonly(upserting),
        upsert,
        upserted: readonly(upserted)
    }
}

export const useUploadApplicationTranslation = () => {
    const service = ApplicationTranslationServiceFactory();

    const uploading = ref(false);
    const uploaded = ref<ApplicationTranslation[]>([]) as Ref<ApplicationTranslation[]>;

    const upload = async (payload: UploadApplicationTranslations) => {
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

export const useDownloadApplicationTranslation = () => {
    const service = ApplicationTranslationServiceFactory();

    const downloading = ref(false);
    const downloaded = ref<File>() as Ref<File>;

    const download = async (payload: DownloadApplicationTranslations) => {
        downloading.value = true;
        try {
            downloaded.value = await service.download(payload);
        }
        finally {
            downloading.value = false;
        }

        /* const subscriberId = service.subscribe("all", onCollectionChanged(uploaded))
         onUnmounted(() => service.unsubscribe(subscriberId));*/
    }

    return {
        downloading: readonly(downloading),
        download,
        downloaded: downloaded
    }
}




