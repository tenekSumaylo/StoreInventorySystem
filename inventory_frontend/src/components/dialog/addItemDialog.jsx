import { GetCategories } from "./../../Api/CategoryClient";
import { Button, CloseButton, Dialog, Portal, Field, Combobox, GridItem, Box, Input, InputGroup, Text, FileUpload, Icon, useFilter, useListCollection, List, Tag } from "@chakra-ui/react";
import { useEffect, useState } from "react";
import { LuUpload } from "react-icons/lu";
import { useComboBoxData } from "../hooks/comboBoxHook";
import { GetAllKeywords } from "./../../Api/KeywordClient";
export const AddItemDialog = () => {
    const[productName, setProductName] = useState("");
    const[brand, setBrand] = useState("");
    const[price, setPrice] = useState(0);
    const[stock, setStock] = useState(0);
    const[category, setCategory] = useState("");
    const[tag, setTags ] = useState([]);
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

    useEffect(() => {
        console.log("effect");
        InitializeCategories();
    }, []);

    useEffect(() => {
        InitializeKeywords();
    }, []);


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
                                        <Box  w="100%" h="full" spaceY={5}>
                                            <FileUpload.Root maxW="xl" alignItems="stretch" maxFiles={1} accept="image/*">
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
                                                {keywordBox.collection.items.map((item) => (
                                                <Combobox.Item item={item} key={item.id}>
                                                    {item.tag}
                                                    <Combobox.ItemIndicator />
                                                </Combobox.Item>
                                                ))}
                                            </Combobox.Content>
                                            </Combobox.Positioner>
                                            </Combobox.Root>          
                                            <Tag.Root>
                                                <Tag.Label>Norwen</Tag.Label>
                                                <Tag.EndElement>
                                                    <Tag.CloseTrigger/>
                                                </Tag.EndElement>
                                            </Tag.Root>
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
                                                    <Input/>
                                                    <Field.ErrorText></Field.ErrorText>
                                                </Field.Root>
                                                <Field.Root w="sm" color="black"> 
                                                    <Field.Label>Price
                                                        <Field.RequiredIndicator/>
                                                    </Field.Label>
                                                    <InputGroup startElement="P" endElement="PHP" w="sm">
                                                        <Input placeholder="0.00" type="number"/>
                                                    </InputGroup>
                                                    <Field.ErrorText></Field.ErrorText>
                                                </Field.Root>      
                                                <Field.Root w="sm" color="black"> 
                                                    <Field.Label>Stock
                                                        <Field.RequiredIndicator/>
                                                    </Field.Label>
                                                    <InputGroup startElement="P" endElement="PHP" w="sm">
                                                        <Input placeholder="0.00" type="number"/>
                                                    </InputGroup>
                                                    <Field.ErrorText></Field.ErrorText>
                                                </Field.Root>    
                                                <Combobox.Root
                                                collection={categoryBox.collection}
                                                onInputValueChange={(e) => categoryBox.filter(e.inputValue)}
                                                width="sm"
                                                
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
                                <Button variant="solid">Save Product</Button>
                            </Dialog.Footer>
                        </Dialog.Content>
                    </Dialog.Positioner>
                </Dialog.Backdrop>
            </Portal>
        </Dialog.Root>
    );
}