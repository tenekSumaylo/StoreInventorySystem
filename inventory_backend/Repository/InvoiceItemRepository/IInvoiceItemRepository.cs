using inventory_backend.Models;
using inventory_backend.Repository.GenericRepository;

namespace inventory_backend.Repository.InvoiceItemRepository
{
    public interface IInvoiceItemRepository : IGenericRepository<InvoiceItem>
    {
    }
}
