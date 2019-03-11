<template>
  <q-modal v-model="this.form">
    <q-card class="q-pa-sm col-md-6">
      <form @submit="onSubmit">
        <div class="q-title text-weight-regular">{{ this.formTitle }} client</div>
        <q-input
          autofocus
          v-model="form.name"
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
          <q-btn type="submit" color="primary" icon="check" label="Submit" class="q-mr-xs"/>
          <q-btn type="reset" color="secondary" icon="clear_all" label="Reset"/>
        </div>
      </form>
    </q-card>
  </q-modal>
</template>
<script>
import { date } from 'quasar';
import axios from 'axios';

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
    uri: String,
  },
  data() {
    return {
      form: {
        clientId: 0,
        name: '',
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
    onReset(event) {
      event.preventDefault();
      this.form.clientId = 0;
      this.form.name = '';
      this.form.email = '';
      this.form.contactNumber = '';
      this.form.address = '';
    },
    async onSubmit(event) {
      event.preventDefault();
      try {
        debugger;
        const [message, isSuccess] = await axios.post(this.uri, this.form).data;
        if (isSuccess) {
          this.$q.notify({
            message,
            type: 'positive',
          });
        } else {
          this.$q.notify({
            message,
            type: 'warning',
          });
        }
      } catch {
        console.log('error..');
      }
    },
  },
  created() {
    this.form = Object.assign({}, this.$props);
    this.form.name = this.$props.clientName;
  },
};
</script>
