import Vue from 'vue';
import Router from 'vue-router';
import Home from '../components/Home';
import Clients from '../components/Clients/Clients';

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/clients',
      name: 'clients',
      component: Clients
    }
  ] 
});