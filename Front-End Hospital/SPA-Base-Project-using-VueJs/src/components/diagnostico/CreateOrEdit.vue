<template>
 <div  >


            <el-form  :inline="true" :model="diagnostico" :rules="rules" label-position="top" ref="diagnostico"  class="formStylebox"  >
              <h2>{{titutlo}}</h2>
                

                  <el-form-item v-if="this.$route.params.id < 1" class="formStyle" label="Elegir Paciente" >
                    <el-input  placeholder="Filtrar Paciente" v-model="busqueda" clearable > 
                        <i slot="suffix" class=" el-input__icon el-icon-search"   v-if="busqueda == ''" > </i> 
                        <i slot="suffix"  class="el-input__icon el-icon-circle-close el-input__clear"
                        @click="busqueda = ''"  v-if="busqueda !== ''"></i>
                    </el-input>
                    <el-select v-model="diagnostico.idPaciente" placeholder="Elegir Paciente" class="formStyle" >
                        <el-option 
                        v-for="paciente in filteredPacientes" 
                        :key="paciente.idPaciente" 
                        :label="paciente.nombre+' '+paciente.apellido" 
                        :value="paciente.idPaciente" >
                        </el-option>
                    </el-select>
                </el-form-item>
                  
                  <el-form-item label="Paciente" v-if="this.$route.params.id > 0" >
                    <el-input disabled v-for="paciente in filteredPacienteName"  :key="paciente.idPaciente"   :value="paciente.nombre+' '+paciente.apellido"   ></el-input>
                  </el-form-item> 

                <el-form-item label="Sintomas" class="formStyle" prop="sintomas">
                    <el-input v-model="diagnostico.sintomas" placeholder="Sintomas" ></el-input>
                </el-form-item>
                  
                <el-form-item label="Comentario" class="formStyle" prop="comentario">
                    <el-input type="textarea" v-model="diagnostico.comentario" placeholder="Comentario detallado..."></el-input>
                </el-form-item>
                <el-form-item label="Enfermedad" class="formStyle" prop="enfermedad">
                    <el-input v-model="diagnostico.enfermedad" placeholder="Enfermedad"></el-input>
                </el-form-item>
                <br>
                <el-form-item label="Fecha de Diagnostico" class="formStyle" prop="fecha">
        <el-date-picker type="date" placeholder="Pick a date" v-model="diagnostico.fecha" ></el-date-picker>
                 </el-form-item>
             
                
                <el-form-item >
                    <el-button v-on:click="reiniciar">Reiniciar</el-button>
                    <el-button type="primary" v-on:click="save">Guardar</el-button>
                </el-form-item>
                <el-form-item class="busquedaInput" >
                    <el-button size="medium"  @click="$router.push(`/diagnostico`)" type="text">Volver a la Lista<i class="rotateIcon el-icon-back"> </i></el-button>
                </el-form-item>
            </el-form>
  

  
   
 </div>
</template>

<script>
export default {
  name: "ObservacionesCreateOrEdit",
  data() {
    return {
      loading: false,
      busqueda:'',
      idUsuario:this.$session.get("usuarioActualId"),
      pacientes: [],
      diagnosticos: [],
      diagnostico: {
        idDiagnostico: 0,
        idPaciente: '',
        idUsuario: this.$session.get("usuarioActualId"),
        sintomas: "",
        especialidad: "nada",
        enfermedad: "",
        comentario: "",
        fecha:''
      },
      rules: {
        sintomas: [
          {
            required: true,
            message: "Por favor introduzca un sintoma.",
            trigger: "blur"
          }
        ],
        enfermedad: [
          {
            required: true,
            message: "Por favor introduzca una enfermedad(s).",
            trigger: "blur"
          }
        ],
        comentario: [
          {
            required: true,
            message: "Por favor introduzca un comentario.",
            trigger: "blur"
          }
        // ],
        // fecha: [
        //   {
        //     required: true,
        //     message: "Por favor introduzca una fecha.",
        //     trigger: "blur"
        //   }
        ]
      }
    };
  },
  computed: {
    titutlo: function() {
      return this.$route.params.id == 0
        ? "Agregar Diagnostico"
        : "Editar Diagnostico";
    },
    filteredPacientes: function() {
            let self = this;
            return self.pacientes.filter(el => {
                return el.nombre.toString().toLowerCase().match(self.busqueda.toLowerCase()) ||
                el.apellido.toString().toLowerCase().match(self.busqueda.toLowerCase()) ;
                });
         },
      filteredPacienteName: function() {
        let self = this;
        return self.pacientes.filter(el => {
            return el.idPaciente.toString() == self.diagnostico.idPaciente
            });
      }

        
  },
  created() {
    let self = this;
    self.get(self.$route.params.id);
    self.getAll();
    self.acceso();
  },
  methods: {
    reiniciar() {
      let self = this;
      self.$refs["diagnostico"].resetFields();
    },
    acceso() {
      let self = this;
      if (!self.$session.exists() || self.$session.get("tipoDeAcceso") < "2") {
        self.$router.push("/");
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

    
    get(id) {
      if (id > 0) {
        if (id == undefined) return;
        let self = this;
        self.loading = true;
        self.$store.state.services.diagnosticoService
          .get(id)
          .then(r => {
            self.loading = false;
            self.diagnostico.idPaciente = r.data.idPaciente;
            self.diagnostico.idUsuario = r.data.idUsuario;
            self.diagnostico.sintomas = r.data.sintomas;
            self.diagnostico.enfermedad = r.data.enfermedad;
            self.diagnostico.comentario = r.data.comentario;
            self.diagnostico.especialidad = r.data.especialidad;
            
            self.diagnostico.fecha = r.data.fecha;
            
            self.busqueda = r.data.idPaciente;
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
                
                this.$refs["diagnostico"].validate((valid) => {
            if (valid ) {
                    self.loading = true;
                    if(self.$route.params.id > 0)
                    {
                        self.$store.state.services.diagnosticoService
                        .update(self.$route.params.id,self.diagnostico)
                        .then( r => {
                                self.loading = false;
                                self.$router.push('/diagnostico');
                                  self.$message({  
                                message: "Diagnostico Editado!",
                                type: "success"
                            });
                        })
                        .catch(r => {
                            self.$message({  
                                message: "Ocurrio un error inesperado, contactar soporte.",
                                type: "error"
                            });
                        });
                        }else{
                          if( self.$route.params.id < 1 ){
                             self.$store.state.services.diagnosticoService
                            .add(self.diagnostico)
                            .then( r => {
                                    self.loading = false;
                                    self.$refs['diagnostico'].resetFields();
                                self.$message({type: 'success',message: 'Diagnostico Creado!'});
                                })
                            
                            .catch(r => {
                                self.$message({  
                                    message: "Ocurrio un error inesperado, contactar soporte.!",
                                    type: "error"
                                });
                            });
                        }
                        } 
                    
                }
          });
             
       }
    }
}

</script>