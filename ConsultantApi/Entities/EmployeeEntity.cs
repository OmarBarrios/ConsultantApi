using System;

namespace ConsultantApi.Data_access.Models
{
    public class EmployeeEntity
    {
        public EmployeeEntity()
        { }

        public EmployeeEntity(Guid uuid, string name, DateTime birthday, string nationality, string chapterArea, string email, Guid companyAssigned, DateTime created_at, DateTime updated_at)
        {
            this.Uuid = uuid;
            this.Name = name;
            this.Birthday = birthday;
            this.Nationality = nationality;
            this.ChapterArea = chapterArea;
            this.Email = email;
            this.CompanyAssigned = companyAssigned;
            this.Created_at = created_at;
            this.Updated_at = updated_at;
        }

        public Guid Uuid { get; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Nationality { get; set; }
        public string ChapterArea { get; set; }
        public string Email { get; set; }
        public Guid CompanyAssigned { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}