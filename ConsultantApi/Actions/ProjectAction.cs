using ConsultantApi.Data_access.Repositories;
using ConsultantApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultantApi.Actions
{
    public class ProjectAction
    {
        private ProjectRepository projectRepository;
        ProjectAction()
        {
            this.projectRepository = new ProjectRepository();
        }

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