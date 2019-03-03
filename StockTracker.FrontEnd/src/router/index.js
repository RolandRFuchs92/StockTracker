import Vue from 'vue';
import Router from 'vue-router';
import Home from '../components/Home';
import ClientsForm from '../components/Clients/Form';


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
      component: ClientsForm,
      props: {
        name: 'Add'
      }
    },
    {
      path: '/clients/edit',
      name: 'dogs',
      component: ClientsForm,
      props: { 
        name: 'Edit' 
      }
    }
  ] 
});