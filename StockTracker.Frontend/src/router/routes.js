import Vue from 'vue';
import LayoutList from '../layouts/LayoutList';

Vue.component('layout-list', LayoutList);

const applicationSettings = {
  appName: 'Stock Tracker App',
  userFullname: 'Roland',
};

const apiPort = '61751';
const baseUri = `http://localhost:${apiPort}/api/`;

const uris = {
  clients: {
    getAll: 'clients/getall',
    edit: 'clients/edit',
    add: 'clients/add',
  },
};

const uri = val => `${baseUri}${val}`;

const routes = [
  {
    path: '/',
    component: () => import('layouts/MyLayout.vue'),
    props: applicationSettings,
    children: [
      {
        path: '',
        component: () => import('pages/Index.vue'),
      },
      {
        path: '/client/View',
        props: {
          uriFetch: uri(uris.clients.getAll),
          uriEdit: uri(uris.clients.edit),
          uriAdd: uri(uris.clients.add),
        },
        component: () => import('../pages/clients/View'),
      },
    ],
  },
];

// Always leave this as last one
if (process.env.MODE !== 'ssr') {
  routes.push({
    path: '*',
    component: () => import('pages/Error404.vue'),
  });
}

export default routes;
