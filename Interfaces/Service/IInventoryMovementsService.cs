using DTO;

namespace Interfaces.Service
{
    public interface IInventoryMovementsService
    {
        Task<List<InventoryMovementsDTO>> GetAll();
        Task updateInventory(InventoryMovementsDTO dto);
    }
}