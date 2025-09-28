import UnAuthorizedHeader from "./../components/layout/UnAuthorizedHeader";
import { HStack, Box, VStack, Text, Stack, Field, Button, Input } from "@chakra-ui/react";

const RegisterPage = () => {
    return(
        <>
            <div className="bg-gray-100 h-full w-full min-h-screen justify-center">
                <VStack alignContent="center" align="center" gap="10">  
                    <UnAuthorizedHeader/>
                    <form className="flex justify-center bg-white w-xl min-h-[600px] rounded-4xl" > 
                        <Stack gap="4" align="center" maxW="sm" justifyContent="center">
                        <Field.Root w="sm" color="black" required>
                            <Field.Label>Username
                                <Field.RequiredIndicator/>
                            </Field.Label>
                            <Input/>
                            <Field.ErrorText></Field.ErrorText>
                        </Field.Root>
                        <Field.Root w="sm" color="black" required> 
                            <Field.Label>Password
                                <Field.RequiredIndicator/>
                            </Field.Label>
                            <Input type="password"/>
                            <Field.ErrorText></Field.ErrorText>
                        </Field.Root>
                        <Field.Root w="sm" color="black" required>  
                            <Field.Label>First name
                                <Field.RequiredIndicator/>
                            </Field.Label>
                            <Input />
                            <Field.ErrorText></Field.ErrorText>
                        </Field.Root>
                        <Field.Root w="sm" color="black" required> 
                            <Field.Label>Last name
                                <Field.RequiredIndicator/>
                            </Field.Label>
                            <Input />
                            <Field.ErrorText></Field.ErrorText>
                        </Field.Root>
                        <Field.Root w="sm" color="black">  
                            <Field.Label>Address</Field.Label>
                            <Input />
                            <Field.ErrorText></Field.ErrorText>
                        </Field.Root>
                        <Field.Root w="sm" color="black"> 
                            <Field.Label>Date of Birth</Field.Label>
                            <Input />
                            <Field.ErrorText></Field.ErrorText>
                        </Field.Root>
                        <Button type="submit" bg="black" color="white" rounded="3xl" w="sm">Register</Button>

                        </Stack>
                    </form>
                </VStack>
            </div>
        </>
    );
}

export default RegisterPage;