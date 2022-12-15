using System;

namespace ConsultantApi.Data_access.Models
{
    public class ProjectEntity
    {

        public ProjectEntity()
        { }

        public ProjectEntity(Guid uuid, string name, Guid projectAssigned, string startDate, DateTime created_at, DateTime updated_at)
        { 
            this.Uuid = uuid;
            this.Name = name;
            this.ProjectAssigned = projectAssigned;
            this.StartDate = startDate;
            this.Created_at = created_at;
            this.Updated_at = updated_at;
        }
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public Guid ProjectAssigned { get; set; }
        public string StartDate { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}