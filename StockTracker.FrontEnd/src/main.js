import Vue from 'vue';
import App from './App';
import router from './router';
import BootstrapVue from 'bootstrap-vue';
import Vue2Sidebar from 'vue2-sidebar';

Vue.use(BootstrapVue);
Vue.use(Vue2Sidebar);
Vue.config.productionTip = false;

new Vue({
  el: '#app',
  router,
  render: h => h(App),
});
