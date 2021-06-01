using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheckFaceEmployees.Api.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Photo { get; set; }

        public string Finger { get; set; }

        [StringLength(50)]
        public string NameEn { get; set; }

        [StringLength(50)]
        public string NameVn { get; set; }

        [StringLength(3)]
        public string Gender { get; set; }

        [StringLength(10)]
        public string Bod { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(30)]
        public string PaperType { get; set; }

        [StringLength(12)]
        public string PassportNumber { get; set; }

        [StringLength(10)]
        public string IssueDate { get; set; }

        [StringLength(10)]
        public string ExpireDate { get; set; }

        [StringLength(12)]
        public string Cccd { get; set; }

        [StringLength(12)]
        public string Cmtc { get; set; }
    }
}