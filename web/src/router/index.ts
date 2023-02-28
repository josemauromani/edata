import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    alias: "/users",
    name: "users",
    component: () => import("../components/user/UserList.vue"),
  },
  {
    path: "/users/:id",
    name: "user-details",
    component: () => import("../components/user/UserDetails.vue"),
  },
  {
    path: "/add",
    name: "add",
    component: () => import("../components/user/AddUser.vue"),
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
