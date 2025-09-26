import { Avatar, AvatarGroup, Button, Drawer, Flex, HStack, Icon, List, Portal, Text } from "@chakra-ui/react"
import { useState } from "react"
import { Home, HomeIcon, ListIcon, ShoppingCart, UserRound } from "lucide-react";

const AuthorizedDrawer = () => {
    const[openCloseStatus, setStatus] = useState(false);
    return(
        <Drawer.Root open={openCloseStatus} 
                onOpenChange={(e) => setStatus(e.open)}
                size="xs">
            <Drawer.Trigger asChild>
                <Icon>
                    <UserRound/>
                </Icon>
            </Drawer.Trigger>
            <Portal>
                <Drawer.Backdrop/>
                <Drawer.Positioner>
                    <Drawer.Content bg="black">
                        <Drawer.Header>
                            <Drawer.Title flex>
                                <Flex gap={0} align="center">
                                    <Text color="white">
                                        Norwen's Inventory System
                                    </Text>
                                </Flex>
                            </Drawer.Title>
                        </Drawer.Header>
                        <Drawer.Body>
                            <div>
                                <Avatar.Root
                                size="2xl"
                                className="inline-flex items-center justify-center h-[250px] w-[250px] rounded-full overflow-hidden"
                                >
                                <Avatar.Fallback />
                                <Avatar.Image
                                    className="h-full w-full object-cover rounded-full border"
                                    src="https://media.licdn.com/dms/image/v2/D4D03AQEsQXE-rrFTOw/profile-displayphoto-shrink_200_200/B4DZX7qxIfGkAY-/0/1743684048360?e=2147483647&v=beta&t=2Xi2MFNUCJi4HDguIyjqyY51rm5rxIylAOTBnFBdV8E"
                                />
                                </Avatar.Root>
                                <div>
                                    <List.Root as="ul"
                                            className="list-none p-0 m-0">
                                        <List.Item color="white" >
                                            <Icon>
                                                <HomeIcon/>
                                            </Icon>
                                            Home
                                        </List.Item>
                                            <List.Item color="white" >
                                            <Icon>
                                                <ShoppingCart/>
                                            </Icon>
                                            Cart
                                        </List.Item>
                                    </List.Root>
                                </div>
                            </div>
                        </Drawer.Body>
                    </Drawer.Content>
                </Drawer.Positioner>
            </Portal>
        </Drawer.Root>
    )
}
export default AuthorizedDrawer;