using ConsultantApi.Data_access.Repositories;
using ConsultantApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultantApi.Actions
{
    public class CompanyAction
    {
        private CompanyRepository companyRepository;
        CompanyAction()
        {
            this.companyRepository = new CompanyRepository();
        }

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
        public ICompanyData[] GetAll()
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