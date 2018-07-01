<template>
  <el-container>
      <el-aside id="sideNav" style="width:0px;" >
        <navegationmenu  ></navegationmenu>
      </el-aside>
    <el-container>
    <el-container>
      <el-header>
        <el-row>
          <el-col justify style="padding:7px;" :span="2">
            <div class="botonNav">
              <el-button id="sideBar" v-on:click="visible" type="text"><i class="material-icons">menu</i></el-button>
            </div>
          </el-col>
          <el-col :span="22">
            <div class="grid-content ">
              <h3>DrHelp</h3>  
            </div>
          </el-col>
        </el-row>
      </el-header>
      <el-main>
        <el-row>
          <el-col :span="20" :offset="2">
            <router-view></router-view>
          </el-col>
        </el-row>
      </el-main>
      <el-footer>© <a target="_blank" href="http://anexsoft.com/p/186/proyecto-base-spa-con-vue-vuex-vuerouter-axios-y-element-ui">{{ 'Desarrollo por Satisfaction ' + new Date().getFullYear() }}</a></el-footer>
    </el-container>
   </el-container>
</el-container>
</template>

<script>



import navegationmenu from "@/components/shared/NavegationMenu";

export default {
  
  components: {
    navegationmenu
  },
  props: {
    source: String
  },
  
 mounted(){
        this.invisible(); //method1 will execute at pageload
  },
    methods: {
    visible () {
      const x = document.getElementById("sideNav");
        if (x.style.visibility == 'hidden') {
        x.style.visibility = 'visible';
         x.style.width= '240px';
     } else {
        x.style.visibility = 'hidden';
         x.style.width= '0px';
     }  
       }
  },
  invisible(){
      const x = document.getElementById("sideNav");
        x.style.width= '0px';
      x.style.visibility = 'hidden';
    
  }

};

</script>

