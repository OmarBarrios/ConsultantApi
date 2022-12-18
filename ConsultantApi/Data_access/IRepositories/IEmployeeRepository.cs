using ConsultantApi.Data_access.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultantApi.Data_access
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeEntity>> GetAll();
        Task<EmployeeEntity> GetByUuid(string uuid);
        Task<EmployeeEntity> Create(EmployeeEntity employee);
        Task<EmployeeEntity> Update(string uuid, EmployeeEntity employee);
        Task<Boolean> Delete(string uuid, DateTime employeeDeleted);
    }
}
