using AutoMapper;
using DTO;
using Models.Models;

namespace Configurations
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<Input, InputDTO>().ReverseMap();
            CreateMap<Machine, MachineDTO>().ReverseMap();
            CreateMap<InventoryMovement, InventoryMovementsDTO>().ReverseMap();
        }
    }
}
