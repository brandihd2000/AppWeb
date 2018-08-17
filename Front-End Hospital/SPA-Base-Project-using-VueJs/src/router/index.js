import Vue from 'vue'
import Router from 'vue-router'

import Default from '@/components/Default'
import ExampleIndex from '@/components/example/Index'
import ExampleView from '@/components/example/View'

import UsuarioIndex from '@/components/usuario/Index'
import UsuarioCreateOrEdit from '@/components/usuario/CreateOrEdit'
import PacienteIndex from '@/components/paciente/Index'
import PacienteCreateOrEdit from '@/components/paciente/CreateOrEdit'

import ObservacionesIndex from '@/components/observaciones/Index'
import ObservacionesCreateOrEdit from '@/components/observaciones/CreateOrEdit'

import DiagnosticoIndex from '@/components/diagnostico/Index'
import DiagnosticoCreateOrEdit from '@/components/diagnostico/CreateOrEdit'

Vue.use(Router)

const routes = [
  { path: '/', name: 'Default', component: Default },
  { path: '/example', name: 'ExampleIndex', component: ExampleIndex },
  { path: '/example/:id', name: 'ExampleView', component: ExampleView },

  { path: '/usuario', name: 'UsuarioIndex', component: UsuarioIndex },
  { path: '/usuario/:id', name: 'UsuarioCreateOrEdit', component: UsuarioCreateOrEdit },

  { path: '/paciente', name: 'PacienteIndex', component: PacienteIndex },
  { path: '/paciente/:id', name: 'PacienteCreateOrEdit', component: PacienteCreateOrEdit },

  { path: '/observaciones', name: 'ObservacionesIndex', component: ObservacionesIndex },
  { path: '/observaciones/:id', name: 'ObservacionesCreateOrEdit', component: ObservacionesCreateOrEdit },

  { path: '/diagnostico', name: 'DiagnosticoIndex', component: DiagnosticoIndex },
  { path: '/diagnostico/:id', name: 'DiagnosticoCreateOrEdit', component: DiagnosticoCreateOrEdit }
]

export default new Router({
  routes
})
