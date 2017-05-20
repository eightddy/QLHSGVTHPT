namespace DemoProject.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblUser")]
    public partial class tblUser
    {
        [Key]
        [StringLength(50)]
        [DisplayName("Tên đăng nhập")]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }

        public int MaGV { get; set; }

        public int MaQuyen { get; set; }

        public virtual tblPhanQuyen tblPhanQuyen { get; set; }
    }
}
