using CloudManagementAPI.Models;
using CloudManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CloudManagementAPI.Controllers
{
    [ApiController]
    [Route("api/cloudresources")]
    public class CloudResourcesController : ControllerBase
    {
        private readonly ICloudResourceService _service;

        public CloudResourcesController(ICloudResourceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<CloudResource>>> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<CloudResource>> Get(int id)
        {
            var resource = await _service.GetByIdAsync(id);
            if (resource == null) return NotFound();
            return Ok(resource);
        }
    }
}
