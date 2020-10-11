using AutoMapper;
using Pumox.Test.BLL.Models;

namespace Pumox.Test.DAL
{
    public class PumoxTestMappingProfile : Profile
    {
        public PumoxTestMappingProfile()
        {
            CreateMap<CompanyBrief, Company>()
                .ReverseMap();

            CreateMap<Company, Company>();
        }
    }
}
