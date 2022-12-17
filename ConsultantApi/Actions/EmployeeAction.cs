using ConsultantApi.Data_access.Models;
using ConsultantApi.Data_access.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultantApi.Actions
{
    public class EmployeeAction
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeeAction()
        {
            this.employeeRepository = new EmployeeRepository();
        }

        public async Task<List<EmployeeEntity>> GetAll()
        {
            try
            {
                List<EmployeeEntity> employees = await employeeRepository.GetAll();
                return employees;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<EmployeeEntity> GetByUuid(Guid uuid)
        {
            try
            {
                string employeeUuid = uuid.ToString();
                EmployeeEntity employee = await employeeRepository.GetByUuid(employeeUuid);
                return employee;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<EmployeeEntity> Create(EmployeeEntity employee)
        {
            try
            {
                EmployeeEntity newEmployee = new EmployeeEntity(
                    Guid.NewGuid(),
                    employee.Name,
                    DateTime.UtcNow,
                    employee.Nationality,
                    employee.ChapterArea,
                    employee.Email,
                    employee.CompanyAssigned,
                    DateTime.UtcNow,
                    DateTime.UtcNow
                    );

                await employeeRepository.Create(newEmployee);
                
                return newEmployee;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<EmployeeEntity> Update(Guid uuid, EmployeeEntity employee)
        {
            try
            {
                EmployeeEntity employeeInDb = await GetByUuid(uuid);
                EmployeeEntity employeeUpdate = new EmployeeEntity();

                if (employeeInDb != null) 
                {
                    employeeUpdate = new EmployeeEntity(
                        employeeInDb.Uuid,
                        employee.Name ?? employeeInDb.Name,
                        employee.Birthday == null ? employeeInDb.Birthday : employee.Birthday,
                        employee.Nationality ?? employeeInDb.Nationality,
                        employee.ChapterArea ?? employeeInDb.ChapterArea,
                        employee.Email ?? employeeInDb.Email,
                        employee.CompanyAssigned == null ? employeeInDb.CompanyAssigned : employee.CompanyAssigned,
                        employeeInDb.Created_at,
                        DateTime.UtcNow
                    );                
                }

                string employeeUuid = uuid.ToString();
                await employeeRepository.Update(employeeUuid, employeeUpdate);
                
                return employeeUpdate;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Boolean> Delete(Guid uuid)
        {
            try
            {
                string employeeUuid = uuid.ToString();
                DateTime employeeDelete = DateTime.UtcNow;
                Boolean isDeleted = await employeeRepository.Delete(employeeUuid, employeeDelete);

                return isDeleted;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}