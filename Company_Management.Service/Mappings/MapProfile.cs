using AutoMapper;
using Company_Management.Core.DTO;
using Company_Management.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Management.Service.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Department,DepartmentDto>().ReverseMap();
            CreateMap<Employee,EmployeeDto>().ReverseMap();
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<Role,RoleDto>().ReverseMap();
            CreateMap<User,UserDto>().ReverseMap();
        }
    }
}
