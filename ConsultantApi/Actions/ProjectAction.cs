using ConsultantApi.Data_access.Models;
using ConsultantApi.Data_access.Repositories;
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