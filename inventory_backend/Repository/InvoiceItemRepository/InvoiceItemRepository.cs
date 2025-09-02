using inventory_backend.Data;
using inventory_backend.Models;
using inventory_backend.Repository.InvoiceRepository;
using inventory_backend.Repository.GenericRepository;

namespace inventory_backend.Repository.InvoiceItemRepository
{
    public class InvoiceItemRepository : GenericRepository<InvoiceItem>, IInvoiceItemRepository
    {
        public InvoiceItemRepository(InventorySystemDbContext context) : base(context) { }
    }
}
