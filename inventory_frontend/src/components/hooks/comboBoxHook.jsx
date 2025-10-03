import { useFilter, useListCollection } from "@chakra-ui/react"

export const useComboBoxData = () => {
    const {contains} = useFilter( {sensitivity: "base"});
    const { collection, filter, set } = useListCollection( {
        initialItems: [],
        filter: contains,
        itemToString: (item) => item.name || item.tag,
        itemToValue: (item) => item.name || item.tag
    });

    return { collection, filter, set };
}