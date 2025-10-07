import { Box, Text, Field, Input, Button, useToastStyles } from "@chakra-ui/react";
import UnAuthorizedHeader from "./../components/layout/UnAuthorizedHeader";
import { FaGoogle } from "react-icons/fa";
import { useState } from "react";
import { GoogleLogin, LoginClient } from "./../Api/LoginClient";
import { useNavigate } from "react-router";
import {LoginHandler} from "./../components/login/loginHandler";
import { toaster, Toaster } from "./../components/ui/toaster";

const LoginPage = () => {
    const[username, setUserName] = useState("");
    const[password, setPassword] = useState("");
    const[error, setErrors] = useState([]);
    const[usernameError, setUsernameError] = useState("");
    const[passwordError, setPasswordError] = useState("");
    const[invalidUsername, setInvalidUsername] = useState(false);
    const[invalidPassword, setInvalidPassword] = useState(false);
    const navigate = useNavigate();

    const HandleLogin = async (e) => {
        e.preventDefault();
        const result = await LoginHandler({
                                        username: username,
                                        password: password
                                    });
        if (result.status === 200) {
            toaster.create({
                description: "Login Successful!",
                type: "success",
                closable: true
            });
            setTimeout(() => {
                navigate("/AuthorizedUser")
            }, 3000);

        }
        else {
            toaster.create({
                description: "Login Unsuccessful.",
                type: "error",
                closable: true
            });
            console.log("norwen");
        }
    }

    const handleGoogle = () => {
        GoogleLogin()
        .then(response => {
            if ( response.status === 200 ) {
            toaster.create({
                description: "Login Successful!",
                type: "success",
                closable: true
            });
            setTimeout(() => {
                navigate("/AuthorizedUser")
            }, 3000);
            }
        })
        .catch(error => {
            console.log(error);
            toaster.create({
                description: "Login Unsuccessful.",
                type: "error",
                closable: true
            });
        });
    }

    const handleGoogleV1 = () => {
        window.location.href = window.location.hostname === "localhost" ? "http://localhost:5166/api/Auth/Google" : "http://192.168.0.198:5166/api/Auth/Google";
    }

    return(
        <div className="flex flex-col bg-gray-100 min-h-screen gap-20 items-center"> 
            <UnAuthorizedHeader/>
            <Toaster/>
            <Box bg="white" 
                boxAlign="center" 
                w="xl" h="md" 
                rounded="4xl"
                display="flex"
                flexDirection="column"
                alignItems="center"
                gap="0">
                <Text fontWeight="bold" pt="5" fontSize="2xl">Login</Text>
                <form className="flex flex-col items-center gap-5" onSubmit={HandleLogin}>
                    <Field.Root required invalid={!username} w="sm">
                        <Field.Label>Username</Field.Label>
                        <Input placeholder="Enter your username here" 
                            value={username}
                            onChange={(e) => setUserName(e.target.value)}/>
                        <Field.ErrorText>{usernameError}</Field.ErrorText>
                    </Field.Root>

                    <Field.Root required invalid={!password} w="sm">
                        <Field.Label>Password</Field.Label>
                        <Input placeholder="Enter your password here" 
                            type="password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}/>
                        <Field.ErrorText>{passwordError}</Field.ErrorText>
                    </Field.Root>
                    <Button type="submit" w="2xs">Login</Button>
                </form>
                <Text color="blue.500" textDecoration="underline">Forgot your password?</Text>
                <Text pt="3" mb="2">Or Login with</Text>
                <FaGoogle onClick={handleGoogleV1} size="24"/>
            </Box>
        </div>
    );
}

export default LoginPage;