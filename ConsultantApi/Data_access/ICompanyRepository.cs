using ConsultantApi.Data_access.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultantApi.Data_access
{
    public interface ICompanyRepository
    {
        Task<List<CompanyEntity>> GetAll();
        Task<CompanyEntity> GetByUuid(string uuid);
        Task<CompanyEntity> Create(CompanyEntity company);
        Task<CompanyEntity> Update(string uuid, CompanyEntity company);
        Task<Boolean> Delete(string uuid, DateTime companyDeleted);

    }
}
