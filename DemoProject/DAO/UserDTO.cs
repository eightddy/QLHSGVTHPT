using DemoProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoProject.DAO
{
    public class UserDTO
    {
        [Required]
        [StringLength(50)]
        [DisplayName("Tên đăng nhập")]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Xác nhận mật khẩu")]
        public string PasswordConfirm { get; set; }

        
        public int MaGV { get; set; }
        [Required]
        public int MaQuyen { get; set; }

        public virtual tblPhanQuyen tblPhanQuyen { get; set; }
    }
}