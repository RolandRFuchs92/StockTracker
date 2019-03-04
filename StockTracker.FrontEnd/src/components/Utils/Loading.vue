<template>
  <div id="util-loading">
    <div class="spinner-grow" role="status">
      <span class="sr-only"></span>
    </div>
      <span>Loading...</span>
  </div>
</template>
<script>
export default {
  name: 'util-loading',
  props: {
    isLoading: Boolean
  }
}
</script>
