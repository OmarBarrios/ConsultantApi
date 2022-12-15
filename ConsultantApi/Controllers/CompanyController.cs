using ConsultantApi.Actions;
using ConsultantApi.Data_access.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConsultantApi.Controllers
{
    public class CompanyController : ApiController
    {
        readonly CompanyAction companyAction = new CompanyAction();
        // GET: api/Company
        public async Task<List<CompanyEntity>>  Get()
        {
            List<CompanyEntity> companies = await companyAction.GetAll();
            return companies;
        }
        // GET: api/Company/5
        public async Task<CompanyEntity> Get([FromUri] Guid uuid)
        {
            CompanyEntity company = await companyAction.GetByUuid(uuid);
            return company;
        }
        // POST: api/Company
        public async Task<CompanyEntity> Post([FromBody] CompanyEntity company)
        {
            CompanyEntity newCompany = await companyAction.Create(company);
            return newCompany;
        }
        // PUT: api/Company/5
        public async Task<CompanyEntity> Put([FromUri] Guid uuid, [FromBody] CompanyEntity company)
        {
            CompanyEntity companyUpdated = await companyAction.Update(uuid, company);
            return companyUpdated;
        }
        // DELETE: api/Company/5
        public async Task<Boolean> Delete([FromUri] Guid uuid)
        {
            Boolean companyDeleted = await companyAction.Delete(uuid);
            return companyDeleted;
        }
    }
}
