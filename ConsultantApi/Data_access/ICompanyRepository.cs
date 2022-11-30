using ConsultantApi.Entities;
using System;

namespace ConsultantApi.Data_access
{
    public interface ICompanyRepository
    {
        ICompanyData Create(ICompanyData company);
        ICompanyData[] GetAll();
        ICompanyData GetByUuid(Guid uuid);
        ICompanyData Update(Guid uuid, ICompanyData company);
        Boolean Delete(Guid uuid);

    }
}
