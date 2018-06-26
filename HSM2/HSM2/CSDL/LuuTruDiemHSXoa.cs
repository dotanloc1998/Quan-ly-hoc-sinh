using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2.CSDL
{
    public class LuuTruDiemHSXoa
    {
        [Key] public string MaDiemXoa { get; set; }
        public double SoDiemXoa { get; set; }
        public string MaHSCuaDiemXoa { get; set; }
        public LuuTruHSXoa KhoaNgoaiCuaLuuTruDiem { get; set; }
        public LuuTruDiemHSXoa(string maDiem, string maHS, double diemTB)
        {
            MaDiemXoa = maDiem;
            MaHSCuaDiemXoa = maHS;
            SoDiemXoa = diemTB;
        }
        public LuuTruDiemHSXoa()
        {

        }
    }
}
