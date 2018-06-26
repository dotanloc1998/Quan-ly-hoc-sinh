using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2.CSDL
{
    public class LoaiDiemCuaTungMon
    {
        [Key]
        public string MaLoaiDiem { get; set; }
        public double SoDiem { get; set; }
        public string MaDiemCuaLoaiDiem { get; set; }
        public Diem KhoaNgoaiDiemCuaLoaiDiem { get; set; }
        public LoaiDiemCuaTungMon()
        {

        }
        public LoaiDiemCuaTungMon(string maLoaiDiem, double soDiem, string maDiem)
        {
            MaLoaiDiem = maLoaiDiem;
            SoDiem = soDiem;
            MaDiemCuaLoaiDiem = maDiem;
        }
    }
}
