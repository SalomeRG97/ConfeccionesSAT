using DTO;
using Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace ConfeccionesSAT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryMovementsController(IInventoryMovementsService _inventoryMovementsService) : ControllerBase
    {

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var dto = await _inventoryMovementsService.GetAll();
            return Ok(dto);
        }

        [HttpPost("UpdateInventory")]
        public async Task<IActionResult> Create(InventoryMovementsDTO dto)
        {
            await _inventoryMovementsService.updateInventory(dto);
            return Ok();
        }
    }
}
