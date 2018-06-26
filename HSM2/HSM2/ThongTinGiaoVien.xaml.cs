using HSM2.CSDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HSM2
{
    /// <summary>
    /// Interaction logic for ThongTinGiaoVien.xaml
    /// </summary>
    public partial class ThongTinGiaoVien : UserControl
    {
        public static string maGVTrongNay;

        public ThongTinGiaoVien(string maGV)
        {
            //Sau khi biết được giáo viên nào đã đăng nhập
            InitializeComponent();
            MyEntity db = new MyEntity();
            //Hình từ đường dẫn database
            var link = from linkNao in db.TDuongDans
                       where linkNao.MaDuongDan == "HA3"
                       select linkNao;
            List<DuongDan> dsDuongDan = link.ToList();
            DuongDan timDuocHinh1 = dsDuongDan[0];
            string pathHinh1 = timDuocHinh1.DuongDanDenFile;
            try
            {
                ImageSource imageSourceHinh1 = new BitmapImage(new Uri(pathHinh1));
                hinh3.ImageSource = imageSourceHinh1;
            }
            catch (Exception)
            {


            }
            maGVTrongNay = maGV;
            cbMonDay.ItemsSource = db.TMonHocs.ToList();
            cbMonDay.SelectedValuePath = "MaMH";
            cbMonDay.DisplayMemberPath = "TenMH";
            //Ta kiếm thông tin giáo viên đó trong CSDL
            var a = from ai in db.TGiaoViens
                    where maGVTrongNay == ai.MaGV
                    select ai;
            List<GiaoVien> giaoViens = a.ToList();
            foreach (var item in giaoViens)
            {
                //Rồi truyền thông tin giáo viên đó vào các textbox trên giao diện
                if (maGV.ToUpper() == item.MaGV)
                {
                    tbHoTenGV.Text = item.HoTenGV;
                    tbDiaChiGV.Text = item.DiaChiGV;
                    tbMaGV.Text = item.MaGV;
                    tbQueQuanGV.Text = item.QueQuanGV;
                    tbSDTGV.Text = item.SDT;
                    cbMonDay.Text = item.MonDay;
                    dpNgaySinhGV.Text = item.NgaySinhGV.ToString();
                    tbLopChuNhiem.Text = item.LopChuNhiem;
                    break;
                }
            }
        }
        private void btCapNhat_Click(object sender, RoutedEventArgs e)
        {
            //Khởi chạy CSDL
            MyEntity db = new MyEntity();
            //Nếu lớp chủ nhiệm không bị trùng thì cho đổi và môn dạy không bị trùng thì cho đổi
            var danhSachLop = from lopNao in db.TGiaoViens
                              where tbLopChuNhiem.Text.ToUpper() == lopNao.LopChuNhiem.ToUpper()
                              select lopNao;
            List<GiaoVien> dayLopNay = danhSachLop.ToList();

            //Xem lớp đó có ai dạy môn mà giáo viên này đang chủ nhiệm không ?
            var monDangDuocDay = from monNao in db.TGiaoVienDayHocSinhs
                                 where monNao.MonMaLopDuocDay == cbMonDay.Text && monNao.MaLopCuaSV == tbLopChuNhiem.Text
                                 select monNao;
            List<GiaoVienDayHocSinh> coGiaoVienDay = monDangDuocDay.ToList();

            if (dayLopNay.Count != 0 && dayLopNay[0].MaGV.ToUpper() != maGVTrongNay.ToUpper())
            {
                if (MessageBox.Show("Lớp này đã có giáo viên chủ nhiệm vui lòng kiểm tra lại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
                {
                    var a = from ai in db.TGiaoViens
                            where maGVTrongNay == ai.MaGV
                            select ai;
                    List<GiaoVien> giaoViens = a.ToList();
                    foreach (var item in giaoViens)
                    {
                        if (maGVTrongNay.ToUpper() == item.MaGV)
                        {
                            tbLopChuNhiem.Text = item.LopChuNhiem;
                            break;
                        }
                    }
                    tbLopChuNhiem.Focus();
                }
            }
            else if (!(tbLopChuNhiem.Text.Substring(0, 3).ToUpper() == "10A" || tbLopChuNhiem.Text.Substring(0, 3).ToUpper() == "11A" || tbLopChuNhiem.Text.Substring(0, 3).ToUpper() == "12A") || tbLopChuNhiem.Text.Length < 4 || tbLopChuNhiem.Text.Length > 5)
            {
                if (MessageBox.Show("Mã lớp không hợp lệ!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
                {
                    tbLopChuNhiem.Text = "";
                    tbLopChuNhiem.Focus();
                }
            }
            else if (coGiaoVienDay.Count != 0)
            {
                MessageBox.Show("Lớp này đã có giáo viên: " + coGiaoVienDay[0].MaCuaGV + " dạy môn " + coGiaoVienDay[0].MonMaLopDuocDay, "Thông báo!!!", MessageBoxButton.OK);
            }
            else
            {
                //Tạo ra 1 giáo viên với thông tin từ các textbox trên giao diện
                GiaoVien a = new GiaoVien(tbMaGV.Text, tbHoTenGV.Text, dpNgaySinhGV.DisplayDate, tbQueQuanGV.Text, tbDiaChiGV.Text, tbSDTGV.Text, cbMonDay.Text, tbLopChuNhiem.Text);
                //Tìm giáo viên cần sửa
                var canKiem = from ai in db.TGiaoViens
                              where maGVTrongNay == ai.MaGV
                              select ai;
                List<GiaoVien> giaoViens = canKiem.ToList();
                GiaoVien b = giaoViens[0];
                //Tìm giáo viên này chủ nhiệm lớp nào dạy môn gì
                var timKiemGVDayHS = from timKiem in db.TGiaoVienDayHocSinhs
                                     where b.MaGV == timKiem.MaCuaGV
                                     select timKiem;
                List<GiaoVienDayHocSinh> nhungLopGiaoVienNayDay = timKiemGVDayHS.ToList();
                //Lưu lại thông tin chỉnh sửa
                DateTime thoiDiemNhap = DateTime.Now;
                string[] gioPhutGiay = thoiDiemNhap.ToString("HH:mm:ss").Split(':');
                string nam = thoiDiemNhap.Year.ToString();
                string taoKey = nam[2].ToString() + nam[3].ToString() + "TS" + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2];
                LuuTruThongTinGVSua truocKhiSua = new LuuTruThongTinGVSua(taoKey, b, thoiDiemNhap);
                db.TLuuTruThongTinGVSuas.Add(truocKhiSua);
                taoKey = nam[2].ToString() + nam[3].ToString() + "SS" + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2];
                LuuTruThongTinGVSua sauKhiSua = new LuuTruThongTinGVSua(taoKey, a, thoiDiemNhap);
                db.TLuuTruThongTinGVSuas.Add(sauKhiSua);
                //Lưu lại CSDL
                db.SaveChanges();
                //Xóa giáo viên cũ add giáo viên mới 
                db.TGiaoViens.Attach(b);
                db.TGiaoViens.Remove(b);
                db.TGiaoViens.Add(a);

                //Nếu giáo viên này đổi môn học
                if (nhungLopGiaoVienNayDay.Count != 0)
                {
                    if (nhungLopGiaoVienNayDay[0].MonMaLopDuocDay != a.MonDay)
                    {
                        //Những lớp mà giáo viên này dạy không còn giáo viên này dạy môn đó nữa
                        foreach (var lopDays in nhungLopGiaoVienNayDay)
                        {
                            db.TGiaoVienDayHocSinhs.Remove(lopDays);
                        }
                    }
                }
                //Vì giáo viên chủ nhiệm lớp nào thì cũng dạy lớp đó môn của mình
                GiaoVienDayHocSinh lienKetMoi = new GiaoVienDayHocSinh(a.MaGV, a.LopChuNhiem, a.MonDay);
                db.TGiaoVienDayHocSinhs.Add(lienKetMoi);

                //Lưu lại CSDL
                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                //Cập nhật lại các textbox trên giao diện
                tbHoTenGV.Text = a.HoTenGV;
                tbDiaChiGV.Text = a.DiaChiGV;
                tbMaGV.Text = a.MaGV;
                tbQueQuanGV.Text = a.QueQuanGV;
                tbSDTGV.Text = a.SDT;
                cbMonDay.Text = a.MonDay;
                dpNgaySinhGV.Text = a.NgaySinhGV.ToString();
                tbLopChuNhiem.Text = a.LopChuNhiem;
            }
        }


        private void btInThongTin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GiaoDienInThongTin a = new GiaoDienInThongTin();
                InGiaoVien b = new InGiaoVien();
                b.Refresh();
                a.inThongTin.ViewerCore.ReportSource = b;
                a.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
