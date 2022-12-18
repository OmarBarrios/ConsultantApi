using ConsultantApi.Data_access.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultantApi.Data_access
{
    public interface IProjectRepository
    {
        Task<List<ProjectEntity>> GetAll();
        Task<ProjectEntity> GetByUuid(string uuid);
        Task<ProjectEntity> Create(ProjectEntity project);
        Task<ProjectEntity> Update(string uuid, ProjectEntity project);
        Task<Boolean> Delete(string uuid, DateTime projectDeleted);
    }
}
