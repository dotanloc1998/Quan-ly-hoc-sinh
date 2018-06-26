using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2.CSDL
{
    public class LuuTruLoaiDiemHSSua
    {
        [Key]
        public string MaLoaiDiemSua { get; set; }
        public double SoDiemSua { get; set; }
        public string MaDiemCuaLoaiDiemSua { get; set; }
        public LuuTruDiemHSSua KhoaNgoaiDiemCuaLoaiDiemSua { get; set; }
        public LuuTruLoaiDiemHSSua(string maLoaiDiem, double soDiem, string maDiem)
        {
            MaLoaiDiemSua = maLoaiDiem;
            SoDiemSua = soDiem;
            MaDiemCuaLoaiDiemSua = maDiem;
        }
        public LuuTruLoaiDiemHSSua()
        {

        }
    }
}
