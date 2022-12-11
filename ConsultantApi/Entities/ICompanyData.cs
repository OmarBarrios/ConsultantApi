using System;

namespace ConsultantApi.Entities
{
    public interface ICompanyData
    {
        Guid Uuid { get; set; }
        string Sector { get; set; }
        string Address { get; set; }
        string StartDatePartner { get; set; }
        string Created_at { get; set; }
        string Updated_at { get; set; }
    }
}
