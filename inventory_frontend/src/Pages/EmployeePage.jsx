import { Flex, Group, Input, Button, HStack, List } from "@chakra-ui/react";
import AuthorizedHeader from "./../components/layout/AuthorizedHeader";
import { AddItemDialog } from "./../components/dialog/addItemDialog";
import { Toaster } from "./../components/ui/toaster";
import { useState, useEffect } from "react";
import { GetPaginatedProductsApi } from "./../Api/ProductClient";
import { ItemCard } from "./../components/cards/itemCard";
import { EditCard } from "./../components/cards/editCard";

const EmployeePage = () => {
    const[products, setProducts] = useState([]);
    const[shoppingCart, setShoppingCart] = useState(null);

    useEffect(() => {
        const result = async () => { await GetPaginatedProductsApi()
        .then(response => {
            console.log("TEST");
            console.log(response.products);
            setProducts(response.products);
        })
        .catch(error => {
            console.log(error);
        });}
        result();

    },[]);
    return(
        <div className="min-h-screen bg-gray-100">
            <Toaster/>
            <Flex direction="column" alignItems="center" gap={14}>
                <AuthorizedHeader/>
                <HStack>
                    <AddItemDialog/>
                    <Group attached w="full" maxW="xl" bg="white">
                        <form className="flex">
                            <Input flex="1" placeholder="What do you need?" w="xl" color="black"></Input>
                            <Button type="submit" bg="black" variant="outline" color="white">
                                Search
                            </Button>
                        </form>
                    </Group>
                </HStack>
                <Flex wrap="wrap" gap={4} justifyContent="center" justify="flex-start">
                    {products && products.map((product) => (
                        <List.Root listStyleType="none" key={product.id}>
                            <EditCard productName={product.productName} brand={product.brand}
                                productId={product.id}
                                tags={product.tags} productImage={product.productImage} price={product.price}
                                stock={product.stock}
                                />
                        </List.Root>
                            /*
    const[productName, setProductName] = useState("");
    const[brand, setBrand] = useState("");
    const[price, setPrice] = useState(0);
    const[stock, setStock] = useState(0);
    const[category, setCategory] = useState("");
    const[tags, setTags ] = useState([]);
    const[image, setImage] = useState([]);*/
                    ))}
                </Flex>

            </Flex>
        </div>
    );
}

export default EmployeePage;