using System;

namespace ConsultantApi.Data_access.Models
{
    public class ProjectEntity
    {
        public ProjectEntity()
        { }

        public ProjectEntity(Guid uuid, string name, Guid companyAssigned, DateTime startDate, DateTime created_at, DateTime updated_at)
        { 
            this.Uuid = uuid;
            this.Name = name;
            this.CompanyAssigned = companyAssigned;
            this.StartDate = startDate;
            this.Created_at = created_at;
            this.Updated_at = updated_at;
        }
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public Guid CompanyAssigned { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}