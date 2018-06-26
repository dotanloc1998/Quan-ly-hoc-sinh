using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2.CSDL
{
    public class LuuTruLoaiDiemHSXoa
    {
        [Key]
        public string MaLoaiDiemXoa { get; set; }
        public double SoDiemXoa { get; set; }
        public string MaDiemCuaLoaiDiemXoa { get; set; }
        public LuuTruDiemHSXoa KhoaNgoaiCuaLuuLoaiDiem { get; set; }
        public LuuTruLoaiDiemHSXoa(string maLoaiDiem, double soDiem, string maDiem)
        {
            MaLoaiDiemXoa = maLoaiDiem;
            SoDiemXoa = soDiem;
            MaDiemCuaLoaiDiemXoa = maDiem;
        }
        public LuuTruLoaiDiemHSXoa()
        {

        }
    }
}
