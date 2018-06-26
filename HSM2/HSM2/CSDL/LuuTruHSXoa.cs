using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2.CSDL
{
    public class LuuTruHSXoa
    {
        [Key] public string MaSoHSXoa { get; set; }
        public string HoTenXoa { get; set; }
        public string DiaChiXoa { get; set; }
        public DateTime NgaySinhXoa { get; set; }
        public string XLHocLucXoa { get; set; }
        public string XLHanhKiemXoa { get; set; }
        public string QueQuanXoa { get; set; }
        public string LopCuaHSXoa { get; set; }
        public double DiemTBCuaHSXoa { get; set; }
        public LuuTruHSXoa(HocSinh hocSinhBackup)
        {
            MaSoHSXoa = hocSinhBackup.MaSoHS;
            HoTenXoa = hocSinhBackup.HoTen;
            NgaySinhXoa = hocSinhBackup.NgaySinh;
            DiaChiXoa = hocSinhBackup.DiaChi;
            XLHocLucXoa = hocSinhBackup.XLHocLuc;
            XLHanhKiemXoa = hocSinhBackup.XLHanhKiem;
            QueQuanXoa = hocSinhBackup.QueQuan;
            LopCuaHSXoa = hocSinhBackup.LopCuaHS;
            DiemTBCuaHSXoa = hocSinhBackup.DiemTBCuaHS;
        }
        public LuuTruHSXoa()
        {

        }
    }
}
