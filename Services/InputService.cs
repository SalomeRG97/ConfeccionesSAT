using AutoMapper;
using DTO;
using Interfaces.Repository.Base;
using Interfaces.Service;
using Models.Models;

namespace Services
{
    public class InputService(IMapper _mapper, IUnitOfWork _unitOfWork) : IInputService
    {
        public async Task<List<InputDTO>> GetAll()
        {
            var data = await _unitOfWork.InputRepository.GetAllAsync();
            return _mapper.Map<List<InputDTO>>(data);
        }

        public async Task<InputDTO> GetById(int Id)
        {
            var data = await _unitOfWork.InputRepository.GetOne(x => x.Id == Id);
            if (data == null)
            {
                return new InputDTO();
            }
            return _mapper.Map<InputDTO>(data);
        }

        public async Task Create(InputDTO dto)
        {
            var data = await _unitOfWork.InputRepository.GetOne(x => x.Id == dto.Id);
            if (data != null)
            {
                return;
            }
            var entity = _mapper.Map<Input>(dto);
            _unitOfWork.InputRepository.AddAsync(entity);
            await _unitOfWork.Commit();
        }

        public async Task Update(InputDTO dto)
        {
            var data = await _unitOfWork.InputRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map(dto, data);
            _unitOfWork.InputRepository.UpdateAsync(entity);
            await _unitOfWork.Commit();
        }

        public async Task Delete(int Id)
        {
            var data = await _unitOfWork.InputRepository.GetOne(x => x.Id == Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map<Input>(data);
            _unitOfWork.InputRepository.DeleteAsync(entity);
            await _unitOfWork.Commit();
        }
    }
}
