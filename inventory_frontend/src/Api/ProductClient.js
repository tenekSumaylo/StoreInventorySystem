import axiosClient from "./axiosClient"

export const AddProductApi = async (productInformation) => {
    console.log("HERE");
    console.log(productInformation);
    const result = await axiosClient.post("/Products", productInformation);
    try {
        if ( result.status === 200 ) {
            console.log("ANIMAL");
            console.log(result.data);
            console.log(result.data.addProduct);
            if ( result.data ) {
                console.log("Added product successfully");
                return {status: result.status};
            }
        }
    }
    catch (error) {
        console.log(error);
        return {status: error.response.status};
    }
}

export const GetPaginatedProductsApi = async (search, page, pageSize, item) => {
    try {
        console.log("API");
        console.log(search);
        const result = await axiosClient.get("/Products/PaginatedProducts", {
        params : {
            searchParam: search,
            page: page,
            pageSize: pageSize,
            dto: item
        }
        });
        console.log(result);
        if ( result.status === 200 ) {
            console.log("Paginated");
            console.log(result);
            return {status: result.status, products: result.data}
        }
    }
    catch (error) {
        return {status: error.response.status};
    }
}

export const UpdateProductApi = async (id, item) => {
    try {
        console.log("the item");
        console.log(id);
        console.log(item);
        const result = await axiosClient.put(`/Products/${id}`);
        if ( result.status === 200 ) {
            return {status: result.status};
        }
        else {
            return {status: result.status};
        }
    }
    catch (error) {
        if ( error.response ) {
            return {status: error.response.status};
        }
        else if ( error.request ) {
            return { status: 0};
        }
        else {
            return {status: -1};
        }
    }
}