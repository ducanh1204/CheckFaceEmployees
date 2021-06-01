using Astec.Model.Models;
using AutoMapper;
using CheckFaceEmployees.Api.Models;

namespace CheckFaceEmployees.Api.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<EMPLOYEE, EmployeeViewModel>();
        }
    }
}