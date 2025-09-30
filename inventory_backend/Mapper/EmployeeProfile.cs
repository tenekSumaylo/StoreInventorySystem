using AutoMapper;
using inventory_backend.Dtos;
using inventory_backend.Models.Users;

namespace inventory_backend.Mapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<RegisterDto, Employee>();
        }
    }
}
