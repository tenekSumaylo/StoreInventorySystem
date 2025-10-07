using inventory_backend.Repository.InvoiceItemRepository;
using inventory_backend.Repository.InvoiceRepository;
using inventory_backend.Repository.OrderItemRepository;
using inventory_backend.Repository.OrderRepository;
using inventory_backend.Repository.ProductRepository;
using inventory_backend.Repository.ShoppingCartItemRepository;
using inventory_backend.Repository.ShoppingCartRepository;

namespace inventory_backend.UnitOfWorkPattern
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; init; }
        IOrderRepository OrderRepository { get; init; }
        IOrderItemRepository OrderItemRepository { get; init; }
        IInvoiceRepository InvoiceRepository { get; init; }
        IInvoiceItemRepository InvoiceItemRepository { get; init; }
        IShoppingCartItemRepository ShoppingCartItemRepository { get; init; }
        IShoppingCartRepository ShoppingCartRepository { get; init; }
        Task<bool> Checkout();
        Task<bool> SaveChangesAsync();
    }
}
