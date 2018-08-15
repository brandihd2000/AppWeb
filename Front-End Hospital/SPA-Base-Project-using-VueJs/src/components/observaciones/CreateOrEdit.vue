<template>
 <div  >


 <el-row :gutter="20">
    <el-col :span="14" :offset="5">  
          <h2>{{titutlo}}</h2>
            <el-form  :inline="true" :model="observacion" :rules="rules" label-position="top" ref="observacion"  class="formStylebox"  >
                

                  <el-form-item v-if="this.$route.params.id < 1" class="formStyle" label="Elegir Paciente" >
                    <el-input  placeholder="Filtrar Paciente" v-model="busqueda" clearable > 
                        <i slot="suffix" class=" el-input__icon el-icon-search"   v-if="busqueda == ''" > </i> 
                        <i slot="suffix"  class="el-input__icon el-icon-circle-close el-input__clear"
                        @click="busqueda = ''"  v-if="busqueda !== ''"></i>
                    </el-input>
                    <el-select v-model="observacion.idPaciente" placeholder="Elegir Paciente" class="formStyle" >
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


                <el-form-item label="Discapacidad" class="formStyle" prop="discapacidad">
                    <el-input v-model="observacion.discapacidad" placeholder="Discapacidad" ></el-input>
                </el-form-item>
                <el-form-item label="Enfermedades" class="formStyle" prop="enfermedades">
                    <el-input type="textarea" v-model="observacion.enfermedades" placeholder="Enferemedades que tienes..."></el-input>
                </el-form-item>
                <br>
                <el-form-item label="Alergias" class="formStyle" prop="alergias">
                    <el-input v-model="observacion.alergias" placeholder="Alergias"></el-input>
                </el-form-item>
                <el-form-item label="Medicamentos" class="formStyle" prop="medicamentos">
                    <el-input v-model="observacion.medicamentos" placeholder="Medicamentos"></el-input>
                </el-form-item>
                <br>
                
                <el-form-item >
                    <el-button v-on:click="reiniciar">Reiniciar</el-button>
                    <el-button type="primary" v-on:click="save">Guardar</el-button>
                </el-form-item>
                <el-form-item class="busquedaInput" >
                    <el-button size="medium"  @click="$router.push(`/observaciones`)" type="text">Volver a la Lista<i class="rotateIcon el-icon-back"> </i></el-button>
                </el-form-item>
            </el-form>
    </el-col>
</el-row>

  
   
 </div>
</template>

<script>
export default {
  name: "ObservacionesCreateOrEdit",
  data() {
    return {
      loading: false,
      busqueda:'',
      pacientes: [],
      observaciones: [],
      observacion: {
        idObservaciones: 0,
        idPaciente: '',
        discapacidad: "",
        enfermedades: "",
        alergias: "",
        medicamentos: ""
      },
      rules: {
        discapacidad: [
          {
            required: true,
            message: "Por favor introduzca una capacidad.",
            trigger: "blur"
          }
        ],
        enfermedades: [
          {
            required: true,
            message: "Por favor introduzca una enfermedade(s).",
            trigger: "blur"
          }
        ],
        alergias: [
          {
            required: true,
            message: "Por favor introduzca una alergia(s)",
            trigger: "blur"
          }
        ],
        medicamentos: [
          {
            required: true,
            message: "Por favor introduzca un medicamento(s).",
            trigger: "blur"
          }
        ]
      }
    };
  },
  computed: {
    titutlo: function() {
      return this.$route.params.id == 0
        ? "Agregar Observacion"
        : "Editar Observacion";
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
            return el.idPaciente.toString() == self.observacion.idPaciente
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
      self.$refs["observaciones"].resetFields();
    },
    acceso() {
      let self = this;
      if (!self.$session.exists() || self.$session.get("tipoDeAcceso") < "1") {
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
        self.$store.state.services.observacionesService
          .get(id)
          .then(r => {
            self.loading = false;
            self.observacion.idPaciente = r.data.idPaciente;
            self.observacion.discapacidad = r.data.discapacidad;
            self.observacion.enfermedades = r.data.enfermedades;
            self.observacion.alergias = r.data.alergias;
            self.observacion.medicamentos = r.data.medicamentos;
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
                
                this.$refs["observacion"].validate((valid) => {
            if (valid ) {
                    self.loading = true;
                    if(self.$route.params.id > 0)
                    {
                        self.$store.state.services.observacionesService
                        .update(self.$route.params.id,self.observacion)
                        .then( r => {
                                self.loading = false;
                                self.$router.push('/observaciones');
                                  self.$message({  
                                message: "Observacion Editada!",
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
                             self.$store.state.services.observacionesService
                            .add(self.observacion)
                            .then( r => {
                                    self.loading = false;
                                    self.$refs['observacion'].resetFields();
                                self.$message({type: 'success',message: 'Observacion Creada!'});
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