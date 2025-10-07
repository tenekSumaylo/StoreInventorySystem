import axiosClient from "./axiosClient"


export const CheckoutApi = async (checkoutInformation) => {
    try {
        console.log(checkoutInformation);
        console.log(`${checkoutInformation.shoppingCartId} -- ${checkoutInformation.CartItems} -- ${checkoutInformation.subTotal}`);
        const result = await axiosClient.post("/Checkout", checkoutInformation);
        return {status: result.status};
    }
    catch (error) {
        if (error.response) {
            console.log("Error thru response");
            console.log(error.message);
            return {status: error.response.status};
        }
        else if (error.request) {
            console.log("Error thru request");
            return {status: 0};
        }
        else {
            return {status: -1}
        }
    }
}