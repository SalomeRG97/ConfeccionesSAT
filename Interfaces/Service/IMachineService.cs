using DTO;

namespace Interfaces.Service
{
    public interface IMachineService
    {
        Task Create(MachineDTO dto);
        Task Delete(int Id);
        Task<List<MachineDTO>> GetAll();
        Task<MachineDTO> GetById(int Id);
        Task Update(MachineDTO dto);
    }
}