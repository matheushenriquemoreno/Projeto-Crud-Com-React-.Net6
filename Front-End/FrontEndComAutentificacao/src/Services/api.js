import axios from "axios";
import { useNavigate } from "react-router-dom";

const instaciarAxios = () => {
  const navegacao = useNavigate();

  const api = axios.create({
    baseURL: "https://localhost:7103/",
  });

  api.interceptors.request.use((config) => {
    const token = localStorage.getItem("token");

    config.headers.Authorization = `Bearer ${token}`;

    return config;
  });

  api.interceptors.response.use(
    (response) => response,
    (err) => {
      console.log(err);
      if (err.response.status === 401) {
        sessionStorage.clear();
        localStorage.setItem("token", "");
        navegacao({ pathname: "/", search: "?expirou=true" });
      }
      return Promise.reject(err);
    }
  );

  return api;
};

export default instaciarAxios;
