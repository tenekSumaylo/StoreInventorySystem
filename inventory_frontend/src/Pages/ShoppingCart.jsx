import AuthorizedHeader from "./../components/layout/AuthorizedHeader";
import { Box, Flex, Grid, GridItem, EmptyState, VStack, useStatStyles } from "@chakra-ui/react";
import { useEffect, useState } from "react";
import { LuShoppingCart } from "react-icons/lu";
const ShoppingCartPage = () => {
    const[ShoppingItems, SetShoppingItems] = useState([]);
    return(
        
        <div className="bg-gray-100 min-h-screen">
            
            <Flex direction="column" alignItems="center" gap="5" >
                <AuthorizedHeader/>
                <Grid templateColumns="3fr 1fr 1fr 1fr 1fr" w="4xl"  fontWeight="bold" fontFamily="serif" textAlign="center">
                    <GridItem>
                        Item Name
                    </GridItem>
                    <GridItem textAlign="center">
                        Quantity
                    </GridItem>
                    <GridItem textAlign="center">
                        Price
                    </GridItem>
                    <GridItem textAlign="center">
                        Amount
                    </GridItem>
                </Grid>
                <Box rounded="2xl" bg="white" h="100%" w="4xl">
                    {/*
                        !ShoppingItems || ShoppingItems.length === 0 ? (
                        <EmptyState.Root display="flex" 
                            flexDirection="column" 
                            alignItems="center"
                            justifyContent="center">
                        <EmptyState.Content>
                            <EmptyState.Indicator>
                            <LuShoppingCart />
                            </EmptyState.Indicator>
                            <VStack textAlign="center">
                            <EmptyState.Title>Your cart is empty</EmptyState.Title>
                            <EmptyState.Description>
                                Explore our products and add items to your cart
                            </EmptyState.Description>
                            </VStack>
                        </EmptyState.Content>
                        </EmptyState.Root>
                        ) : (
                            <div>
                                
                            </div>
                        ) 
                    */}
                </Box> 
            </Flex>
        </div>
    );
}

export default ShoppingCartPage;