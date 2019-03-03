<template>
  <b-col sm="6">
    <h4>Client {{ name }}</h4>
    <br>
    <b-form @submit="onSubmit" @reset="onReset">
      <b-form-group label="Client Name" label-for="client-name">
        <b-form-input id="client-name" type="text" v-model="form.name" required placeholder="Client Name"></b-form-input>
      </b-form-group>

      <b-form-group label="Email" label-for="client-email">
        <b-form-input id="client-email" type="email" v-model="form.email" required placeholder="Client Email"></b-form-input>
      </b-form-group>

      <b-form-group label="Mobile" label-for="client-contact-number">
        <b-form-input id="client-contact-number" type="text" v-model="form.contactnumber" required placeholder="Client Contact Number"></b-form-input>
      </b-form-group>

      <b-form-group label="Address" label-for="client-address"> 
        <b-form-input id="client-address" type="text" v-model="form.address" required placeholder="Address"></b-form-input>
      </b-form-group>

      <b-button type="submit" variant="primary">Submit</b-button>
      <b-button type="reset" variant="default">reset</b-button>
    </b-form>
  </b-col>
</template>
<script>
export default {
  name: 'client-edit',
  props: ['name'],
  data() {
    return {
      name: '',
      form: {
        name: '',
        email: '',
        contactnumber: '',
        address: ''
      }
    }
  },
  methods: {
    onSubmit(event){
      event.preventDefault();
      alert(JSON.stringify(this.form));
    },
    onReset(event){
      this.form.email = '';
      this.form.name = '';
      this.form.contactnumber = '';
      this.form.address = '';
    }
  }
}
</script>
