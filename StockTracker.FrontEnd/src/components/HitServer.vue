
<template>
		<div class="nooo">
				<h1>Hello {{ name }}</h1>

				<button v-on:click="counter += 1;">Submit</button>
				<div>submit was clicked {{ counter }} time/s</div>
				<br />
				<button v-on:click="greet">Moooo!</button>
				<br />
				<label>This is the payload...</label>
				<div id="payload">{{ info }}</div>
		</div>
</template>

<script>
		import axios from 'axios';
		export default {
				name: 'hit-server',
				props: {
						name: String
				},
				data() {
						return {
								info: null,
								counter: 0
						}
				},
				methods: {
						greet: function (event) {
								alert('Hello ' + this.name);
								if (event) {
										alert(event.target.tagName);
								}
						}
				},
				created() {
						axios
								.get('https://api.coindesk.com/v1/bpi/currentprice.json')
								.then(response => (this.info = response.data));
				}
		};
</script>