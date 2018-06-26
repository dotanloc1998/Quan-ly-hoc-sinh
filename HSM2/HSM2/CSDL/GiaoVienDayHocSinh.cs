using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2.CSDL
{
    public class GiaoVienDayHocSinh
    {
        [Key, Column(Order = 0)]
        public string MaCuaGV { get; set; }
        [Key, Column(Order = 1)]
        public string MaLopCuaSV { get; set; }
        public string MonMaLopDuocDay { get; set; }
        public GiaoVien KhoaNgoaiGV { get; set; }
        public HocSinh KhoaNgoaiHS { get; set; }
        public GiaoVienDayHocSinh(string maGV, string maLop, string tenMonHoc)
        {
            MaCuaGV = maGV;
            MaLopCuaSV = maLop;
            MonMaLopDuocDay = tenMonHoc;
        }
        public GiaoVienDayHocSinh()
        {

        }
    }
}
