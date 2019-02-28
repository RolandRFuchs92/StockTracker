<template>
		<div id="app">
			<sidebar-menu :menu="menu">
				<b-container fluid>
					<router-view/>
				</b-container>
			</sidebar-menu>
		</div>
</template>

<script>
	import 'bootstrap/dist/css/bootstrap.css';
	import 'bootstrap-vue/dist/bootstrap-vue.css';


		export default {
				name: 'app',
				data() {
					return {
						   menu: [
                    {
                        header: true,
                        title: 'Welcome back, Roland',
                        // component: componentName
                        // visibleOnCollapse: true
                    },
                    {
                        title: 'Clients',
												icon: 'fa fa-user',
												child: [
													{
														href: '/clients/edit',
														title: 'Edit'
													},
													{
														href: '/clients/add',
														title: 'Add'
													},
													{
														title: 'Reports',
														child: [
																{
																	href: '/clients/list',
																	title: 'All Clients'
																},
																{
																	href: '/clients/list?isActive=true',
																	title: 'ActiveClients'
																}
														]
													}
												]
                    },
                    {
                        title: 'Charts',
                        icon: 'fa fa-chart-area',
                    }]
					}
			},				
		};
</script>

<style lang="scss">
</style>