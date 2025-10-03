import axios from "axios"
import axiosClient from "./axiosClient"

export const GetCategories = async () => {
    return await axiosClient.get("/Category")
    .then( response => {
        console.log(response.data.categories);
        return {
            status: response.status,
            result: response.data.categories
        };
    })
    .catch( error => {
        console.log(error);
        return{ status: error.response.status};
    });
}