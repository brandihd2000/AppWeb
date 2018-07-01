import Axios from 'axios'
import exampleService from '../services/ExampleService'
import usuarioService from '../services/UsuarioService'

// Axios Configuration
Axios.defaults.headers.common.Accept = 'application/json'

export default {
    exampleService: new exampleService(Axios),
    usuarioService: new usuarioService(Axios)

}