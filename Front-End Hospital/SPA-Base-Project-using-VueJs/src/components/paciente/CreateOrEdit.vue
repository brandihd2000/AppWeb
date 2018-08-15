<template>
 <div  >


 <el-row :gutter="20">
    <el-col :span="14" :offset="5">  
          <h2>{{titutlo}}</h2>
            <el-form  :inline="true" :model="paciente" :rules="rules" label-position="top" ref="paciente"  class="formStylebox"  >
                <el-form-item label="Nombre" class="formStyle" prop="nombre">
                    <el-input v-model="paciente.nombre" placeholder="Nombre" ></el-input>
                </el-form-item>
                <el-form-item label="Apellido" class="formStyle" prop="apellido">
                    <el-input v-model="paciente.apellido" placeholder="Apellido"></el-input>
                </el-form-item>
                <br>
                <el-form-item label="Cedula" class="formStyle" prop="cedula">
                    <el-input v-model="paciente.cedula" placeholder="Cedula"></el-input>
                </el-form-item>
                <el-form-item label="Telefono" class="formStyle" prop="telefono">
                    <el-input v-model="paciente.telefono" placeholder="Telefono"></el-input>
                </el-form-item>
                <br>
                <el-form-item label="Fecha de Nacimiento" class="formStyle" prop="fechaNacimiento">
                     <el-date-picker v-model="paciente.fechaNacimiento" type="date" placeholder="Seleccionar Fecha"></el-date-picker>
                </el-form-item>
                {{paciente.fecha / 1000}}
                    <br>
                <el-form-item label="Grupo Sanguineo" class="formStyle" prop="grupoSanguineo">
                    <el-input v-model="paciente.grupoSanguineo" placeholder="Grupo Sanguineo"></el-input>
                </el-form-item>
                <br>
                <el-form-item >
                    <el-button v-on:click="reiniciar">Reiniciar</el-button>
                    <el-button type="primary" v-on:click="save">Guardar</el-button>
                </el-form-item>
                <el-form-item class="busquedaInput" >
                    <el-button size="medium"  @click="$router.push(`/paciente`)" type="text">Volver a la Lista<i class="rotateIcon el-icon-back"> </i></el-button>
                </el-form-item>
            </el-form>
    </el-col>
</el-row>

  
   
 </div>
</template>

<script>
export default {
    name:"PacienteCreateOrEdit",
    data(){
        return{
            loading: false,
            pacientes:[],
            paciente:{
                idPaciente:0,
                nombre:'',
                apellido:'',
                cedula:'',
                telefono:'',
                fechaNacimiento:'',
                grupoSanguineo:''
            },
            rules:{
                nombre:[
                    {required:true, message:'Por favor introduzca un nombre.', trigger:'blur'}
                ],
                apellido:[
                    {required:true, message:'Por favor introduzca un apellido.', trigger:'blur'}
                ],
                cedula:[
                    {required:true, message:'Por favor introduzca una cedula.', trigger:'blur'}
                ],
                telefono:[
                    {required:true, message:'Por favor introduzca un telefono.', trigger:'blur'}
                ],
                fechaNacimiento:[
                    {required:true, message:'Por favor introduzca un fecha.', trigger:'blur'}
                ],
                 grupoSanguineo:[
                    {required:true, message:'Por favor introduzca un grupo sanguineo.', trigger:'blur'}
                ],
            }
        };
    },
    computed:{
        titutlo: function(){
            return this.$route.params.id == 0 ? "Agregar Paciente" : "Editar Paciente";
        },
         cedulaFilter: function(){
            let self = this;
        return self.pacientes.filter(el => {
            return el.cedula.toString() == self.paciente.cedula;
            });
        }
    },
    created(){
        let self = this;
        self.get(self.$route.params.id);
        self.getAll();
        self.acceso();
    },
    methods:{
        reiniciar(){
            let self = this;
            self.$refs['paciente'].resetFields();
        },
          acceso(){
            let self = this;
            if (!self.$session.exists() || self.$session.get('tipoDeAcceso') < "1") {
                self.$router.push('/')
             }
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
                self.$message({  
                message: "Ocurrio un error inesperado, contactar soporte.",
                type: "error"
                });
            });
        },
        get(id){    
            if(id > 0){
            if(id == undefined) return;
            let self = this;
            self.loading = true;
            self.$store.state.services.pacienteService
            .get(id)
            .then( r => {
                self.loading = false;
                self.paciente.idPaciente = r.data.idPaciente;
                self.paciente.nombre =  r.data.nombre;
                self.paciente.apellido =  r.data.apellido;
                self.paciente.cedula =  r.data.cedula;
                self.paciente.telefono =  r.data.telefono;
                self.paciente.fechaNacimiento =  r.data.fechaNacimiento;
                self.paciente.grupoSanguineo =  r.data.grupoSanguineo;
            })
            .catch(r => {
              self.$message({
                message: "Ocurrio un error inesperado, contactar soporte.",
                type: "error"
                });
            }); 
            }     
        },
        save(){
            let self = this;
                
                this.$refs["paciente"].validate((valid) => {
            if (valid ) {
                    self.loading = true;
                    if(self.$route.params.id > 0)
                    {
                        self.cedula = self.cedulaFilter[0];
                        if(self.cedula.length < 1){
                        self.$store.state.services.pacienteService
                        .update(self.$route.params.id,self.paciente)
                        .then( r => {
                                self.loading = false;
                                self.$router.push('/paciente');
                                  self.$message({  
                                message: "Paciente Editado!",
                                type: "success"
                            });
                        })
                        .catch(r => {
                            self.$message({  
                                message: "Ocurrio un error inesperado, contactar soporte.",
                                type: "error"
                            });
                        });
                        }else if( self.paciente.idPaciente == self.cedula.idPaciente && self.paciente.cedula == self.cedula.cedula ){
                             self.$store.state.services.pacienteService
                            .update(self.$route.params.id,self.paciente)
                            .then( r => {
                                    self.loading = false;
                                    self.$router.push('/paciente');
                                    self.$message({  
                                    message: "Paciente Editado!",
                                    type: "success"
                                });
                            })
                            .catch(r => {
                                self.$message({  
                                    message: "Ocurrio un error inesperado, contactar soporte.",
                                    type: "error"
                                });
                            });
                        }else if(self.cedulaFilter.length > 0){
                            self.$message({
                            type: 'warning',
                            message: 'Las cedulas deben ser unicas, cambielo por favor!'
                        });
                        }
                    }else{
                    if(self.cedulaFilter.length < 1){
                        self.$store.state.services.pacienteService
                        .add(self.paciente)
                        .then( r => {
                                self.loading = false;
                                self.$refs['paciente'].resetFields();
                                self.$message({type: 'success',message: 'Paciente Creado!'});
                                self.$confirm('Desea crear otro paciente?', 'Paciente Creado', {
                                confirmButtonText: 'Si',
                                cancelButtonText: 'No',
                                type: 'info'
                                }).then(() => {
                                    self.$router.push('/paciente/0');
                                }).catch(() => { 
                                    self.$router.push('/paciente');
                                });
                        })
                        .catch(r => {
                            self.$message({  
                                message: "Ocurrio un error inesperado, contactar soporte.",
                                type: "error"
                            });
                        });
                        }else{
                            self.$message({
                            type: 'warning',
                            message: 'Los correos deben ser unicos, cambielo por favor!'
                      });
                     }
                    }
                }else{
                    self.$message({  
                    message: "Ocurrio un error inesperado, contactar soporte.",
                    type: "error"
                });
              }
          });
             
       }
    }
}
</script>