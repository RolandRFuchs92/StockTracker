<template>
  <div id="clients-view" class="row">
    <client-report
      v-bind:uri="uriFetch"
      @edit="editMechanism"
      @add="addMechanisim"
      @settings="settings"
      class="q-pb-sm q-ma-sm"
    />

    <div class="q-ma-sm" v-if="formTitle.toLowerCase() === 'edit'" :key="updateTrigger">
      <client-edit v-bind="form" v-bind:formTitle="formTitle" v-bind:uri="uriEdit"/>
    </div>

    <div class="q-ma-sm" v-if="formTitle.toLowerCase() === 'add'">
      <client-add v-bind:formTitle="formTitle" v-bind:uri="uriAdd"/>
    </div>
  </div>
</template>
<script>
// import { Notify } from 'quasar';
import clientForm from '../../components/Clients/Form';
import clientReport from '../../components/Clients/Report';

const clientAdd = Object.assign({}, clientForm);
const clientEdit = Object.assign({}, clientForm);

export default {
  name: 'clients-view',
  props: {
    uriFetch: String,
    uriAdd: String,
    uriEdit: String,
  },
  data() {
    return {
      form: {},
      formTitle: '',
      updateTrigger: 0,
    };
  },
  components: {
    'client-add': clientAdd,
    'client-edit': clientEdit,
    'client-report': clientReport,
  },
  methods: {
    editMechanism(data) {
      this.form = data;
      this.formTitle = 'Edit';
      this.updateTrigger += 1;
    },
    addMechanisim() {
      this.formTitle = 'Add';
    },
    settings() {
      this.$q.notify({
        message: 'Coming soon!',
        type: 'info',
      });
    },
  },
};
</script>
