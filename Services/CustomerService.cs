using SampleDotNetDynamo.Models.Entities;
using SampleDotNetDynamo.Repositories;
using SampleDotNetDynamo.Services.Interfaces;

namespace SampleDotNetDynamo.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> CreateCustomerAsync(Customer customer)
        {
            return await _customerRepository.CreateAsync(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
        {
            return await _customerRepository.GetAllAsync();
        }
    }
}
