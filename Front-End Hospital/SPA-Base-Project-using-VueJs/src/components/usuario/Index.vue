<template>
    <div>
        <h2>Usuarios</h2>
        <div v-loading="loading">
            <el-table :data="usuarios" :default-sort = "{prop: 'id', order: 'descending'}" style="width: 100%"  height="500">
                <el-table-column prop="idUsuario" label="Id"   width="100px"  sortable  fixed ></el-table-column>
                <el-table-column prop="nombre" label="Nombre"   width="130px"  ></el-table-column>
                <el-table-column prop="apellido" label="Apellido"   width="130px"  ></el-table-column>
                <el-table-column prop="especialidad" label="Especialidad" sortable  width="150px"  ></el-table-column>
                <el-table-column prop="tipo" label="Tipo"   width="130px"  ></el-table-column>
                <el-table-column prop="email" label="Email"   width="180px"  ></el-table-column>
                <el-table-column prop="contraseña" label="Contraseña"   width="130px"  ></el-table-column>
                <el-table-column  label="Operations">
                <template slot-scope="scope">
                   
                    <router-link  class="button" tag="button">Ver</router-link>
                    <el-button  size="mini" type="danger"> <a >Borrar</a></el-button>
                    
                    <a :href="'#/usuario/createOrEdit/' + scope.row.idUsuario" > <el-button  size="mini" >Ver</el-button></a>
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
        usuarios: []
        };
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
        }
    }
    };
    </script>