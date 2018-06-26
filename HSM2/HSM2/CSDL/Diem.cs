using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2.CSDL
{
    public class Diem
    {
        [Key] public string MaDiem { get; set; }
        public double SoDiem { get; set; }
        public string MaHSCuaDiemA { get; set; }

        public HocSinh MaHSCuaDiem { get; set; }
        public Diem()
        {

        }
        public Diem(string maDiem, string maHS, double diemTB)
        {
            MaDiem = maDiem;
            MaHSCuaDiemA = maHS;
            SoDiem = diemTB;
        }
    }
}
