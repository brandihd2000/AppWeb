<template>
 <div  >


 <el-row :gutter="20">
    <el-col :span="14" :offset="5">  
          <h2>{{titutlo}}</h2>
            <el-form  inline="true" :model="usuario" :rules="rules" label-position="top" ref="usuario"  class="formStylebox"  >
                <el-form-item label="Nombre" class="formStyle" prop="nombre">
                    <el-input v-model="usuario.nombre" placeholder="Nombre" ></el-input>
                </el-form-item>
                <el-form-item label="Apellido" class="formStyle" prop="apellido">
                    <el-input v-model="usuario.apellido" placeholder="Apellido"></el-input>
                </el-form-item>
                <br>
                <el-form-item label="Especialidad" class="formStyle" prop="especialidad">
                    <el-input v-model="usuario.especialidad" placeholder="Especialidad"></el-input>
                </el-form-item>
                <el-form-item label="Tipo" class="formStyle" prop="tipo">
                    <el-select v-model="usuario.tipo" class="formStyle" placeholder="Por favor Seleccione">
                        <el-option label="Admin" value="admin"></el-option>
                        <el-option label="Doctor/a" value="doctor"></el-option>
                        <el-option label="Enfermero/a" value="enfermero"></el-option>
                        <el-option label="Secretario/a" value="secretario"></el-option>
                    </el-select>
                </el-form-item>
                <br>
                <el-form-item label="Email" class="formStyle" prop="email">
                    <el-input v-model="usuario.email" type="email" placeholder="Email"></el-input>
                </el-form-item>
                    <br>
                <el-form-item label="Contraseña" class="formStyle" prop="contraseña">
                    <el-input type="password" v-model="usuario.contraseña" placeholder="Contraseña"></el-input>
                </el-form-item>
                <el-form-item label="Confirmar Contraseña" class="formStyle" prop="contraseñaConfirm">
                    <el-input type="password" v-model="contraseñaConfirm" v-on:load="confirmar"  placeholder="Confirmar"></el-input>
                </el-form-item>
                <br>
                <el-form-item >
                    <el-button type="primary" v-on:click="save">Guardar</el-button>
                </el-form-item>
            </el-form>
    </el-col>
</el-row>

  
   
 </div>
</template>

<script>
export default {
    name:"UsuarioCreateOrEdit",
    data(){
        return{
            loading: false,
            usuarios:[],
            contraseñaConfirm:"",
            usuario:{
                idUsuario:0,
                nombre:'',
                apellido:'',
                especialidad:'',
                tipo:'',
                email:'',
                contraseña:''
            },
            rules:{
                nombre:[
                    {required:true, message:'Por favor introduzaca un nombre.', trigger:'blur'}
                ],
                apellido:[
                    {required:true, message:'Por favor introduzaca un apellido.', trigger:'blur'}
                ],
                especialidad:[
                    {required:true, message:'Por favor introduzaca una especialidad.', trigger:'blur'}
                ],
                tipo:[
                    {required:true, message:'Por favor eliga un tipo.', trigger:'blur'}
                ],
                email:[
                    {required:true, message:'Por favor eliga un tipo.', trigger:'blur'},
                    {type:'email',message:'Por favor introducit email correctamente.',trigger: 'blur,change'}
                ],
                 contraseña:[
                    {required:true, message:'Por favor introduzca una contraseña.', trigger:'blur'}
                ],
            }
        };
    },
    computed:{
        titutlo: function(){
            return this.$route.params.id == 0 ? "Agregar Usuario" : "Editar Usuario";
        }
    },
    created(){
        let self = this;
        self.get(self.$route.params.id);
    },
    methods:{
       
        get(id){    
            if(id > 0){
            if(id == undefined) return;
            let self = this;
            self.loading = true;
            self.$store.state.services.usuarioService
            .get(id)
            .then( r => {
                self.loading = false;
                self.usuario.idUsuario = r.data.idUsuario;
                self.usuario.nombre =  r.data.nombre;
                self.usuario.apellido =  r.data.apellido;
                self.usuario.especialidad =  r.data.especialidad;
                self.usuario.tipo =  r.data.tipo;
                self.usuario.email =  r.data.email;
                self.usuario.contraseña =  r.data.contraseña;
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
                this.$refs["usuario"].validate((valid) => {
            if (valid) {
              
                self.loading = true;
                if(self.$route.params.id > 0){
                    self.$store.state.services.usuarioService
                    .update(self.$route.params.id,self.usuario)
                    .then( r => {
                            self.loading = false;
                            self.$router.push('/usuario');
                    })
                    .catch(r => {
                        self.$message({  
                            message: "Ocurrio un error inesperado, contactar soporte.",
                            type: "error"
                        });
                    });
                }else{
                    self.$store.state.services.usuarioService
                    .add(self.usuario)
                    .then( r => {
                            self.loading = false;
                            self.$router.push('/usuario');
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
