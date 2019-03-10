<template>
  <div id="clients-view" class="row">
    <client-report v-bind:uri="uriFetch" @edit="editMechanism" class="q-pb-sm q-ma-sm"/>

    <div class="q-ma-sm" v-if="formTitle.toLowerCase() === 'edit'" :key="updateTrigger">
      <client-edit v-bind="form" v-bind:formTitle="formTitle"/>
    </div>

    <div class="q-ma-sm" v-if="formTitle.toLowerCase() === 'add'">
       <div class="q-ma-sm" v-if="formTitle.toLowerCase() === 'edit'" :key="updateTrigger">
        <client-add v-bind="form" v-bind:formTitle="formTitle"/>
    </div>
    </div>
  </div>
</template>
<script>
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
      showForm: false,
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
      this.showForm = true;
      this.form = data;
      this.formTitle = 'Edit';
      this.updateTrigger += 1;
    },
  },
};
</script>
