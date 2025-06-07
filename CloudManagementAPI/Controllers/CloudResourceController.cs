using CloudManagementAPI.Models;
using CloudManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CloudManagementAPI.Services;

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

        [HttpPost("{id}/details")]
        public async Task<ActionResult<string>> GetResourceDetails(int id)
        {
            var resource = await _service.GetByIdAsync(id);
            if (resource == null) return NotFound();


            string result = _service.GetCloudResourceDetails(resource);

            return Ok(result);
        }

        [HttpPost("{id}/action")]
        public async Task<ActionResult<string>> PerformAction(int id, [FromBody] string actionType)
        {
            var resource = await _service.GetByIdAsync(id);
            if (resource == null)
            {
                return NotFound($"Cloud resource with ID {id} not found.");
            }

            string result = _service.PerformCloudResourceAction(resource, actionType);

            return Ok(result);
        }
    }
}
