using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2.CSDL
{
    public class LichSuChinhSua
    {
        [Key]
        public string MaChinhSua { get; set; }
        public DateTime ThoiGianChinhSua { get; set; }
        public string MaGVSua { get; set; }
        public LichSuChinhSua()
        {

        }
         public LichSuChinhSua(string maSua , DateTime thoiGian , string maGV)
        {
            MaChinhSua = maSua;
            ThoiGianChinhSua = thoiGian;
            MaGVSua = maGV;
        }
    }
}
