using MachineLicenseManagement.WebKeyGen.Models;
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
        public ActionResult<IEnumerable<LicenseModel>> GetAll()
        {
            var licenses = _licenseService.GetLicenses();
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
            var id = _licenseService.SaveLicense(license);
            return CreatedAtAction(nameof(GetById), new { id }, license);
        }
        
    }
}
