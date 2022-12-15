using ConsultantApi.Data_access.Models;
using ConsultantApi.Data_access.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultantApi.Actions
{
    public class CompanyAction
    {
        readonly CompanyRepository companyRepository;
        public CompanyAction()
        {
            this.companyRepository = new CompanyRepository();
        }
        public async Task<List<CompanyEntity>>  GetAll()
        {
            try
            {
                List<CompanyEntity> companies = await companyRepository.GetAll();

                return companies;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<CompanyEntity> GetByUuid(Guid uuid)
        {
            try
            {
                string companyUuid = uuid.ToString();
                CompanyEntity company = await companyRepository.GetByUuid(companyUuid);

                return company;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<CompanyEntity> Create(CompanyEntity company) 
        {
            try
            {
                CompanyEntity newCompany = new CompanyEntity(
                    Guid.NewGuid(),
                    company.Sector,
                    company.Name,
                    company.Address,
                    company.StartDatePartner,
                    DateTime.UtcNow,
                    DateTime.UtcNow
                    );
                
                await companyRepository.Create(newCompany);

                return newCompany;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<CompanyEntity> Update(Guid uuid, CompanyEntity company)
        {
            try
            {
                CompanyEntity companyInDb = await GetByUuid(uuid);
                CompanyEntity companyUpdate = new CompanyEntity();

                if (companyInDb != null)
                {
                    companyUpdate = new CompanyEntity(
                        companyInDb.Uuid,
                        company.Sector ?? companyInDb.Sector,
                        company.Name ?? companyInDb.Name,
                        company.Address ?? companyInDb.Address,
                        company.StartDatePartner ?? companyInDb.StartDatePartner,
                        companyInDb.Created_at,
                        DateTime.UtcNow
                    );
                }

                string companyUuid = uuid.ToString();
                await companyRepository.Update(companyUuid, companyUpdate);
                
                return companyUpdate;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Boolean> Delete(Guid uuid)
        {
            try
            {
                string companyUuid = uuid.ToString();
                DateTime companyDeleted = DateTime.UtcNow;
                Boolean isDeleted = false;
                await companyRepository.Delete(companyUuid, companyDeleted);

                CompanyEntity result = await GetByUuid(uuid);

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