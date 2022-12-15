using ConsultantApi.Data_access.Models;
using System;

namespace ConsultantApi.Data_access.Repositories
{
    public class ProjectRepository
    {
        public ProjectEntity Create(ProjectEntity project)
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
        public ProjectEntity[] GetAll()
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
        public ProjectEntity GetByUuid(Guid uuid)
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
        public ProjectEntity Update(Guid uuid, ProjectEntity project)
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
    }
}