namespace DemoProject.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMonHoc")]
    public partial class tblMonHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMonHoc()
        {
            tblGiaoViens = new HashSet<tblGiaoVien>();
        }

        [Key]
        public int MaMon { get; set; }

        [StringLength(50)]
        [DisplayName("Bộ môn")]
        public string TenMon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblGiaoVien> tblGiaoViens { get; set; }
    }
}
