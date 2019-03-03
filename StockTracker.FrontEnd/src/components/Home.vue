<template>
    <div class="home">
        <h1>{{ msg }}</h1>
        <b-alert show>Welcome to your new single-page application, built with <a href="https://vuejs.org" target="_blank">Vue.js</a>.</b-alert>
    </div>
</template>

<script>
    export default {
        name: 'home',
        props: {
            msg: String
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
