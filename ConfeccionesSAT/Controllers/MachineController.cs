using DTO;
using Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace ConfeccionesSAT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController(IMachineService _machineService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var dto = await _machineService.GetAll();
            return Ok(dto);
        }

        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var dto = await _machineService.GetById(Id);
            return Ok(dto);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(MachineDTO dto)
        {
            await _machineService.Create(dto);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(MachineDTO dto)
        {
            await _machineService.Update(dto);
            return Ok();
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _machineService.Delete(Id);
            return Ok();
        }
    }
}
