using CloudManagementAPI.Models;
using CloudManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CloudManagementAPI.Controllers
{
    [ApiController]
    [Route("api/virtualmachines")]
    public class VirtualMachinesController : ControllerBase
    {
        private readonly IVirtualMachineService _service;

        public VirtualMachinesController(IVirtualMachineService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<VirtualMachine>>> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<VirtualMachine>> Get(int id)
        {
            var vm = await _service.GetByIdAsync(id);
            if (vm == null) return NotFound();
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VirtualMachine vm)
        {
            await _service.AddAsync(vm);
            return CreatedAtAction(nameof(Get), new { id = vm.Id }, vm);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] VirtualMachine vm)
        {
            if (id != vm.Id) return BadRequest("ID mismatch.");
            await _service.UpdateAsync(vm);
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
