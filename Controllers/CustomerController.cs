using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleDotNetDynamo.Models.Dto;
using SampleDotNetDynamo.Models.Mappings;
using SampleDotNetDynamo.Services.Interfaces;

namespace SampleDotNetDynamo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            var customer = request.ToCustomer();
            var response = await _customerService.CreateCustomerAsync(customer);

            return Ok(new { message = "Customer created successfully" });
        }

        [HttpGet]
        public async Task<IActionResult> ListCustomers()
        {
            var response = await _customerService.GetAllCustomerAsync();

            return Ok(response);
        }
    }
}
