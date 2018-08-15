<template>
    <div>
        <div class="tituloLista">
             <h2>Observaciones</h2>
        </div>
      
        <div class="busquedaInput">
            <el-tooltip class="item" effect="dark" content="Agregar Observaciones" placement="right">
                <el-button id="deleteObservacion" icon="el-icon-plus" size="large" type="text" v-on:click="$router.push(`/observaciones/0`)" > Agregar Observaciones </el-button>
            </el-tooltip>
        </div>
    
          <div class="busquedaInput">
            <el-input  placeholder="Buscar Observaciones" v-model="busqueda" clearable > 
                <i slot="prefix" class=" el-input__icon el-icon-search"> </i> 
                <i slot="suffix"  class="el-input__icon el-icon-circle-close el-input__clear"
                @click="busqueda = ''"  v-if="busqueda !== ''"></i>
            </el-input>
        </div>
        <div v-loading="loading" >
            <el-table :data="observacionFilter"  :default-sort = "{prop: 'id', order: 'descending'}" style="width: 100%"  height="500">
                <el-table-column prop="idObservaciones" label="Id"   width="70px"  sortable   ></el-table-column>
                <el-table-column prop="idPaciente" label="Id Paciente"   width="120px"  sortable   ></el-table-column>
                <el-table-column prop="discapacidad" label="Discapacidad"   width="170px"  ></el-table-column>
                <el-table-column prop="enfermedades" label="Enfermedades"   width="300px"  ></el-table-column>
                <el-table-column prop="alergias" label="Alergias"   width="170px"  ></el-table-column>
                <el-table-column prop="medicamentos" label="Medicamentos" sortable  width="170px"  ></el-table-column>

                <el-table-column  label="Operaciones"  fixed="right" width="130px"  >
                    <template  slot-scope="scope"> 
                        <el-tooltip class="item" effect="dark" content="Editar" placement="left">
                            <el-button  size="mini" v-on:click="$router.push(`/observaciones/` + scope.row.idObservaciones)"> <i class="el-icon-edit">  </i> </el-button>
                        </el-tooltip>
                        <el-tooltip class="item" effect="dark" content="Eliminar" placement="right">
                            <el-button id="deleteUser"  size="mini" type="danger" v-on:click="remove(scope.row.idObservaciones)" title=""><i class="el-icon-delete">  </i> </el-button>
                        </el-tooltip>
                    </template>
                </el-table-column>
            </el-table>
        </div>
    </div>
</template>

    <script>

    export default {
    name: "ObservacionesIndex",
    data() {
        return {
        loading: false,
        observaciones: [],
        busqueda:""
        };
    },
    computed:{
        observacionFilter: function() {
            let self = this;
            return self.observaciones.filter(el => {
                return el.idPaciente.toString().toLowerCase().match(self.busqueda.toLowerCase()) ||
                el.discapacidad.toString().toLowerCase().match(self.busqueda.toLowerCase()) ||
                el.alergias.toString().toLowerCase().match(self.busqueda.toLowerCase()) || 
                el.medicamentos.toString().toLowerCase().match(self.busqueda.toLowerCase()); 
                });
         }
    },
    created() {
        let self = this;
        self.getAll();
        self.acceso();
    },
    methods: {
          acceso() {
        let self = this;
        if (!self.$session.exists() || self.$session.get('tipoDeAcceso') != "4") {
            self.$router.push('/')
        }//else if(Date.now() > self.$session.get('finalDeSesion')){
        //     self.$session.clear();
        //     self.$session.destroy();
        //     self.$router.push(`/`);
        //     self.$message({message: "Su sesión ha caducado.",type: "info" });
        // }
         },
        getAll() {
        let self = this;
        self.loading = true;
        self.$store.state.services.observacionesService
            .getAll()
            .then(r => {
            self.loading = false;
            self.observaciones = r.data;
            })
            .catch(r => {    
                self.$message({message: "Ocurrio un error inesperado, contactar soporte.", type: "error"});
            });
        },
        
        remove(id) {
        let self = this;
            this.$confirm('Esta observacion sera eliminada. Continuar?', 'Advertencia', {
            confirmButtonText: 'Si',
            cancelButtonText: 'Cancelar',
            type: 'warning'
            }).then(() => {
            _remove();
            this.$message({ 
                type: 'success',
                message: 'Observacion Eliminada!'
                });
           
            }).catch(() => {
            this.$message({
                type: 'info',
                message: 'Operacion Cancelada!'
                });          
            });
              function _remove() {
                 self.$store.state.services.observacionesService
                .remove(id)
                .then(r => {
                self.loading = false;
                self.getAll();
                })
                .catch(r => {
                    self.$message({
                    message: "Ocurrio un error inesperado, contactar soporte.",
                    type: "error"
                    });
                });
            }
         }
     }
    }
    </script>