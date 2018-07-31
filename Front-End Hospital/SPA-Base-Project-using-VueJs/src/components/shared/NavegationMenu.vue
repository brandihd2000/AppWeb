<template >
<el-menu  default-active="0">

    <template v-for="(item, i) in items" v-if="item.name <= getsession"  >
        <el-submenu :index="i.toString()"  :key='i' v-if="item.children !== undefined">
            <template slot="title">
                <i :class="'fa fa-' + item.icon"></i>
                <span>{{ item.text }}</span>
            </template>
            <el-menu-item-group title="Opciones">
                <el-menu-item v-for="(child, c) in item.children" :key='c' :index="(i.toString() + c)" @click="redirect(child.path)">
                    <i :class="'fa fa-' + child.icon"></i> <span>{{ child.text }}</span>
                </el-menu-item>
            </el-menu-item-group>    
        </el-submenu>
        <el-menu-item index="2" :key='i' v-if="item.children === undefined" @click="redirect(item.path)">
            <i :class="'fa fa-' + item.icon"></i>
            <span>{{ item.text }}</span>
        </el-menu-item>
    </template>


</el-menu>
</template>

<script>
export default {
  name: "NavegationMenu",
  data: () => ({
    items: [
      { icon: "dashboard", name:"1", text: "Dashboard", path: "/" },
      { icon: "plus", name:"1" ,text: "Paciente",children: 
        [
          { icon: "plus", text: "Agregar", path: "/paciente/0" },
          { icon: "list", text: "Listar", path: "/paciente" }
        ]
      },
      { icon: "user", name:"4" ,text:"Usuario",children: 
        [
          { icon: "plus", text: "Agregar", path: "/usuario/0" },
          { icon: "list", text: "Listar", path: "/usuario" }
        ]
      },
      { icon: "info", name:"1" ,text: "Observaciones",children: 
        [
          { icon: "plus", text: "Agregar", path: "/observaciones/0" },
          { icon: "list", text: "Listar", path: "/observaciones" }
        ]
      },
      { icon: "wrench", name:"1", text: "Configuración"} 
    ]
  }),
  methods: {
    redirect(path) {
      if(path === undefined) return;
      this.$router.push(path);
    }
  },
  computed:{
     getsession: function(){
       let self = this;
       return self.$session.get('tipoDeAcceso');
     }
  }
};

</script>