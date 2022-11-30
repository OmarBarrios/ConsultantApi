using ConsultantApi.Entities;
using System;

namespace ConsultantApi.Data_access
{
    public interface IProjectRepository
    {
        IProjectData Create(IProjectData project);
        IProjectData[] GetAll();
        IProjectData GetByUuid(Guid uuid);
        IProjectData Update(Guid uuid, IProjectData project);
        Boolean Delete(Guid uuid);
    }
}
