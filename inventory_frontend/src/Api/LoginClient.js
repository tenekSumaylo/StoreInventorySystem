import axiosClient from "./axiosClient";


export const LoginClient = async (loginInformation) => {
    try {
        console.log(loginInformation.UserLogin);
        console.log(loginInformation.Password);
        const result = await axiosClient.post("/Auth/Login", loginInformation);
        if ( result.status === 200 ) {
            return result.status;
        }
    }
    catch (err) {
        console.log("otin");
        console.log(err.message);
        debugger;
        return {
            status: err.response.status,
            error: err.respose.data
        };
    }
    debugger;
}