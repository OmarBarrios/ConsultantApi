using ConsultantApi.Entities;
using System;

namespace ConsultantApi.Data_access.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public IProjectData Create(IProjectData project)
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

        public IProjectData[] GetAll()
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

        public IProjectData GetByUuid(Guid uuid)
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

        public IProjectData Update(Guid uuid, IProjectData project)
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