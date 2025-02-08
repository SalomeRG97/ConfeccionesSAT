using AutoMapper;
using DTO;
using Interfaces.Repository.Base;
using Interfaces.Service;
using Models.Models;

namespace Services
{
    public class MachineService(IUnitOfWork _unitOfWork, IMapper _mapper) : IMachineService
    {
        public async Task<List<MachineDTO>> GetAll()
        {
            var data = await _unitOfWork.MachineRepository.GetAllAsync();
            return _mapper.Map<List<MachineDTO>>(data);
        }

        public async Task<MachineDTO> GetById(int Id)
        {
            var data = await _unitOfWork.MachineRepository.GetOne(x => x.Id == Id);
            if (data == null)
            {
                return new MachineDTO();
            }
            return _mapper.Map<MachineDTO>(data);
        }

        public async Task Create(MachineDTO dto)
        {
            var data = await _unitOfWork.MachineRepository.GetOne(x => x.Id == dto.Id);
            if (data != null)
            {
                return;
            }
            var entity = _mapper.Map<Machine>(dto);
            _unitOfWork.MachineRepository.AddAsync(entity);
            await _unitOfWork.Commit();
        }

        public async Task Update(MachineDTO dto)
        {
            var data = await _unitOfWork.MachineRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map(dto, data);
            _unitOfWork.MachineRepository.UpdateAsync(entity);
            await _unitOfWork.Commit();
        }

        public async Task Delete(int Id)
        {
            var data = await _unitOfWork.MachineRepository.GetOne(x => x.Id == Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map<Machine>(data);
            _unitOfWork.MachineRepository.DeleteAsync(entity);
            await _unitOfWork.Commit();
        }
    }
}
