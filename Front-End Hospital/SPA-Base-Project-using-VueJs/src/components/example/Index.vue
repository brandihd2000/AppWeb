<template>
    <div>
      <h2>Example Module</h2>
      <div v-loading="loading">
        <el-table :data="items" :default-sort = "{prop: 'id', order: 'descending'}" style="max-width: 100%"  max-height="500">
          <el-table-column prop="id" label="Id" sortable  width="50px" fixed ></el-table-column>
          <el-table-column prop="title" label="Títutlo"  width="250px" sortable >
            <template slot-scope="scope" >
              <a :href="'#/example/' + scope.row.id">{{ scope.row.title }}</a>
            </template>
          </el-table-column>
          <el-table-column prop="body"  label="Mensaje"></el-table-column>
        </el-table>
       </div>
      </div>
</template>

<script>
export default {
  name: "ExampleIndex",
  data() {
    return {
      loading: false,
      items: []
    };
  },
  created() {
    let self = this;
    self.getAll();
  },
  methods: {
    getAll() {
      let self = this;
      self.loading = true;
      self.$store.state.services.exampleService
        .getAll()
        .then(r => {
          self.loading = false;
          self.items = r.data;
        })
        .catch(r => {});
    }
  }
};
</script>