using ConsultantApi.Actions;
using ConsultantApi.Data_access.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConsultantApi.Controllers
{
    public class EmployeeController : ApiController
    {
        readonly EmployeeAction employeeAction = new EmployeeAction();
        // GET: api/Employee
        public async Task<List<EmployeeEntity>> Get()
        {
            List<EmployeeEntity> employees = await employeeAction.GetAll();
            return employees;
        }

        // GET: api/Employee/5
        public async Task<EmployeeEntity> Get([FromUri] Guid uuid)
        {
            EmployeeEntity employee = await employeeAction.GetByUuid(uuid);
            return employee;
        }

        // POST: api/Employee
        public async Task<EmployeeEntity> Post([FromBody] EmployeeEntity employee)
        {
            EmployeeEntity employeeCreated = await employeeAction.Create(employee);

            return employeeCreated;
        }

        // PUT: api/Employee/5
        public async Task<EmployeeEntity> Put([FromUri] Guid uuid, [FromBody] EmployeeEntity employee)
        {
            EmployeeEntity employeeUpdated = await employeeAction.Update(uuid, employee);

            return employeeUpdated;
        }

        // DELETE: api/Employee/5
        public async Task<bool> Delete([FromUri] Guid uuid)
        {
            Boolean isDeleted = await employeeAction.Delete(uuid);

            return isDeleted;
        }
    }
}
