<template>
 <div>
 
        <h2>{{titutlo}}</h2>
 

    <div class="formStylebox" >
        <el-form  inline="true"  :model="usuario" label-position="top" class="demo-form"  >
            <el-form-item label="Nombre" class="formStyle" >
                <el-input v-model="usuario.nombre" placeholder="Nombre" required ></el-input>
            </el-form-item>
            <el-form-item label="Apellido" class="formStyle">
                <el-input v-model="usuario.apellido" placeholder="Apellido"></el-input>
            </el-form-item>
            <br>
            <el-form-item label="Especialidad" class="formStyle">
                <el-input v-model="usuario.especialidad" placeholder="Especialidad"></el-input>
            </el-form-item>
            <el-form-item label="Tipo" class="formStyle">
                <el-select v-model="usuario.tipo" class="formStyle" placeholder="Por favor Seleccione">
                    <el-option label="Admin" value="admin"></el-option>
                    <el-option label="Doctor/a" value="doctor"></el-option>
                    <el-option label="Enfermero/a" value="enfermero"></el-option>
                    <el-option label="Secretario/a" value="secretario"></el-option>
                </el-select>
            </el-form-item>
            <br>
            <el-form-item label="Email" class="formStyle">
                <el-input v-model="usuario.email" type="email" placeholder="Email"></el-input>
            </el-form-item>
                 <br>
            <el-form-item label="Contraseña" class="formStyle" >
                <el-input type="password" v-model="usuario.contraseña" placeholder="Contraseña"></el-input>
            </el-form-item>
            <el-form-item label="Confirmar Contraseña" class="formStyle">
                <el-input type="password" v-model="contraseñaConfirm" placeholder="Confirmar"></el-input>
            </el-form-item>
            <br>

            <el-form-item >
                <el-button  v-if="usuario.contraseña == contraseñaConfirm" type="primary" @click="onSubmit">Guardar</el-button>
                <el-button  v-else-if="usuario.contraseña != contraseñaConfirm" type="primary" disabled="true" @click="onSubmit">Guardar</el-button>
            </el-form-item>
        </el-form>
    </div>
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

        };
    },
    computed:{
        titutlo: function(){
            return this.$route.params.id == 0 ? "Agregar Usuario" : "Editar Usuario";
        },
        
        
          
    },
    created(){
        let self = this;
        //self.getId();
        self.getAll();

    },
    methods:{
        usuarioFilter() {
                 let self = this;
                 let id = self.$route.params.id;
                 return this.usuarios.filter(el => {
                    return el.idUsuario.toString().match(id);
                });
         },
          onSubmit() {
        console.log('submit!');
      },
        getId(){
            let self = this;
            let info = usuarioFilter();
            alert(info);
            let idEditable = self.$route.params.id;
            if(idEditable != 0){
                       self.loading = false;
                       self.usuario.idUsuario = self.info.idUsuario;
                       self.usuario.nombre = self.info.nombre;
                       self.usuario.apellido = self.info.apellido;
                       self.usuario.especialidad = self.info.especialidad;
                       self.usuario.tipo = self.info.tipo;
                       self.usuario.email = self.info.email;
                       self.usuario.contraseña = self.info.contraseña;
            
            }
        },
         getAll() {
        let self = this;
        self.loading = true;

        self.$store.state.services.usuarioService
            .getAll()
            .then(r => {
            self.loading = false;
            self.usuarios = r.data;
            })
            .catch(r => {});
        }

    }
}
</script>
