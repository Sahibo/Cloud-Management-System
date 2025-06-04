using CloudManagementAPI.Models;
using CloudManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CloudManagementAPI.Controllers
{
    [ApiController]
    [Route("api/storagebuckets")]
    public class StorageBucketsController : ControllerBase
    {
        private readonly IStorageBucketService _service;

        public StorageBucketsController(IStorageBucketService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<StorageBucket>>> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<StorageBucket>> Get(int id)
        {
            var bucket = await _service.GetByIdAsync(id);
            if (bucket == null) return NotFound();
            return Ok(bucket);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StorageBucket bucket)
        {
            await _service.AddAsync(bucket);
            return CreatedAtAction(nameof(Get), new { id = bucket.Id }, bucket);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] StorageBucket bucket)
        {
            if (id != bucket.Id) return BadRequest("ID mismatch.");
            await _service.UpdateAsync(bucket);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
