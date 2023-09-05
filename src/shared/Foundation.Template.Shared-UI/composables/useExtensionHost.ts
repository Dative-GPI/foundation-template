import { computed, onMounted, onUnmounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';

import { ServiceFactory } from '@dative-gpi/bones-ui';

import { useExtensionCommunicationBridge } from './useExtensionCommunicationBridge';

let extensionHostInitialized = false;

export function useExtensionHost() {
    const token = computed(() => new URL(window.location.toString())
        .searchParams.get("token"));

    const languageCode = computed(() => new URL(window.location.toString())
        .searchParams.get("languageCode"));


    onMounted(() => {
        if (extensionHostInitialized) return;
        extensionHostInitialized = true;

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