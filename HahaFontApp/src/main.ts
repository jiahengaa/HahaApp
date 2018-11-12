// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App.vue'
import router from './router'
import ElementUi from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import './sass/default.scss'
// 引入图标库
import './sass/icons/iconfont.css'
import './sass/icons/iconfont.js'
import 'font-awesome/css/font-awesome.css'
// 自定义window上的参数
import './typings/ts-declare'

Vue.config.productionTip = false
Vue.use(ElementUi)

/* eslint-disable no-new */
const vm = new Vue({
  el: '#app',
  router,
  template: '<App/>',
  data: {
    eventHub: new Vue()
  },
  components: { App },
  methods: {
    updateData(data: any) {
      Object.keys(data).forEach(key => {
        const obj: Object = data[key]
        this.$root.$data.eventHub.$emit(key, obj);
      })
    },
  }
})

window.vm = vm



