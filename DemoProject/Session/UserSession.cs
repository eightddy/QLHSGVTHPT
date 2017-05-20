using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoProject.Session
{
    [Serializable]
    public class UserSession
    {
        public string username { get; set; }
        public int MaGV { get; set; }
        public int MaQuyen { get; set; }
    }
}