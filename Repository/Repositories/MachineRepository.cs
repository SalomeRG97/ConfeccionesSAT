using Interfaces.Repository.Repositories;
using Models.Models;
using Repository.Base;

namespace Repository.Repositories
{
    public class MachineRepository : Repository<Machine>, IMachineRepository
    {
        public MachineRepository(ConfeccionesSATDbContext context) : base(context)
        {
        }
    }
}
