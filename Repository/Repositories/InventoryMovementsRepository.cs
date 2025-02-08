using Interfaces.Repository.Repositories;
using Models.Models;
using Repository.Base;

namespace Repository.Repositories
{
    public class InventoryMovementsRepository : Repository<InventoryMovement>, IInventoryMovementsRepository
    {
        public InventoryMovementsRepository(ConfeccionesSATDbContext context) : base(context)
        {
        }
    }
}
