import { ref } from "vue";
import { useTranslations } from "./useTranslations";


const { entities: translations, getMany, fetching } = useTranslations();

const init = ref<Promise<any> | null>(null);

export const useTranslationsProvider = () => {
    const $tr = (code: string, defaultValue: string, ...parameters: string[]) => {
        let translation = translations.value.find(t => t.code === code)?.value ?? defaultValue;
        if (translation && parameters.length) {
            for (let p of parameters) {
                translation = translation.replace(`{${parameters.indexOf(p)}}`, p.toString());
            }
        }
        return translation;
    }

    const fetch = () => {
        if (!init.value)
            init.value = getMany();
        return init.value;
    }

    return {
        init: fetch,
        initializing: fetching,
        $tr
    }
}

