<template>
  <div id="client-report">
    <q-table title="Clients" :data="tableData" :columns="columns" row-key="name">
      <q-tr slot="bottom-row" slot-scope="props" :props="props">
        <q-td colspan="100%">
          <q-btn flat icon="add_box" class="float-right" v-on:click="emitAdd"></q-btn>
        </q-td>
      </q-tr>
      <q-td slot="body-cell-test" slot-scope="props" :props="props">
        <q-btn
          name="create"
          v-on:click="emitEdit(props)"
          flat
          icon="create"
          size="xs"
          :props="props"
        />
      </q-td>
    </q-table>
  </div>
</template>
<script>
import axios from 'axios';
import { date } from 'quasar';

const { formatDate } = date;

export default {
  name: 'client-report',
  props: {
    uri: String,
  },
  data() {
    return {
      columns: [
        {
          name: 'clientName',
          label: 'Client',
          sortable: true,
          align: 'left',
          field: 'clientName',
        },
        {
          name: 'contactNumber',
          label: 'Tel',
          align: 'left',
          field: 'contactNumber',
        },
        {
          name: 'email',
          align: 'left',
          label: 'Email',
          field: 'email',
        },
        {
          name: 'createdOn',
          align: 'left',
          label: 'Created',
          field: 'createdOn',
          format(val) {
            return formatDate(val, 'D MMM YYYY HH:mm');
          },
        },
        {
          name: 'lastCheckup',
          align: 'left',
          label: 'Last Checkup',
          field: 'lastCheckup',
          format(val) {
            return val === null ? 'Never' : formatDate(val, 'D MMM YYYY HH:mm');
          },
        },
        {
          name: 'test',
          align: 'right',
        },
      ],
      tableData: [],
    };
  },
  async created() {
    const data = await axios.get(this.uri);
    this.tableData = data.data.body;
  },
  methods: {
    emitEdit(data) {
      this.$emit('edit', data.row);
    },
    emitAdd() {
      this.$emit('add');
    },
  },
};
</script>
