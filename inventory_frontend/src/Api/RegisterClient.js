import axiosClient from "./axiosClient";

export default RegisterClient = async (registerInformation) => {
    try {
        const result = await axiosClient.post("/Auth/Register", registerInformation);
        if ( result.status === 200 && result.succeeded) {
            return result.status;
        }
        throw result;
    }
    catch ( err ) {
        return {
            status: err.response.status,
            error: err.response.data
        }
    }
}