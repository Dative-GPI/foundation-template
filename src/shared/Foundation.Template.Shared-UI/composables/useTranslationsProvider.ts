import { ref } from "vue";
import { ServiceFactory } from "@dative-gpi/bones-ui";
import { ComposableFactory } from "@dative-gpi/bones-ui";

import { APPLICATION_TRANSLATIONS_URL } from "../config";
import { ApplicationTranslation } from "../models";

const ApplicationTranslationServiceFactory = ServiceFactory.create("application-translation", f => f.build(
    f.addGetMany(APPLICATION_TRANSLATIONS_URL, ApplicationTranslation),
    f.addNotify<ApplicationTranslation>()
));

const useApplicationTranslations = ComposableFactory.getMany(ApplicationTranslationServiceFactory);

const { entities: translations, getMany, fetching } = useApplicationTranslations()

const init = ref<Promise<any> | null>(null);

export const useTranslationsProvider = () => {
    const has = (code: string) => {
        return !!translations.value.find(t => t.code === code);
    }

    const get = (code: string) => {
        const t = translations.value.find(t => t.code === code);
        return t ? t.value : null
    }

    const fetch = () => {
        if (!init.value)
            init.value = getMany();
        return init.value;
    }

    return {
        has,
        get,
        init: fetch,
        initializing: fetching
    }
}