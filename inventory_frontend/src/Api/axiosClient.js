import axios from "axios";

const axiosClient = axios.create();

axiosClient.defaults.baseURL = "http//localhost:5166/api"

axiosClient.defaults.headers = {
    "Content-Type" : "application/json",
    Accept : "application/json"
}

axiosClient.defaults.timeout = 3000;

export default axiosClient;