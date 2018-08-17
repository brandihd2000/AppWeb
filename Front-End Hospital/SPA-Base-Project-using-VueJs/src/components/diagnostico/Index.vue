<template>
    <div>
        <div class="tituloLista">
             <h2>Diagnosticos</h2>
        </div>
      
        <div class="busquedaInput">
            <el-tooltip class="item" effect="dark" content="Agregar Diagnostico" placement="right">
                <el-button id="deleteUser" icon="el-icon-plus" size="large" type="text" v-on:click="$router.push(`/diagnostico/0`)" > Agregar Diagnostico </el-button>
            </el-tooltip>
        </div>
          <!-- <div class="busquedaInput">
            <el-input  placeholder="Buscar En Diagnostico" v-model="busqueda" clearable > 
                <i slot="prefix" class=" el-input__icon el-icon-search"> </i> 
                <i slot="suffix"  class="el-input__icon el-icon-circle-close el-input__clear"
                @click="busqueda = ''"  v-if="busqueda !== ''"></i>
            </el-input>
        </div> -->
        <div v-loading="loading" >
            <el-table :data="diagnosticos"  :default-sort = "{prop: 'id', order: 'descending'}" style="width: 100%"  height="500">
                <el-table-column prop="idDiagnostico" label="Diagnostico"     sortable  style="display:hidden" ></el-table-column>
                <el-table-column prop="idPaciente" label="Paciente"     sortable   ></el-table-column>
                <el-table-column prop="idUsuario" label="Usuario"     sortable   ></el-table-column>
                
                <el-table-column prop="sintomas" label="Sintomas"  ></el-table-column>
                <el-table-column prop="enfermedad" label="Enfermedad"   width="100px" ></el-table-column>
                <el-table-column prop="comentario" label="Comentario"   width="100px" align="center" >
                    <template slot-scope="scope">
                        <el-popover trigger="hover" placement="top">
                            <p> {{ scope.row.comentario }}</p>
                                <div slot="reference" class="name-wrapper">
                                    <el-tag size="medium"> <i class="el-icon-view"> </i></el-tag>
                                </div>
                        </el-popover>
                    </template>
                </el-table-column>
                <el-table-column prop="fecha" label="Fecha de diagnostico" width="160px"   ></el-table-column>
                
                <el-table-column  label="Operaciones"  fixed="right" width="130px"  >
                    <template  slot-scope="scope"> 
                        <el-tooltip v-if="$session.get('tipoDeAcceso') >= 3"  class="item" effect="dark" content="Editar" placement="left">
                            <el-button  size="mini" v-on:click="$router.push(`/diagnostico/` + scope.row.idDiagnostico)"> <i class="el-icon-edit">  </i> </el-button>
                        </el-tooltip>
                        <el-tooltip v-if="$session.get('tipoDeAcceso') == 4" class="item" effect="dark" content="Eliminar" placement="right">
                            <el-button id="deleteUser"  size="mini" type="danger" v-on:click="remove(scope.row.idDiagnostico)" title=""><i class="el-icon-delete">  </i> </el-button>
                        </el-tooltip>
                    </template>
                </el-table-column>
            </el-table>
        </div>
    </div>
</template>

    <script>

    export default {
    name: "UsuarioIndex",
    data() {
        return {
        loading: false,
        diagnosticos: [],
        busqueda:""
        };
    },
    computed:{
        diagnosticoFilter: function() {
            let self = this;
            return self.diagnosticos.filter(el => {
                return el.idUsuario.toString().toLowerCase().match(self.busqueda.toLowerCase()) ||
                el.nombre.toString().toLowerCase().match(self.busqueda.toLowerCase()) ||
                el.apellido.toString().toLowerCase().match(self.busqueda.toLowerCase()) || 
                el.especialidad.toString().toLowerCase().match(self.busqueda.toLowerCase() );
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
        if (!self.$session.exists() || self.$session.get('tipoDeAcceso') < "3") {
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
        self.$store.state.services.diagnosticoService
            .getAll()
            .then(r => {
            self.loading = false;
            self.diagnosticos = r.data;
            })
            .catch(r => {    
                self.$message({message: "Ocurrio un error inesperado, contactar soporte.", type: "error"});
            });
        },
        
        remove(id) {
        let self = this;
            this.$confirm('Este usuario sera eliminado. Continuar?', 'Advertencia', {
            confirmButtonText: 'Si',
            cancelButtonText: 'Cancelar',
            type: 'warning'
            }).then(() => {
            _remove();
            this.$message({ 
                type: 'success',
                message: 'Diagnostico Eliminado!'
                });
           
            }).catch(() => {
            this.$message({
                type: 'info',
                message: 'Operacion Cancelada!'
                });          
            });
              function _remove() {
                 self.$store.state.services.diagnosticoService
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