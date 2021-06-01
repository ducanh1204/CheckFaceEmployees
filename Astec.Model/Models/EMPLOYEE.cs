namespace Astec.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPLOYEE")]
    public partial class EMPLOYEE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public byte[] Photo { get; set; }

        public byte[] Finger { get; set; }

        [StringLength(50)]
        [Column(TypeName ="nvarchar")]
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
