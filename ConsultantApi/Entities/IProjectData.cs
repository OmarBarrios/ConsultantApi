using System;

namespace ConsultantApi.Entities
{
    public interface IProjectData
    {
        Guid Uuid { get; set; }
        string Name { get; set; }
        ICompanyData CompanyAssigned { get; set; }
        string StartDate { get; set; }
    }
}
