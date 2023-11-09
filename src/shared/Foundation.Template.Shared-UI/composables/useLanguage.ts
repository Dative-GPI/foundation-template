import { Ref, inject } from "vue";
import { LANGUAGE_CODE } from "../config";

export function useLanguage() {
    const languageCode = inject<Ref<string>>(LANGUAGE_CODE);

    if (!languageCode || !languageCode.value) throw new Error("No language code found");

    return {
        languageCode
    }
}