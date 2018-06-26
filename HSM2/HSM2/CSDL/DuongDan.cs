using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2.CSDL
{
   public class DuongDan
    {
        [Key]
        public string MaDuongDan { get; set; }
        public string DuongDanDenFile { get; set; }

        public DuongDan(string maDuongDan , string duongDan)
        {
            MaDuongDan = maDuongDan;
            DuongDanDenFile = duongDan;
        }
        public DuongDan()
        {

        }
    }
}
