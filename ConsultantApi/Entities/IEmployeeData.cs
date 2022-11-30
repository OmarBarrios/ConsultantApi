using System;

namespace ConsultantApi.Entities
{
    public interface IEmployeeData
    {
        Guid Uuid { get; }
        string Name { get; set; }
        string Birthday { get; set; }
        string Nationality { get; set; }
        string Chapter { get; set; }
        string ChapterArea { get; set; }
        string ImageUser { get; set; }
        string Email { get; set; }
        ICompanyData CompanyAssigned { get; set; }
    }
}
