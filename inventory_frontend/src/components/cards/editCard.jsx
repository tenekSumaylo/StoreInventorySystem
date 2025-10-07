import { AddShoppingCartItemApi } from "./../../Api/ShoppingCartClient";
import { Card, Button, Image, Text } from "@chakra-ui/react";
import { Toaster, toaster } from "./../../components/ui/toaster";
import { useEffect } from "react";
import { Navigate, useNavigate } from "react-router";
import { EditItemDialog } from "../dialog/editItemDialog";
export const EditCard = (props) => {
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
            <EditItemDialog productName={props.productName} brand={props.brand} price={props.price} stock={props.stock} category={props.category}
                tags={props.tags} image={props.productImage} id={props.productId}/>
        </Card.Footer>
        </Card.Root>
    );

}

    /*
    const[productName, setProductName] = useState("");
    const[brand, setBrand] = useState("");
    const[price, setPrice] = useState(0);
    const[stock, setStock] = useState(0);
    const[category, setCategory] = useState("");
    const[tags, setTags ] = useState([]);
    const[image, setImage] = useState([]);*/