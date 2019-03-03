import Vue from 'vue';
import App from './App';
import router from './router';
import BootstrapVue from 'bootstrap-vue';
import VueSidebarMenu from 'vue-sidebar-menu'
import 'vue-sidebar-menu/dist/vue-sidebar-menu.css'

import { library, dom } from '@fortawesome/fontawesome-svg-core';
import { faAngleDown, faUser, faChartArea } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';

library.add(
  faAngleDown,
  faUser,
  faChartArea
);
Vue.component('font-awesome-icon', FontAwesomeIcon);

dom.watch();

Vue.use(BootstrapVue);
Vue.use(VueSidebarMenu);

Vue.config.productionTip = false;

new Vue({
  el: '#app',
  router,
  render: h => h(App),
});
