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
        [StringLength(50, ErrorMessage = "Độ dài của {0} phải từ {2} đến {1} kí tự", MinimumLength = 5)]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập thông tin này")]
        [DisplayName("Giới tính")]
        public string GT { get; set; }


        [DisplayName("Ngày sinh")]
        [DataType(DataType.Date,ErrorMessage ="Bạn phải nhập kiểu ngày tháng")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Bạn phải nhập thông tin này")]
        public DateTime NgaySinh { get; set; }


        [StringLength(255, ErrorMessage = "Độ dài không vượt quá 255 kí tự")]
        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Bạn phải nhập thông tin này")]
        public string DiaChi { get; set; }


        [StringLength(50, ErrorMessage = "Độ dài không vượt quá 50 kí tự")]
        [DisplayName("Dân tộc")]
        [Required(ErrorMessage = "Bạn phải nhập thông tin này")]
        public string DanToc { get; set; }


        [StringLength(50, ErrorMessage = "Độ dài không vượt quá 50 kí tự")]
        [DisplayName("Tôn giáo")]
        [Required(ErrorMessage = "Bạn phải nhập thông tin này")]
        public string TonGiao { get; set; }


        [DisplayName("Lớp")]
        [Required(ErrorMessage = "Bạn phải nhập thông tin này")]
        public int? MaLop { get; set; }

        public virtual tblLop tblLop { get; set; }
    }
}
