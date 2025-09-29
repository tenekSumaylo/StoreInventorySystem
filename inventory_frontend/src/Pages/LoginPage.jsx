import { Box, Text, Field, Input, Button, useStepsItemContext } from "@chakra-ui/react";
import UnAuthorizedHeader from "./../components/layout/UnAuthorizedHeader";
import { FaGoogle } from "react-icons/fa";
import { useState } from "react";
import { LoginClient } from "./../Api/LoginClient";

const LoginPage = () => {
    const[username, setUserName] = useState("");
    const[password, setPassword] = useState("");
    const[error, setErrors] = useState([]);
    const[usernameError, setUsernameError] = useState("");
    const[passwordError, setPasswordError] = useState("");

    const HandleLogin = async (e) => {
        e.preventDefault();
        if ( !username.trim() ){
            setUsernameError("Username is fucking required");
        }

        if ( !password.trim() ) {
            setPasswordError("Password is fucking required");
        }
        try {
            const result = await LoginClient({
                UserLogin: username,
                Password: password
            });
            if ( result === 200 ) {
                console.log("Successful login");
            }
            else {
                console.log("Unsuccessful login");
            }
            debugger;
        }
        catch ( err ) {
            console.log(err);
        }
    }

    return(
        <div className="flex flex-col bg-gray-100 min-h-screen gap-20 items-center"> 
            <UnAuthorizedHeader/>
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
                <FaGoogle size="24"/>
            </Box>
        </div>
    );
}

export default LoginPage;