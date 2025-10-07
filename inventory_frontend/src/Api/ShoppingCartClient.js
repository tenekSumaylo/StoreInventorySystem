import axiosClient from "./axiosClient"

export const AddShoppingCartItemApi = async (cartInformation) => {
    try {
        console.log(`Credentials ${cartInformation.productId}-~${cartInformation.shoppingCartId}}`);
        const result = await axiosClient.post("/ShoppingCartItem", cartInformation);
        if ( result.status === 200 ){
            return {status: result.status};
        }
    }
    catch (error) {
        return {status: error.response.status};
    }
}

export const UpdateShoppingCartItemApi = async(item) => {
    try {
        const result = await axiosClient.put("/ShoppingCartItem/ItemQuantity", item);
        return {status: result.status, data: result.data};
    }
    catch (error) {
        console.log(error);
        return {status: error.response.status};
    }
}

export const DeleteShoppingCartItemApi = async (dto) => {
    try {
        console.log(`YAWA ${dto}`);
        const result = await axiosClient.delete("/ShoppingCartItem", {
            data: dto,
            headers: { "Content-Type" : "application/json"}
        });
        console.log(`Here is the Api response ${result.status}`);
        return {status: result.status, data: result.data};
    }
    catch (error) {
        console.log("NIGGER");
        if (error.response) {
            return {status: error.response.status, message: "Response handling error"};
        }
        else if (error.request) {
            return {status: 0, message: "Request handling error"};
        }
    }
}


export const GetShoppingCartApi = async () => {
    try {
        const result = await axiosClient.get("/ShoppingCart");
        if (result.status === 200) {
            return {status: result.status, cart: result.data};
        }
    }
    catch (error) {
        console.log(error);
        return {status: error.response.status};
    }
}

export const AddShoppingCartApi = async () => {
    try {
        const result = await axiosClient.post("/ShoppingCart");
        if ( result.status === 200 ) {
            console.log("Added shopping cart");
            return { status: result.status };
        }
    }
    catch (error) {
        return {status: result.response.status};
    }
}