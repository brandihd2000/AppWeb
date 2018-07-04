import Vue from 'vue'
import Router from 'vue-router'

import Default from '@/components/Default'
import ExampleIndex from '@/components/example/Index'
import ExampleView from '@/components/example/View'

import UsuarioIndex from '@/components/usuario/Index'
import UsuarioCreateOrEdit from '@/components/usuario/CreateOrEdit'

import PacienteCreateOrEdidt from '@/components/paciente/CreateOrEdit'


Vue.use(Router)

const routes = [
  { path: '/', name: 'Default', component: Default },
  { path: '/example', name: 'ExampleIndex', component: ExampleIndex },
  { path: '/example/:id', name: 'ExampleView', component: ExampleView },

  { path: '/usuario', name: 'UsuarioIndex', component: UsuarioIndex },
  { path: '/usuario/:id', name: 'UsuarioCreateOrEdit', component: UsuarioCreateOrEdit },

  {path:'/paciente',name:'CreateOrEdit',component:PacienteCreateOrEdidt},

]

export default new Router({
  routes
})
