import { Link } from "react-router";
import AuthorizedDrawer from "./SideDrawer";
import { Box, Flex, Stack, Button, Menu, Avatar, List } from "@chakra-ui/react";

const UnAuthorizedHeader = () => {
    return(
        <Box h="14" 
        bg="white" 
        w="100%" 
        display="flex" 
        flexDirection="row" 
        alignItems="center" 
        justifyContent="flex-end"
        pr="5"
        gap="5"> 
            <List.Root display="flex" flexDirection="row" listStyleType="none" gap="5" alignItems="center">
                <List.Item>
                    <Link to="/">
                        <Button height="14" width="20" _hover={ {color: "black", fontWeight: "bold"}} bg="white" color="black">
                            Home
                        </Button>
                    </Link>
                </List.Item>
                <List.Item>
                    <Link to="/Login">
                        <Button height="10" width="20" bg="black" color="white">
                            Signin
                        </Button>
                    </Link>
                </List.Item>
                <List.Item>
                    <Link to="/Register">
                        <Button height="10" width="20" bg="black" color="white">
                            Signup
                        </Button>
                    </Link>
                </List.Item>
            </List.Root>
        </Box>
    )
}
export default UnAuthorizedHeader;