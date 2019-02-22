
<template>
		<div class="nooo">
				<h1>Hello {{ name }}</h1>

				<button>Submit</button>
				<br />
				<label>This is the payload...</label>
				<div id="payload"></div>
		</div>
</template>

<script>
		export default {
				name: 'hit-server',
				props: {
						name: String
				}
		};
</script>