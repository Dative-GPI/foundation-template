import { onMounted, onUnmounted, provide, ref } from 'vue';
import { useRoute, useRouter } from 'vue-router';

import { ServiceFactory } from '@dative-gpi/bones-ui';

import { useExtensionCommunicationBridge } from './useExtensionCommunicationBridge';
import { ACCESS_TOKEN, LANGUAGE_CODE } from '../config';

let extensionHostInitialized = false;

const token = ref<string | null>(null);
const languageCode = ref<string | null>(null);

export function useExtensionHost() {

    onMounted(() => {
        if (extensionHostInitialized) return;
        extensionHostInitialized = true;

        token.value = new URL(window.location.toString())
            .searchParams.get("token")

        languageCode.value = new URL(window.location.toString())
            .searchParams.get("languageCode")

        const { goTo, setHeight } = useExtensionCommunicationBridge();

        const router = useRouter();
        const route = useRoute();

        const unsubscribe = router.afterEach((to, _from) => {
            goTo(to.path);
        });

        const intervalId = setInterval(() => {
            setHeight(
                document.body.scrollHeight,
                route.path
            );
        }, 10)

        ServiceFactory.http.interceptors.request.use((config) => {
            config.headers.common['Authorization'] = `Bearer ${token.value}`;
            config.headers.common['Accept-Language'] = languageCode.value;
            return config;
        });

        provide(ACCESS_TOKEN, token);
        provide(LANGUAGE_CODE, languageCode);

        onUnmounted(() => {
            unsubscribe();
            clearInterval(intervalId);
        })
    })

    return {
        token,
        languageCode
    }
}
