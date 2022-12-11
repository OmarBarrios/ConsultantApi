using ConsultantApi.Data_access.Models;
using ConsultantApi.Data_access.Repositories;
using ConsultantApi.Entities;
using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Web.WebPages;

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
                        result.GetGuid("uuid"),
                        result.GetString("sector"),
                        result.GetString("address"),
                        result.GetString("start_date_partner"),
                        result.GetMySqlDateTime("created_at").ToString(),
                        result.GetMySqlDateTime("updated_at").ToString(),
                        result.GetMySqlDateTime("deleted_at").ToString().IsNullOrWhiteSpace() ? "" : result.GetMySqlDateTime("deleted_at").ToString()
                   );

                    if (company.Deleted_at == "")
                    {
                        companies.Add(company);
                    }
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
                        result.GetString("sector"),
                        result.GetString("address"),
                        result.GetString("start_date_partner"),
                        result.GetMySqlDateTime("created_at").ToString(),
                        result.GetMySqlDateTime("updated_at").ToString(),
                        result.GetMySqlDateTime("deleted_at").ToString()
                   );
                }
                
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
                company.Uuid = new Guid();
                company.Created_at = new DateTime().ToString();
                company.Updated_at = new DateTime().ToString();

                companyRepository.Create(company);

                CompanyModel newCompany = GetByUuid(company.Uuid);

                return newCompany;
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
                string companyUuid = uuid.ToString();
                company.Updated_at = new DateTime().ToString();
                companyRepository.Update(companyUuid, company);

                CompanyModel companyUpdated = GetByUuid(uuid);
                return companyUpdated;
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
                string companyDeleted = new DateTime().ToString();
                Boolean isDeleted = false;
                companyRepository.Delete(companyUuid, companyDeleted);

                CompanyModel result = GetByUuid(uuid);

                if (result.Deleted_at != null)
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