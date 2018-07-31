<template>
 <div  >


 <el-row :gutter="20">
    <el-col :span="14" :offset="5">  
          <h2>{{titutlo}}</h2>
            <el-form  :inline="true" :model="observacion" :rules="rules" label-position="top" ref="observacion"  class="formStylebox"  >
                 <el-form-item prop="idPaciente" label="Paciente"  >
                    <el-input  type="text"  placeholder="Filtrar Paciente a elegir"></el-input>
                        <br>
                    <el-select  v-model="observacion.idPaciente" >
                        <el-option v-bind:key="paciente" v-for="paciente in filteredPacientes" :value="paciente.idPaciente" >{{paciente.nombre}} </el-option>
                    </el-select>
                </el-form-item> 
                <el-form-item label="Discapacidad" class="formStyle" prop="discapacidad">
                    <el-input v-model="observacion.discapacidad" placeholder="Discapacidad" ></el-input>
                </el-form-item>
                <el-form-item label="Enfermedades" class="formStyle" prop="enfermedades">
                    <el-input v-model="observacion.enfermedades" placeholder="Enfermedades"></el-input>
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
      pacientes: [],
      observaciones: [],
      paciente:{
                idPaciente:0,
                nombre:"",
                apellido:"",
                cedula:"",
                telefono:"",
                fechaNacimiento:"",
                grupoSanguineo:""
            },
      observacion: {
        idObservaciones: 0,
        idPaciente: 0,
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
    filteredPacientes: function(){
            let self = this;
        return self.pacientes.filter(el => {
            return el.idPaciente.toString() == self.paciente.idPaciente;
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
                self.$refs["observacion"].validate((valid) => {
            if (valid) {
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
                     
                    }else if(self.$route.params.id < 1){
                        self.$store.state.services.observacionesService
                        .add(self.observacion)
                        .then( r => {
                                self.loading = false;
                                self.$refs['observaciones'].resetFields();
                                self.$message({type: 'success',message: 'Observacion Creada!'});
                                
                        })
                        .catch(r => {
                            self.$message({  
                                message: "Ocurrio un error inesperado, contactar soporte.",
                                type: "error"
                            });
                     
                        });
      
                      }
  }
     });
}
    
}
}

</script>