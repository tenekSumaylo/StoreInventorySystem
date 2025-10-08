import UnAuthorizedHeader from "./../components/layout/UnAuthorizedHeader";
import { HStack, Box, VStack, Text, Stack, Field, Button, Input, NumberInput, FieldRequiredIndicator, Icon } from "@chakra-ui/react";
import { useState } from "react";
import {RegisterClient} from "./../Api/RegisterClient";
import { toaster, Toaster } from "./../components/ui/toaster";

const RegisterPage = () => {
    const[username, setUsername] = useState("");
    const[password, setPassword] = useState("");
    const[firstname, setFirstName] = useState("");
    const[lastname, setLastName] = useState("");
    const[phoneNumber, setPhoneNumber] = useState("");
    const[address, setAddress] = useState("");
    const[email, setEmail] = useState("");
    const[month, setMonth] = useState(1);
    const[day, setDay] = useState(1);
    const[year, setYear] = useState(new Date().getFullYear());

    const handleSubmit = async (e) => {
        e.preventDefault();
        const dob = new Date(year, month - 1, day);
        const registerInformation = {
            username: username,
            password: password,
            firstname: firstname,
            lastname: lastname,
            phoneNumber: phoneNumber,
            address: address,
            email: email,
            dateOfBirth: dob.toISOString().split("T")[0]
        }
        console.log(registerInformation);
        const result = await RegisterClient(registerInformation);
        if ( result.status === 200 ) {
            toaster.create({
                description: "Registration Successful!",
                type: "info",
                closable: true
            });
        }
        else {
            toaster.create({
                description: "Registration Unsuccessful.",
                type: "error",
                closable: true
            });
            console.log("norwen");
        }

    }
    


    return(
        <>
            <div className="bg-gray-100 h-full w-full min-h-screen justify-center">
                <Toaster/>
                <VStack alignContent="center" align="center" gap="10" >  
                    <UnAuthorizedHeader/>
                    <Text color="black" fontSize="2xl" fontWeight="bold">Register Account</Text>
                    <form className="flex justify-center bg-white w-xl min-h-[800px] rounded-4xl" onSubmit={handleSubmit} > 
                        <Stack gap="4" align="center" maxW="sm" display="flex" justifyContent="center">
                            <Field.Root w="sm" color="black" required invalid={!username}>
                                <Field.Label>Username
                                    <Field.RequiredIndicator/>
                                </Field.Label>
                                <Input value={username} onChange={(e) => setUsername(e.target.value) }/>
                                <Field.ErrorText></Field.ErrorText>
                            </Field.Root>
                            <Field.Root w="sm" color="black" required invalid={!password}> 
                                <Field.Label>Password
                                    <Field.RequiredIndicator/>
                                </Field.Label>
                                <Input type="password" value={password} onChange={(e) => setPassword(e.target.value) }/>
                                <Field.ErrorText></Field.ErrorText>
                            </Field.Root>

                            <Field.Root w="sm" color="black" required invalid={!firstname}>  
                                <Field.Label>First name
                                    <Field.RequiredIndicator/>
                                </Field.Label>
                                <Input value={firstname} onChange={(e) => setFirstName(e.target.value) }/>
                                <Field.ErrorText></Field.ErrorText>
                            </Field.Root>

                            <Field.Root w="sm" color="black" required invalid={!lastname}> 
                                <Field.Label>Last name
                                    <Field.RequiredIndicator/>
                                </Field.Label>
                                <Input value={lastname} onChange={(e) => setLastName(e.target.value) }/>
                                <Field.ErrorText></Field.ErrorText>
                            </Field.Root>
                            <Field.Root w="sm" color="black" required invalid={!phoneNumber}>  
                                <Field.Label>Phone Number</Field.Label>
                                <Input placeholder="(09) 999999999" type="number" value={phoneNumber} onChange={(e) => setPhoneNumber(e.target.value) }/>
                                <Field.ErrorText></Field.ErrorText>
                            </Field.Root>
                            <Field.Root w="sm" color="black" invalid={!address} required>  
                                <Field.Label>Address</Field.Label>
                                <Input value={address} onChange={(e) => setAddress(e.target.value) }/>
                                <Field.ErrorText></Field.ErrorText>
                            </Field.Root>

                            <Field.Root w="sm" color="black" invalid={!email} required>  
                                <Field.Label>Email</Field.Label>
                                <Input value={email} onChange={(e) => setEmail(e.target.value) }/>
                                <Field.ErrorText></Field.ErrorText>
                            </Field.Root>
                            <VStack>
                                <Text 
                                fontSize="sm"        
                                fontWeight="medium"  
                                color="gray.700"     
                                lineHeight="short"   
                                fontFamily="body"   
                                >
                                Date of Birth(mm/dd/yy)
                                </Text>
                                <HStack>
                                    <NumberInput.Root required
                                        min={1} 
                                        max={12} 
                                        value={month} 
                                         onValueChange={(e) => setMonth(Number(e.value))} 
                                         step={1}>
                                        <NumberInput.Control/>
                                        <NumberInput.Input />
                                    </NumberInput.Root>
                                    <NumberInput.Root required
                                        min={1} 
                                        max={31} 
                                        value={day}
                                        onValueChange={(e) => setDay(Number(e.value))} 
                                        step={1}>
                                        <NumberInput.Control/>
                                        <NumberInput.Input />
                                    </NumberInput.Root>
                                    <NumberInput.Root required
                                        min={1920} 
                                        max={new Date().getFullYear()} 
                                        value={year} onValueChange={(e) => setYear(Number(e.value))} 
                                        step={1}>
                                        <NumberInput.Control/>
                                        <NumberInput.Input />
                                    </NumberInput.Root>
                                </HStack>
                            </VStack>
                            <Button type="submit" bg="black" color="white" rounded="3xl" w="sm">Register</Button>
                        </Stack>
                    </form>
                </VStack>
            </div>
        </>
    );
}

export default RegisterPage;