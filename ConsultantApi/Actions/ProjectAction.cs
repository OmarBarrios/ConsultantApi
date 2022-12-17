using ConsultantApi.Data_access.Models;
using ConsultantApi.Data_access.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultantApi.Actions
{
    public class ProjectAction
    {
        private ProjectRepository projectRepository;
        public ProjectAction()
        {
            this.projectRepository = new ProjectRepository();
        }

        public async Task<List<ProjectEntity>> GetAll()
        {
            try
            {
                List<ProjectEntity> projects = await projectRepository.GetAll();
                return projects;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<ProjectEntity> GetByUuid(Guid uuid)
        {
            try
            {
                string projectUuid = uuid.ToString();
                ProjectEntity project = await projectRepository.GetByUuid(projectUuid);
                return project;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<ProjectEntity> Create(ProjectEntity project)
        {
            try
            {
                ProjectEntity newProject = new ProjectEntity(
                    Guid.NewGuid(),
                    project.Name,
                    project.CompanyAssigned,
                    (DateTime)project.StartDate,
                    DateTime.UtcNow,
                    DateTime.UtcNow
                    );
                await projectRepository.Create(newProject);
                return newProject;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<ProjectEntity> Update(Guid uuid, ProjectEntity project)
        {
            try
            {
                ProjectEntity projectInDb = await GetByUuid(uuid);
                ProjectEntity projectUpdate = new ProjectEntity();

                if (projectInDb != null)
                {
                    projectUpdate = new ProjectEntity(
                        projectInDb.Uuid,
                        project.Name ?? projectInDb.Name,
                        project.CompanyAssigned == null ? projectInDb.CompanyAssigned : project.CompanyAssigned,
                        project.StartDate == null ? projectInDb.StartDate : project.StartDate,
                        projectInDb.Created_at,
                        DateTime.UtcNow
                    );
                }

                string projectUuid = uuid.ToString();
                await projectRepository.Update(projectUuid, projectUpdate);

                return projectUpdate;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Boolean> Delete(Guid uuid)
        {
            try
            {
                string projectUuid = uuid.ToString();
                DateTime projectDelete = DateTime.UtcNow;
                
                Boolean isDeleted = await projectRepository.Delete(projectUuid, projectDelete);
                return isDeleted;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}