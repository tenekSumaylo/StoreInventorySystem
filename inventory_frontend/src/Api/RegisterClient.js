import axiosClient from "./axiosClient";

export const RegisterClient = async (registerInformation) => {
    try {
        const result = await axiosClient.post("/Auth/Register", registerInformation);
        if ( result.status === 200 && result.succeeded) {
            return { status: result.status };
        }
        throw result;
    }
    catch ( err ) {
        console.log(err);
        return {
            status: err.response.status,
            error: err.response.data
        };
    }
}