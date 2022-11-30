using System;

namespace ConsultantApi.Entities
{
    public interface ICompanyData
    {
        Guid Uuid { get; set; }
        string Sector { get; set; }
        string Address { get; set; }
        string StartDatePartner { get; set; }
    }
}
