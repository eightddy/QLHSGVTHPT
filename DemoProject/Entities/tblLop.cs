namespace DemoProject.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblLop")]
    public partial class tblLop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblLop()
        {
            tblGiangDays = new HashSet<tblGiangDay>();
            tblHocSinhs = new HashSet<tblHocSinh>();
        }

        [Key]
        public int MaLop { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Tên lớp")]
        public string TenLop { get; set; }

        public int NienKhoa { get; set; }

        public int? GVCN { get; set; }

        public int SiSo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblGiangDay> tblGiangDays { get; set; }

        public virtual tblGiaoVien tblGiaoVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblHocSinh> tblHocSinhs { get; set; }
    }
}
