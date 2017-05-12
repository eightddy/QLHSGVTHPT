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

    [Table("tblGiaoVien")]
    public partial class tblGiaoVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblGiaoVien()
        {
            tblGiangDays = new HashSet<tblGiangDay>();
            tblLops = new HashSet<tblLop>();
        }

        [Key]
        public int MaGV { get; set; }
        // HoTen:
        [Required(ErrorMessage = "Bạn phải nhập trường này")]
        [StringLength(50,ErrorMessage ="Không được nhấp quá 50 kí tự")]
        [DisplayName("Họ tên")]
        public string HoTen { get; set; }
        
        // Giới tính:
        [StringLength(11)]
        [DisplayName("Giới tính")]
        public string GT { get; set; }

        // Ngày sinh:
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        // Số điện thoại
        [StringLength(11,ErrorMessage = "Số điện thoại không quá 11 số")]
        [RegularExpression(@"((016)\d{8})|((09)\d{8})", ErrorMessage ="Sai định dạng, Định dạng đúng : 09x.., 016x..")]
        [DisplayName("SĐT")]
        public string SDT { get; set; }

        // Địa chỉ
        [StringLength(255)]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        // Lương
        [DisplayName("Lương")]
        public int? Luong { get; set; }

        // Mã môn
        [DisplayName("Bộ môn")]
        public int? MaMon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblGiangDay> tblGiangDays { get; set; }

        public virtual tblMonHoc tblMonHoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblLop> tblLops { get; set; }
    }
}
