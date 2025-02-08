using AutoMapper;
using DTO;
using Interfaces.Repository.Base;
using Interfaces.Service;
using Models.Models;

namespace Services
{
    public class InventoryMovementsService(IUnitOfWork _unitOfWork, IMapper _mapper) : IInventoryMovementsService
    {
        public async Task updateInventory(InventoryMovementsDTO dto)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var entity = _mapper.Map<InventoryMovement>(dto);
                    _unitOfWork.InventoryMovementsRepository.AddAsync(entity);
                    await _unitOfWork.Commit();

                    await _unitOfWork.InputRepository.update_inventory(dto.IdInput, dto.Lot, dto.Type);
                    await _unitOfWork.Commit();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }

        }

        public async Task<List<InventoryMovementsDTO>> GetAll()
        {
            var data = await _unitOfWork.InventoryMovementsRepository.GetAllAsync();
            return _mapper.Map<List<InventoryMovementsDTO>>(data);
        }
    }
}
