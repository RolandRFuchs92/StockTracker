import Vue from 'vue';
import Router from 'vue-router';
import Home from '../components/Home';
import ClientsForm from '../components/Clients/Form';
import ClientsAll from '../components/Clients/Reports/All';

const baseUrl = "http://localhost:61751/api"

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
        name: 'Add',
        postUrl: `${baseUrl}/clients/add`
      }
    },
    {
      path: '/clients/edit',
      name: 'dogs',
      component: ClientsForm,
      props: { 
        name: 'Edit' ,
        postUrl: `${baseUrl}/clients/edit`
      }
    },
    {
      path: '/clients/all',
      name: 'Get All',
      component: ClientsAll,
      props: {
        uri: `${baseUrl}/clients/getall`
      }
    }
  ] 
});