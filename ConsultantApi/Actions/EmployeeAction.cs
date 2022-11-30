using ConsultantApi.Data_access.Repositories;
using ConsultantApi.Entities;
using System;

namespace ConsultantApi.Actions
{
    public class EmployeeAction
    {
        private EmployeeRepository employeeRepository;
        EmployeeAction()
        {
            this.employeeRepository = new EmployeeRepository();
        }

        public IEmployeeData Create(IEmployeeData employee)
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
        public IEmployeeData[] GetAll()
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
        public IEmployeeData GetByUuid(Guid uuid)
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
        public IEmployeeData Update(Guid uuid, IEmployeeData employe)
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