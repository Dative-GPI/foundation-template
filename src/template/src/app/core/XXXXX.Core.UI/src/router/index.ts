// Composables
import { createRouter, createWebHistory } from 'vue-router'

import { routes as templateRoutes } from "@dative-gpi/foundation-template-core-ui"

const routes = [
  {
    path: '/organisations/:organisationId/xxxxx/home',
    name: 'home',
    component: () => import('@/views/Home.vue'),
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes: [
    ...templateRoutes,
    ...routes
  ]
})

export default router
