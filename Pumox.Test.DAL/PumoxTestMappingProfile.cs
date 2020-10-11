using AutoMapper;
using Pumox.Test.BLL.Entities.Briefs;
using Pumox.Test.BLL.Entities.DTO;
using Pumox.Test.DAL.Entities;

namespace Pumox.Test.DAL
{
    public class PumoxTestMappingProfile : Profile
    {
        public PumoxTestMappingProfile()
        {
            CreateMap<CompanyDTO, Company>()
                .ReverseMap();

            CreateMap<Company, Company>();

            CreateMap<Employee, EmployeeBrief>()
                .ReverseMap();
        }
    }
}
