using Microsoft.AspNetCore.Mvc;

namespace MachineLicenseManagement.WebKeyGen.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class LicenseController:ControllerBase
    {
        private readonly LicenseService _licenseService;
        public LicenseController(LicenseService licenseService)
        {
            _licenseService = licenseService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var licenses = _licenseService.GetAll();
            return Ok(licenses);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var license = _licenseService.GetById(id);
            if (license == null)
                return NotFound();
            return Ok(license);
        }
        [HttpPost]
        public IActionResult Create([FromBody] LicenseModel license)
        {
            var id = _licenseService.Create(license);
            return CreatedAtAction(nameof(GetById), new { id }, license);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _licenseService.Delete(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
