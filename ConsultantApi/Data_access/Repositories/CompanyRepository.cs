using ConsultantApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultantApi.Data_access.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
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