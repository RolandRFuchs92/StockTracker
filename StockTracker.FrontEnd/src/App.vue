<template>
		<div id="app">
			<vue2-sidebar heading="Welcome back, Roland">
			<b-container fluid>
				<b-row>
					<b-col xl="2" lg="4" md="5" style="background-color: lightblue;">col 1</b-col>
					<b-col style="background-color: red;">col 2</b-col>
				</b-row>
			</b-container>
				<router-view/>
			</vue2-sidebar>
		</div>
</template>

<script>
	import 'bootstrap/dist/css/bootstrap.css';
	import 'bootstrap-vue/dist/bootstrap-vue.css';

		export default {
				name: 'app'
		};
</script>

<style lang="scss">
</style>