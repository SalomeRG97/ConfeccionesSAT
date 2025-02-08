using Interfaces.Repository.Base;
using Models.Models;

namespace Interfaces.Repository.Repositories
{
    public interface IInputRepository : IRepository<Input>
    {
        Task update_inventory(int id_input, int quant, string movement_type);
    }
}
