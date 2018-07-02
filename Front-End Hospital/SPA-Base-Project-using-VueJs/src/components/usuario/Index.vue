<template>
    <div>
        <div class="tituloLista">
             <h2>Usuarios</h2>
        </div>
        <div class="busquedaInput">
            <el-input  placeholder="Buscar Usuario" v-model="busqueda" clearable > 
                <i slot="prefix" class=" el-input__icon el-icon-search"> </i> 
                <i slot="suffix"  class="el-input__icon el-icon-circle-close el-input__clear"
                @click="busqueda = ''"  v-if="busqueda !== ''"></i>
            </el-input>
        </div>
        <div v-loading="loading" >
            <el-table :data="usuarioFilter"  :default-sort = "{prop: 'id', order: 'descending'}" style="width: 100%"  height="500">
                <el-table-column prop="idUsuario" label="Id"   width="70px"  sortable   ></el-table-column>
                <el-table-column prop="nombre" label="Nombre"   width="170px"  ></el-table-column>
                <el-table-column prop="apellido" label="Apellido"   width="170px"  ></el-table-column>
                <el-table-column prop="especialidad" label="Especialidad" sortable  width="170px"  ></el-table-column>
                <el-table-column prop="tipo" label="Tipo"   width="100px"  ></el-table-column>
                <el-table-column prop="email" label="Email"   width="220px"  ></el-table-column>
                <el-table-column prop="contraseña" label="Contraseña" tyep="password"  width="100px" align="center" >
                    <template slot-scope="scope">
                        <el-popover trigger="hover" placement="top">
                            <p> {{ scope.row.contraseña }}</p>
                                <div slot="reference" class="name-wrapper">
                                    <el-tag size="medium"> <i class="el-icon-view"> </i></el-tag>
                                </div>
                        </el-popover>
                    </template>
                </el-table-column>
                <el-table-column  label="Operaciones"  fixed="right" width="130px"  >
                    <template  slot-scope="scope"> 
                        <el-tooltip class="item" effect="dark" content="Editar" placement="left">
                            <el-button  size="mini" v-on:click="$router.push(`/usuarioCreateOrEdit/` + scope.row.idUsuario)"> <i class="el-icon-edit">  </i> </el-button>
                        </el-tooltip>
                        <el-tooltip class="item" effect="dark" content="Eliminar" placement="right">
                            <el-button id="deleteUser"  size="mini" type="danger" v-on:click="delete1" title=""><i class="el-icon-delete">  </i> </el-button>
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
        usuarios: [],
        busqueda:""
        };
    },
    computed:{
        usuarioFilter: function() {
            return this.usuarios.filter(el => {
                return el.idUsuario.toString().toLowerCase().match(this.busqueda.toLowerCase()) ||
                el.nombre.toString().toLowerCase().match(this.busqueda.toLowerCase()) ||
                el.apellido.toString().toLowerCase().match(this.busqueda.toLowerCase()) || 
                el.especialidad.toString().toLowerCase().match(this.busqueda.toLowerCase()) || 
                el.tipo.toString().toLowerCase().match(this.busqueda.toLowerCase()) || 
                el.email.toString().toLowerCase().match(this.busqueda.toLowerCase());
                });
         }
    },
    created() {
        let self = this;
        self.getAll();
    },
    methods: {
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
        },
        delete1() {
          let confirmacion = confirm("Seguro que desea Eliminar este usuario?");
          if(confirmacion == true){
                alert("Se fue.");
          }else{
              alert("Se quedo.");
          }
        }
     }
    };
    </script>