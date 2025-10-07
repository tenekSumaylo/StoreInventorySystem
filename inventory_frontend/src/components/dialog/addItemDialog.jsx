import { GetCategories } from "./../../Api/CategoryClient";
import { Button, CloseButton, Dialog, Portal, Field, Combobox, GridItem, Box, Input, InputGroup, Text, FileUpload, Icon, useFilter, useListCollection, List, Tag, useFileUpload } from "@chakra-ui/react";
import { useEffect, useState } from "react";
import { LuUpload } from "react-icons/lu";
import { useComboBoxData } from "../hooks/comboBoxHook";
import { GetAllKeywords } from "./../../Api/KeywordClient";
import { AddProductApi } from "./../../Api/ProductClient";
import { toaster } from "./../../components/ui/toaster";
export const AddItemDialog = () => {
    const[productName, setProductName] = useState("");
    const[brand, setBrand] = useState("");
    const[price, setPrice] = useState(0);
    const[stock, setStock] = useState(0);
    const[category, setCategory] = useState("");
    const[tags, setTags ] = useState([]);
    const[image, setImage] = useState([]);
    const categoryBox = useComboBoxData();
    const keywordBox = useComboBoxData();
    const InitializeCategories = () => {
         GetCategories()
        .then( response => {
            console.log(response);
            console.log("YAWA");
            console.log(response.result);
            categoryBox.set(response.result ?? []);
            console.log("otin");
        })
        .catch(error => {
            console.log(error);
            categoryBox.set([]);
        });
    }

    const InitializeKeywords = () => {
        console.log("Getting keywords");
        GetAllKeywords()
        .then( response => {
            console.log("KEYWORDS");
            console.log(response.result);
            keywordBox.set( response.result ?? []);
        })
        .catch( error => {
            console.log(error);
            console.log("ERROR ASSS");
            keywordBox.set([]);
        })
    }

    const handleValueChange = (details) => {
        console.log("Handled");
        console.log(details.items);
        setTags(details.items);
    }

    useEffect(() => {
        console.log("effect");
        InitializeCategories();
    }, []);

    useEffect(() => {
        InitializeKeywords();
    }, []);

    const handleAddProduct = (e) => {
        e.preventDefault();
        console.log(category);
        const base64String = btoa(
        new Uint8Array(image).reduce((data, byte) => data + String.fromCharCode(byte), '')
        );
        const productInformation = {
            categoryId: category,
            productName: productName,
            brand: brand,
            price: Number(price),
            stock: Number(stock),
            tags: tags,
            productImage: base64String
        };
        console.log(productInformation);
        AddProductApi(productInformation)
        .then(response => {
            console.log(response.status);
            toaster.create({
                description: "Product Added Successfully",
                type: "success",
                closable: true
            });
            setCategory("");
            setProductName("");
            setBrand("");
            setPrice(0);
            setStock(0);
            setTags([]);
            setImage([]);
        })
        .catch(error =>{
            console.log(error);
        });

    }

    return(
        <Dialog.Root size="cover" placement="center" motionPreset="slide-in-bottom">
            <Dialog.Trigger asChild>
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
                                <div className="flex flex-row" >
                                        <Box  w="100%" h="full" spaceY={5} display="flex" flexDirection="column" alignItems="center">
                                            <FileUpload.Root maxW="xl" 
                                            
                                            alignItems="stretch" maxFiles={1} 
                                                accept="image/*"
                                                onFileChange={ async (e) => {
                                                        const file = e.acceptedFiles[0];
                                                        if (!file) return;
                                                        const buffer = await file.arrayBuffer();
                                                        const byteArr = new Uint8Array(buffer);
                                                        console.log("THIS IS IT");
                                                        console.log(byteArr);
                                                        setImage(byteArr);
                                                        //const blob = new Blob([byteArr], {type: "image/png"});
                                                        //const previewUrl = URL.createObjectURL(blob);
                                                        //console.log("Preview", previewUrl);
                                                }}
                                                >
                                                <FileUpload.HiddenInput />
                                                <FileUpload.Dropzone>
                                                    <Icon size="md" color="fg.muted">
                                                    <LuUpload />
                                                    </Icon>
                                                    <FileUpload.DropzoneContent>
                                                    <Box>Drag and drop files here</Box>
                                                    <Box color="fg.muted">.png, .jpg up to 5MB</Box>
                                                    </FileUpload.DropzoneContent>
                                                </FileUpload.Dropzone>
                                                <FileUpload.List />
                                            </FileUpload.Root>

                                            <Combobox.Root
                                            collection={keywordBox.collection}
                                            onInputValueChange={(e) => keywordBox.filter(e.inputValue)}
                                            width="sm"
                                            onValueChange={handleValueChange}
                                            multiple
                                            >
                                            <Combobox.Label>Select Keyword</Combobox.Label>
                                            <Combobox.Control>
                                                <Combobox.Input placeholder="Type to search" />
                                                <Combobox.IndicatorGroup>
                                                <Combobox.ClearTrigger />
                                                <Combobox.Trigger />
                                                </Combobox.IndicatorGroup>
                                            </Combobox.Control>
                                            
                                            <Combobox.Positioner>
                                            <Combobox.Content>
                                                <Combobox.Empty>No items found</Combobox.Empty>
                                                {keywordBox.collection.items.map((item) => (
                                                <Combobox.Item item={item} key={item.id}>
                                                    {item.tag}
                                                    <Combobox.ItemIndicator />
                                                </Combobox.Item>
                                                ))}
                                            </Combobox.Content>
                                            </Combobox.Positioner>
                                            </Combobox.Root>          
                                            { tags && ( 
                                                <div className="flex flex-row gap-5">
                                                {tags.map((items) =>  
                                                (
                                                        <Tag.Root key={items.id}>
                                                            <Tag.Label>{items.tag}</Tag.Label>
                                                            <Tag.EndElement>
                                                                <Tag.CloseTrigger onClick={(e) => setTags((prev) => prev.filter(t => t.id !== items.id))}/>
                                                            </Tag.EndElement>
                                                        </Tag.Root>
                                                ))}
                                                </div>
                                                )
                                            }
                                        </Box>
                                        <Box w="100%" h="100%">
                                            <form className="flex flex-col items-center gap-4">
                                                <Field.Root w="sm" color="black"> 
                                                    <Field.Label>Product Name
                                                        <Field.RequiredIndicator/>
                                                    </Field.Label>
                                                    <Input value={productName}
                                                        onChange={(e) => setProductName(e.target.value)}/>
                                                    <Field.ErrorText></Field.ErrorText>
                                                </Field.Root>
                                                <Field.Root w="sm" color="black"> 
                                                    <Field.Label>Brand
                                                        <Field.RequiredIndicator/>
                                                    </Field.Label>
                                                    <Input value={brand}
                                                        onChange={(e) => setBrand(e.target.value)}/>
                                                    <Field.ErrorText></Field.ErrorText>
                                                </Field.Root>
                                                <Field.Root w="sm" color="black"> 
                                                    <Field.Label>Price
                                                        <Field.RequiredIndicator/>
                                                    </Field.Label>
                                                    <InputGroup startElement="P" endElement="PHP" w="sm">
                                                        <Input placeholder="0.00" 
                                                            type="number"
                                                            value={price}
                                                            onChange={(e)=> setPrice(e.target.value)}/>
                                                    </InputGroup>
                                                    <Field.ErrorText></Field.ErrorText>
                                                </Field.Root>      
                                                <Field.Root w="sm" color="black"> 
                                                    <Field.Label>Stock
                                                        <Field.RequiredIndicator/>
                                                    </Field.Label>
                                                    <InputGroup startElement="P" endElement="PHP" w="sm">
                                                        <Input placeholder="0.00"
                                                             type="number"
                                                             value={stock}
                                                             onChange={(e) => setStock(e.target.value)}/>
                                                    </InputGroup>
                                                    <Field.ErrorText></Field.ErrorText>
                                                </Field.Root>    

                                                <Combobox.Root
                                                collection={categoryBox.collection}
                                                onInputValueChange={(e) => categoryBox.filter(e.inputValue)}
                                                width="sm"
                                                onValueChange={(e) => {
                                                    console.log(e);  
                                                    if (e.items.length === 0){
                                                        return;
                                                    }
                                                    console.log(e.items[0].id);  
                                                    setCategory(e.items[0].id)
                                                }}
                                                >
                                                <Combobox.Label>Select Category</Combobox.Label>
                                                <Combobox.Control>
                                                    <Combobox.Input placeholder="Type to search" />
                                                    <Combobox.IndicatorGroup>
                                                    <Combobox.ClearTrigger />
                                                    <Combobox.Trigger />
                                                    </Combobox.IndicatorGroup>
                                                </Combobox.Control>
                                                
                                                <Combobox.Positioner>
                                                <Combobox.Content>
                                                    <Combobox.Empty>No items found</Combobox.Empty>
                                                    {categoryBox.collection.items.map((item) => (
                                                    <Combobox.Item item={item} key={item.id}>
                                                        {item.name}
                                                        <Combobox.ItemIndicator />
                                                    </Combobox.Item>
                                                    ))}
                                                </Combobox.Content>
                                                </Combobox.Positioner>
                                                </Combobox.Root>                                                
                                            </form>
                                        </Box>
                                </div>
                            </Dialog.Body>
                            <Dialog.Footer>
                                <Dialog.ActionTrigger asChild>
                                    <Button variant="outline">
                                        Cancel
                                    </Button>
                                </Dialog.ActionTrigger>
                                <Button variant="solid" onClick={handleAddProduct}>Save Product</Button>
                            </Dialog.Footer>
                        </Dialog.Content>
                    </Dialog.Positioner>
                </Dialog.Backdrop>
            </Portal>
        </Dialog.Root>
    );
}