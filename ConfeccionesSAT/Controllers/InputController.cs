using DTO;
using Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace ConfeccionesSAT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputController(IInputService _inputService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var dto = await _inputService.GetAll();
            return Ok(dto);
        }

        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var dto = await _inputService.GetById(Id);
            return Ok(dto);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(InputDTO dto)
        {
            await _inputService.Create(dto);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(InputDTO dto)
        {
            await _inputService.Update(dto);
            return Ok();
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _inputService.Delete(Id);
            return Ok();
        }
    }
}
