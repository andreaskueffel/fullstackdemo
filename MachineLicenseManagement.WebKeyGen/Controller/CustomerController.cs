using MachineLicenseManagement.WebKeyGen.Models;
using Microsoft.AspNetCore.Mvc;

namespace MachineLicenseManagement.WebKeyGen.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController:ControllerBase
    {
        private readonly LicenseService _licenseService;
        public CustomerController(LicenseService licenseService)
        {
            _licenseService = licenseService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CustomerModel>> GetAll()
        {
            var customers = _licenseService.GetCustomers();
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Models.CustomerModel customer)
        {
            var success = _licenseService.CreateCustomer(customer);
            if (!success)
                return Conflict("Customer with the same name already exists.");
            return CreatedAtAction(nameof(GetAll), null, customer);
        }

    }
}
