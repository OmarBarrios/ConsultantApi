using ConsultantApi.Entities;
using System;

namespace ConsultantApi.Data_access
{
    public interface IEmployeeRepository
    {
        IEmployeeData Create(IEmployeeData employee);
        IEmployeeData[] GetAll();
        IEmployeeData GetByUuid(Guid uuid);
        IEmployeeData Update(Guid uuid, IEmployeeData employee);
        Boolean Delete(Guid uuid);
    }
}
