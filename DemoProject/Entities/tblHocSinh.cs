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

    [Table("tblHocSinh")]
    public partial class tblHocSinh
    {
        [Key]
        public int MaHS { get; set; }


        [DisplayName("Họ tên")]
        [Required(ErrorMessage = "Bạn phải nhập thông tin này")]
        [StringLength(50, ErrorMessage = "Độ dài của Họ tên không vượt quá 50 kí tự")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập thông tin này")]
        [DisplayName("Giới tính")]
        public string GT { get; set; }


        [DisplayName("Ngày sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NgaySinh { get; set; }


        [StringLength(50, ErrorMessage = "Độ dài không vượt quá 50 kí tự")]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }


        [StringLength(50, ErrorMessage = "Độ dài không vượt quá 50 kí tự")]
        [DisplayName("Dân tộc")]
        public string DanToc { get; set; }


        [StringLength(50, ErrorMessage = "Độ dài không vượt quá 50 kí tự")]
        [DisplayName("Tôn giáo")]
        public string TonGiao { get; set; }


        [DisplayName("Lớp")]
        public int? MaLop { get; set; }

        public virtual tblLop tblLop { get; set; }
    }
}
