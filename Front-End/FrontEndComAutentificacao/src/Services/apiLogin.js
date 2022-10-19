import axios from 'axios';

const apiLogin = axios.create({
    baseURL: "https://localhost:7126/",
})

export default apiLogin;