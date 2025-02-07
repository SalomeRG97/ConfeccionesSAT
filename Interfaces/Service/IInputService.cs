using DTO;

namespace Interfaces.Service
{
    public interface IInputService
    {
        Task Create(InputDTO dto);
        Task Delete(int Id);
        Task<List<InputDTO>> GetAll();
        Task<InputDTO> GetById(int Id);
        Task Update(InputDTO dto);
    }
}