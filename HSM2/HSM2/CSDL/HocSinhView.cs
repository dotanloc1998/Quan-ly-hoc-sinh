using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2.CSDL
{
    public class HocSinhView
    {
        public string MaSoHS { get; set; }
        public string HoTen { get; set; }
        public string XLHocLuc { get; set; }
        public string XLHanhKiem { get; set; }
        public string LopCuaHS { get; set; }
        public double DiemTBCuaMonDuocChon { get; set; }
        public double Diem15CuaMonDuocChon { get; set; }
        public double Diem45CuaMonDuocChon { get; set; }
        public double DiemHKCuaMonDuocChon { get; set; }
        public HocSinhView()
        {

        }
        public HocSinhView(string maSoHS, string hoTen, string hanhKiem, string lop)
        {
            MaSoHS = maSoHS;
            HoTen = hoTen;
            XLHanhKiem = hanhKiem;
            LopCuaHS = lop;
        }
        public HocSinhView(string hocLuc)
        {
            XLHocLuc = hocLuc;
        }
        public HocSinhView(double diemTB)
        {
            DiemTBCuaMonDuocChon = diemTB;
        }
        public HocSinhView(double diem15, double diem45, double diemHK)
        {
            Diem15CuaMonDuocChon = diem15;
            Diem45CuaMonDuocChon = diem45;
            DiemHKCuaMonDuocChon = diemHK;
        }
    }
}
