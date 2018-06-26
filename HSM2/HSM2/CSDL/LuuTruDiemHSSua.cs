using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2.CSDL
{
    public class LuuTruDiemHSSua
    {
        [Key] public string MaDiemSua { get; set; }
        public double SoDiemSua { get; set; }
        public string MaHSCuaDiemSua { get; set; }
        public LuuTruHSSua MaHSSuaCuaDiemSua { get; set; }
        public LuuTruDiemHSSua(string maDiem, string maHS, double diemTB)
        {
            MaDiemSua = maDiem;
            MaHSCuaDiemSua = maHS;
            SoDiemSua = diemTB;
        }
        public LuuTruDiemHSSua()
        {

        }
    }
}
