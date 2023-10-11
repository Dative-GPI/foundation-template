import { onMounted, onUnmounted, ref } from 'vue';
import { useRoute, useRouter } from 'vue-router';

import { ServiceFactory } from '@dative-gpi/bones-ui';

import { useExtensionCommunicationBridge } from './useExtensionCommunicationBridge';

let extensionHostInitialized = false;

export function useExtensionHost() {
    const token = ref<string | null>(null);
    const languageCode = ref<string | null>(null);

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
