using ConsultantApi.Data_access.Models;
using ConsultantApi.Data_access.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ConsultantApi.Actions
{
    public class CompanyAction
    {
        readonly CompanyRepository companyRepository;
        public CompanyAction()
        {
            this.companyRepository = new CompanyRepository();
        }
        public List<CompanyModel> GetAll()
        {
            try
            {
                List<CompanyModel> companies = new List<CompanyModel>();
                MySqlDataReader result = companyRepository.GetAll();

                while (result.Read())
                {
                    CompanyModel company = new CompanyModel(
                        result.GetInt64("id"),
                        result.GetGuid("uuid"),
                        result.GetString("name"),
                        result.GetString("sector"),
                        result.GetString("address"),
                        result.GetString("start_date_partner"),
                        (DateTime)result.GetMySqlDateTime("created_at"),
                        (DateTime)result.GetMySqlDateTime("updated_at")
                   );

                    companies.Add(company);
                }
                result.Close();

                return companies;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public CompanyModel GetByUuid(Guid uuid)
        {
            try
            {
                string companyUuid = uuid.ToString();
                MySqlDataReader result = companyRepository.GetByUuid(companyUuid);
                CompanyModel company = null;

                while (result.Read())
                {
                    company = new CompanyModel(
                        result.GetGuid("uuid"),
                        result.GetString("name"),
                        result.GetString("sector"),
                        result.GetString("address"),
                        result.GetString("start_date_partner"),
                        (DateTime)result.GetMySqlDateTime("created_at"),
                        (DateTime)result.GetMySqlDateTime("updated_at")
                   );
                }
                Console.WriteLine(company);
                result.Close();
                return company;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public CompanyModel Create(CompanyModel company) 
        {
            try
            {
                CompanyModel newCompany = new CompanyModel(
                    Guid.NewGuid(),
                    company.Sector,
                    company.Name,
                    company.Address,
                    company.StartDatePartner,
                    DateTime.UtcNow,
                    DateTime.UtcNow
                    );
                
                companyRepository.Create(newCompany);

                CompanyModel companyAdded = GetByUuid(company.Uuid);

                return companyAdded;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public CompanyModel Update(Guid uuid, CompanyModel company)
        {
            try
            {
                CompanyModel companyInDb = GetByUuid(uuid);
                CompanyModel companyUpdate = new CompanyModel();

                if (companyInDb != null)
                {
                    companyUpdate = new CompanyModel(
                    companyInDb.Uuid,
                    company.Sector == null ? companyInDb.Sector : company.Sector,
                    company.Name == null ? companyInDb.Name : company.Name,
                    company.Address == null ? companyInDb.Address : company.Address,
                    company.StartDatePartner == null ? companyInDb.StartDatePartner : company.StartDatePartner,
                    companyInDb.Created_at,
                    DateTime.UtcNow
                    );
                }

                string companyUuid = uuid.ToString();
                companyRepository.Update(companyUuid, companyUpdate);

                
                return companyUpdate;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Boolean Delete(Guid uuid)
        {
            try
            {
                string companyUuid = uuid.ToString();
                DateTime companyDeleted = DateTime.UtcNow;
                Boolean isDeleted = false;
                companyRepository.Delete(companyUuid, companyDeleted);

                CompanyModel result = GetByUuid(uuid);

                if (result != null)
                {
                    isDeleted = true;
                }

                return isDeleted;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}