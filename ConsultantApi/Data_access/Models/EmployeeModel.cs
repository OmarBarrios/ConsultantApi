using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultantApi.Data_access.Models
{
    [Table("employees")]
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        public Guid Uuid { get; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Nationality { get; set; }
        public string Chapter { get; set; }
        public string ChapterArea { get; set; }
        public string ImageUser { get; set; }
        public string Email { get; set; }
        public CompanyModel CompanyAssigned { get; set; }
    }
}