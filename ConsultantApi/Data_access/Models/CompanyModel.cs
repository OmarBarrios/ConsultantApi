using System;

namespace ConsultantApi.Data_access.Models
{
    public class CompanyModel
    {
        public CompanyModel()
        { }
        public CompanyModel(long id, Guid uuid, string name, string sector, string Address, string startDatePartner, DateTime created_at, DateTime updated_at)
        {
            this.Uuid = uuid;
            this.Id = id;
            this.Sector = sector;
            this.Name = name;
            this.Address = Address;
            this.StartDatePartner = startDatePartner;
            this.Created_at = created_at;
            this.Updated_at = updated_at;
        }
        public CompanyModel(Guid uuid, string name, string sector, string Address, string startDatePartner, DateTime created_at, DateTime updated_at) 
        {
            this.Uuid = uuid;
            this.Sector = sector;
            this.Name = name;
            this.Address = Address;
            this.StartDatePartner = startDatePartner;
            this.Created_at = created_at;
            this.Updated_at = updated_at;
        }
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public string Sector { get; set; }
        public string Address { get; set; }
        public string StartDatePartner { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}