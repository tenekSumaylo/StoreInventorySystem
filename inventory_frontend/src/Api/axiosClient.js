import axios from "axios";
import { BsWindowSidebar } from "react-icons/bs";

const axiosClient = axios.create();


axiosClient.defaults.baseURL ="http://localhost:5166/api";
axiosClient.defaults.withCredentials = true;
axiosClient.defaults.headers = {
    "Content-Type" : "application/json",
    Accept : "application/json"
}


export default axiosClient;