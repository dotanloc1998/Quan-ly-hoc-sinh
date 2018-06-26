using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2.CSDL
{
    public class LuuTruHSSua
    {
        [Key]
        public string MaSua { get; set; }
        public string MaSoHSSua { get; set; }
        public string HoTenSua { get; set; }
        public string DiaChiSua { get; set; }
        public DateTime NgaySinhSua { get; set; }
        public string XLHocLucSua { get; set; }
        public string XLHanhKiemSua { get; set; }
        public string QueQuanSua { get; set; }
        public string LopCuaHSSua { get; set; }
        public double DiemTBCuaHSSua { get; set; }

        public string MaChinhSuaCuaLuuTru { get; set; }
        public LichSuChinhSua KhoaNgoaiCuaLuuTru { get; set; }
        public LuuTruHSSua(string msHS, string hoTen, DateTime ngaySinh, string diaChi, string xlHocLuc, string xlHanhKiem, string queQuan, string lopCuaHS, double diemTB , string maLuu)
        {
            MaSoHSSua = msHS;
            HoTenSua = hoTen;
            NgaySinhSua = ngaySinh;
            DiaChiSua = diaChi;
            XLHocLucSua = xlHocLuc;
            XLHanhKiemSua = xlHanhKiem;
            QueQuanSua = queQuan;
            LopCuaHSSua = lopCuaHS;
            DiemTBCuaHSSua = diemTB;
            MaChinhSuaCuaLuuTru = maLuu;
        }

        public LuuTruHSSua(string msHS, string hoTen, DateTime ngaySinh, string diaChi, string xlHanhKiem, string queQuan, string lopCuaHS, string maLuu)
        {
            MaSoHSSua = msHS;
            HoTenSua = hoTen;
            NgaySinhSua = ngaySinh;
            DiaChiSua = diaChi;
            XLHanhKiemSua = xlHanhKiem;
            QueQuanSua = queQuan;
            LopCuaHSSua = lopCuaHS;
            MaChinhSuaCuaLuuTru = maLuu;
        }
        public LuuTruHSSua()
        {

        }
        public LuuTruHSSua(string maSua,HocSinh canLuu , string maLuu)
        {
            MaSua = maSua;
            MaSoHSSua = canLuu.MaSoHS;
            HoTenSua = canLuu.HoTen;
            NgaySinhSua = canLuu.NgaySinh;
            DiaChiSua = canLuu.DiaChi;
            XLHocLucSua = canLuu.XLHocLuc;
            XLHanhKiemSua = canLuu.XLHanhKiem;
            QueQuanSua = canLuu.QueQuan;
            LopCuaHSSua = canLuu.LopCuaHS;
            DiemTBCuaHSSua = canLuu.DiemTBCuaHS;
            MaChinhSuaCuaLuuTru = maLuu;
        }
    }
}
