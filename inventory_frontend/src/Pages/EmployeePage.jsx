import { Flex, Group, Input, Button, HStack } from "@chakra-ui/react";
import AuthorizedHeader from "./../components/layout/AuthorizedHeader";
import { AddItemDialog } from "./../components/dialog/addItemDialog";

const EmployeePage = () => {

    return(
        <div className="min-h-screen bg-gray-100">
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

            </Flex>
        </div>

    );
}

export default EmployeePage;