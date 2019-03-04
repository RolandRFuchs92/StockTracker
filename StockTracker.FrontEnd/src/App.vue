<template>
	<div id="app">
		<b-container fluid>
			<div class="row">
				<sidebar-menu :menu="menu" style="position:relative;"/>
				<transition name="fade">
						<keep-alive>
							<b-col>
								<router-view></router-view>
							</b-col>
						</keep-alive>
				</transition>
			</div>
		</b-container>
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
													href: '/clients/all',
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