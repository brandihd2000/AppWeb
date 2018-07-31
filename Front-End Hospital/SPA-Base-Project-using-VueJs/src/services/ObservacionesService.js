class ObservacionesService {
    axios
    baseUrl

    constructor(axios) {
        this.axios = axios
        this.baseUrl = ("http://localhost:60863/api/observaciones/");
    }

    getAll(params) {
        let self = this;
        return self.axios.get(`${self.baseUrl}get`)
    }

    get(id) {
        let self = this;
        return self.axios.get(`${self.baseUrl}get/${id}`)
    }

    add(model) {
        let self = this;
        return self.axios.post(`${self.baseUrl}add/`, model)
    }

    update(id, model) {
        let self = this;
        return self.axios.put(`${self.baseUrl}update/${id}`, model)
    }

    remove(id) {
        let self = this;
        return self.axios.delete(`${self.baseUrl}delete/${id}`);
    }
}
export default ObservacionesService