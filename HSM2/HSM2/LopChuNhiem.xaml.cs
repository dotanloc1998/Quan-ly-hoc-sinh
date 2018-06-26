using HSM2.CSDL;
using Microsoft.Win32;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace HSM2
{
    /// <summary>
    /// Interaction logic for LopChuNhiem.xaml
    /// </summary>
    public partial class LopChuNhiem : UserControl
    {
        public static string maGVTrongNay = "";
        public static string lopGiaoVienTrongNay = "";
        public LopChuNhiem(string maGV)
        {
            InitializeComponent();
            //Biết được giáo viên nào đăng nhập
            maGVTrongNay = maGV;
            MyEntity db = new MyEntity();
            //Hình từ đường dẫn database
            var link = from linkNao in db.TDuongDans
                       where linkNao.MaDuongDan == "HA4"
                       select linkNao;
            List<DuongDan> dsDuongDan = link.ToList();
            DuongDan timDuocHinh1 = dsDuongDan[0];
            string pathHinh1 = timDuocHinh1.DuongDanDenFile;
            try
            {
                ImageSource imageSourceHinh1 = new BitmapImage(new Uri(pathHinh1));
                hinh4.ImageSource = imageSourceHinh1;
            }
            catch (Exception)
            {


            }
            var giaoVien = from ai in db.TGiaoViens
                           where ai.MaGV == maGVTrongNay
                           select ai;
            List<GiaoVien> cacGiaoViens = giaoVien.ToList();
            //Tìm lớp chủ nhiệm của giáo viên đó
            foreach (var item in cacGiaoViens)
            {
                if (maGVTrongNay.ToUpper() == item.MaGV)
                {
                    lopGiaoVienTrongNay = item.LopChuNhiem;
                    break;
                }
            }
            //Tìm các học sinh được chủ nhiệm bởi giáo viên đó
            var hocSinhThuocChuNhiem = from ai in db.THocSinhs
                                       where ai.LopCuaHS == lopGiaoVienTrongNay
                                       select ai;
            List<HocSinh> listHocSinhChuNhiem = hocSinhThuocChuNhiem.ToList();
            //Đổ dữ liệu vào giao diện
            dtHocSinh.ItemsSource = listHocSinhChuNhiem;
            cbMonHS.ItemsSource = db.TMonHocs.ToList();
            cbMonHS.SelectedValuePath = "MaMH";
            cbMonHS.DisplayMemberPath = "TenMH";
        }
        private void btThem_Click(object sender, RoutedEventArgs e)
        {
            MyEntity db = new MyEntity();
            //Tìm thông tin giáo viên đang đăng nhập trong CSDL
            var a = from ai in db.TGiaoViens
                    where maGVTrongNay == ai.MaGV
                    select ai;
            List<GiaoVien> giaoViens = a.ToList();
            foreach (var item in giaoViens)
            {
                if (maGVTrongNay.ToUpper() == item.MaGV)
                {
                    //Truyền vào giao diện ThemHocSinh mã của giáo viên đang đăng nhập và lớp chủ nhiệm của giáo viên đó
                    ThemHocSinh b = new ThemHocSinh(maGVTrongNay, item.LopChuNhiem);
                    b.ShowDialog();
                    //Khi giao diện ThemHocSinh bị tắt
                    if (b.IsActive == false)
                    {
                        //Cập nhật lại giao diện LopChuNhiem
                        var hocSinhThuocChuNhiem = from ai in db.THocSinhs
                                                   where ai.LopCuaHS == lopGiaoVienTrongNay
                                                   select ai;
                        List<HocSinh> listHocSinhChuNhiem = hocSinhThuocChuNhiem.ToList();
                        dtHocSinh.ItemsSource = listHocSinhChuNhiem;
                    }
                    break;
                }
            }
        }

        private void cbMonHS_DropDownClosed(object sender, EventArgs e)
        {
            MyEntity db = new MyEntity();
            var timMaMonHoc = from monNao in db.TMonHocs
                              where monNao.TenMH == cbMonHS.Text
                              select monNao;
            List<MonHoc> a = timMaMonHoc.ToList();
            if (a.Count != 0 && txtMaHS.Text != "")
            {
                string maMonHocTimDuoc = a[0].MaMH;
                //Tìm điểm của học sinh được chọn
                var timDiem = from diemNao in db.TDiems
                              where diemNao.MaDiem == "D" + maMonHocTimDuoc + txtMaHS.Text.ToUpper()
                              select diemNao;
                List<Diem> b = timDiem.ToList();
                txtDiemTBM.Text = b[0].SoDiem.ToString();

                //Tìm điểm 15
                var timDiem15 = from diemNao in db.TLoaiDiemCuaTungMons
                                where diemNao.MaLoaiDiem == "D" + maMonHocTimDuoc + "15" + txtMaHS.Text.ToUpper()
                                select diemNao;
                List<LoaiDiemCuaTungMon> c = timDiem15.ToList();
                txtDiem15.Text = c[0].SoDiem.ToString();
                //Tìm điểm 45
                var timDiem45 = from diemNao in db.TLoaiDiemCuaTungMons
                                where diemNao.MaLoaiDiem == "D" + maMonHocTimDuoc + "45" + txtMaHS.Text.ToUpper()
                                select diemNao;
                List<LoaiDiemCuaTungMon> d = timDiem45.ToList();
                txtDiem45.Text = d[0].SoDiem.ToString();
                //Tìm điểm HK
                var timDiemHK = from diemNao in db.TLoaiDiemCuaTungMons
                                where diemNao.MaLoaiDiem == "D" + maMonHocTimDuoc + "HK" + txtMaHS.Text.ToUpper()
                                select diemNao;
                List<LoaiDiemCuaTungMon> f = timDiemHK.ToList();
                txtDiemHK.Text = f[0].SoDiem.ToString();
            }
            else
            {
                txtDiemTBM.Text = "";
                txtDiem15.Text = "";
                txtDiem45.Text = "";
                txtDiemHK.Text = "";
            }
        }

        private void btXoa_Click(object sender, RoutedEventArgs e)
        {
            AdminDangNhap admin = new AdminDangNhap();
            admin.ShowDialog();
            if (admin.NhapDung())
            {
                //Các học sinh được chọn
                List<HocSinh> hocSinhs = dtHocSinh.SelectedItems.OfType<HocSinh>().ToList();
                //Nếu có HS được chọn
                if (hocSinhs.Count != 0)
                {
                    try
                    {
                        if (MessageBox.Show("Xóa học sinh sẽ xóa luôn tất cả điểm của học sinh đó!!!", "Thông báo!", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
                        {
                            MyEntity db = new MyEntity();
                            foreach (var item in hocSinhs)
                            {
                                DateTime thoiDiemNhap = DateTime.Now;
                                string[] gioPhutGiay = thoiDiemNhap.ToString("HH:mm:ss").Split(':');
                                LichSuChinhSua xoaHocSinh = new LichSuChinhSua("Xoa" + item.MaSoHS.ToUpper() + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], thoiDiemNhap, maGVTrongNay);
                                db.TLichSuChinhSuas.Add(xoaHocSinh);
                                //Kiếm điểm của học sinh này
                                var diemCuaHocSinhNay = from hocSinhNao in db.TDiems
                                                        where hocSinhNao.MaHSCuaDiemA.ToUpper() == item.MaSoHS.ToUpper()
                                                        select hocSinhNao;
                                List<Diem> xoaNhungDiemNay = diemCuaHocSinhNay.ToList();

                                var chiTietDiemHS = from diemNao in db.TLoaiDiemCuaTungMons
                                                    where diemNao.MaDiemCuaLoaiDiem.Substring(3) == item.MaSoHS.ToUpper()
                                                    select diemNao;
                                List<LoaiDiemCuaTungMon> xoaNhungLoaiDiemNay = chiTietDiemHS.ToList();

                                //Lưu trữ backup trước
                                //Lưu trữ điểm
                                foreach (var item1 in xoaNhungDiemNay)
                                {
                                    LuuTruDiemHSXoa diemBackup = new LuuTruDiemHSXoa(item1.MaDiem, item1.MaHSCuaDiemA, item1.SoDiem);
                                    db.TLuuTruDiemHSXoas.Add(diemBackup);
                                }
                                //Lưu trữ loại điểm
                                foreach (var item3 in xoaNhungLoaiDiemNay)
                                {
                                    LuuTruLoaiDiemHSXoa diemBackup = new LuuTruLoaiDiemHSXoa(item3.MaLoaiDiem, item3.SoDiem, item3.MaDiemCuaLoaiDiem);
                                    db.TLuuTruLoaiDiemHSXoas.Add(diemBackup);
                                }
                                //Xóa hết điểm
                                foreach (var item2 in xoaNhungDiemNay)
                                {
                                    db.TDiems.Attach(item2);
                                    db.TDiems.Remove(item2);
                                }
                                //Xóa hết loại điểm
                                foreach (var item4 in xoaNhungLoaiDiemNay)
                                {
                                    db.TLoaiDiemCuaTungMons.Attach(item4);
                                    db.TLoaiDiemCuaTungMons.Remove(item4);
                                }
                                //Lưu trữ thông tin học sinh
                                LuuTruHSXoa hocSinhCanLuu = new LuuTruHSXoa(item);
                                db.TLuuTruHSXoas.Add(hocSinhCanLuu);
                                //Xóa học sinh
                                db.THocSinhs.Attach(item);
                                db.THocSinhs.Remove(item);
                            }
                            //Lưu CSDL
                            db.SaveChanges();
                            //Cập nhật lại giao diện
                            var hocSinhThuocChuNhiem = from ai in db.THocSinhs
                                                       where ai.LopCuaHS == lopGiaoVienTrongNay
                                                       select ai;
                            List<HocSinh> listHocSinhChuNhiem = hocSinhThuocChuNhiem.ToList();
                            dtHocSinh.ItemsSource = listHocSinhChuNhiem;
                            txtDiaChiHS.Text = "";
                            txtDiem15.Text = "";
                            txtDiem45.Text = "";
                            txtDiemHK.Text = "";
                            txtDiemTBM.Text = "";
                            txtHanhKiem.Text = "";
                            txtHocLuc.Text = "";
                            txtHoTenHS.Text = "";
                            txtMaHS.Text = "";
                            txtQueQuanHS.Text = "";
                            cbMonHS.Text = "";
                            dpNgaySinhHS.Text = "";
                            imgForChange.Source = null;
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Có lỗi vui lòng kiểm tra lại!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Bạn phải chọn học sinh để xóa!!", "Thông báo!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btSua_Click(object sender, RoutedEventArgs e)
        {
            AdminDangNhap admin = new AdminDangNhap();
            admin.ShowDialog();
            if (admin.NhapDung())
            {
                MyEntity db = new MyEntity();
                //Chọn 1 HS trong datagrid
                HocSinh a = (HocSinh)dtHocSinh.SelectedItem;
                {
                    if (a != null && cbMonHS.Text != "")
                    {
                        //Check xem người dùng có nhập sai môn học 
                        bool nhapDung = false;
                        var listMonHoc = from monNao in db.TMonHocs
                                         select monNao;
                        List<MonHoc> nhungMonTimDuoc = listMonHoc.ToList();
                        foreach (var item in nhungMonTimDuoc)
                        {
                            if (item.TenMH == cbMonHS.Text)
                            {
                                nhapDung = true;
                                break;
                            }
                        }
                        if (nhapDung)
                        {
                            try
                            {
                                //Tạo ra một lịch sử chỉnh sửa 
                                DateTime thoiDiemNhap = DateTime.Now;
                                string[] gioPhutGiay = thoiDiemNhap.ToString("HH:mm:ss").Split(':');
                                string nam = thoiDiemNhap.Year.ToString();
                                LichSuChinhSua suaHocSinh = new LichSuChinhSua("Sua" + a.MaSoHS.ToUpper() + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], DateTime.Now, maGVTrongNay);
                                db.TLichSuChinhSuas.Add(suaHocSinh);

                                //Lưu lại các thông tin trước khi sửa của HS như thông tin học sinh đó
                                LuuTruHSSua truocKhiSua = new LuuTruHSSua("TS" + a.MaSoHS.ToUpper() + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], a, suaHocSinh.MaChinhSua);
                                db.TLuuTruHSSuas.Add(truocKhiSua);

                                //Điểm của học sinh đó
                                string monDuocChon = cbMonHS.Text;
                                string monDoi = "";

                                //Kiếm môn học đang được chọn trong combo box
                                var monHocs = from monNao in db.TMonHocs
                                              where monDuocChon == monNao.TenMH
                                              select monNao;
                                List<MonHoc> listMH = monHocs.ToList();
                                foreach (var item in listMH)
                                {
                                    if (item.TenMH == monDuocChon)
                                    {
                                        monDoi = item.MaMH;
                                        break;
                                    }
                                }
                                //Kiếm điểm của A tương ứng môn trong combo box
                                var diemXoa = from diemNao in db.TDiems
                                              where "D" + monDoi + a.MaSoHS == diemNao.MaDiem
                                              select diemNao;
                                List<Diem> kiemThay = diemXoa.ToList();
                                Diem diemCuaA = kiemThay[0];
                                //Lưu trữ lại điểm này
                                LuuTruDiemHSSua diemTruocSua = new LuuTruDiemHSSua("TS" + diemCuaA.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], a.MaSoHS, diemCuaA.SoDiem);
                                db.TLuuTruDiemHSSuas.Add(diemTruocSua);
                                //Lưu trữ lại các loại điểm của điểm này
                                var cacLoaiDiemMonNay = from diemNao in db.TLoaiDiemCuaTungMons
                                                        where "D" + monDoi + a.MaSoHS == diemNao.MaDiemCuaLoaiDiem
                                                        select diemNao;
                                List<LoaiDiemCuaTungMon> listLoaiDiemKiemDuoc = cacLoaiDiemMonNay.ToList();

                                foreach (var item in listLoaiDiemKiemDuoc)
                                {
                                    LuuTruLoaiDiemHSSua diemCanLuu = new LuuTruLoaiDiemHSSua("TS" + item.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], item.SoDiem, item.MaDiemCuaLoaiDiem);
                                    db.TLuuTruLoaiDiemHSSuas.Add(diemCanLuu);
                                }
                                db.SaveChanges();

                                //Tạo 1 HS b mới vẫn chưa có xếp loại học lực và các loại điểm
                                HocSinh b = new HocSinh(txtMaHS.Text, txtHoTenHS.Text, dpNgaySinhHS.DisplayDate, txtDiaChiHS.Text, txtHanhKiem.Text, txtQueQuanHS.Text, a.LopCuaHS);
                                //Cập nhật điểm cho b trước
                                Diem diemTBMonDoi = new Diem("D" + monDoi + b.MaSoHS, b.MaSoHS, 0.0);
                                LoaiDiemCuaTungMon diem15 = new LoaiDiemCuaTungMon("D" + monDoi + "15" + txtMaHS.Text, double.Parse(txtDiem15.Text), diemTBMonDoi.MaDiem);
                                LoaiDiemCuaTungMon diem45 = new LoaiDiemCuaTungMon("D" + monDoi + "45" + txtMaHS.Text, double.Parse(txtDiem45.Text), diemTBMonDoi.MaDiem);
                                LoaiDiemCuaTungMon diemHK = new LoaiDiemCuaTungMon("D" + monDoi + "HK" + txtMaHS.Text, double.Parse(txtDiemHK.Text), diemTBMonDoi.MaDiem);
                                //Tính lại điểm trung bình môn đổi
                                diemTBMonDoi.SoDiem = Math.Round((diem15.SoDiem + diem45.SoDiem * 2 + diemHK.SoDiem * 2) / 5, 2);
                                //Tìm loại học lực và điểm trung bình cho b
                                //Trước đó chúng ta phải thực hiện xóa điểm của a đi
                                db.TDiems.Attach(diemCuaA);
                                db.TDiems.Remove(diemCuaA);
                                foreach (var item1 in listLoaiDiemKiemDuoc)
                                {
                                    db.TLoaiDiemCuaTungMons.Attach(item1);
                                    db.TLoaiDiemCuaTungMons.Remove(item1);
                                }
                                db.SaveChanges();

                                //Tiến hành add điểm của b và phải add vào luôn cả Table Sửa như là kết quả sau khi sửa
                                db.TDiems.Add(diemTBMonDoi);
                                LuuTruDiemHSSua diemSauSua = new LuuTruDiemHSSua("SS" + diemTBMonDoi.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], b.MaSoHS, diemTBMonDoi.SoDiem);
                                db.TLuuTruDiemHSSuas.Add(diemSauSua);

                                db.TLoaiDiemCuaTungMons.Add(diem15);
                                LuuTruLoaiDiemHSSua diem15SauSua = new LuuTruLoaiDiemHSSua("SS" + diem15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diem15.SoDiem, diem15.MaDiemCuaLoaiDiem);
                                db.TLuuTruLoaiDiemHSSuas.Add(diem15SauSua);

                                db.TLoaiDiemCuaTungMons.Add(diem45);
                                LuuTruLoaiDiemHSSua diem45SauSua = new LuuTruLoaiDiemHSSua("SS" + diem45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diem45.SoDiem, diem45.MaDiemCuaLoaiDiem);
                                db.TLuuTruLoaiDiemHSSuas.Add(diem45SauSua);

                                db.TLoaiDiemCuaTungMons.Add(diemHK);
                                LuuTruLoaiDiemHSSua diemHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemHK.SoDiem, diemHK.MaDiemCuaLoaiDiem);
                                db.TLuuTruLoaiDiemHSSuas.Add(diemHKSauSua);
                                db.SaveChanges();

                                //Tìm danh sách điểm của B vì đã được cập nhật rồi tính điểm TB cho B
                                var diemB = from diemNao in db.TDiems
                                            where b.MaSoHS == diemNao.MaHSCuaDiemA
                                            select diemNao;

                                List<Diem> listDiemCuaB = diemB.ToList();
                                double diemTBHS = 0;

                                //Các loại điểm để xét học lực
                                Diem diemToan = new Diem();
                                Diem diemNV = new Diem();
                                Diem diemSinh = new Diem();
                                Diem diemVatLy = new Diem();
                                Diem diemHoa = new Diem();
                                Diem diemSu = new Diem();
                                Diem diemDia = new Diem();
                                Diem diemNN = new Diem();
                                Diem diemCD = new Diem();
                                Diem diemQP = new Diem();
                                Diem diemTD = new Diem();
                                Diem diemCN = new Diem();
                                Diem diemTH = new Diem();

                                foreach (var item in listDiemCuaB)
                                {
                                    if (item.MaDiem.Substring(1, 2) == "TO")
                                    {
                                        diemToan = item;
                                    }
                                    else if (item.MaDiem.Substring(1, 2) == "NV")
                                    {
                                        diemNV = item;
                                    }
                                    else if (item.MaDiem.Substring(1, 2) == "SI")
                                    {
                                        diemSinh = item;
                                    }
                                    else if (item.MaDiem.Substring(1, 2) == "VL")
                                    {
                                        diemVatLy = item;
                                    }
                                    else if (item.MaDiem.Substring(1, 2) == "HO")
                                    {
                                        diemHoa = item;
                                    }
                                    else if (item.MaDiem.Substring(1, 2) == "SU")
                                    {
                                        diemSu = item;
                                    }
                                    else if (item.MaDiem.Substring(1, 2) == "DI")
                                    {
                                        diemDia = item;
                                    }
                                    else if (item.MaDiem.Substring(1, 2) == "NN")
                                    {
                                        diemNN = item;
                                    }
                                    else if (item.MaDiem.Substring(1, 2) == "CD")
                                    {
                                        diemCD = item;
                                    }
                                    else if (item.MaDiem.Substring(1, 2) == "QP")
                                    {
                                        diemQP = item;
                                    }
                                    else if (item.MaDiem.Substring(1, 2) == "TD")
                                    {
                                        diemTD = item;
                                    }
                                    else if (item.MaDiem.Substring(1, 2) == "CN")
                                    {
                                        diemCN = item;
                                    }
                                    else
                                    {
                                        diemTH = item;
                                    }
                                }

                                diemTBHS = Math.Round((diemToan.SoDiem * 2 + diemNV.SoDiem * 2 + diemSinh.SoDiem + diemVatLy.SoDiem + diemHoa.SoDiem + diemSu.SoDiem + diemDia.SoDiem + diemNN.SoDiem + diemCD.SoDiem + diemQP.SoDiem + diemTD.SoDiem + diemCN.SoDiem + diemTH.SoDiem) / 15, 2);
                                b.DiemTBCuaHS = diemTBHS;

                                string hocLuc = "";
                                if (diemTBHS >= 8 && diemNV.SoDiem >= 8 && diemTH.SoDiem >= 6.5 && diemCN.SoDiem >= 6.5 && diemTD.SoDiem >= 6.5 && diemQP.SoDiem >= 6.5 && diemCD.SoDiem >= 6.5 && diemNN.SoDiem >= 6.5 && diemDia.SoDiem >= 6.5 && diemSu.SoDiem >= 6.5 && diemHoa.SoDiem >= 6.5 && diemToan.SoDiem >= 6.5 && diemSinh.SoDiem >= 6.5 && diemVatLy.SoDiem >= 6.5 || diemTBHS >= 8 && diemToan.SoDiem >= 8 && diemTH.SoDiem >= 6.5 && diemCN.SoDiem >= 6.5 && diemTD.SoDiem >= 6.5 && diemQP.SoDiem >= 6.5 && diemCD.SoDiem >= 6.5 && diemNN.SoDiem >= 6.5 && diemDia.SoDiem >= 6.5 && diemSu.SoDiem >= 6.5 && diemHoa.SoDiem >= 6.5 && diemNV.SoDiem >= 6.5 && diemSinh.SoDiem >= 6.5 && diemVatLy.SoDiem >= 6.5)
                                {
                                    hocLuc = "Giỏi";
                                }
                                else if (diemTBHS >= 6.5 && diemNV.SoDiem >= 6.5 && diemTH.SoDiem >= 5 && diemCN.SoDiem >= 5 && diemTD.SoDiem >= 5 && diemQP.SoDiem >= 5 && diemCD.SoDiem >= 5 && diemNN.SoDiem >= 5 && diemDia.SoDiem >= 5 && diemSu.SoDiem >= 5 && diemHoa.SoDiem >= 5 && diemToan.SoDiem >= 5 && diemSinh.SoDiem >= 5 && diemVatLy.SoDiem >= 5 || diemTBHS >= 6.5 && diemToan.SoDiem >= 6.5 && diemTH.SoDiem >= 5 && diemCN.SoDiem >= 5 && diemTD.SoDiem >= 5 && diemQP.SoDiem >= 5 && diemCD.SoDiem >= 5 && diemNN.SoDiem >= 5 && diemDia.SoDiem >= 5 && diemSu.SoDiem >= 5 && diemHoa.SoDiem >= 5 && diemNV.SoDiem >= 5 && diemSinh.SoDiem >= 5 && diemVatLy.SoDiem >= 5)
                                {
                                    hocLuc = "Khá";
                                }
                                else if (diemTBHS >= 5 && diemNV.SoDiem >= 5 && diemTH.SoDiem >= 3.5 && diemCN.SoDiem >= 3.5 && diemTD.SoDiem >= 3.5 && diemQP.SoDiem >= 3.5 && diemCD.SoDiem >= 3.5 && diemNN.SoDiem >= 3.5 && diemDia.SoDiem >= 3.5 && diemSu.SoDiem >= 3.5 && diemHoa.SoDiem >= 3.5 && diemToan.SoDiem >= 3.5 && diemSinh.SoDiem >= 3.5 && diemVatLy.SoDiem >= 3.5 || diemTBHS >= 5 && diemToan.SoDiem >= 5 && diemTH.SoDiem >= 3.5 && diemCN.SoDiem >= 3.5 && diemTD.SoDiem >= 3.5 && diemQP.SoDiem >= 3.5 && diemCD.SoDiem >= 3.5 && diemNN.SoDiem >= 3.5 && diemDia.SoDiem >= 3.5 && diemSu.SoDiem >= 3.5 && diemHoa.SoDiem >= 3.5 && diemNV.SoDiem >= 3.5 && diemSinh.SoDiem >= 3.5 && diemVatLy.SoDiem >= 3.5)
                                {
                                    hocLuc = "Trung bình";
                                }
                                else if (diemTBHS >= 3.5 && diemNV.SoDiem >= 2 && diemTH.SoDiem >= 2 && diemCN.SoDiem >= 2 && diemTD.SoDiem >= 2 && diemQP.SoDiem >= 2 && diemCD.SoDiem >= 2 && diemNN.SoDiem >= 2 && diemDia.SoDiem >= 2 && diemSu.SoDiem >= 2 && diemHoa.SoDiem >= 2 && diemToan.SoDiem >= 2 && diemSinh.SoDiem >= 2 && diemVatLy.SoDiem >= 2 || diemTBHS >= 3.5 && diemToan.SoDiem >= 2 && diemTH.SoDiem >= 2 && diemCN.SoDiem >= 2 && diemTD.SoDiem >= 2 && diemQP.SoDiem >= 2 && diemCD.SoDiem >= 2 && diemNN.SoDiem >= 2 && diemDia.SoDiem >= 2 && diemSu.SoDiem >= 2 && diemHoa.SoDiem >= 2 && diemNV.SoDiem >= 2 && diemSinh.SoDiem >= 2 && diemVatLy.SoDiem >= 2)
                                {
                                    hocLuc = "Yếu";
                                }
                                else
                                {
                                    hocLuc = "Kém";
                                }
                                //Từ điểm TB suy ra học lực
                                b.XLHocLuc = hocLuc;
                                //Xóa A gán B vào THocSinhs
                                db.THocSinhs.Attach(a);
                                db.THocSinhs.Remove(a);
                                db.THocSinhs.Add(b);
                                //Và gán b vào bảng sau khi sửa
                                LuuTruHSSua sauKhiSua = new LuuTruHSSua("SS" + b.MaSoHS.ToUpper() + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], b, suaHocSinh.MaChinhSua);
                                db.TLuuTruHSSuas.Add(sauKhiSua);
                                db.SaveChanges();


                                //Đổ lại dữ liệu vào datagrid
                                var hocSinhThuocChuNhiem = from ai in db.THocSinhs
                                                           where ai.LopCuaHS == lopGiaoVienTrongNay
                                                           select ai;
                                List<HocSinh> listHocSinhChuNhiem = hocSinhThuocChuNhiem.ToList();
                                dtHocSinh.ItemsSource = listHocSinhChuNhiem;

                                txtDiaChiHS.Text = "";
                                txtDiem15.Text = "";
                                txtDiem45.Text = "";
                                txtDiemHK.Text = "";
                                txtDiemTBM.Text = "";
                                txtHanhKiem.Text = "";
                                txtHocLuc.Text = "";
                                txtHoTenHS.Text = "";
                                txtMaHS.Text = "";
                                txtQueQuanHS.Text = "";
                                cbMonHS.Text = "";
                                dpNgaySinhHS.Text = "";
                                dtHocSinh.UnselectAll();

                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Có lỗi vui lòng kiểm tra lại!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng kiểm tra lại ô Môn học!!!", "Thông báo!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }

                    }
                    else if (a != null && cbMonHS.Text == "")
                    {
                        try
                        {
                            //Tạo ra một lịch sử chỉnh sửa 
                            DateTime thoiDiemNhap = DateTime.Now;
                            string[] gioPhutGiay = thoiDiemNhap.ToString("HH:mm:ss").Split(':');
                            string nam = thoiDiemNhap.Year.ToString();
                            string taoKey = "TS" + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2];
                            LichSuChinhSua suaHocSinh = new LichSuChinhSua("Sua" + a.MaSoHS.ToUpper() + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], DateTime.Now, maGVTrongNay);
                            db.TLichSuChinhSuas.Add(suaHocSinh);
                            //Lưu lại các thông tin trước khi sửa của HS như thông tin học sinh đó
                            LuuTruHSSua truocKhiSua = new LuuTruHSSua("TS" + a.MaSoHS.ToUpper() + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], a, suaHocSinh.MaChinhSua);
                            db.TLuuTruHSSuas.Add(truocKhiSua);
                            db.SaveChanges();
                            //Tạo 1 HS b mới thừa kế xếp loại học lực và các loại điểm của  a
                            HocSinh b = new HocSinh(txtMaHS.Text, txtHoTenHS.Text, dpNgaySinhHS.DisplayDate, txtDiaChiHS.Text, a.XLHocLuc, txtHanhKiem.Text, txtQueQuanHS.Text, a.LopCuaHS, a.DiemTBCuaHS);
                            db.THocSinhs.Attach(a);
                            db.THocSinhs.Remove(a);
                            db.THocSinhs.Add(b);
                            //Và gán b vào bảng sau khi sửa
                            LuuTruHSSua sauKhiSua = new LuuTruHSSua("SS" + b.MaSoHS.ToUpper() + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], b, suaHocSinh.MaChinhSua);
                            db.TLuuTruHSSuas.Add(sauKhiSua);
                            db.SaveChanges();
                            //Đổ lại dữ liệu vào datagrid
                            var hocSinhThuocChuNhiem = from ai in db.THocSinhs
                                                       where ai.LopCuaHS == lopGiaoVienTrongNay
                                                       select ai;
                            List<HocSinh> listHocSinhChuNhiem = hocSinhThuocChuNhiem.ToList();
                            dtHocSinh.ItemsSource = listHocSinhChuNhiem;

                            txtDiaChiHS.Text = "";
                            txtDiem15.Text = "";
                            txtDiem45.Text = "";
                            txtDiemHK.Text = "";
                            txtDiemTBM.Text = "";
                            txtHanhKiem.Text = "";
                            txtHocLuc.Text = "";
                            txtHoTenHS.Text = "";
                            txtMaHS.Text = "";
                            txtQueQuanHS.Text = "";
                            cbMonHS.Text = "";
                            dpNgaySinhHS.Text = "";
                            dtHocSinh.UnselectAll();


                            imgForChange.Source = null;

                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Có lỗi vui lòng kiểm tra lại!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn học sinh để sửa!!!", "Thông báo!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }

        private void dtHocSinh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HocSinh a = (HocSinh)dtHocSinh.SelectedItem;

            if (a != null)
            {
                //Tìm đường dẫn hình ảnh của HS
                MyEntity db = new MyEntity();
                var duongDan = from linkNao in db.TDuongDans
                               where linkNao.MaDuongDan == "HAHS"
                               select linkNao.DuongDanDenFile;
                List<string> link = duongDan.ToList();
                string path = link[0];
                txtMaHS.Text = a.MaSoHS;
                txtHoTenHS.Text = a.HoTen;
                dpNgaySinhHS.Text = a.NgaySinh.ToString();
                txtHanhKiem.Text = a.XLHanhKiem;
                txtDiaChiHS.Text = a.DiaChi;
                txtHocLuc.Text = a.XLHocLuc;
                txtQueQuanHS.Text = a.QueQuan;
                cbMonHS.Text = "";
                txtDiem15.Text = "";
                txtDiem45.Text = "";
                txtDiemHK.Text = "";
                try
                {
                    string hinhHocSinh = path + "\\" + a.MaSoHS.ToLower() + ".jpg";
                    ImageSource imageSourceHS = new BitmapImage(new Uri(hinhHocSinh));
                    imgForChange.Source = imageSourceHS;
                }
                catch (Exception)
                {


                }
            }
        }

        private void txtDiem15_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDiem15.Text == "")
            {
                txtDiem15.Text = "0";
            }
        }

        private void txtDiem15_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(txtDiem15.Text, out diem);
            if (laDouble || txtDiem15.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtDiem15.Text = "";
                    txtDiem15.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtDiem15.Text = "";
            }
        }

        private void txtDiem45_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDiem45.Text == "")
            {
                txtDiem45.Text = "0";
            }
        }

        private void txtDiem45_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(txtDiem45.Text, out diem);
            if (laDouble || txtDiem45.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtDiem45.Text = "";
                    txtDiem45.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtDiem45.Text = "";
            }
        }

        private void txtDiemHK_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDiemHK.Text == "")
            {
                txtDiemHK.Text = "0";
            }
        }

        private void txtDiemHK_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(txtDiemHK.Text, out diem);
            if (laDouble || txtDiemHK.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtDiemHK.Text = "";
                    txtDiemHK.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtDiemHK.Text = "";
            }
        }

        private void btXemNangCao_Click(object sender, RoutedEventArgs e)
        {
            HocSinh a = (HocSinh)dtHocSinh.SelectedItem;
            HocSinh b = new HocSinh(txtMaHS.Text, txtHoTenHS.Text, dpNgaySinhHS.DisplayDate, txtDiaChiHS.Text, txtHanhKiem.Text, txtQueQuanHS.Text, lopGiaoVienTrongNay);
            if (a != null)
            {
                //Đề phòng trường hợp giáo viên thay đổi textbox thông tin học sinh bên ngoài sẵn tiện sửa điểm luôn                
                XemNangCao giaoDien = new XemNangCao(b, maGVTrongNay);
                giaoDien.ShowDialog();
                if (giaoDien.IsActive == false && giaoDien.CoNhanCapNhatKhong())
                {
                    MyEntity db = new MyEntity();
                    //Cập nhật lại giao diện LopChuNhiem
                    var hocSinhThuocChuNhiem = from ai in db.THocSinhs
                                               where ai.LopCuaHS == lopGiaoVienTrongNay
                                               select ai;
                    List<HocSinh> listHocSinhChuNhiem = hocSinhThuocChuNhiem.ToList();
                    dtHocSinh.ItemsSource = listHocSinhChuNhiem;
                    txtDiaChiHS.Text = "";
                    txtDiem15.Text = "";
                    txtDiem45.Text = "";
                    txtDiemHK.Text = "";
                    txtDiemTBM.Text = "";
                    txtHanhKiem.Text = "";
                    txtHocLuc.Text = "";
                    txtHoTenHS.Text = "";
                    txtMaHS.Text = "";
                    txtQueQuanHS.Text = "";
                    cbMonHS.Text = "";
                    dpNgaySinhHS.Text = "";
                    dtHocSinh.UnselectAll();
                }
            }
            else
            {
                MessageBox.Show("Phải chọn học sinh để dùng chức năng này", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btCapNhatDiem_Click(object sender, RoutedEventArgs e)
        {
            AdminDangNhap admin = new AdminDangNhap();
            admin.ShowDialog();
            if (admin.NhapDung())
            {
                //Mở ra giao diện chọn file
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Các tệp Excel (*.xls;*.xlsx)|*.xls;*.xlsx|All files (*.*)|*.*";
                openFileDialog.ShowDialog();
                //Lấy số lượng học sinh có trong CSDL
                MyEntity db = new MyEntity();
                var giaoVien = from ai in db.TGiaoViens
                               where ai.MaGV == maGVTrongNay
                               select ai;
                List<GiaoVien> cacGiaoViens = giaoVien.ToList();
                //Tìm lớp chủ nhiệm của giáo viên đó
                foreach (var item in cacGiaoViens)
                {
                    if (maGVTrongNay.ToUpper() == item.MaGV)
                    {
                        lopGiaoVienTrongNay = item.LopChuNhiem;
                        break;
                    }
                }
                //Tìm các học sinh được chủ nhiệm bởi giáo viên đó
                var hocSinhThuocChuNhiem = from ai in db.THocSinhs
                                           where ai.LopCuaHS == lopGiaoVienTrongNay
                                           select ai;
                List<HocSinh> listHocSinhChuNhiem = hocSinhThuocChuNhiem.ToList();
                bool capNhatThanhCong = false;
                //Bắt đầu cập nhật điểm cho từng học sinh
                foreach (var hocSinh in listHocSinhChuNhiem)
                {
                    //Tạo ra một lịch sử chỉnh sửa 
                    DateTime thoiDiemNhap = DateTime.Now;
                    string[] gioPhutGiay = thoiDiemNhap.ToString("HH:mm:ss").Split(':');
                    string nam = thoiDiemNhap.Year.ToString();
                    LichSuChinhSua suaHocSinh = new LichSuChinhSua("Sua" + hocSinh.MaSoHS.ToUpper() + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], DateTime.Now, maGVTrongNay);
                    db.TLichSuChinhSuas.Add(suaHocSinh);

                    //Lưu lại các thông tin trước khi sửa của HS 
                    LuuTruHSSua truocKhiSua = new LuuTruHSSua("TS" + hocSinh.MaSoHS.ToUpper() + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], hocSinh, suaHocSinh.MaChinhSua);
                    db.TLuuTruHSSuas.Add(truocKhiSua);


                    //Lưu trữ lại tất cả điểm trước khi sửa
                    var timDiemCuaA = from diemNao in db.TDiems
                                      where diemNao.MaHSCuaDiemA == hocSinh.MaSoHS
                                      select diemNao;
                    List<Diem> listDiemCuaA = timDiemCuaA.ToList();
                    foreach (var diemCuaA in listDiemCuaA)
                    {
                        LuuTruDiemHSSua diemTruocSua = new LuuTruDiemHSSua("TS" + diemCuaA.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], hocSinh.MaSoHS, diemCuaA.SoDiem);
                        db.TLuuTruDiemHSSuas.Add(diemTruocSua);
                    }

                    //Lưu trữ lại tất cả loại điểm trước khi sửa
                    var timLoaiDiemCuaA = from diemNao in db.TLoaiDiemCuaTungMons
                                          where diemNao.MaDiemCuaLoaiDiem.Substring(3).ToUpper() == hocSinh.MaSoHS.ToUpper()
                                          select diemNao;
                    List<LoaiDiemCuaTungMon> listLoaiDiemTungMonA = timLoaiDiemCuaA.ToList();
                    foreach (var loaiDiemCuaA in listLoaiDiemTungMonA)
                    {
                        LuuTruLoaiDiemHSSua diemCanLuu = new LuuTruLoaiDiemHSSua("TS" + loaiDiemCuaA.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], loaiDiemCuaA.SoDiem, loaiDiemCuaA.MaDiemCuaLoaiDiem);
                        db.TLuuTruLoaiDiemHSSuas.Add(diemCanLuu);
                    }

                    //Sau đó tiến hành xóa hết điểm của A
                    foreach (var diemCuaA in listDiemCuaA)
                    {
                        db.TDiems.Remove(diemCuaA);
                    }
                    //Xóa hết loại điểm của A
                    foreach (var loaiDiemCuaA in listLoaiDiemTungMonA)
                    {
                        db.TLoaiDiemCuaTungMons.Remove(loaiDiemCuaA);
                    }

                    if (openFileDialog.FileName != "")
                    {
                        //Tạo ra học sinh B thừa kế gần như toàn bộ thông tin từ A trừ ĐTB và Học lực
                        HocSinh b = new HocSinh(hocSinh.MaSoHS, hocSinh.HoTen, hocSinh.NgaySinh, hocSinh.DiaChi, hocSinh.XLHanhKiem, hocSinh.QueQuan, lopGiaoVienTrongNay);

                        //Tạo đối tượng Excel 
                        Excel.Application app = new Excel.Application();
                        //Mở file Excel Học Sinh
                        Excel.Workbook wb = app.Workbooks.Open(openFileDialog.FileName);
                        try
                        {
                            //Mở sheet đầu tiên là sheet môn toán
                            //Trong này chỉ số đầu tiên bắt đầu từ 1
                            Excel._Worksheet sheetCanMo = wb.Sheets[1];
                            //Truy cập vùng dữ liệu sử dụng
                            Excel.Range range = sheetCanMo.UsedRange;

                            //Bắt đầu đọc dữ liệu

                            //Chúng ta bắt đầu đọc dữ liệu từ dòng 2 vì dòng 1 là tiêu đề

                            //Điểm 15
                            LoaiDiemCuaTungMon diemToan15 = new LoaiDiemCuaTungMon("DTO15" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 2].Value.ToString()), "DTO" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemToan15);

                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemToan15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemToan15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemToan15.SoDiem, diemToan15.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemToan15SauSua);

                            //Điểm 45
                            LoaiDiemCuaTungMon diemToan45 = new LoaiDiemCuaTungMon("DTO45" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 3].Value.ToString()), "DTO" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemToan45);

                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemToan45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemToan45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemToan45.SoDiem, diemToan45.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemToan45SauSua);

                            //Điểm HK
                            LoaiDiemCuaTungMon diemToanHK = new LoaiDiemCuaTungMon("DTOHK" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 4].Value.ToString()), "DTO" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemToanHK);

                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemToanHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemToanHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemToanHK.SoDiem, diemToanHK.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemToanHKSauSua);

                            //ĐTB Môn

                            Diem diemToan = new Diem();
                            diemToan.MaDiem = "DTO" + hocSinh.MaSoHS;
                            diemToan.MaHSCuaDiemA = hocSinh.MaSoHS;
                            diemToan.SoDiem = Math.Round((diemToan15.SoDiem + diemToan45.SoDiem * 2 + diemToanHK.SoDiem * 2) / 5, 2);
                            db.TDiems.Add(diemToan);

                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruDiemHSSua diemToanSauSua = new LuuTruDiemHSSua("SS" + diemToan.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemToan.MaHSCuaDiemA, diemToan.SoDiem);
                            db.TLuuTruDiemHSSuas.Add(diemToanSauSua);

                            //Môn Văn
                            sheetCanMo = wb.Sheets[2];
                            range = sheetCanMo.UsedRange;

                            //Điểm 15
                            LoaiDiemCuaTungMon diemNV15 = new LoaiDiemCuaTungMon("DNV15" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 2].Value.ToString()), "DNV" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemNV15);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemNV15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemNV15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemNV15.SoDiem, diemNV15.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemNV15SauSua);
                            //Điểm 45
                            LoaiDiemCuaTungMon diemNV45 = new LoaiDiemCuaTungMon("DNV45" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 3].Value.ToString()), "DNV" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemNV45);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemNV45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemNV45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemNV45.SoDiem, diemNV45.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemNV45SauSua);
                            //Điểm HK
                            LoaiDiemCuaTungMon diemNVHK = new LoaiDiemCuaTungMon("DNVHK" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 4].Value.ToString()), "DNV" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemNVHK);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemNVHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemNVHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemNVHK.SoDiem, diemNVHK.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemNVHKSauSua);
                            //ĐTB Môn
                            Diem diemNV = new Diem();
                            diemNV.MaDiem = "DNV" + hocSinh.MaSoHS;
                            diemNV.MaHSCuaDiemA = hocSinh.MaSoHS;
                            diemNV.SoDiem = Math.Round((diemNV15.SoDiem + diemNV45.SoDiem * 2 + diemNVHK.SoDiem * 2) / 5, 2);
                            db.TDiems.Add(diemNV);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruDiemHSSua diemNVSauSua = new LuuTruDiemHSSua("SS" + diemNV.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemNV.MaHSCuaDiemA, diemNV.SoDiem);
                            db.TLuuTruDiemHSSuas.Add(diemNVSauSua);

                            //Môn Sinh
                            sheetCanMo = wb.Sheets[3];
                            range = sheetCanMo.UsedRange;

                            //Điểm 15
                            LoaiDiemCuaTungMon diemSinh15 = new LoaiDiemCuaTungMon("DSI15" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 2].Value.ToString()), "DSI" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemSinh15);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemSinh15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemSinh15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemSinh15.SoDiem, diemSinh15.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemSinh15SauSua);
                            //Điểm 45
                            LoaiDiemCuaTungMon diemSinh45 = new LoaiDiemCuaTungMon("DSI45" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 3].Value.ToString()), "DSI" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemSinh45);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemSinh45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemSinh45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemSinh45.SoDiem, diemSinh45.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemSinh45SauSua);
                            //Điểm HK
                            LoaiDiemCuaTungMon diemSinhHK = new LoaiDiemCuaTungMon("DSIHK" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 4].Value.ToString()), "DSI" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemSinhHK);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemSinhHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemSinhHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemSinhHK.SoDiem, diemSinhHK.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemSinhHKSauSua);
                            //ĐTB Môn
                            Diem diemSinh = new Diem();
                            diemSinh.MaDiem = "DSI" + hocSinh.MaSoHS;
                            diemSinh.MaHSCuaDiemA = hocSinh.MaSoHS;
                            diemSinh.SoDiem = Math.Round((diemSinh15.SoDiem + diemSinh45.SoDiem * 2 + diemSinhHK.SoDiem * 2) / 5, 2);
                            db.TDiems.Add(diemSinh);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruDiemHSSua diemSinhSauSua = new LuuTruDiemHSSua("SS" + diemSinh.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemSinh.MaHSCuaDiemA, diemSinh.SoDiem);
                            db.TLuuTruDiemHSSuas.Add(diemSinhSauSua);

                            //Môn Vật lý
                            sheetCanMo = wb.Sheets[4];
                            range = sheetCanMo.UsedRange;

                            //Điểm 15
                            LoaiDiemCuaTungMon diemVatLy15 = new LoaiDiemCuaTungMon("DVL15" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 2].Value.ToString()), "DVL" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemVatLy15);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemVatLy15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemVatLy15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemVatLy15.SoDiem, diemVatLy15.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemVatLy15SauSua);
                            //Điểm 45
                            LoaiDiemCuaTungMon diemVatLy45 = new LoaiDiemCuaTungMon("DVL45" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 3].Value.ToString()), "DVL" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemVatLy45);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemVatLy45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemVatLy45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemVatLy45.SoDiem, diemVatLy45.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemVatLy45SauSua);
                            //Điểm HK
                            LoaiDiemCuaTungMon diemVatLyHK = new LoaiDiemCuaTungMon("DVLHK" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 4].Value.ToString()), "DVL" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemVatLyHK);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemVatLyHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemVatLyHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemVatLyHK.SoDiem, diemVatLyHK.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemVatLyHKSauSua);
                            //ĐTB Môn
                            Diem diemVatLy = new Diem();
                            diemVatLy.MaDiem = "DVL" + hocSinh.MaSoHS;
                            diemVatLy.MaHSCuaDiemA = hocSinh.MaSoHS;
                            diemVatLy.SoDiem = Math.Round((diemVatLy15.SoDiem + diemVatLy45.SoDiem * 2 + diemVatLyHK.SoDiem * 2) / 5, 2);
                            db.TDiems.Add(diemVatLy);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruDiemHSSua diemVatLySauSua = new LuuTruDiemHSSua("SS" + diemVatLy.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemVatLy.MaHSCuaDiemA, diemVatLy.SoDiem);
                            db.TLuuTruDiemHSSuas.Add(diemVatLySauSua);

                            //Môn Hóa
                            sheetCanMo = wb.Sheets[5];
                            range = sheetCanMo.UsedRange;

                            //Điểm 15
                            LoaiDiemCuaTungMon diemHoa15 = new LoaiDiemCuaTungMon("DHO15" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 2].Value.ToString()), "DHO" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemHoa15);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemHoa15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemHoa15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemHoa15.SoDiem, diemHoa15.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemHoa15SauSua);
                            //Điểm 45
                            LoaiDiemCuaTungMon diemHoa45 = new LoaiDiemCuaTungMon("DHO45" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 3].Value.ToString()), "DHO" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemHoa45);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemHoa45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemHoa45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemHoa45.SoDiem, diemHoa45.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemHoa45SauSua);
                            //Điểm HK
                            LoaiDiemCuaTungMon diemHoaHK = new LoaiDiemCuaTungMon("DHOHK" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 4].Value.ToString()), "DHO" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemHoaHK);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemHoaHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemHoaHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemHoaHK.SoDiem, diemHoaHK.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemHoaHKSauSua);
                            //ĐTB Môn
                            Diem diemHoa = new Diem();
                            diemHoa.MaDiem = "DHO" + hocSinh.MaSoHS;
                            diemHoa.MaHSCuaDiemA = hocSinh.MaSoHS;
                            diemHoa.SoDiem = Math.Round((diemHoa15.SoDiem + diemHoa45.SoDiem * 2 + diemHoaHK.SoDiem * 2) / 5, 2);
                            db.TDiems.Add(diemHoa);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruDiemHSSua diemHoaSauSua = new LuuTruDiemHSSua("SS" + diemHoa.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemHoa.MaHSCuaDiemA, diemHoa.SoDiem);
                            db.TLuuTruDiemHSSuas.Add(diemHoaSauSua);

                            //Môn Sử
                            sheetCanMo = wb.Sheets[6];
                            range = sheetCanMo.UsedRange;

                            //Điểm 15
                            LoaiDiemCuaTungMon diemSu15 = new LoaiDiemCuaTungMon("DSU15" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 2].Value.ToString()), "DSU" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemSu15);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemSu15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemSu15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemSu15.SoDiem, diemSu15.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemSu15SauSua);
                            //Điểm 45
                            LoaiDiemCuaTungMon diemSu45 = new LoaiDiemCuaTungMon("DSU45" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 3].Value.ToString()), "DSU" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemSu45);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemSu45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemSu45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemSu45.SoDiem, diemSu45.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemSu45SauSua);
                            //Điểm HK
                            LoaiDiemCuaTungMon diemSuHK = new LoaiDiemCuaTungMon("DSUHK" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 4].Value.ToString()), "DSU" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemSuHK);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemSuHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemSuHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemSuHK.SoDiem, diemSuHK.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemSuHKSauSua);
                            //ĐTB Môn
                            Diem diemSu = new Diem();
                            diemSu.MaDiem = "DSU" + hocSinh.MaSoHS;
                            diemSu.MaHSCuaDiemA = hocSinh.MaSoHS;
                            diemSu.SoDiem = Math.Round((diemSu15.SoDiem + diemSu45.SoDiem * 2 + diemSuHK.SoDiem * 2) / 5, 2);
                            db.TDiems.Add(diemSu);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruDiemHSSua diemSuSauSua = new LuuTruDiemHSSua("SS" + diemSu.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemSu.MaHSCuaDiemA, diemSu.SoDiem);
                            db.TLuuTruDiemHSSuas.Add(diemSuSauSua);

                            //Môn Địa
                            sheetCanMo = wb.Sheets[7];
                            range = sheetCanMo.UsedRange;

                            //Điểm 15
                            LoaiDiemCuaTungMon diemDia15 = new LoaiDiemCuaTungMon("DDI15" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 2].Value.ToString()), "DDI" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemDia15);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemDia15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemDia15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemDia15.SoDiem, diemDia15.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemDia15SauSua);
                            //Điểm 45
                            LoaiDiemCuaTungMon diemDia45 = new LoaiDiemCuaTungMon("DDI45" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 3].Value.ToString()), "DDI" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemDia45);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemDia45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemDia45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemDia45.SoDiem, diemDia45.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemDia45SauSua);
                            //Điểm HK
                            LoaiDiemCuaTungMon diemDiaHK = new LoaiDiemCuaTungMon("DDIHK" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 4].Value.ToString()), "DDI" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemDiaHK);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemDiaHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemDiaHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemDiaHK.SoDiem, diemDiaHK.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemDiaHKSauSua);
                            //ĐTB Môn
                            Diem diemDia = new Diem();
                            diemDia.MaDiem = "DDI" + hocSinh.MaSoHS;
                            diemDia.MaHSCuaDiemA = hocSinh.MaSoHS;
                            diemDia.SoDiem = Math.Round((diemDia15.SoDiem + diemDia45.SoDiem * 2 + diemDiaHK.SoDiem * 2) / 5, 2);
                            db.TDiems.Add(diemDia);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruDiemHSSua diemDiaSauSua = new LuuTruDiemHSSua("SS" + diemDia.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemDia.MaHSCuaDiemA, diemDia.SoDiem);
                            db.TLuuTruDiemHSSuas.Add(diemDiaSauSua);

                            //Môn Ngoại ngữ
                            sheetCanMo = wb.Sheets[8];
                            range = sheetCanMo.UsedRange;

                            //Điểm 15
                            LoaiDiemCuaTungMon diemNN15 = new LoaiDiemCuaTungMon("DNN15" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 2].Value.ToString()), "DNN" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemNN15);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemNN15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemNN15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemNN15.SoDiem, diemNN15.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemNN15SauSua);
                            //Điểm 45
                            LoaiDiemCuaTungMon diemNN45 = new LoaiDiemCuaTungMon("DNN45" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 3].Value.ToString()), "DNN" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemNN45);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemNN45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemNN45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemNN45.SoDiem, diemNN45.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemNN45SauSua);
                            //Điểm HK
                            LoaiDiemCuaTungMon diemNNHK = new LoaiDiemCuaTungMon("DNNHK" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 4].Value.ToString()), "DNN" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemNNHK);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemNNHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemNNHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemNNHK.SoDiem, diemNNHK.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemNNHKSauSua);
                            //ĐTB Môn
                            Diem diemNN = new Diem();
                            diemNN.MaDiem = "DNN" + hocSinh.MaSoHS;
                            diemNN.MaHSCuaDiemA = hocSinh.MaSoHS;
                            diemNN.SoDiem = Math.Round((diemNN15.SoDiem + diemNN45.SoDiem * 2 + diemNNHK.SoDiem * 2) / 5, 2);
                            db.TDiems.Add(diemNN);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruDiemHSSua diemNNSauSua = new LuuTruDiemHSSua("SS" + diemNN.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemNN.MaHSCuaDiemA, diemNN.SoDiem);
                            db.TLuuTruDiemHSSuas.Add(diemNNSauSua);

                            //Môn Công dân
                            sheetCanMo = wb.Sheets[9];
                            range = sheetCanMo.UsedRange;

                            //Điểm 15
                            LoaiDiemCuaTungMon diemCD15 = new LoaiDiemCuaTungMon("DCD15" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 2].Value.ToString()), "DCD" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemCD15);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemCD15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemCD15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemCD15.SoDiem, diemCD15.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemCD15SauSua);
                            //Điểm 45
                            LoaiDiemCuaTungMon diemCD45 = new LoaiDiemCuaTungMon("DCD45" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 3].Value.ToString()), "DCD" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemCD45);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemCD45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemCD45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemCD45.SoDiem, diemCD45.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemCD45SauSua);
                            //Điểm HK
                            LoaiDiemCuaTungMon diemCDHK = new LoaiDiemCuaTungMon("DCDHK" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 4].Value.ToString()), "DCD" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemCDHK);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemCDHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemCDHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemCDHK.SoDiem, diemCDHK.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemCDHKSauSua);
                            //ĐTB Môn
                            Diem diemCD = new Diem();
                            diemCD.MaDiem = "DCD" + hocSinh.MaSoHS;
                            diemCD.MaHSCuaDiemA = hocSinh.MaSoHS;
                            diemCD.SoDiem = Math.Round((diemCD15.SoDiem + diemCD45.SoDiem * 2 + diemCDHK.SoDiem * 2) / 5, 2);
                            db.TDiems.Add(diemCD);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruDiemHSSua diemCDSauSua = new LuuTruDiemHSSua("SS" + diemCD.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemCD.MaHSCuaDiemA, diemCD.SoDiem);
                            db.TLuuTruDiemHSSuas.Add(diemCDSauSua);

                            //Môn Quốc phòng
                            sheetCanMo = wb.Sheets[10];
                            range = sheetCanMo.UsedRange;

                            //Điểm 15
                            LoaiDiemCuaTungMon diemQP15 = new LoaiDiemCuaTungMon("DQP15" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 2].Value.ToString()), "DQP" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemQP15);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemQP15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemQP15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemQP15.SoDiem, diemQP15.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemQP15SauSua);
                            //Điểm 45
                            LoaiDiemCuaTungMon diemQP45 = new LoaiDiemCuaTungMon("DQP45" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 3].Value.ToString()), "DQP" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemQP45);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemQP45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemQP45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemQP45.SoDiem, diemQP45.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemQP45SauSua);
                            //Điểm HK
                            LoaiDiemCuaTungMon diemQPHK = new LoaiDiemCuaTungMon("DQPHK" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 4].Value.ToString()), "DQP" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemQPHK);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemQPHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemQPHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemQPHK.SoDiem, diemQPHK.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemQPHKSauSua);
                            //ĐTB Môn
                            Diem diemQP = new Diem();
                            diemQP.MaDiem = "DQP" + hocSinh.MaSoHS;
                            diemQP.MaHSCuaDiemA = hocSinh.MaSoHS;
                            diemQP.SoDiem = Math.Round((diemQP15.SoDiem + diemQP45.SoDiem * 2 + diemQPHK.SoDiem * 2) / 5, 2);
                            db.TDiems.Add(diemQP);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruDiemHSSua diemQPSauSua = new LuuTruDiemHSSua("SS" + diemQP.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemQP.MaHSCuaDiemA, diemQP.SoDiem);
                            db.TLuuTruDiemHSSuas.Add(diemQPSauSua);

                            //Môn Thể dục
                            sheetCanMo = wb.Sheets[11];
                            range = sheetCanMo.UsedRange;

                            //Điểm 15
                            LoaiDiemCuaTungMon diemTD15 = new LoaiDiemCuaTungMon("DTD15" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 2].Value.ToString()), "DTD" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemTD15);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemTD15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemTD15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemTD15.SoDiem, diemTD15.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemTD15SauSua);
                            //Điểm 45
                            LoaiDiemCuaTungMon diemTD45 = new LoaiDiemCuaTungMon("DTD45" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 3].Value.ToString()), "DTD" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemTD45);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemTD45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemTD45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemTD45.SoDiem, diemTD45.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemTD45SauSua);
                            //Điểm HK
                            LoaiDiemCuaTungMon diemTDHK = new LoaiDiemCuaTungMon("DTDHK" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 4].Value.ToString()), "DTD" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemTDHK);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemTDHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemTDHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemTDHK.SoDiem, diemTDHK.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemTDHKSauSua);
                            //ĐTB Môn
                            Diem diemTD = new Diem();
                            diemTD.MaDiem = "DTD" + hocSinh.MaSoHS;
                            diemTD.MaHSCuaDiemA = hocSinh.MaSoHS;
                            diemTD.SoDiem = Math.Round((diemTD15.SoDiem + diemTD45.SoDiem * 2 + diemTDHK.SoDiem * 2) / 5, 2);
                            db.TDiems.Add(diemTD);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruDiemHSSua diemTDSauSua = new LuuTruDiemHSSua("SS" + diemTD.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemTD.MaHSCuaDiemA, diemTD.SoDiem);
                            db.TLuuTruDiemHSSuas.Add(diemTDSauSua);

                            //Môn Công nghệ
                            sheetCanMo = wb.Sheets[12];
                            range = sheetCanMo.UsedRange;

                            //Điểm 15
                            LoaiDiemCuaTungMon diemCN15 = new LoaiDiemCuaTungMon("DCN15" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 2].Value.ToString()), "DCN" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemCN15);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemCN15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemCN15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemCN15.SoDiem, diemCN15.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemCN15SauSua);
                            //Điểm 45
                            LoaiDiemCuaTungMon diemCN45 = new LoaiDiemCuaTungMon("DCN45" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 3].Value.ToString()), "DCN" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemCN45);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemCN45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemCN45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemCN45.SoDiem, diemCN45.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemCN45SauSua);
                            //Điểm HK
                            LoaiDiemCuaTungMon diemCNHK = new LoaiDiemCuaTungMon("DCNHK" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 4].Value.ToString()), "DCN" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemCNHK);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemCNHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemCNHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemCNHK.SoDiem, diemCNHK.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemCNHKSauSua);
                            //ĐTB Môn
                            Diem diemCN = new Diem();
                            diemCN.MaDiem = "DCN" + hocSinh.MaSoHS;
                            diemCN.MaHSCuaDiemA = hocSinh.MaSoHS;
                            diemCN.SoDiem = Math.Round((diemCN15.SoDiem + diemCN45.SoDiem * 2 + diemCNHK.SoDiem * 2) / 5, 2);
                            db.TDiems.Add(diemCN);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruDiemHSSua diemCNSauSua = new LuuTruDiemHSSua("SS" + diemCN.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemCN.MaHSCuaDiemA, diemCN.SoDiem);
                            db.TLuuTruDiemHSSuas.Add(diemCNSauSua);

                            //Môn Tin học
                            sheetCanMo = wb.Sheets[13];
                            range = sheetCanMo.UsedRange;

                            //Điểm 15
                            LoaiDiemCuaTungMon diemTH15 = new LoaiDiemCuaTungMon("DTH15" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 2].Value.ToString()), "DTH" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemTH15);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemTH15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemTH15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemTH15.SoDiem, diemTH15.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemTH15SauSua);
                            //Điểm 45
                            LoaiDiemCuaTungMon diemTH45 = new LoaiDiemCuaTungMon("DTH45" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 3].Value.ToString()), "DTH" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemTH45);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemTH45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemTH45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemTH45.SoDiem, diemTH45.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemTH45SauSua);
                            //Điểm HK
                            LoaiDiemCuaTungMon diemTHHK = new LoaiDiemCuaTungMon("DTHHK" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhChuNhiem.IndexOf(hocSinh) + 2, 4].Value.ToString()), "DTH" + hocSinh.MaSoHS);
                            db.TLoaiDiemCuaTungMons.Add(diemTHHK);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruLoaiDiemHSSua diemTHHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemTHHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemTHHK.SoDiem, diemTHHK.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemTHHKSauSua);
                            //ĐTB Môn
                            Diem diemTH = new Diem();
                            diemTH.MaDiem = "DTH" + hocSinh.MaSoHS;
                            diemTH.MaHSCuaDiemA = hocSinh.MaSoHS;
                            diemTH.SoDiem = Math.Round((diemTH15.SoDiem + diemTH45.SoDiem * 2 + diemTHHK.SoDiem * 2) / 5, 2);
                            db.TDiems.Add(diemTH);
                            //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                            LuuTruDiemHSSua diemTHSauSua = new LuuTruDiemHSSua("SS" + diemTH.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemTH.MaHSCuaDiemA, diemTH.SoDiem);
                            db.TLuuTruDiemHSSuas.Add(diemTHSauSua);

                            //Chúng ta còn thiếu ĐTB và Xếp loại học lực nên chúng ta sẽ bổ sung
                            double diemTBHS = Math.Round((diemToan.SoDiem * 2 + diemNV.SoDiem * 2 + diemSinh.SoDiem + diemVatLy.SoDiem + diemHoa.SoDiem + diemSu.SoDiem + diemDia.SoDiem + diemNN.SoDiem + diemCD.SoDiem + diemQP.SoDiem + diemTD.SoDiem + diemCN.SoDiem + diemTH.SoDiem) / 15, 2);
                            //Như vậy điểm TB của Hs này là
                            b.DiemTBCuaHS = diemTBHS;
                            //Giờ đến tiêu chí xét
                            string xepLoai = "";
                            if (diemTBHS >= 8 && diemNV.SoDiem >= 8 && diemTH.SoDiem >= 6.5 && diemCN.SoDiem >= 6.5 && diemTD.SoDiem >= 6.5 && diemQP.SoDiem >= 6.5 && diemCD.SoDiem >= 6.5 && diemNN.SoDiem >= 6.5 && diemDia.SoDiem >= 6.5 && diemSu.SoDiem >= 6.5 && diemHoa.SoDiem >= 6.5 && diemToan.SoDiem >= 6.5 && diemSinh.SoDiem >= 6.5 && diemVatLy.SoDiem >= 6.5 || diemTBHS >= 8 && diemToan.SoDiem >= 8 && diemTH.SoDiem >= 6.5 && diemCN.SoDiem >= 6.5 && diemTD.SoDiem >= 6.5 && diemQP.SoDiem >= 6.5 && diemCD.SoDiem >= 6.5 && diemNN.SoDiem >= 6.5 && diemDia.SoDiem >= 6.5 && diemSu.SoDiem >= 6.5 && diemHoa.SoDiem >= 6.5 && diemNV.SoDiem >= 6.5 && diemSinh.SoDiem >= 6.5 && diemVatLy.SoDiem >= 6.5)
                            {
                                xepLoai = "Giỏi";
                            }
                            else if (diemTBHS >= 6.5 && diemNV.SoDiem >= 6.5 && diemTH.SoDiem >= 5 && diemCN.SoDiem >= 5 && diemTD.SoDiem >= 5 && diemQP.SoDiem >= 5 && diemCD.SoDiem >= 5 && diemNN.SoDiem >= 5 && diemDia.SoDiem >= 5 && diemSu.SoDiem >= 5 && diemHoa.SoDiem >= 5 && diemToan.SoDiem >= 5 && diemSinh.SoDiem >= 5 && diemVatLy.SoDiem >= 5 || diemTBHS >= 6.5 && diemToan.SoDiem >= 6.5 && diemTH.SoDiem >= 5 && diemCN.SoDiem >= 5 && diemTD.SoDiem >= 5 && diemQP.SoDiem >= 5 && diemCD.SoDiem >= 5 && diemNN.SoDiem >= 5 && diemDia.SoDiem >= 5 && diemSu.SoDiem >= 5 && diemHoa.SoDiem >= 5 && diemNV.SoDiem >= 5 && diemSinh.SoDiem >= 5 && diemVatLy.SoDiem >= 5)
                            {
                                xepLoai = "Khá";
                            }
                            else if (diemTBHS >= 5 && diemNV.SoDiem >= 5 && diemTH.SoDiem >= 3.5 && diemCN.SoDiem >= 3.5 && diemTD.SoDiem >= 3.5 && diemQP.SoDiem >= 3.5 && diemCD.SoDiem >= 3.5 && diemNN.SoDiem >= 3.5 && diemDia.SoDiem >= 3.5 && diemSu.SoDiem >= 3.5 && diemHoa.SoDiem >= 3.5 && diemToan.SoDiem >= 3.5 && diemSinh.SoDiem >= 3.5 && diemVatLy.SoDiem >= 3.5 || diemTBHS >= 5 && diemToan.SoDiem >= 5 && diemTH.SoDiem >= 3.5 && diemCN.SoDiem >= 3.5 && diemTD.SoDiem >= 3.5 && diemQP.SoDiem >= 3.5 && diemCD.SoDiem >= 3.5 && diemNN.SoDiem >= 3.5 && diemDia.SoDiem >= 3.5 && diemSu.SoDiem >= 3.5 && diemHoa.SoDiem >= 3.5 && diemNV.SoDiem >= 3.5 && diemSinh.SoDiem >= 3.5 && diemVatLy.SoDiem >= 3.5)
                            {
                                xepLoai = "Trung bình";
                            }
                            else if (diemTBHS >= 3.5 && diemNV.SoDiem >= 2 && diemTH.SoDiem >= 2 && diemCN.SoDiem >= 2 && diemTD.SoDiem >= 2 && diemQP.SoDiem >= 2 && diemCD.SoDiem >= 2 && diemNN.SoDiem >= 2 && diemDia.SoDiem >= 2 && diemSu.SoDiem >= 2 && diemHoa.SoDiem >= 2 && diemToan.SoDiem >= 2 && diemSinh.SoDiem >= 2 && diemVatLy.SoDiem >= 2 || diemTBHS >= 3.5 && diemToan.SoDiem >= 2 && diemTH.SoDiem >= 2 && diemCN.SoDiem >= 2 && diemTD.SoDiem >= 2 && diemQP.SoDiem >= 2 && diemCD.SoDiem >= 2 && diemNN.SoDiem >= 2 && diemDia.SoDiem >= 2 && diemSu.SoDiem >= 2 && diemHoa.SoDiem >= 2 && diemNV.SoDiem >= 2 && diemSinh.SoDiem >= 2 && diemVatLy.SoDiem >= 2)
                            {
                                xepLoai = "Yếu";
                            }
                            else
                            {
                                xepLoai = "Kém";
                            }
                            b.XLHocLuc = xepLoai;
                            //Xóa A gán B vào THocSinhs
                            db.THocSinhs.Attach(hocSinh);
                            db.THocSinhs.Remove(hocSinh);
                            db.THocSinhs.Add(b);
                            //Và gán b vào bảng sau khi sửa
                            LuuTruHSSua sauKhiSua = new LuuTruHSSua("SS" + b.MaSoHS.ToUpper() + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], b, suaHocSinh.MaChinhSua);
                            db.TLuuTruHSSuas.Add(sauKhiSua);
                            db.SaveChanges();
                            capNhatThanhCong = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Thông báo!!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        finally
                        {
                            app.Quit();
                            wb = null;
                        }
                    }

                }

                if (capNhatThanhCong)
                {
                    MessageBox.Show("Cập nhật điểm thành công!!!", "Thông báo!!!", MessageBoxButton.OK, MessageBoxImage.Information);
                    //Đổ dữ liệu vào giao diện
                    hocSinhThuocChuNhiem = from ai in db.THocSinhs
                                           where ai.LopCuaHS == lopGiaoVienTrongNay
                                           select ai;
                    listHocSinhChuNhiem = hocSinhThuocChuNhiem.ToList();
                    dtHocSinh.ItemsSource = listHocSinhChuNhiem;
                }
            }
        }

        private void btIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GiaoDienInThongTin a = new GiaoDienInThongTin();
                InLopChuNhiem b = new InLopChuNhiem();
                b.Refresh();
                a.inThongTin.ViewerCore.ReportSource = b;
                a.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btTim_Click(object sender, RoutedEventArgs e)
        {
            MyEntity db = new MyEntity();
            //Tìm học sinh trong lớp giáo viên này chủ nhiệm cùng với điều kiện trong textbox
            var hocSinhThuocChuNhiem = from ai in db.THocSinhs
                                       where ai.LopCuaHS == lopGiaoVienTrongNay && ai.MaSoHS == tbTim.Text || ai.LopCuaHS == lopGiaoVienTrongNay && ai.HoTen == tbTim.Text || ai.LopCuaHS == lopGiaoVienTrongNay && ai.XLHocLuc == tbTim.Text || ai.LopCuaHS == lopGiaoVienTrongNay && ai.DiemTBCuaHS.ToString() == tbTim.Text || ai.LopCuaHS == lopGiaoVienTrongNay && ai.QueQuan == tbTim.Text || ai.LopCuaHS == lopGiaoVienTrongNay && ai.DiaChi == tbTim.Text || ai.LopCuaHS == lopGiaoVienTrongNay && ai.XLHanhKiem == tbTim.Text
                                       select ai;
            List<HocSinh> listHocSinhChuNhiem = hocSinhThuocChuNhiem.ToList();
            //Đổ dữ liệu vào giao diện
            dtHocSinh.ItemsSource = listHocSinhChuNhiem;
        }

        private void tbTim_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbTim.Text == "")
            {
                MyEntity db = new MyEntity();
                var hocSinhThuocChuNhiem = from ai in db.THocSinhs
                                           where ai.LopCuaHS == lopGiaoVienTrongNay
                                           select ai;
                List<HocSinh> listHocSinhChuNhiem = hocSinhThuocChuNhiem.ToList();
                //Đổ dữ liệu vào giao diện
                dtHocSinh.ItemsSource = listHocSinhChuNhiem;
            }
        }
    }
}
