import Vue, { AsyncComponent } from 'vue'
import Router, { RouteConfig, Route, NavigationGuard } from 'vue-router'

const Main: AsyncComponent = (): any => import('@/pages/Main.vue')
const UpcomingMovies:AsyncComponent=():any=>import('@/components/UpcomingMovies.vue')
const PopularActors:AsyncComponent=():any=>import('@/components/PopularActors.vue')

Vue.use(Router)

const routes: RouteConfig[] = [
  {
    path: '/',
    name: '电影',
    component: Main,
    redirect:'/UpcomingMovies',
    children:[
      {
        path:'/UpcomingMovies',
        name:'即将更新',
        component:UpcomingMovies,
        meta:{keepAlive: false}
      },
      {
        path:'/PopularActors',
        name:"热搜影星",
        component:PopularActors,
        meta:{keepAlive: true}
      }
    ]
  },

]

const router: Router = new Router({
  // mode: 'history',
  base: '/',
  routes
})

export default router
