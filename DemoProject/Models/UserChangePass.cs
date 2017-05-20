using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace DemoProject.Models
{
    public class UserChangePass
    {

        [Required(ErrorMessage = "{0} phải nhập !")]
        [DisplayName("Tên đăng nhập")]
        public string username { get; set; }

        [Required(ErrorMessage = "{0} phải nhập !")]
        [DisplayName("Mật khẩu cũ")]
        public string passwordOld { get; set; }

        [Required(ErrorMessage = "{0} phải nhập !")]
        [DisplayName("Mật khẩu mới")]
        public string passwordNew { get; set; }

        [Required(ErrorMessage = "{0} phải nhập !")]
        [DisplayName("Xác nhận mật khẩu")]
        public string passwordConfirm { get; set; }
    }
}