using AutoMapper;
using Employee.API.Helpers;
using Employee.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Profiles
{
    public class EmployeesProfile : Profile
    {

        public EmployeesProfile()
        {
    

            CreateMap<Entities.Employee, Models.EmployeeDTO>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge())
                ).
                ForMember(
                    dest => dest.Department,
                    opt => opt.MapFrom(src => src.Department.DepartmentName));
        }
    }
}
