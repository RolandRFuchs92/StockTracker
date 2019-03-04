<template>
  <div id="clients-all">
    <h4>All Clients</h4>

    <util-loading v-if="isLoading" />
    <div v-if="!isLoading">
      <b-table striped hover :items="result.body" :fields="fields" dark></b-table>
    </div>
  </div>
</template>
<script>
import axios from 'axios';
import moment from 'moment';

export default {
  name: 'clients-all',
  props: {
    uri: String
  },
  data(){
    return {
      isLoading: Boolean,
      fields: [
        { key: 'clientId', sortable: true},
        { key: 'clientName', label: 'Name', sortable: true},
        'email',
        'contactNumber', 
        'address',
        'lastCheckup',
        'createdOn'
      ],
      result: {
        isSuccess: Boolean,
        message: String,
        body: [{
          clientId: Number,
          clientName: String,
          email: String,
          contactNumber: String,
          address: String,
          lastCheckup: Date,
          createdOn: Date
        }]
      }
    };
  },
  watch: {
    result: function(val){
      var body = val.body;

      for(var el of body) {
          el.lastCheckup = el.lastCheckup == null ? 'Never' :  moment(el.lastCheckup).format('DD MMM YYYY HH[h]mm');
          el.createdOn = el.createdOn == null ? 'Never' : moment(el.createdOn).format('DD MMM YYYY HH[h]mm');
      }
    }
  },
  async mounted() {
    var response = await axios.get(this.uri);
    this.result = response.data;
    this.isLoading = false;
  },
}
</script>
