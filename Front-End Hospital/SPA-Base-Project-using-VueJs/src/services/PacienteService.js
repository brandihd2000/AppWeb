class PacienteService{
    axios
    baseUrl

    constructor(axios) {
        this.axios = axios
        this.baseUrl=("http://localhost:60863/api/paciente/");
    }

    getAll(params){
        let self = this;
        return self.axios.get(`${self.baseUrl}get`);
    }
}
export default PacienteService