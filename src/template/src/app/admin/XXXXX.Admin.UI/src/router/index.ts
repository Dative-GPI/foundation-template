// Composables
import { createRouter, createWebHistory } from 'vue-router'

import { routes as templateRoutes } from "@dative-gpi/foundation-template-admin-ui"


const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes: [
    ...templateRoutes,
  ]
})

export default router
