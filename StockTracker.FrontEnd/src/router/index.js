import Vue from 'vue';
import Router from 'vue-router';
import Home from '../components/Home';
import ClientsEdit from '../components/Clients/Edit';
import ClientsAdd from '../components/Clients/Add';

Vue.use(Router);

export default new Router({
  mode: 'history',
  base: __dirname,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
    },
    {
      path: '/clients/add',
      name: 'add',
      component: ClientsEdit,
      props: {
        name: 'Add'
      }
    },
    {
      path: '/clients/edit',
      name: 'dogs',
      component: ClientsEdit,
      props: { 
        name: 'Edit' 
      }
    }
  ] 
});