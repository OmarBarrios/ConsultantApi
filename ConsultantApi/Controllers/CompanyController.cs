using ConsultantApi.Data_access.Repositories;
using ConsultantApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConsultantApi.Controllers
{
    public class CompanyController : ApiController
    {
        // GET: api/Company
        public List<ICompanyData> Get()
        {
            CompanyRepository companyRepository = new CompanyRepository();

            return companyRepository.GetAll();
        }

        // GET: api/Company/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Company
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Company/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Company/5
        public void Delete(int id)
        {
        }
    }
}
