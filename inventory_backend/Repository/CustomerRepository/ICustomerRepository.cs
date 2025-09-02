using inventory_backend.Repository.GenericRepository;
using inventory_backend.Models;
namespace inventory_backend.Repository.CustomerRepository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }
}
