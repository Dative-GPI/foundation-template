// Composables
import { createRouter, createWebHistory } from 'vue-router'

import { routes as templateRoutes } from "@dative-gpi/foundation-template-admin-ui"

const routes = [
  {
    path: '/organisations/:organisationId/teleport/connect/:roomId?',
    name: 'connect',
    component: () => import('@/views/Connect.vue'),
  },
  {
    path: '/organisations/:organisationId/teleport/rooms',
    name: 'rooms',
    component: () => import('@/views/Rooms.vue'),
  },
  {
    path: '/organisations/:organisationId/teleport/rooms/:roomId',
    name: 'room',
    component: () => import('@/views/Room.vue'),
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
