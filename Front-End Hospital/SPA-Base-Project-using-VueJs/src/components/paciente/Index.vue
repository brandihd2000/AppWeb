<template>
    <div>
        <div class="tituloLista">
             <h2>Pacientes</h2>
        </div>
      
        <div class="busquedaInput">
            <el-tooltip class="item" effect="dark" content="Agregar Paciente" placement="right">
                <el-button id="deletePaciente" icon="el-icon-plus" size="large" type="text" v-on:click="$router.push(`/paciente/0`)" > Agregar Paciente </el-button>
            </el-tooltip>
        </div>
    
          <div class="busquedaInput">
            <el-input  placeholder="Buscar Paciente" v-model="busqueda" clearable > 
                <i slot="prefix" class=" el-input__icon el-icon-search"> </i> 
                <i slot="suffix"  class="el-input__icon el-icon-circle-close el-input__clear"
                @click="busqueda = ''"  v-if="busqueda !== ''"></i>
            </el-input>
        </div>
        <div v-loading="loading" >
            <el-table :data="pacienteFilter"  :default-sort = "{prop: 'id', order: 'descending'}" style="width: 100%"  height="500">
                <el-table-column prop="idPaciente" label="Id"   width="70px"  sortable   ></el-table-column>
                <el-table-column prop="nombre" label="Nombre"   width="170px"  ></el-table-column>
                <el-table-column prop="apellido" label="Apellido"   width="170px"  ></el-table-column>
                <el-table-column prop="cedula" label="Cedula" sortable  width="170px"  ></el-table-column>
                <el-table-column prop="telefono" label="Telefono"   width="100px"  ></el-table-column>
                <el-table-column prop="fechaNacimiento" label="Fecha de Nacimiento" type="date"   width="220px"  ></el-table-column>
                <el-table-column prop="grupoSanguineo" label="Grupo Sanguineo"  width="210px" ></el-table-column>

                <el-table-column  label="Operaciones"  fixed="right" width="180px"  >
                    <template  slot-scope="scope"> 
                        <el-tooltip class="item" effect="dark" content="Editar" placement="left">
                            <el-button  size="mini" v-on:click="$router.push(`/paciente/` + scope.row.idPaciente)"> <i class="el-icon-edit">  </i> </el-button>
                        </el-tooltip>
                        <el-tooltip class="item" effect="dark" content="Eliminar" placement="right">
                            <el-button id="deleteUser"  size="mini" type="danger" v-on:click="remove(scope.row.idPaciente)" title=""><i class="el-icon-delete">  </i> </el-button>
                        </el-tooltip>
                        <el-tooltip class="item" effect="dark" content="Observaciones" placement="right">
                            <el-button id="Observaciones" size="mini" type="primary"  @click="$router.push(`/observaciones/0`)"><i class="rotateIcon el-icon-plus"> </i></el-button>
                        </el-tooltip>

        <!-- Boton de observacion

        <el-dialog  title="Observacion" :visible.sync="loginForm" width="25%" center>
        <el-table :data="observacionFilter"  :default-sort = "{prop: 'id', order: 'descending'}" style="width: 100%"  height="500">
                <el-table-column prop="idObservaciones" label="Id"   width="70px"  sortable   ></el-table-column>
                <el-table-column prop="idPaciente" label="Id Paciente"   width="150px"  sortable   ></el-table-column>
                <el-table-column prop="discapacidad" label="Discapacidad"   width="170px"  ></el-table-column>
                <el-table-column prop="alergias" label="Alergias"   width="170px"  ></el-table-column>
                <el-table-column prop="medicamentos" label="Medicamentos" sortable  width="170px"  ></el-table-column>    
        </el-table>
        </el-dialog>-->
                    </template>
                </el-table-column>
            </el-table>
        </div>
    </div>
</template>

    <script>

    export default {
    name: "PacienteIndex",
    data() {
        return {
        loading: false,
        pacientes: [],
        observaciones: [],
        busqueda:""
        };
    },
    computed:{
        pacienteFilter: function() {
            let self = this;
            return self.pacientes.filter(el => {
                return el.idPaciente.toString().toLowerCase().match(self.busqueda.toLowerCase()) ||
                el.nombre.toString().toLowerCase().match(self.busqueda.toLowerCase()) ||
                el.apellido.toString().toLowerCase().match(self.busqueda.toLowerCase()) || 
                el.cedula.toString().toLowerCase().match(self.busqueda.toLowerCase()); 
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
        self.$store.state.services.pacienteService
            .getAll()
            .then(r => {
            self.loading = false;
            self.pacientes = r.data;
            })
            .catch(r => {    
                self.$message({message: "Ocurrio un error inesperado, contactar soporte.", type: "error"});
            });
        },
        
        remove(id) {
        let self = this;
            this.$confirm('Este paciente sera eliminado. Continuar?', 'Advertencia', {
            confirmButtonText: 'Si',
            cancelButtonText: 'Cancelar',
            type: 'warning'
            }).then(() => {
            _remove();
            this.$message({ 
                type: 'success',
                message: 'Paciente Eliminado!'
                });
           
            }).catch(() => {
            this.$message({
                type: 'info',
                message: 'Operacion Cancelada!'
                });          
            });
              function _remove() {
                 self.$store.state.services.pacienteService
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