using SampleDotNetDynamo.Models.Entities;

namespace SampleDotNetDynamo.Repositories
{
    public interface ICustomerRepository
    {
        Task<bool> CreateAsync(Customer customer);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetById(Guid id);
    }
}
