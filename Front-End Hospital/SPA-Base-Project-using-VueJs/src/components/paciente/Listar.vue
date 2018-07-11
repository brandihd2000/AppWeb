<template>
  <div>
      <div class="busquedaInput">
            <el-input  placeholder="Buscar Paciente" v-model="busqueda" clearble  > 
                <i slot="prefix" class=" el-input__icon el-icon-search"   > </i> 
                <i slot="suffix"  class="el-input__icon el-icon-circle-close el-input__clear"
                @click="busqueda = ''"  v-if="busqueda !== ''"></i>
            </el-input>
        </div>
      <!-- DIV DE LA TABLA ↓↓↓↓↓↓ -->
      <div v-loading="loading" >
          <el-table 
             :data="pacienteFilter"
             :row-class-name="tableRowClassName" >
              <el-table-column prop="nombre" label="Nombre" >

              </el-table-column>
              <el-table-column prop="apellido" label="Apellido">
                  
              </el-table-column>
              <el-table-column  prop="cedula" label="Cedula">
                  
              </el-table-column>
              <el-table-column prop="telefono" label="Telefono">
                  
              </el-table-column>
              <el-table-column label="actividades">
                  <template  slot-scope="scope"> 
                        <el-tooltip class="item" effect="dark" content="Editar" placement="left">
                            <el-button  size="mini" v-on:click="$router.push(`/usuarioCreateOrEdit/` + scope.row.idUsuario)"> <i class="el-icon-edit">  </i> </el-button>
                        </el-tooltip>
                        <el-tooltip class="item" effect="dark" content="Eliminar" placement="right">
                            <el-button id="deleteUser"  size="mini" type="danger" v-on:click="delete1" title=""><i class="el-icon-delete">  </i> </el-button>
                        </el-tooltip>
                    </template> 

              </el-table-column>

          </el-table>
      </div>
      <pre>{{$data}}</pre>
  </div>
  
</template>
<script>

export default {
    name:"Listar",
  created(){
      let self = this;
      self.getAll();

    },
  data(){
      return{
          loading : false,
          pacientes: [],
          busqueda: ""
      };
  },

  computed:{
      pacienteFilter:function(){
          return this.pacientes.filter(el=>{
              return el.nombre.toString().toLowerCase().match(this.busqueda.toLowerCase()) ||
              el.apellido.toString().toLowerCase().match(this.busqueda.toString().toLowerCase());
            
              
          });
        
      }
  },
  methods:{
      
        getAll() {
        let self = this;
        self.loading = true;
        self.$store.state.services.pacienteService
            .getAll()
            .then(r => {
            
            self.pacientes = r.data;
            self.loading=false;
            })
            .catch(r => {});
        },
        tableRowClassName({row, rowIndex}) {
        if (rowIndex === 1) {
          return 'warning-row';
        } else if (rowIndex === 3) {
          return 'success-row';
        }
        return '';
      }
  }
}
</script>
