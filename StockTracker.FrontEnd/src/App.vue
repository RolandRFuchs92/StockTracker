<template>
		<div id="app">
				<Home msg="Hello world!" />
				<Hit-Server name="boi" />
		</div>
</template>

<script>
		import Home from './components/Home.vue';
		import HitServer from './components/HitServer.vue';
		//import axios from "axios";

		export default {
				name: 'app',
				components: {
						Home,
						HitServer
				}
		};
</script>

<style>
</style>
