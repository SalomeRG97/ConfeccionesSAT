using Interfaces.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using MySql.Data.MySqlClient;
using Repository.Base;

namespace Repository.Repositories
{
    public class InputRepository : Repository<Input>, IInputRepository
    {
        public InputRepository(ConfeccionesSATDbContext context) : base(context)
        {
        }

        public async Task update_inventory(int id_input, int quant, string movement_type)
        {
            var parameters = new[]
            {
                new MySqlParameter("id_input", id_input),
                new MySqlParameter("quant", quant),
                new MySqlParameter("movement_type", movement_type)
            };

            await _context.Database.ExecuteSqlRawAsync("CALL update_inventory(?, ?, ?)", parameters);
        }
    }
}
