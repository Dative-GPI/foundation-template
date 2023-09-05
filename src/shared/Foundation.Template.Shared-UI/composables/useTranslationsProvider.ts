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

export const useTranslationsProvider = () => {
    const has = (code: string) => {
        return !!translations.value.find(t => t.code === code);
    }

    return {
        has,
        init: getMany,
        initializing: fetching
    }
}

