<template>
  <q-card class="q-pa-sm col-md-6">
    <form>
      <div class="q-headline">{{ this.formTitle }}</div>
      <q-input
        autofocus
        v-model="form.clientName"
        type="text"
        float-label="Name"
        placeholder="Company Name"
      />
      <q-input
        v-model="form.email"
        type="email"
        float-label="Email"
        placeholder="Company Admin Email"
      />
      <q-input
        v-model="form.contactNumber"
        type="tel"
        float-label="Contact Number"
        placeholder="Company contact number"
      />
      <q-input
        v-model="form.address"
        type="text"
        float-label="Address"
        placeholder="Company address"
      />
      <sub class="text-weight-light" v-if="this.form.clientId > 0">
        ClientId[{{this.form.clientId}}]
        <br>
        CreatedOn[{{ comCreatedOn }}]
      </sub>
      <div class="q-pt-xs">
        <q-btn
          type="submit"
          color="primary"
          icon="check"
          label="Submit"
          :submit="onClick"
          class="q-mr-xs"
        />
        <q-btn type="reset" color="secondary" icon="clear_all" label="Reset" v-on:click="onReset"/>
      </div>
    </form>
  </q-card>
</template>
<script>
import { date } from 'quasar';

const { formatDate } = date;

export default {
  name: 'client-form',
  props: {
    clientId: Number,
    clientName: String,
    email: String,
    contactNumber: String,
    address: String,
    formTitle: String,
    createdOn: String,
  },
  data() {
    return {
      form: {
        clientId: 0,
        clientName: '',
        email: '',
        contactNumber: '',
        address: '',
        formTitle: '',
        createdOn: '',
      },
    };
  },
  computed: {
    comCreatedOn() {
      return formatDate(this.createdOn, 'DD MMM YYYY HH:mm');
    },
  },
  methods: {
    onReset() {
      this.form.clientId = 0;
      this.form.clientName = '';
      this.form.email = '';
      this.form.contactNumber = '';
      this.form.address = '';
    },
    onClick() {},
  },
  created() {
    this.form = Object.assign({}, this.$props);
  },
};
</script>
