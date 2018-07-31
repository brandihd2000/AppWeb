import Axios from 'axios'
import exampleService from '../services/ExampleService'
import usuarioService from '../services/UsuarioService'
import pacienteService from '../services/PacienteService'
import observacionesService from '../services/ObservacionesService'

// Axios Configuration
Axios.defaults.headers.common.Accept = 'application/json'

export default {
    exampleService : new exampleService(Axios),
    usuarioService : new usuarioService(Axios),
    pacienteService : new pacienteService(Axios),
    observacionesService: new observacionesService(Axios),
}