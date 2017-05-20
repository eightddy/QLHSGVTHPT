using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DemoProject.DAO
{
    [Table("GiangDayDTO")]
    public partial class GiangDayDTO
    {
        [Key]
        public int MaGV { get; set; }

        [DisplayName("Giáo viên")]
        public string HoTenGV { get; set; }

        [Key]
        public int MaLop { get; set; }
        public string TenLop { get; set; }

        [Key]
        public string Thu { get; set; }
        public int TietBD { get; set; }
        public int TietKT { get; set; }

    }
}