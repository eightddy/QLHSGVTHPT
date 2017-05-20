using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
namespace DemoProject.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblGiangDay")]
    public partial class tblGiangDay
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Tên giáo viên")]
        public int MaGV { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Bộ môn")]
        public int MaLop { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        [DisplayName("Thứ")]
        public string Thu { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "{0} must be a number between {1} and {2}.")]
        
        public int? TietBD { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "{0} must be a number between {1} and {2}.")]
        public int? TietKT { get; set; }

        public virtual tblLop tblLop { get; set; }

        public virtual tblGiaoVien tblGiaoVien { get; set; }
    }
}
