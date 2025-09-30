import { LoginClient } from "./../../Api/LoginClient";
import { useNavigate } from "react-router";

const LoginHandler = async (props) => {
    try {
        const result = await LoginClient({
            UserLogin: props.username,
            Password: props.password
        });
        if ( result === 200 ) {
            return true;
        }
        else {
            console.log("Unsuccessful login");
        }
    }
    catch ( err ) {
        console.log(err);
        return false;
    }
}

export default LoginHandler;