import { inject } from "vue";
import { LANGUAGE_CODE } from "../config";

export function useLanguage() {
    const languageCode = inject(LANGUAGE_CODE);

    return {
        languageCode
    }
}