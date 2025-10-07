import { UpdateShoppingCartItemApi, GetShoppingCartApi, DeleteShoppingCartItemApi } from "./../../Api/ShoppingCartClient"
import { toaster, Toaster } from "./../../components/ui/toaster";

export const updateCart = async (item) => {
    return await UpdateShoppingCartItemApi(item)
    .then(response => {
        return {status: response.status};
    })
    .catch(error => {
        if (error.response) {
            return {status: error.response.status};
        }
        else if (error.request) {
            return {status: 500};
        }
    });
}

export const shoppingCartInitialize = async (setCart) => {
        await GetShoppingCartApi()
        .then(response => {
            setCart(response.cart);
            console.log(response.cart);
        })
        .catch(error => {
            console.log(error);
        });
}

export const deleteCartItem = async (item) => {
    console.log(`WEHWHE ${item.id}`);
    return await DeleteShoppingCartItemApi({id: item.id})
    .then(response => {
        console.log(`ATAY ${response}`);
        console.log(`This is the response ${response.status} and data --- ${response.data}`);
        if (response.data) {
            toaster.create({
                description: "Deletion Successful!",
                type: "success",
                closable: true
            });
        }
        else {
            toaster.create({
                description: "Deletion Unsuccessful!",
                type: "error",
                closable: true
            });
        }
        return response.status;
    })
    .catch(error => {
        console.log(error);
    })
}