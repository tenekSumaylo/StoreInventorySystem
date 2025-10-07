using inventory_backend.Dtos;
using inventory_backend.Models;

namespace inventory_backend.Mapper.CustomMapper
{
    public static class DtoMappers
    {
        public static ProductResponseDto ToDto(this Product product) =>
            new ProductResponseDto(product.Id, product.ProductName, product.Brand, product.Price, product.Stock, product.Tags.Select( b => new TagResponseDto(b.Id, b!.Tag!.Tag)), product.ProductImage);
       

        public static IEnumerable<ProductResponseDto> ToDto(this IEnumerable<Product> product) => product.Select(product => new ProductResponseDto(product.Id, product.ProductName, product.Brand, product.Price, product.Stock, product.Tags.Select(b => new TagResponseDto(b.Id, b!.Tag!.Tag)), product.ProductImage));
       

        public static ShoppingCartResponseDto ToDto(this ShoppingCart cart) =>
            new ShoppingCartResponseDto(cart.Id, cart.CartItems.Select(b => new ShoppingCartItemResponseDto(b.Id, b.ShoppingCartId,new ProductResponseDto(b.ProductId, b!.Product!.ProductName,
                b.Product.Brand, b.Product.Price, b.Product.Stock, b.Product.Tags.Select(b => new TagResponseDto(b.Id, b!.Tag!.Tag)), b.Product.ProductImage), b.Quantity)));

        public static ShoppingCart ToEntity(this CheckoutRequestDto checkout, Guid customerId) =>
            new ShoppingCart()
            {
                Id = checkout.ShoppingCartId,
                CustomerId = customerId
            };

        public static IEnumerable<Product> ToEntity(this IEnumerable<ProductCheckoutRequestDto> products) =>
            products.Select(b =>
            {
                return new Product()
                {
                    Id = b.Id,
                    ProductName = b.ProductName,
                    Brand = b.Brand,
                    Price = b.Price,
                    Stock = b.Stock,
                    ProductImage = b.ProductImage
                };
            });

        public static IEnumerable<ShoppingCartItem> ToEnumerableEntity(this IEnumerable<ShoppingCartItemRequestCheckout> dto )
        {
            return dto.Select(b => new ShoppingCartItem()
            {
                ProductId = b.Product.Id,
                ShoppingCartId = b.ShoppingCartId,
                Quantity = b.Quantity,
                Product = new Product()
                {
                    Id = b.Product.Id,
                    ProductName = b.Product.ProductName,
                    Brand = b.Product.Brand,
                    Price = b.Product.Price,
                    Stock = b.Product.Stock,
                    ProductImage = b.Product.ProductImage
                }
            });
        }

        public static Product ToEntity(this ProductResponseDto dto) =>
            new Product()
            {
                Id = dto.Id,

            };
        
    }
}
