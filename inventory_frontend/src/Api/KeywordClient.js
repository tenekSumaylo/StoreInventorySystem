import axiosClient from "./axiosClient";
export const GetAllKeywords = async () => {
    console.log("KEYWORDS");
    return await axiosClient.get("/Tags")
    .then( response => {
        console.log(response.data.keywords);
        return {
            status: response.status,
            result: response.data.keywords
        };
    })
    .catch( error => {
        console.log(error);
        return{ status: error.response.status};
    });
}

