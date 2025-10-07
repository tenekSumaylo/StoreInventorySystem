
using inventory_backend.Data;
using inventory_backend.Models;
using inventory_backend.Repository.InvoiceItemRepository;
using inventory_backend.Repository.InvoiceRepository;
using inventory_backend.Repository.OrderItemRepository;
using inventory_backend.Repository.OrderRepository;
using inventory_backend.Repository.ProductRepository;
using inventory_backend.Repository.ShoppingCartItemRepository;
using inventory_backend.Repository.ShoppingCartRepository;

namespace inventory_backend.UnitOfWorkPattern
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IProductRepository ProductRepository { get; init; }
        public IOrderRepository OrderRepository { get; init; }
        public IOrderItemRepository OrderItemRepository { get; init; }
        public IInvoiceRepository InvoiceRepository { get; init; }
        public IInvoiceItemRepository InvoiceItemRepository { get; init; }
        public IShoppingCartItemRepository ShoppingCartItemRepository { get; init; }
        public IShoppingCartRepository ShoppingCartRepository { get; init; }
        private readonly InventorySystemDbContext _context;
        
        public UnitOfWork(InventorySystemDbContext context)
        {
            _context = context;
            ProductRepository = new ProductRepository(context);
            InvoiceRepository = new InvoiceRepository(context);
            InvoiceItemRepository = new InvoiceItemRepository(context);
            OrderRepository = new OrderRepository(context);
            OrderItemRepository = new OrderItemRepository(context);
            ShoppingCartItemRepository = new ShoppingCartItemRepository(context);
            ShoppingCartRepository = new ShoppingCartRepository(context);
        }

        public Task<bool> Checkout()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
