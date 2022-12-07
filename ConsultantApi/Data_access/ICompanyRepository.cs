using ConsultantApi.Entities;
using System;
using System.Collections.Generic;

namespace ConsultantApi.Data_access
{
    public interface ICompanyRepository
    {
        ICompanyData Create(ICompanyData company);
        List<ICompanyData> GetAll();
        ICompanyData GetByUuid(Guid uuid);
        ICompanyData Update(Guid uuid, ICompanyData company);
        Boolean Delete(Guid uuid);

    }
}
