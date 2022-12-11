using ConsultantApi.Actions;
using ConsultantApi.Data_access.Models;
using ConsultantApi.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ConsultantApi.Controllers
{
    public class CompanyController : ApiController
    {
        readonly CompanyAction companyAction = new CompanyAction();
        // GET: api/Company
        public List<CompanyModel> Get()
        {
            List<CompanyModel> companies = companyAction.GetAll();
            return companies;
        }

        // GET: api/Company/5
        public CompanyModel Get([FromUri] Guid uuid)
        {
            CompanyModel company = companyAction.GetByUuid(uuid);
            return company;
        }

        // POST: api/Company
        public CompanyModel Post([FromBody] CompanyModel company)
        {
            CompanyModel newCompany = companyAction.Create(company);
            return newCompany;
        }

        // PUT: api/Company/5
        public CompanyModel Put([FromUri] Guid uuid, [FromBody] CompanyModel company)
        {
            CompanyModel companyUpdated = companyAction.Update(uuid, company);
            return companyUpdated;
        }

        // DELETE: api/Company/5
        public Boolean Delete([FromUri] Guid uuid)
        {
            Boolean companyDeleted = companyAction.Delete(uuid);
            return companyDeleted;
        }
    }
}
