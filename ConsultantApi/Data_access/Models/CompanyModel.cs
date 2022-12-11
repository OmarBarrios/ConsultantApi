using System;

namespace ConsultantApi.Data_access.Models
{
    public class CompanyModel
    {
        public CompanyModel(Guid uuid, string sector, string Address, string startDatePartner, string created_at, string updated_at, string deleted_at) 
        {
            this.Uuid = uuid;
            this.Sector = sector;
            this.Address = Address;
            this.StartDatePartner = startDatePartner;
            this.Created_at = created_at;
            this.Updated_at = updated_at;
            this.Deleted_at = deleted_at;
        }
        public int Id { get; }
        public Guid Uuid { get; set; }
        public string Sector { get; set; }
        public string Address { get; set; }
        public string StartDatePartner { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }
        public string Deleted_at { get; set; }
    }
}