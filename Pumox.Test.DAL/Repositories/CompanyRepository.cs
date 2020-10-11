using AutoMapper;
using PDCore.Extensions;
using PDCore.Interfaces;
using PDCore.Utils;
using PDCoreNew.Context.IContext;
using PDCoreNew.Repositories.Repo;
using Pumox.Test.BLL.Entities.DTO;
using Pumox.Test.BLL.Models;
using Pumox.Test.DAL.Contracts;
using Pumox.Test.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Pumox.Test.DAL.Repositories
{
    public class CompanyRepository : SqlRepositoryEntityFrameworkDisconnected<Company>, ICompanyRepository
    {
        public CompanyRepository(IEntityFrameworkDbContext ctx, ILogger logger, IMapper mapper) : base(ctx, logger, mapper)
        {
        }

        public Task<List<CompanyDTO>> GetDTO(CompanySearch companySearch)
        {
            var query = FindAll();

            string keyword = companySearch.Keyword;

            if (keyword != null)
            {
                query = query.Where(c => c.Name.Contains(keyword)
                                         || c.Employees.Any(e => e.FirstName.Contains(keyword) || e.LastName.Contains(keyword)));
            }

            var dateFrom = companySearch.EmployeeDateOfBirthFrom;
            var dateTo = companySearch.EmployeeDateOfBirthTo;

            if (!ObjectUtils.AreNull(dateFrom, dateTo))
            {
                var findByDateFunc = SqlUtils.GetFindByDateExpression<Employee>(dateFrom, dateTo, e => e.DateOfBirth);

                query = query.Where(c => c.Employees.AsQueryable().Any(findByDateFunc));
            }

            var jobTitles = companySearch.EmployeeJobTitles;

            if (!jobTitles.IsEmpty())
            {
                query = query.Where(c => c.Employees.Any(e => jobTitles.Contains(e.JobTitle)));
            }

            return mapper.ProjectTo<CompanyDTO>(query).ToListAsync();
        }
    }
}
