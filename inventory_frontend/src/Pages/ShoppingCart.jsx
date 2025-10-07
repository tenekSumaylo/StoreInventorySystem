import { GetShoppingCartApi } from './../Api/ShoppingCartClient';
import AuthorizedHeader from './../components/layout/AuthorizedHeader';
import {
  Box,
  Flex,
  Grid,
  Text,
  Heading,
  Image,
  HStack,
  IconButton,
  Input,
  Button,
  VStack,
  Icon,
} from '@chakra-ui/react';
import { Plus, CircleX, Minus, ArrowBigLeft,  } from 'lucide-react';
import { FaCcVisa, FaCreditCard, FaRegCreditCard } from 'react-icons/fa';
import { useState, useEffect } from 'react';
import { deleteCartItem, shoppingCartInitialize, updateCart } from './../components/shoppingCartFunctions/shoppingCartCalls';
import { toaster, Toaster } from "./../components/ui/toaster";
import { CheckoutApi } from './../Api/CheckoutClient';

const calculateSubtotal = (items) => {
  return items.reduce((accumulator, item, pos ) => {
    return accumulator + item.quantity * item.product.price;
  }, 0);
};

// --- Cart Item Component ---
const CartItem = ({ item, setCart  }) => (
  <Flex
    align="center"
    justify="space-between"
    py={4}
    borderBottom="1px solid"
    borderColor="gray.100"
  >
    <HStack spacing={4} flex="1">
      {/* Product Image - You would replace the src with your API's productImage URL */}
      <Image
        src={`data:image/jpeg;base64,${item.product.productImage}`}
        onError={(e) => e.target.src = `data:image/png;base64,${item.product.productImage}`}
        alt="Product Picture"
        width="100%"
        height="120px"
        objectFit="contain"
        p="2"
      />
      <Box>
        <Text fontWeight="medium">{item.product.productName}</Text>
        <Text fontSize="sm" color="gray.500">
          Ref: {item.id}
        </Text>
      </Box>
    </HStack>

    <Text color="gray.600" w="80px" textAlign="left" display={{ base: 'none', md: 'block' }}>
      {item.color}
    </Text>

    <HStack w="120px" justify="center">
      <IconButton
        aria-label="Decrease quantity"
        size="xs"
        variant="outline"
        borderRadius="full"
        onClick={async () => {
            await updateCart({ id: item.id, quantity: item.quantity - 1});
            console.log(item);
            shoppingCartInitialize(setCart);
        }}>
            <Minus/>
        </IconButton>
      <Text>{item.quantity}</Text>
      <IconButton
        aria-label="Increase quantity"
        size="xs"
        variant="outline"
        borderRadius="full"
        onClick={async () => {
            await updateCart({ id: item.id, quantity: item.quantity + 1});
            console.log(item);
            shoppingCartInitialize(setCart);
        }}>
            <Plus/>
        </IconButton>
    </HStack>

    <Text fontWeight="medium" w="100px" textAlign="right">
      {/* Format price to NGN */}
      {new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD',
        minimumFractionDigits: 2,
      }).format(item.quantity * item.product.price)}
    </Text>

    <IconButton
      aria-label="Remove item"
      size="xs"
      variant="ghost"
      ml={4}
      onClick={async () => {
        await deleteCartItem({id: item.id});
        shoppingCartInitialize(setCart);
      }} // Implement state update
    ><CircleX/></IconButton>
  </Flex>
);

// --- Card Details Form Component ---
const CardDetails = ({id, cart, subtotal, setCart}) => (
  <VStack
    as="form"
    spacing={6}
    p={8}
    w={{ base: 'lg', lg: '300px' }}
    bg="black"
    color="white"
    position={{ base: 'relative', lg: 'fixed' }}
    right="0"
    top="14"
    bottom="0"
    boxShadow="xl"
    align="stretch"
    borderRadius={{ base: 'lg', lg: 'none' }}
  >
    <Heading size="md" color="yellow.400" mt={4}>
      Card Details
    </Heading>

    <Box>
      <Text fontSize="sm" mb={2}>
        Select Card Type
      </Text>
      <HStack spacing={4}>
        <Icon as={FaCcVisa} boxSize={8} color="white" />
        <Text fontSize="xl" fontWeight="bold">
          VISA
        </Text>
        <Icon as={FaRegCreditCard} boxSize={8} color="gray.600" /> {/* Generic Verve Icon */}
        <Text fontSize="xl" color="gray.600">
          Verve
        </Text>
      </HStack>
    </Box>

    <VStack align="stretch" spacing={4}>
      <Input
        placeholder="Card Number"
        variant="flushed"
        color="white"
        _placeholder={{ color: 'gray.400' }}
        borderColor="gray.500"
      />
      <HStack>
        <Input
          placeholder="Expiry Date (MM/YY)"
          variant="flushed"
          color="white"
          _placeholder={{ color: 'gray.400' }}
          borderColor="gray.500"
        />
        <Input
          placeholder="CVV"
          variant="flushed"
          color="white"
          _placeholder={{ color: 'gray.400' }}
          borderColor="gray.500"
          w="80px"
        />
      </HStack>
    </VStack>

    <Box flexGrow={1} /> {/* Spacer */}

    <Button
      size="lg"
      bg="white"
      color="black"
      _hover={{ bg: 'whiteAlpha.900' }}
      fontWeight="bold"
      onClick={async () => {
        await CheckoutApi({
          shoppingCartId: id,
          CartItems: cart,
          subTotal: subtotal
        })
        .then(response => {
          if (response.status === 200 ) {
            toaster.create({
                description: "Checkout Successful!",
                type: "success",
                closable: true
            });
            shoppingCartInitialize(setCart);
          }
          else {
            toaster.create({
                description: "Checkout Failed!",
                type: "error",
                closable: true
            });
          }

        })
        .catch(error => {
            toaster.create({
                description: "Checkout Failed!",
                type: "error",
                closable: true
            });
        });
      }}
    >
      Checkout
    </Button>
  </VStack>
);

// --- Main Shopping Cart View Component ---
const ShoppingCart = () => {
  const[cart, setCart] = useState(null);
  const[subtotal, setSubtotal] = useState(0);

  useEffect(() => {
    shoppingCartInitialize(setCart);
  }, []);

  useEffect(() => {
    if ( cart && cart.cartItems) {
        setSubtotal(calculateSubtotal(cart.cartItems));
    }
  },[cart]);
  return (
    <Flex direction="column">
        <Toaster/>
        <AuthorizedHeader/>
        <Grid
        templateColumns={{ base: '1fr', lg: '3fr 1fr' }}
        gap={0}
        minH="100vh"
        maxW="1400px"
        mx="auto"
        >
        {/* Left Section: Shopping Cart */}
        <Box p={{ base: 4, md: 10 }} bg="white">
            <HStack mb={8} spacing={4} align="center">
            {/* A simple logo placeholder */}
            <Box w="30px" h="30px" bg="gray.900" borderRadius="full" />
            <Heading size="lg" fontWeight="light">
                Your Shopping Cart
            </Heading>
            </HStack>

            <VStack spacing={0} align="stretch" mb={8}>
            {/* Map over the cart items */}
            {cart && cart.cartItems.map((item) => (
                <CartItem key={item.id} item={item} setCart={setCart} />
            ))}
            </VStack>

            <Flex justify="space-between" align="center" mt={10}>
            <HStack
                as="a"
                href="#" // Replace with React Router Link
                spacing={2}
                color="gray.600"
                _hover={{ color: 'gray.900' }}
                onClick={(e) => {
                e.preventDefault();
                console.log('Go back to shop');
                }}
            >
                <Icon as={ArrowBigLeft} />
                <Text fontWeight="medium">Back to Shop</Text>
            </HStack>

            <HStack spacing={4}>
                <Text fontSize="lg" fontWeight="light">
                Subtotal:
                </Text>
                <Text fontSize="xl" fontWeight="bold">
                {new Intl.NumberFormat('en-US', {
                    style: 'currency',
                    currency: 'USD',
                    minimumFractionDigits: 2,
                }).format(subtotal)}
                </Text>
            </HStack>
            </Flex>
        </Box>

        {/* Right Section: Card Details (Fixed on large screens) */}
        <CardDetails id={cart?.shoppingCartId} cart={cart?.cartItems} subtotal={subtotal} setCart={setCart}/>
        </Grid>
    </Flex>

  );
};

export default ShoppingCart;