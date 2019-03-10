<template>
  <div class="row gutter-xs">
    <form class="col-md-3">
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
        v-model="form.contactnumber"
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
      <div class="q-pt-xs">
        <q-btn
          type="submit"
          color="primary"
          icon="check"
          label="Submit"
          @click="onClick"
          class="q-mr-xs"
        />
        <q-btn type="reset" color="secondary" icon="clear_all" label="Reset" @click="onClick"/>
      </div>
    </form>
  </div>
</template>
<script>
export default {
  name: 'client-form',
  data() {
    return {
      form: {
        name: '',
        email: '',
        contactnumber: '',
        address: '',
      },
    };
  },
  methods: {
    onClick() {
      return '';
    },
  },
};
</script>
