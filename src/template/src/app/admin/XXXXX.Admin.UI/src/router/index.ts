// Composables
import { createRouter, createWebHistory } from 'vue-router'

import { routes as templateRoutes } from "@dative-gpi/foundation-template-admin-ui"

const templateExtensionRoutes = templateRoutes.map((route: any) => { route.path = route.path.replace("extension", "xxxxx"); return route; })

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes: [
    ...templateExtensionRoutes,
  ]
})

export default router
