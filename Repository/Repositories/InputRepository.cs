using Interfaces.Repository.Repositories;
using Models.Models;
using Repository.Base;

namespace Repository.Repositories
{
    public class InputRepository : Repository<Input>, IInputRepository
    {
        public InputRepository(ConfeccionesSATDbContext context) : base(context)
        {
        }
    }
}
