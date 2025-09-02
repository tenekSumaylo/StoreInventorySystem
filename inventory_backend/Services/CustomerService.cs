using inventory_backend.Repository.CustomerRepository;

namespace inventory_backend.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;   

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


    }
}
