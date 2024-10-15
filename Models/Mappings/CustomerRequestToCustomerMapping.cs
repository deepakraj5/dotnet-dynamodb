using SampleDotNetDynamo.Models.Dto;
using SampleDotNetDynamo.Models.Entities;

namespace SampleDotNetDynamo.Models.Mappings
{
    public static class CustomerRequestToCustomerMapping
    {
        public static Customer ToCustomer(this CreateCustomerRequest customerRequest)
        {
            return new Customer
            {
                Id = Guid.NewGuid(),
                Name = customerRequest.Name,
                Email = customerRequest.Email
            };
        }
    }
}
