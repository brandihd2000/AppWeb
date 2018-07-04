<template>
  
  <div >
    <el-col :span="24" >
      <h1>Campos</h1>
    <el-row style="border: solid gray1px;"  >
      <!-- Desde aca el form -->
      <el-col >
      <el-form label-width="100px" >
      <el-col  :span="15">
    <div >
        <el-row :glutter="50">
                 <el-col :span="10">
                   <el-form-item label="Nombre">
                    <el-input id="Nombre" placeholder="Nombre: "></el-input>
                   </el-form-item>
                    
                 </el-col>
                 <el-col :span="10">
                   <el-form-item label="Apellido">
                    <el-input placeholder="Apellido: "></el-input>
                   </el-form-item>
                 </el-col>
        </el-row>
        <el-row>
          <el-col :span="10">
            <el-form-item label="Cedula">
             <el-input placeholder="Cedula: "></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="10">
            <el-form-item label="Telefono">
              <el-input placeholder="Telefono"></el-input>
            </el-form-item>
          </el-col>

        </el-row>
        <el-row>
          <el-col label-width="250px" :span="10">
            <el-form-item label="Tipo-sangre">
             <el-select placeholder="Grupo Sanguineo">
               <el-option label="A+" value="A+"></el-option>
               <el-option label="A-" value="A-"></el-option>
               <el-option label="AB+" value="AB+"></el-option>
               <el-option label="AB-" value="AB-"></el-option>
               <el-option label="B+" value="B+"></el-option>
               <el-option label="B-" value="B-"></el-option>
               <el-option label="O+" value="A\O+"></el-option>
               <el-option label="O-" value="O-"></el-option>


             </el-select>
            </el-form-item>
          </el-col>
          <el-col :span="10">
            <el-form-item label="Nacimiento">
              <el-date-picker type="date" placeholder="Fecha de Nacimiento" style="width: 100%;"></el-date-picker>
            </el-form-item>
          </el-col>

        </el-row>
        <el-row>
          <el-col :span="10">
            <el-form-item label="Sexo">
              <el-select>
                <el-option label="M" value="M"></el-option>
                <el-option label="F" value="F "></el-option>
              </el-select>
            </el-form-item>
          </el-col>
        </el-row>
        
    </div>
      </el-col>

                                                        <!-- Columna de las OBSERVACIONES -->
      <el-col :span="9"> 
        <el-row>
          <el-col :span="18">
            <el-form-item label="Alergia a :">
              <el-input placeholder=" Medicamento"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="18">
            <el-form-item label="Discapacidad:">
              <el-input placeholder=" Discapacidad"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="18">
            <el-form-item label="Enfermedad :">
              <el-input placeholder=" Enfermedad"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
      </el-col>
      <el-button type="primary" @click="onSubmit">Crear</el-button>
      </el-form>
      </el-col>
      <!-- Jasta aqui el from -->
    </el-row>
    </el-col>
  </div>

</template>
<script>
export default {
  name:"CreateOrEdit",
  data(){
      return{

      };
  },
    methods: {
      onSubmit() {
        console.log('submit!');
      }
    }
}
</script>
