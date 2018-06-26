using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2.CSDL
{
    public class MonHoc
    {
        [Key] public string MaMH { get; set; }
        public string TenMH { get; set; }

        
        public MonHoc()
        {

        }

    }
}
