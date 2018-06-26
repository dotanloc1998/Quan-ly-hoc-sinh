using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2.CSDL
{
    public class GiaoVien
    {
        [Key] public string MaGV { get; set; }
        public string HoTenGV { get; set; }
        public DateTime NgaySinhGV { get; set; }
        public string QueQuanGV { get; set; }
        public string DiaChiGV { get; set; }
        public string SDT { get; set; }   
        public string MonDay { get; set; }
        public string LopChuNhiem { get; set; }
        public MonHoc MaMonHocCuaGV { get; set; }
        public ICollection<GiaoVienDayHocSinh> giaoVienDayHocSinhs { get; set; }

        public GiaoVien()
        {


        }
        public GiaoVien(string maGV,string hoTenGV,DateTime ngaySinh,string queQuan,string diaChi,string sdt,string monDayGV , string lopChuNhiem)
        {
            MaGV = maGV;
            HoTenGV = hoTenGV;
            NgaySinhGV = ngaySinh;
            QueQuanGV = queQuan;
            DiaChiGV = diaChi;
            SDT = sdt;
            MonDay = monDayGV;
            LopChuNhiem = lopChuNhiem;
        }
    }
}
