namespace DemoProject.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblGiangDay")]
    public partial class tblGiangDay
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaGV { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaLop { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string Thu { get; set; }

        public int? TietBD { get; set; }

        public int? TietKT { get; set; }

        public virtual tblLop tblLop { get; set; }

        public virtual tblGiaoVien tblGiaoVien { get; set; }
    }
}
