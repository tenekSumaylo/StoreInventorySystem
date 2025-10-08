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

export const LogoutApi = async () => {
    try {
        const result = await axiosClient.post("/Auth/Logout");
        return {status: result.status};
    }
    catch (error) {
        if ( error.response ) {
            return {status: error.response.status};
        }
        else if (error.request) {
            return {status: 0};
        }
        else {
            return {status: -1};
        }
    }
}


export const GoogleLogin = async () => {
    try {
        const result = await axiosClient.get("/Auth/Google");
        if ( result.status === 200 ) {
            return { status: result.status} ;
        }
    }
    catch (error) {
        console.log(error);
        return { status: result.status };
    }
}