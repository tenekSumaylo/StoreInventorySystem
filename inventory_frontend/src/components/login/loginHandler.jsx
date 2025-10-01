import { LoginClient } from "./../../Api/LoginClient";
import { useNavigate } from "react-router";

const LoginHandler = async (props) => {
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

export default LoginHandler;