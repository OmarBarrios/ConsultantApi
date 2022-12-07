using ConsultantApi.Data_access.Models;
using ConsultantApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultantApi.Data_access.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private ClientMysql clientDb = new ClientMysql();

        public ICompanyData Create(ICompanyData company)
        {
            try
            {
                return null;
            }
            catch
            {
                throw new Exception();
            }
        }

        public List<ICompanyData> GetAll()
        {
            try
            {
                List<ICompanyData> data = new List<ICompanyData>();

                clientDb.Run().Open();

                var query = clientDb.Run().CreateCommand();
                query.CommandText = "SELECT * FROM companies LIMIT 100";

                var result = query.ExecuteReader();
                
                while (result.Read())
                {
                    var company = new CompanyModel(result.GetGuid("uuid"), result.GetString("sector"), result.GetString("address"), result.GetString("start_date_partner"));
                    data.Add(company);
                }

                return data;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ICompanyData GetByUuid(Guid uuid)
        {
            try
            {
                return null;
            }
            catch
            {
                throw new Exception();
            }
        }

        public ICompanyData Update(Guid uuid, ICompanyData company)
        {
            try
            {
                return null;
            }
            catch
            {
                throw new Exception();
            }
        }

        public Boolean Delete(Guid uuid)
        {
            try
            {
                return false;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}