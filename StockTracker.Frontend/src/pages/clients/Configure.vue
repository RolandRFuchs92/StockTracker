<template>
  <client-add/>
</template>
<script>
import clientadd from '../../components/Clients/Form';

export default {
  name: 'clients-view',
  components: {
    'client-add': clientadd,
  },
};
</script>
