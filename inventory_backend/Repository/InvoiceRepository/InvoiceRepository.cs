using inventory_backend.Data;
using inventory_backend.Models;
using inventory_backend.Repository.GenericRepository;

namespace inventory_backend.Repository.InvoiceRepository
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(InventorySystemDbContext inventory ) : base(inventory)
        {

        }
    }
}
