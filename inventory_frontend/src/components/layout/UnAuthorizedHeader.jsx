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
                    <Button height="14" width="20" _hover={ {color: "black", fontWeight: "bold"}}>
                        Home
                    </Button>
                </List.Item>
                <List.Item>
                    <Button height="10" width="20" bg="black" color="white">
                        Signin
                    </Button>
                </List.Item>
                <List.Item>
                    <Button height="10" width="20" bg="black" color="white">
                        Signup
                    </Button>
                </List.Item>
            </List.Root>
        </Box>
    )
}
export default UnAuthorizedHeader;