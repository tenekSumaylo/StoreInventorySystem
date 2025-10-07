import { useEffect, useState } from "react";
import AuthorizedHeader from "./../components/layout/AuthorizedHeader";
import { VStack, Input, Button, Group, Flex, Card, Image, Text, List} from "@chakra-ui/react";
import { checkLogin } from "./../components/login/loginHandler";
import { useNavigate } from "react-router";
import { GetPaginatedProductsApi } from "./../Api/ProductClient";
import { ItemCard } from "./../components/cards/itemCard";
import { AddShoppingCartApi, GetShoppingCartApi } from "./../Api/ShoppingCartClient";
import { Toaster } from "./../components/ui/toaster";
const AuthorizedHome = () => {
    const navigate = useNavigate();
    const[products, setProducts] = useState([]);
    const[shoppingCart, setShoppingCart] = useState(null);
    const[search, setSearch] = useState("");

    useEffect(() => {
        const loadData = async () => {
            await checkLogin().
            then(response=> {
                if (response.status === 200 ){
                    if ( response.employee ) {
                        navigate("/employee");
                    }
                }
                else {
                    navigate("/");
                }
            })
            .catch(error => {
                navigate("/");
            });
            
            await GetPaginatedProductsApi()
            .then(response => {
                console.log("Products get successful");
                setProducts(response.products);
                console.log(`this is product ${products}`);
            })
            .catch(error => {
                console.log(error);
            });

            await AddShoppingCartApi()
            .then(response => {
                if ( response.status === 200 ) {
                    GetShoppingCartApi()
                    .then(response => {
                        if ( response.status === 200 ) {
                        console.log("shopping cart get successful");
                            setShoppingCart(response.cart);
                        }
                        console.log(shoppingCart);
                    })
                    .catch(error => {
                        console.log(error);
                    });
                }
            })
            .catch(error => {
                console.log(error);
            });
        }

        loadData();

    },[]);

    const handleSearch = async (e) => {
        e.preventDefault();
        console.log(`This is search ${search}`);
        await GetPaginatedProductsApi(search)
        .then(response => {
            setProducts(response.products);
        })
        .catch(error => {
            console.log("error");
        });
    }

    return(
        <>
        <div className="bg-gray-100 min-h-screen">
            <VStack gap="14" justifyItems="center" pb="5">
                <Toaster/>
                <AuthorizedHeader/>
                <Group attached w="full" maxW="xl" bg="white">
                    <form className="flex" onSubmit={handleSearch}>
                        <Input flex="1" placeholder="What do you need?" w="xl" color="black"
                                onChange={(e) => setSearch(e.target.value)} value={search}></Input>
                        <Button type="submit" bg="black" variant="outline" color="white">
                            Search
                        </Button>
                    </form>
                </Group>
                <Flex wrap="wrap" gap={4} justifyContent="center" justify="flex-start">
                    {shoppingCart && shoppingCart.shoppingCartId && products && products.map((product) => (
                        <List.Root listStyleType="none" key={product.id}>
                            <ItemCard productName={product.productName} brand={product.brand}
                                productId={product.id} shoppingCartId={shoppingCart.shoppingCartId}
                                tags={product.tags} productImage={product.productImage} price={product.price}
                                stock={product.stock}
                                />
                        </List.Root>
                    ))}
                </Flex>
                
            </VStack>
        </div>
        </>
    );
}

export default AuthorizedHome;