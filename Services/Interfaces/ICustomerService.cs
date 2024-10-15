using SampleDotNetDynamo.Models.Entities;

namespace SampleDotNetDynamo.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> CreateCustomerAsync(Customer customer);
        Task<IEnumerable<Customer>> GetAllCustomerAsync();
    }
}
