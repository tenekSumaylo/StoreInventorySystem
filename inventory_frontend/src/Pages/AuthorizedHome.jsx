import { useEffect } from "react";
import AuthorizedHeader from "./../components/layout/AuthorizedHeader";
import { VStack, Input, Button, Group, Flex, Card, Image, Text} from "@chakra-ui/react";
import { checkLogin } from "./../components/login/loginHandler";
import { useNavigate } from "react-router";
const AuthorizedHome = () => {
    const navigate = useNavigate();
    
    useEffect(() => {
         const result = checkLogin();
         if (result.status === 200) {
            if (result.employee) {
                navigate("/employee");
            } 
         }
         else {
            navigate("/");
         }
    },[]);

    return(
        <>
        <div className="bg-gray-100">
            <VStack gap="14" justifyItems="center" pb="5">
                <AuthorizedHeader/>
                <Group attached w="full" maxW="xl" bg="white">
                    <form className="flex">
                        <Input flex="1" placeholder="What do you need?" w="xl" color="black"></Input>
                        <Button type="submit" bg="black" variant="outline" color="white">
                            Search
                        </Button>
                    </form>

                </Group>
                <Flex wrap="wrap" gap={4} justifyContent="center" >
                        <Card.Root maxW="sm" overflow="hidden">
                        <Image
                            src="https://images.unsplash.com/photo-1555041469-a586c61ea9bc?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1770&q=80"
                            alt="Green double couch with wooden legs"
                        />
                        <Card.Body gap="2">
                            <Card.Title>Living room Sofa</Card.Title>
                            <Card.Description>
                            This sofa is perfect for modern tropical spaces, baroque inspired
                            spaces.
                            </Card.Description>
                            <Text textStyle="2xl" fontWeight="medium" letterSpacing="tight" mt="2">
                            $450
                            </Text>
                        </Card.Body>
                        <Card.Footer gap="2">
                            <Button variant="solid">Buy now</Button>
                            <Button variant="ghost">Add to cart</Button>
                        </Card.Footer>
                        </Card.Root>
                        <Card.Root maxW="sm" overflow="hidden">
                        <Image
                            src="https://images.unsplash.com/photo-1555041469-a586c61ea9bc?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1770&q=80"
                            alt="Green double couch with wooden legs"
                        />
                        <Card.Body gap="2">
                            <Card.Title>Living room Sofa</Card.Title>
                            <Card.Description>
                            This sofa is perfect for modern tropical spaces, baroque inspired
                            spaces.
                            </Card.Description>
                            <Text textStyle="2xl" fontWeight="medium" letterSpacing="tight" mt="2">
                            $450
                            </Text>
                        </Card.Body>
                        <Card.Footer gap="2">
                            <Button variant="solid">Buy now</Button>
                            <Button variant="ghost">Add to cart</Button>
                        </Card.Footer>
                        </Card.Root>
                        <Card.Root maxW="sm" overflow="hidden">
                        <Image
                            src="https://images.unsplash.com/photo-1555041469-a586c61ea9bc?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1770&q=80"
                            alt="Green double couch with wooden legs"
                        />
                        <Card.Body gap="2">
                            <Card.Title>Living room Sofa</Card.Title>
                            <Card.Description>
                            This sofa is perfect for modern tropical spaces, baroque inspired
                            spaces.
                            </Card.Description>
                            <Text textStyle="2xl" fontWeight="medium" letterSpacing="tight" mt="2">
                            $450
                            </Text>
                        </Card.Body>
                        <Card.Footer gap="2">
                            <Button variant="solid">Buy now</Button>
                            <Button variant="ghost">Add to cart</Button>
                        </Card.Footer>
                        </Card.Root>
                        <Card.Root maxW="sm" overflow="hidden">
                        <Image
                            src="https://images.unsplash.com/photo-1555041469-a586c61ea9bc?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1770&q=80"
                            alt="Green double couch with wooden legs"
                        />
                        <Card.Body gap="2">
                            <Card.Title>Living room Sofa</Card.Title>
                            <Card.Description>
                            This sofa is perfect for modern tropical spaces, baroque inspired
                            spaces.
                            </Card.Description>
                            <Text textStyle="2xl" fontWeight="medium" letterSpacing="tight" mt="2">
                            $450
                            </Text>
                        </Card.Body>
                        <Card.Footer gap="2">
                            <Button variant="solid">Buy now</Button>
                            <Button variant="ghost">Add to cart</Button>
                        </Card.Footer>
                        </Card.Root>
                        <Card.Root maxW="sm" overflow="hidden">
                        <Image
                            src="https://images.unsplash.com/photo-1555041469-a586c61ea9bc?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1770&q=80"
                            alt="Green double couch with wooden legs"
                        />
                        <Card.Body gap="2">
                            <Card.Title>Living room Sofa</Card.Title>
                            <Card.Description>
                            This sofa is perfect for modern tropical spaces, baroque inspired
                            spaces.
                            </Card.Description>
                            <Text textStyle="2xl" fontWeight="medium" letterSpacing="tight" mt="2">
                            $450
                            </Text>
                        </Card.Body>
                        <Card.Footer gap="2">
                            <Button variant="solid">Buy now</Button>
                            <Button variant="ghost">Add to cart</Button>
                        </Card.Footer>
                        </Card.Root>

                </Flex>
            </VStack>
        </div>
        </>
    );
}

export default AuthorizedHome;