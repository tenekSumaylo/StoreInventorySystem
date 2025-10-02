import axiosClient from "./axiosClient";


export const LoginClient = async (loginInformation) => {
    try {
        console.log(loginInformation.UserLogin);
        console.log(loginInformation.Password);
        const result = await axiosClient.post("/Auth/Login", loginInformation);
        if ( result.status === 200 ) {
            return { status: result.status };
        }
    }
    catch (err) {
        console.log(err.message);
        debugger;
        return {
            status: err.response.status,
            error: err.response.data
        };
    }
    debugger;
}

export const LoginCheck = async() => {
    try {
        const result = await axiosClient.get("/Auth/Check")
        if ( result.status === 200 ) {
            console.log("CHERKS");
            console.log(`${result.status}--${result.data.isCustomer}--${result.data.isEmployee}`);
            return {
                status: result.status,
                isCustomer: result.data.isCustomer,
                isEmployee: result.data.isEmployee
            };
        }
    }
    catch (error) {
        console.log("HELP");
        return { status: error.response.status };
    }

}