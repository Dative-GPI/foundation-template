import { inject } from "vue";
import { ACCESS_TOKEN } from "../config";

export function useCredentials() {
    const token = inject(ACCESS_TOKEN);
    
    return {
        token
    }
}