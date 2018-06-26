using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2.CSDL
{
   public class GhiNhoDangNhap
    {
        [Key]
        public string MaDangNhapTruoc { get; set; }
        public GhiNhoDangNhap(string maDangNhap)
        {
            MaDangNhapTruoc = maDangNhap;
        }
        public GhiNhoDangNhap()
        {

        }
    }
}
