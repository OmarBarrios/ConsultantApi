using ConsultantApi.Entities;
using System;

namespace ConsultantApi.Data_access.Models
{
    public class CompanyModel : ICompanyData
    {
        public CompanyModel(Guid uuid, string sector, string Address, string startDatePartner) 
        {
            this.Uuid = uuid;
            this.Sector = sector;
            this.Address = Address;
            this.StartDatePartner = startDatePartner;
        }
        public int Id { get; set; }
        public Guid Uuid { get; set; }
        public string Sector { get; set; }
        public string Address { get; set; }
        public string StartDatePartner { get; set; }
    }
}