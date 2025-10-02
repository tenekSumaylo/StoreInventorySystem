import { Button, CloseButton, Dialog, Portal, Flex, Grid, GridItem, Box } from "@chakra-ui/react";

export const AddItemDialog = () => {

    return(
        <Dialog.Root size="cover" placement="center" motionPreset="slide-in-bottom">
            <Dialog.Trigger>
                <Button variant="outline" bg="black" color="white">
                    Add New Product
                </Button>
            </Dialog.Trigger>
            <Portal>
                <Dialog.Backdrop>
                    <Dialog.Positioner>
                        <Dialog.Content>
                            <Dialog.Header>
                                <Dialog.Title>
                                    Add New Product
                                </Dialog.Title>
                                <Dialog.CloseTrigger asChild>
                                    <CloseButton size="sm"/>
                                </Dialog.CloseTrigger>
                            </Dialog.Header>
                            <Dialog.Body>
                                <Flex h="fit" w="fit">
                                    <Grid templateColumns="repeat(2, 1fr)"> 
                                        <GridItem bg="black">
                                            <Box bg="black"></Box>
                                        </GridItem>
                                        <GridItem bg="blue">

                                        </GridItem>
                                    </Grid>
                                </Flex>
                            </Dialog.Body>
                            <Dialog.Footer>
                                <Dialog.ActionTrigger asChild>
                                    <Button variant="outline">
                                        Cancel
                                    </Button>
                                </Dialog.ActionTrigger>
                                <Button variant="solid">Save Product</Button>
                            </Dialog.Footer>
                        </Dialog.Content>
                    </Dialog.Positioner>
                </Dialog.Backdrop>
            </Portal>
        </Dialog.Root>
    );
}