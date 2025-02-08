using AutoMapper;
using Interfaces.Repository.Base;

namespace Services
{
    public class InventoryMovementsService(IUnitOfWork _unitOfWork, IMapper _mapper)
    {
        public async Task update_inventory(int id_input, int quant, string movement_type)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {

            }
            await _unitOfWork.InputRepository.update_inventory(id_input, quant, movement_type);
            await _unitOfWork.Commit();
        }
    }
}
