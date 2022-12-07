using ConsultantApi.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultantApi.Data_access.Models
{
    [Table("projects")]
    public class ProjectModel
    {
        [Key]
        public int Id { get; set; }
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public ICompanyData CompanyAssigned { get; set; }
        public string StartDate { get; set; }
    }
}