import Vue from 'vue';
import LayoutList from '../layouts/LayoutList';

Vue.component('layout-list', LayoutList);

const applicationSettings = {
  appName: 'Stock Tracker App',
  userFullname: 'Roland',
};

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
        path: '/client/add',
        component: () => import('../pages/clients/Configure'),
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
