using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2.CSDL
{
    public class DangNhap
    {

        [Key]public string MaTaiKhoan{ get; set; }
        public string MatKhau { get; set; }
        public GiaoVien GiaoVienCuaDangNhap { get; set; }
        public string MaPin { get; set; }

        public DangNhap()
        {

        }
        public DangNhap(string maTK,string matKhau,string maPIN)
        {
            MaTaiKhoan = maTK;
            MatKhau = matKhau;            
            MaPin = maPIN;
        }
    }
}
