class UsuarioService {
    axios
    baseUrl

    constructor(axios) {
        this.axios = axios
        this.baseUrl=("http://localhost:60863/api/usuario/");
    }

    getAll(params) {
        let self = this;
        return self.axios.get(`${self.baseUrl}get`)
    }

    get(id) {
        let self = this;
        return self.axios.get(`${self.baseUrl}get/${id}`)
    }
}
export default UsuarioService