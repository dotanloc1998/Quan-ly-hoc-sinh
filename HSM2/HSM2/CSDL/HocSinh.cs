using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2.CSDL
{
    public class HocSinh
    {
        [Key] public string MaSoHS { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public string XLHocLuc { get; set; }
        public string XLHanhKiem { get; set; }
        public string QueQuan { get; set; }        
        public string LopCuaHS { get; set; }
        public double DiemTBCuaHS { get; set; }
        public GiaoVien MaGVCuaHS { get; set; }
        public ICollection<GiaoVienDayHocSinh> giaoVienDayHocSinhs { get; set; }
        public HocSinh()
        {

        }
        public HocSinh(string msHS, string hoTen, DateTime ngaySinh, string diaChi, string xlHocLuc, string xlHanhKiem, string queQuan,  string lopCuaHS , double diemTB)
        {
            MaSoHS = msHS;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            XLHocLuc = xlHocLuc;
            XLHanhKiem = xlHanhKiem;
            QueQuan = queQuan;           
            LopCuaHS = lopCuaHS;
            DiemTBCuaHS = diemTB;
        }

        public HocSinh(string msHS, string hoTen, DateTime ngaySinh, string diaChi, string xlHanhKiem, string queQuan , string lopCuaHS)
        {
            MaSoHS = msHS;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;            
            XLHanhKiem = xlHanhKiem;
            QueQuan = queQuan;
            LopCuaHS = lopCuaHS;
        }

    }
}
