using inventory_backend.Data;
using inventory_backend.Models;
using inventory_backend.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace inventory_backend.Repository.InvoiceRepository
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(InventorySystemDbContext inventory ) : base(inventory)
        {

        }

        public async Task<IEnumerable<Invoice>> GetAllByCustomer(Guid customerId)
        {
            return await _dbSet.Where(i => i.CustomerId == customerId)
                .Include(x => x.InvoiceItems)
                .Select(i => i).ToListAsync();
        }
    }
}
