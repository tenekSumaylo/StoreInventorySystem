
using inventory_backend.Data;
using inventory_backend.Models;
using inventory_backend.Repository.InvoiceItemRepository;
using inventory_backend.Repository.InvoiceRepository;
using inventory_backend.Repository.ProductRepository;

namespace inventory_backend.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRepository ProductRepository { get; init; }
        public IInvoiceRepository InvoiceRepository { get; init; }
        public IInvoiceItemRepository InvoiceItemRepository { get; init; }
        private readonly InventorySystemDbContext _context;
        
        public UnitOfWork(InventorySystemDbContext context)
        {
            _context = context;
            ProductRepository = new ProductRepository(context);
            InvoiceRepository = new InvoiceRepository(context);
            InvoiceItemRepository = new InvoiceItemRepository(context);
        }

        public Task<bool> Checkout()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
