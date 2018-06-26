using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2.CSDL
{
    public class LuuTruThongTinGVSua
    {
        [Key]
        public string MaSuaChuaThongTinGV { get; set; }
        public string MaGVSua { get; set; }
        public string HoTenGVSua { get; set; }
        public DateTime NgaySinhGVSua { get; set; }
        public string QueQuanGVSua { get; set; }
        public string DiaChiGVSua { get; set; }
        public string SDTSua { get; set; }
        public string MonDaySua { get; set; }
        public string LopChuNhiemSua { get; set; }
        public DateTime NgayThangSua { get; set; }
        public LuuTruThongTinGVSua(string maSuaChua, GiaoVien a, DateTime ngaySua)
        {
            MaSuaChuaThongTinGV = maSuaChua;
            MaGVSua = a.MaGV;
            HoTenGVSua = a.HoTenGV;
            NgaySinhGVSua = a.NgaySinhGV;
            QueQuanGVSua = a.QueQuanGV;
            DiaChiGVSua = a.DiaChiGV;
            SDTSua = a.SDT;
            MonDaySua = a.MonDay;
            LopChuNhiemSua = a.LopChuNhiem;
            NgayThangSua = ngaySua;
        }
        public LuuTruThongTinGVSua()
        {

        }
    }
}
