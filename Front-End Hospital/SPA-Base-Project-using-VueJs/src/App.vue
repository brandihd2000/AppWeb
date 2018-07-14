<template>
  <el-container>
      <el-aside id="sideNav" style="width:0px;" >
        <navegationmenu :key="$route.fullPath" ></navegationmenu>
      </el-aside>
    <el-container>
    <el-container>
      <el-header> 
        <div  class="botonNav">
          <el-button id="sideBar" v-if="this.$session.exists()" v-on:click="visible" icon="el-icon-menu" type="text"></el-button>
        </div>
        <div class="botonNav">
          <h3><a v-on:click="$router.push(`/`)"> DrHelp</a></h3>  
        </div>
        <div  class=" botonNav floatRight">
          <el-button  v-on:click="loginForm = true" v-if="!this.$session.exists()"  type="text">Iniciar Sesión</el-button>
          <el-button  v-on:click="logOut" v-if="this.$session.exists()" type="text">Cerrar Sesión</el-button> 
        </div>
        <el-dialog  title="Iniciar Sesión" :visible.sync="loginForm" width="25%" center>
            <el-form :model="parametros" :rules="rules" ref="parametros"  size="mini" >
              <el-form-item label="Correo:" prop="email" >
                <el-input v-model="parametros.email" auto-complete="off"></el-input>
              </el-form-item>
              <el-form-item label="Contraseña:" prop="contraseña" >
                <el-input v-model="parametros.contraseña" auto-complete="off" type="password" ></el-input>
              </el-form-item>
            </el-form>
            <span slot="footer" class="dialog-footer">
              <el-button v-on:click="cancelar">Cancelar</el-button>
              <el-button type="primary" v-on:click="logIn">Enviar</el-button>
            </span>
          </el-dialog>
      </el-header>
      <el-main>
        <el-row>
          <el-col :span="20" :offset="2">
            <router-view ></router-view>
          </el-col>
        </el-row>
      </el-main>
      <el-footer></el-footer>
    </el-container>
   </el-container>
</el-container>
</template>
<script>

import navegationmenu from "@/components/shared/NavegationMenu";

export default {
  data(){
    return{
         loginForm: false,
         parametros:{
           email:'',
           contraseña:''
         },
         usuarios:[],
         info:{},
         rules:{
                email:[
                    {required:true, message:'Por favor introduzca un correo.', trigger:'blur'},
                    {type:'email',message:'Por favor introducir correo correctamente.',trigger: 'blur,change'}
                ],
                 contraseña:[
                    {required:true, message:'Por favor introduzca una contraseña.', trigger:'blur'},
                ],
            }
    }
  },
  components: {
    navegationmenu,
  },
    props: {
    source: String
  },
  computed:{
    emailFilter: function() {
      let self = this;
       return self.usuarios.filter(el => {
        return el.email.toString().toLowerCase() == self.parametros.email.toLowerCase();
      });
    },
    
  },
  created() {
        let self = this;
        self.getAll();
    },
 mounted(){
      let self = this;
      
  },
    methods: {
     
      cancelar(){
        let self = this;
        self.loginForm = false;
        self.parametros.email='';
        self.parametros.contraseña='';
      },
      logOut(){
        let self = this;
        self.$session.clear();
        self.$session.destroy();
        self.$router.push(`logOut`);
      },
      logIn(){
        let self = this;
        self.loading = true;
        self.$refs["parametros"].validate((valid) => {
           if (valid){ 
              if(self.emailFilter.length < 1){
                self.$message({message: "Correo no econtrado en el sistema.",type: "warning" });
              }else{
                self.info = self.emailFilter[0];
                if(self.parametros.contraseña == self.info.contraseña){
                  self.parametros.email='';
                  self.parametros.contraseña='';
                  self.$session.start();
                  self.$session.set('finalDeSesion',Date.now() + 1800000);
                  self.$session.set('tipoDeAcceso',self.info.tipo );
                  self.$session.set('usuarioActual',self.info.nombre +" "+self.info.apellido);
                  self.loginForm = false;
                  self.$message({message: "Bienvenido " + self.$session.get('usuarioActual') + "!",type: "success" });
                  self.$router.push(`/logIn`);
                  }else if(self.parametros.contraseña != self.info.contraseña ){
                    self.$message({message: "Contraseña incorrecta.",type: "warning" });
                  }
                }
            }
        });
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
            .catch(r => {self.$message({message: "Ocurrio un error inesperado, contactar soporte.",type: "error" });
            });
        },
      visible() {
          const x = document.getElementById("sideNav");
          if (x.style.visibility == 'hidden') {
              x.style.visibility = 'visible';
              x.style.width= '240px';
          } else {
              x.style.visibility = 'hidden';
              x.style.width= '0px';
          }  
        },
   }
};
</script>

