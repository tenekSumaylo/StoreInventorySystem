import { Box, Button, List } from "@chakra-ui/react";
import AuthorizedDrawer from "./SideDrawer";
import { Link } from "react-router";
const AuthorizedHeader = () => {
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
            <List.Root display="flex" flexDirection="row" listStyleType="none" gap="5">
                <List.Item>
                    <Link to="/AuthorizedUser">
                        <Button color="black" height="14" width="20" _hover={ {color: "black", fontWeight: "bold"}} bg="white">
                            Home
                        </Button>
                    </Link>

                </List.Item>
                <List.Item>
                    <Button height="14" width="20">
                        Orders
                    </Button>
                </List.Item>
            </List.Root>
            <AuthorizedDrawer />
        </Box>
    )
}
export default AuthorizedHeader;