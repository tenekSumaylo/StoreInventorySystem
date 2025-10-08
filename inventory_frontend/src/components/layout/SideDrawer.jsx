import { Avatar, AvatarGroup, Button, Drawer, Flex, HStack, Icon, List, Portal, Text } from "@chakra-ui/react"
import { useState } from "react"
import { Home, HomeIcon, ListIcon, ShoppingCart, UserRound } from "lucide-react";
import { Link } from "react-router";
import { LogoutApi } from "./../../Api/LoginClient";

const AuthorizedDrawer = () => {
    const[openCloseStatus, setStatus] = useState(false);
    return(
        <Drawer.Root open={openCloseStatus} 
                onOpenChange={(e) => setStatus(e.open)}
                size="xs"
                >
            <Drawer.Trigger asChild>
                <Icon color="black">
                    <UserRound/>
                </Icon>
            </Drawer.Trigger>
            <Portal>
                <Drawer.Backdrop/>
                <Drawer.Positioner>
                    <Drawer.Content bg="white">
                        <Drawer.Header>
                            <Drawer.Title flex>
                                <Flex gap={0} align="center">
                                    <Text color="black">
                                        Store Inventory System
                                    </Text>
                                </Flex>
                            </Drawer.Title>
                        </Drawer.Header>
                        <Drawer.Body className="flex">
                            <div>
                                <div className="flex items-center">
                                    <Avatar.Root
                                    size="2xl"
                                    className="inline-flex items-center justify-center h-[250px] w-[250px] rounded-full overflow-hidden"
                                    mr="5"
                                    >
                                    <Avatar.Fallback />
                                    <Avatar.Image 
                                        className="h-full w-full object-cover rounded-full border"
                                        src="https://media.licdn.com/dms/image/v2/D4D03AQEsQXE-rrFTOw/profile-displayphoto-shrink_200_200/B4DZX7qxIfGkAY-/0/1743684048360?e=2147483647&v=beta&t=2Xi2MFNUCJi4HDguIyjqyY51rm5rxIylAOTBnFBdV8E"
                                    />
                                    </Avatar.Root>
                                    <div>
                                        <Text textStyle="xl">Norwen T. Penas</Text>
                                    </div>
                                </div>
                                <div>
                                    <List.Root as="ul"
                                            className="list-none p-0 m-0"
                                            listStyleType="none"
                                            gap="5"
                                            pt="5"
                                            >
                                        <List.Item color="Black" spaceX="3" _hover={ {color: 'orange.500'}}> 
                                            <Icon>
                                                <HomeIcon/>
                                            </Icon>
                                            <span>Home</span>
                                        </List.Item>
                                        <List.Item color="Black" spaceX="3" _hover={ {color: 'orange.500'}}>
                                            <Link to="/ShoppingCart">
                                                <Icon>
                                                    <ShoppingCart/>
                                                </Icon>
                                                <span>Cart</span>
                                            </Link>
                                        </List.Item>
                                        <List.Item color="Black" spaceX="3" _hover={ {color: 'orange.500'}}>
                                            <Link to="/" onClick={async () => {
                                                await LogoutApi()
                                                .then(response => {
                                                    console.log(response);
                                                })
                                                .catch(error => {
                                                    console.log(error);
                                                });
                                            }}>
                                                <Icon>
                                                    <ShoppingCart/>
                                                </Icon>
                                                <span>Logout</span>
                                            </Link>
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