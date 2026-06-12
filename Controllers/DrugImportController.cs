using ElearingEnglis.services.Drug;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElearingEnglis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugImportController : ControllerBase
    {
        private readonly IDrugImportService _service;

        public DrugImportController(IDrugImportService service)
        {
            _service = service;
        }

        [HttpPost("import-local")]
        public async Task<IActionResult> ImportFromLocal([FromBody] ImportRequest request)
        {
            var inserted = await _service.ImportFromJsonAsync(request.Path);
            return Ok(new { inserted });
        }
    }
}
