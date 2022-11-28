import axios from 'axios';

const apiLogin = axios.create({
    baseURL: "https://localhost:44341/",
})

export default apiLogin;