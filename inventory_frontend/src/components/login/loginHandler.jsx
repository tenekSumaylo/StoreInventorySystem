import { LoginClient, LoginCheck } from "./../../Api/LoginClient";
import { useNavigate } from "react-router";

export const LoginHandler = async (props) => {
    try {
        const result = await LoginClient({
            UserLogin: props.username,
            Password: props.password
        });
        if ( result.status === 200 ) {
            return { status: result.status };
        }
        else {
            return { status: result.status, errors: result.error};
        }
    }
    catch ( err ) {
        console.log(err);
        return false;
    }
}


export const checkLogin = async () => {
        const res = await LoginCheck();
        console.log("otin");
        if ( res.status !== 200 ) {
            console.log("err");
            return {status: res.status};
        }
        else {
            console.log(`Res status: ${res.status}`);
            console.log(`${res.status}--${res.isCustomer}--${res.isEmployee}`);
            return {status: res.status, employee: res.isEmployee, customer: res.isCustomer};
        }
}