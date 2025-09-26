import AuthorizedDrawer from "./SideDrawer";
import { Box, HStack, ListItem, List } from "@chakra-ui/react";

const UnAuthorizedHeader = () => {
    return(
        <header>
            <Box>
                <HStack>
                    <List.Root listStyle="none" display="flex">
                        <List.Item>
                            Home
                        </List.Item>
                        <List.Item>
                            Inventory
                        </List.Item>
                    </List.Root>
                    <AuthorizedDrawer/>
                </HStack>
            </Box>
        </header>

    )
}

export default UnAuthorizedHeader;