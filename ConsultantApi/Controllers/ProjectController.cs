using ConsultantApi.Actions;
using ConsultantApi.Data_access.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConsultantApi.Controllers
{
    public class ProjectController : ApiController
    {
        readonly ProjectAction projectAction = new ProjectAction();
        // GET: api/Project
        public async Task<List<ProjectEntity>> Get()
        {
            List<ProjectEntity> projects = await projectAction.GetAll();
            return projects;
        }

        // GET: api/Project/5
        public async Task<ProjectEntity> Get([FromUri] Guid uuid)
        {
            ProjectEntity project = await projectAction.GetByUuid(uuid);
            return project;
        }

        // POST: api/Project
        public async Task<ProjectEntity> Post([FromBody] ProjectEntity project)
        {
            ProjectEntity projectCreated = await projectAction.Create(project);
            return projectCreated;
        }

        // PUT: api/Project/5
        public async Task<ProjectEntity> Put([FromUri] Guid uuid, [FromBody] ProjectEntity project)
        {
            ProjectEntity projectUpdated = await projectAction.Update(uuid, project);
            
            return projectUpdated;
        }

        // DELETE: api/Project/5
        public async Task<Boolean> Delete([FromUri] Guid uuid)
        {
            Boolean isDeleted = await projectAction.Delete(uuid);

            return isDeleted;
        }
    }
}
