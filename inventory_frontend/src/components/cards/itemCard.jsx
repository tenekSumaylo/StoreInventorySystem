import { AddShoppingCartItemApi } from "./../../Api/ShoppingCartClient";
import { Card, Button, Image, Text } from "@chakra-ui/react";
import { Toaster, toaster } from "./../../components/ui/toaster";
import { useEffect } from "react";
import { Navigate, useNavigate } from "react-router";
export const ItemCard = (props) => {
    const navigate = useNavigate();
    const addToCart = () => {
        AddShoppingCartItemApi({
            productId: props.productId,
            shoppingCartId: props.shoppingCartId
        }).
        then(response => {
            if ( response.status === 200 ) {
                toaster.create({
                    description: "Added To Cart Successfully",
                    type: "success",
                    closable: true
                });
            }
            else {
                toaster.create({
                description: "Failed to add to cart",
                type: "error",
                closable: true
            });
            }
        })
        .catch(error => {
            toaster.create({
                description: "Failed to add to cart",
                type: "error",
                closable: true
            });
        });
    }

    const handleBuy = () => {
        AddShoppingCartItemApi({
            productId: props.productId,
            shoppingCartId: props.shoppingCartId
        });
        navigate("/ShoppingCart");
    }

    // get api 
    return (
        <Card.Root maxW="sm" overflow="hidden"
            maxWidth="calc(25%-1rem)">
        <Image
            src={`data:image/jpeg;base64,${props.productImage}`}
            onError={(e) => e.target.src = `data:image/png;base64,${props.productImage}`}
            alt="Product Picture"
            width="100%"
            height="120px"
            objectFit="contain"
            p="2"
        />
        <Card.Body gap="2">
            <Card.Title>{props.productName}</Card.Title>
            <Card.Description>
                {props.brand}
            </Card.Description>
            <Text textStyle="2xl" fontWeight="medium" letterSpacing="tight" mt="2">
            ${props.price}
            </Text>
        </Card.Body>
        <Card.Footer gap="2">
            <Button variant="solid" onClick={handleBuy}>Buy now</Button>
            <Button variant="ghost" onClick={addToCart} >Add to cart</Button>
        </Card.Footer>
        </Card.Root>
    );

}