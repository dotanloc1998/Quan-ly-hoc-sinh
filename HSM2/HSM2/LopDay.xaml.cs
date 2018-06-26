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
    /// Interaction logic for LopDay.xaml
    /// </summary>
    public partial class LopDay : UserControl
    {
        public static string maGVTrongNay;
        public LopDay(string maGV)
        {
            InitializeComponent();
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
            //Không show lớp mà giáo viên này chủ nhiệm
            var giaoVien = from ai in db.TGiaoViens
                           where ai.MaGV == maGVTrongNay
                           select ai;
            List<GiaoVien> dsGV = giaoVien.ToList();
            GiaoVien khongCanCoiLopChuNhiem = dsGV[0];
            var nhungLopGVDay = from lopNao in db.TGiaoVienDayHocSinhs
                                where lopNao.MaCuaGV == maGV && lopNao.MaLopCuaSV != khongCanCoiLopChuNhiem.LopChuNhiem
                                select lopNao.MaLopCuaSV;
            cbLopDay.ItemsSource = nhungLopGVDay.ToList();
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

        private void btThemLop_Click(object sender, RoutedEventArgs e)
        {
            //Tìm thông tin giáo viên trong CSDL
            MyEntity db = new MyEntity();
            var giaoViens = from ai in db.TGiaoViens
                            where maGVTrongNay == ai.MaGV
                            select ai;
            List<GiaoVien> giaoVien = giaoViens.ToList();
            GiaoVien giaoVienTimDuoc = giaoVien[0];
            ChonLop a = new ChonLop(maGVTrongNay, giaoVienTimDuoc.MonDay);
            a.ShowDialog();
            if (a.IsActive == false)
            {
                var nhungLopGVDay = from lopNao in db.TGiaoVienDayHocSinhs
                                    where lopNao.MaCuaGV == maGVTrongNay && lopNao.MaLopCuaSV != giaoVienTimDuoc.LopChuNhiem
                                    select lopNao.MaLopCuaSV;
                cbLopDay.ItemsSource = nhungLopGVDay.ToList();
            }
        }

        private void cbLopDay_DropDownClosed(object sender, EventArgs e)
        {
            MyEntity db = new MyEntity();
            //Tìm ra môn GV này dạy
            var giaoVien = from ai in db.TGiaoViens
                           where ai.MaGV == maGVTrongNay
                           select ai;
            List<GiaoVien> dsGiaoViens = giaoVien.ToList();
            string monHoc = dsGiaoViens[0].MonDay;

            var maMon = from monNao in db.TMonHocs
                        where monNao.TenMH == monHoc
                        select monNao;
            List<MonHoc> dsMons = maMon.ToList();
            string maMH = dsMons[0].MaMH;

            var nhungHocSinhLopNay = from ai in db.THocSinhs
                                     where ai.LopCuaHS == cbLopDay.Text
                                     select ai;
            List<HocSinh> dsHocSinh = nhungHocSinhLopNay.ToList();
            List<HocSinhView> dshocSinhViews = new List<HocSinhView>();

            if (dsHocSinh.Count != 0)
            {
                foreach (var hocSinh in dsHocSinh)
                {
                    HocSinhView a = new HocSinhView(hocSinh.MaSoHS, hocSinh.HoTen, hocSinh.XLHanhKiem, hocSinh.LopCuaHS);
                    var timDiemHSNay = from diemNao in db.TDiems
                                       where diemNao.MaDiem == "D" + maMH + hocSinh.MaSoHS
                                       select diemNao;
                    List<Diem> soDiemKiemDC = timDiemHSNay.ToList();
                    Diem diemCuaHS = soDiemKiemDC[0];

                    var timLoaiDiemHSNay = from diemNao in db.TLoaiDiemCuaTungMons
                                           where diemNao.MaDiemCuaLoaiDiem == diemCuaHS.MaDiem
                                           select diemNao;
                    List<LoaiDiemCuaTungMon> loaiDiemKiemDuoc = timLoaiDiemHSNay.ToList();

                    double diem15 = 0;
                    double diem45 = 0;
                    double diemHK = 0;
                    foreach (var diem in loaiDiemKiemDuoc)
                    {
                        if (diem.MaLoaiDiem == "D" + maMH + "15" + hocSinh.MaSoHS)
                        {
                            diem15 = diem.SoDiem;
                        }
                        else if (diem.MaLoaiDiem == "D" + maMH + "45" + hocSinh.MaSoHS)
                        {
                            diem45 = diem.SoDiem;
                        }
                        else
                        {
                            diemHK = diem.SoDiem;
                        }
                    }

                    a.Diem15CuaMonDuocChon = diem15;
                    a.Diem45CuaMonDuocChon = diem45;
                    a.DiemHKCuaMonDuocChon = diemHK;
                    a.DiemTBCuaMonDuocChon = diemCuaHS.SoDiem;
                    dshocSinhViews.Add(a);
                }
            }

            if (dshocSinhViews.Count != 0)
            {
                dtHocSinh.ItemsSource = dshocSinhViews;
            }

        }

        private void btXoaLop_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Đồng ý xóa lớp dạy này?", "Thông báo!!!", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.OK) == MessageBoxResult.OK)
            {
                MyEntity db = new MyEntity();
                var lopXoa = from lopNao in db.TGiaoVienDayHocSinhs
                             where lopNao.MaCuaGV == maGVTrongNay && lopNao.MaLopCuaSV == cbLopDay.Text
                             select lopNao;
                List<GiaoVienDayHocSinh> lopCanXoa = lopXoa.ToList();
                db.TGiaoVienDayHocSinhs.Remove(lopCanXoa[0]);
                db.SaveChanges();
                cbLopDay.Text = "";
                var nhungLopGVDay = from lopNao in db.TGiaoVienDayHocSinhs
                                    where lopNao.MaCuaGV == maGVTrongNay
                                    select lopNao.MaLopCuaSV;
                cbLopDay.ItemsSource = nhungLopGVDay.ToList();
                dtHocSinh.ItemsSource = "";
            }
        }

        private void dtHocSinh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HocSinhView a = (HocSinhView)dtHocSinh.SelectedItem;

            if (a != null)
            {
                txtMaHS.Text = a.MaSoHS;
                txtHoTenHS.Text = a.HoTen;
                txtHanhKiem.Text = a.XLHanhKiem;
                txtLopHS.Text = a.LopCuaHS;
                txtDiem15.Text = a.Diem15CuaMonDuocChon.ToString();
                txtDiem45.Text = a.Diem45CuaMonDuocChon.ToString();
                txtDiemHK.Text = a.DiemHKCuaMonDuocChon.ToString();
                txtDiemTBM.Text = a.DiemTBCuaMonDuocChon.ToString();
                //Tìm đường dẫn hình ảnh của HS
                MyEntity db = new MyEntity();
                var duongDan = from linkNao in db.TDuongDans
                               where linkNao.MaDuongDan == "HAHS"
                               select linkNao.DuongDanDenFile;
                List<string> link = duongDan.ToList();
                string path = link[0];
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

        //Giao diện
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

        private void btSua_Click(object sender, RoutedEventArgs e)
        {
            AdminDangNhap admin = new AdminDangNhap();
            admin.ShowDialog();
            if (admin.NhapDung())
            {
                HocSinhView duocChon = (HocSinhView)dtHocSinh.SelectedItem;
                if (duocChon != null)
                {
                    MyEntity db = new MyEntity();
                    //Kiếm môn học mà giáo viên này dạy
                    var giaoVien = from ai in db.TGiaoViens
                                   where ai.MaGV == maGVTrongNay
                                   select ai;
                    List<GiaoVien> giaoVienTimDuoc = giaoVien.ToList();
                    GiaoVien canKiemMon = giaoVienTimDuoc[0];

                    //Kiếm mã MH
                    var monHoc = from monNao in db.TMonHocs
                                 where monNao.TenMH == canKiemMon.MonDay
                                 select monNao.MaMH;
                    List<string> monKiemDuoc = monHoc.ToList();
                    string maMH = monKiemDuoc[0];



                    //Vì đây là HocSinhView không phải HocSinh nên chúng ta phải kiếm học sinh tương ứng trong CDSL THocSinhs

                    var timHS = from ai in db.THocSinhs
                                where duocChon.MaSoHS == ai.MaSoHS
                                select ai;
                    List<HocSinh> timThay = timHS.ToList();
                    HocSinh a = timThay[0];

                    //Tạo ra một lịch sử chỉnh sửa 
                    DateTime thoiDiemNhap = DateTime.Now;
                    string[] gioPhutGiay = thoiDiemNhap.ToString("HH:mm:ss").Split(':');
                    string nam = thoiDiemNhap.Year.ToString();
                    LichSuChinhSua suaHocSinh = new LichSuChinhSua("Sua" + a.MaSoHS.ToUpper() + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], DateTime.Now, maGVTrongNay);
                    db.TLichSuChinhSuas.Add(suaHocSinh);

                    //Lưu lại các thông tin trước khi sửa của HS như thông tin học sinh đó
                    LuuTruHSSua truocKhiSua = new LuuTruHSSua("TS" + a.MaSoHS.ToUpper() + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], a, suaHocSinh.MaChinhSua);
                    db.TLuuTruHSSuas.Add(truocKhiSua);


                    //Tìm điểm của A
                    //Kiếm điểm của A tương ứng môn dạy của giáo viên này
                    var diemXoa = from diemNao in db.TDiems
                                  where "D" + maMH + a.MaSoHS == diemNao.MaDiem
                                  select diemNao;
                    List<Diem> kiemThay = diemXoa.ToList();
                    Diem diemCuaA = kiemThay[0];

                    //Lưu trữ lại điểm này
                    LuuTruDiemHSSua diemTruocSua = new LuuTruDiemHSSua("TS" + diemCuaA.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], a.MaSoHS, diemCuaA.SoDiem);
                    db.TLuuTruDiemHSSuas.Add(diemTruocSua);

                    //Lưu trữ lại các loại điểm của điểm này
                    var cacLoaiDiemMonNay = from diemNao in db.TLoaiDiemCuaTungMons
                                            where "D" + maMH + a.MaSoHS == diemNao.MaDiemCuaLoaiDiem
                                            select diemNao;
                    List<LoaiDiemCuaTungMon> listLoaiDiemKiemDuoc = cacLoaiDiemMonNay.ToList();

                    foreach (var item in listLoaiDiemKiemDuoc)
                    {
                        LuuTruLoaiDiemHSSua diemCanLuu = new LuuTruLoaiDiemHSSua("TS" + item.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], item.SoDiem, item.MaDiemCuaLoaiDiem);
                        db.TLuuTruLoaiDiemHSSuas.Add(diemCanLuu);
                    }
                    db.SaveChanges();

                    //Tạo 1 học sinh B mới thừa hưởng các thông tin
                    HocSinh b = new HocSinh(a.MaSoHS, a.HoTen, a.NgaySinh, a.DiaChi, a.XLHanhKiem, a.QueQuan, a.LopCuaHS);

                    //Cập nhật loại điểm cho b trước

                    Diem diemTBMonDoi = new Diem("D" + maMH + b.MaSoHS, b.MaSoHS, 0.0);
                    LoaiDiemCuaTungMon diem15 = new LoaiDiemCuaTungMon("D" + maMH + "15" + a.MaSoHS, double.Parse(txtDiem15.Text), diemTBMonDoi.MaDiem);
                    LoaiDiemCuaTungMon diem45 = new LoaiDiemCuaTungMon("D" + maMH + "45" + a.MaSoHS, double.Parse(txtDiem45.Text), diemTBMonDoi.MaDiem);
                    LoaiDiemCuaTungMon diemHK = new LoaiDiemCuaTungMon("D" + maMH + "HK" + a.MaSoHS, double.Parse(txtDiemHK.Text), diemTBMonDoi.MaDiem);

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

                    //Cập nhật lại Datagrid
                    var nhungHocSinhLopNay = from ai in db.THocSinhs
                                             where ai.LopCuaHS == cbLopDay.Text
                                             select ai;
                    List<HocSinh> dsHocSinh = nhungHocSinhLopNay.ToList();
                    List<HocSinhView> dshocSinhViews = new List<HocSinhView>();

                    foreach (var hocSinh in dsHocSinh)
                    {
                        HocSinhView view = new HocSinhView(hocSinh.MaSoHS, hocSinh.HoTen, hocSinh.XLHanhKiem, hocSinh.LopCuaHS);
                        var timDiemHSNay = from diemNao in db.TDiems
                                           where diemNao.MaDiem == "D" + maMH + hocSinh.MaSoHS
                                           select diemNao;
                        List<Diem> soDiemKiemDC = timDiemHSNay.ToList();
                        Diem diemCuaHS = soDiemKiemDC[0];

                        var timLoaiDiemHSNay = from diemNao in db.TLoaiDiemCuaTungMons
                                               where diemNao.MaDiemCuaLoaiDiem == diemCuaHS.MaDiem
                                               select diemNao;
                        List<LoaiDiemCuaTungMon> loaiDiemKiemDuoc = timLoaiDiemHSNay.ToList();

                        double diem15view = 0;
                        double diem45view = 0;
                        double diemHKview = 0;
                        foreach (var diem in loaiDiemKiemDuoc)
                        {
                            if (diem.MaLoaiDiem == "D" + maMH + "15" + hocSinh.MaSoHS)
                            {
                                diem15view = diem.SoDiem;
                            }
                            else if (diem.MaLoaiDiem == "D" + maMH + "45" + hocSinh.MaSoHS)
                            {
                                diem45view = diem.SoDiem;
                            }
                            else
                            {
                                diemHKview = diem.SoDiem;
                            }
                        }

                        view.Diem15CuaMonDuocChon = diem15view;
                        view.Diem45CuaMonDuocChon = diem45view;
                        view.DiemHKCuaMonDuocChon = diemHKview;
                        view.DiemTBCuaMonDuocChon = diemCuaHS.SoDiem;
                        dshocSinhViews.Add(view);
                    }

                    dtHocSinh.ItemsSource = dshocSinhViews;
                }
                else
                {
                    MessageBox.Show("Bạn phải chọn học sinh để chỉnh sửa!!!", "Thông báo!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btCapNhatDiem_Click(object sender, RoutedEventArgs e)
        {
            AdminDangNhap admin = new AdminDangNhap();
            admin.ShowDialog();
            if (admin.NhapDung())
            {
                if (cbLopDay.Text != "")
                {
                    //Mở ra giao diện chọn file
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Các tệp Excel (*.xls;*.xlsx)|*.xls;*.xlsx|All files (*.*)|*.*";
                    openFileDialog.ShowDialog();

                    //Lấy số lượng học sinh có trong CSDL
                    MyEntity db = new MyEntity();
                    //Lấy các học sinh có lớp trong combobox
                    var hocSinhCanTim = from ai in db.THocSinhs
                                        where ai.LopCuaHS == cbLopDay.Text
                                        select ai;
                    List<HocSinh> listHocSinhLopNay = hocSinhCanTim.ToList();
                    bool capNhatThanhCong = false;
                    //Bắt đầu cập nhật điểm cho từng học sinh

                    //Kiếm môn học mà giáo viên này dạy
                    var giaoVien = from ai in db.TGiaoViens
                                   where ai.MaGV == maGVTrongNay
                                   select ai;
                    List<GiaoVien> giaoVienTimDuoc = giaoVien.ToList();
                    GiaoVien canKiemMon = giaoVienTimDuoc[0];

                    //Kiếm mã MH
                    var monHoc = from monNao in db.TMonHocs
                                 where monNao.TenMH == canKiemMon.MonDay
                                 select monNao.MaMH;
                    List<string> monKiemDuoc = monHoc.ToList();
                    string maMH = monKiemDuoc[0];

                    foreach (var hocSinh in listHocSinhLopNay)
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

                        //Lưu trữ lại điểm của môn này trước khi sửa
                        var timDiemCuaA = from diemNao in db.TDiems
                                          where diemNao.MaDiem == "D" + maMH + hocSinh.MaSoHS
                                          select diemNao;
                        List<Diem> listDiemCuaA = timDiemCuaA.ToList();
                        Diem diemCuaA = listDiemCuaA[0];

                        //Lưu trữ lại điểm này
                        LuuTruDiemHSSua diemTruocSua = new LuuTruDiemHSSua("TS" + diemCuaA.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], hocSinh.MaSoHS, diemCuaA.SoDiem);
                        db.TLuuTruDiemHSSuas.Add(diemTruocSua);

                        //Lưu trữ lại các loại điểm của điểm này
                        var cacLoaiDiemMonNay = from diemNao in db.TLoaiDiemCuaTungMons
                                                where "D" + maMH + hocSinh.MaSoHS == diemNao.MaDiemCuaLoaiDiem
                                                select diemNao;
                        List<LoaiDiemCuaTungMon> listLoaiDiemKiemDuoc = cacLoaiDiemMonNay.ToList();

                        foreach (var item in listLoaiDiemKiemDuoc)
                        {
                            LuuTruLoaiDiemHSSua diemCanLuu = new LuuTruLoaiDiemHSSua("TS" + item.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], item.SoDiem, item.MaDiemCuaLoaiDiem);
                            db.TLuuTruLoaiDiemHSSuas.Add(diemCanLuu);
                        }

                        db.SaveChanges();

                        //Sau đó tiến hành xóa điểm môn này của A

                        db.TDiems.Remove(diemCuaA);

                        //Xóa hết loại điểm môn này của A
                        foreach (var loaiDiemCuaA in listLoaiDiemKiemDuoc)
                        {
                            db.TLoaiDiemCuaTungMons.Remove(loaiDiemCuaA);
                        }

                        if (openFileDialog.FileName != "")
                        {
                            //Tạo ra học sinh B thừa kế gần như toàn bộ thông tin từ A trừ ĐTB và Học lực
                            HocSinh b = new HocSinh(hocSinh.MaSoHS, hocSinh.HoTen, hocSinh.NgaySinh, hocSinh.DiaChi, hocSinh.XLHanhKiem, hocSinh.QueQuan, hocSinh.LopCuaHS);

                            //Tạo đối tượng Excel 
                            Excel.Application app = new Excel.Application();
                            //Mở file Excel Học Sinh
                            Excel.Workbook wb = app.Workbooks.Open(openFileDialog.FileName);

                            try
                            {
                                //Mở sheet thứ 2 là sheet điểm của lớp này
                                //Trong này chỉ số đầu tiên bắt đầu từ 1
                                Excel._Worksheet sheetCanMo = wb.Sheets[2];
                                //Truy cập vùng dữ liệu sử dụng
                                Excel.Range range = sheetCanMo.UsedRange;
                                //Bắt đầu đọc dữ liệu

                                //Chúng ta bắt đầu đọc dữ liệu từ dòng 2 vì dòng 1 là tiêu đề

                                //Điểm 15
                                LoaiDiemCuaTungMon diem15 = new LoaiDiemCuaTungMon("D" + maMH + "15" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhLopNay.IndexOf(hocSinh) + 2, 2].Value.ToString()), "D" + maMH + hocSinh.MaSoHS);
                                db.TLoaiDiemCuaTungMons.Add(diem15);

                                //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                                LuuTruLoaiDiemHSSua diem15SauSua = new LuuTruLoaiDiemHSSua("SS" + diem15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diem15.SoDiem, diem15.MaDiemCuaLoaiDiem);
                                db.TLuuTruLoaiDiemHSSuas.Add(diem15SauSua);


                                //Điểm 45
                                LoaiDiemCuaTungMon diem45 = new LoaiDiemCuaTungMon("D" + maMH + "45" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhLopNay.IndexOf(hocSinh) + 2, 3].Value.ToString()), "D" + maMH + hocSinh.MaSoHS);
                                db.TLoaiDiemCuaTungMons.Add(diem45);

                                //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                                LuuTruLoaiDiemHSSua diem45SauSua = new LuuTruLoaiDiemHSSua("SS" + diem45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diem45.SoDiem, diem45.MaDiemCuaLoaiDiem);
                                db.TLuuTruLoaiDiemHSSuas.Add(diem45SauSua);


                                //Điểm HK
                                LoaiDiemCuaTungMon diemHK = new LoaiDiemCuaTungMon("D" + maMH + "HK" + hocSinh.MaSoHS, double.Parse(range.Cells[listHocSinhLopNay.IndexOf(hocSinh) + 2, 4].Value.ToString()), "D" + maMH + hocSinh.MaSoHS);
                                db.TLoaiDiemCuaTungMons.Add(diemHK);

                                //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                                LuuTruLoaiDiemHSSua diemHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemHK.SoDiem, diemHK.MaDiemCuaLoaiDiem);
                                db.TLuuTruLoaiDiemHSSuas.Add(diemHKSauSua);

                                Diem diem = new Diem();
                                diem.MaDiem = "D" + maMH + hocSinh.MaSoHS;
                                diem.MaHSCuaDiemA = hocSinh.MaSoHS;
                                diem.SoDiem = Math.Round((diem15.SoDiem + diem45.SoDiem * 2 + diemHK.SoDiem * 2) / 5, 2);
                                db.TDiems.Add(diem);

                                //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                                LuuTruDiemHSSua diemToanSauSua = new LuuTruDiemHSSua("SS" + diem.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diem.MaHSCuaDiemA, diem.SoDiem);
                                db.TLuuTruDiemHSSuas.Add(diemToanSauSua);

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

                                MessageBox.Show(ex.Message, "Có lỗi xảy ra!!!", MessageBoxButton.OK, MessageBoxImage.Error);
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
                        var nhungHocSinhLopNay = from ai in db.THocSinhs
                                                 where ai.LopCuaHS == cbLopDay.Text
                                                 select ai;
                        List<HocSinh> dsHocSinh = nhungHocSinhLopNay.ToList();
                        List<HocSinhView> dshocSinhViews = new List<HocSinhView>();

                        foreach (var hocSinhV in dsHocSinh)
                        {
                            HocSinhView view = new HocSinhView(hocSinhV.MaSoHS, hocSinhV.HoTen, hocSinhV.XLHanhKiem, hocSinhV.LopCuaHS);
                            var timDiemHSNay = from diemNao in db.TDiems
                                               where diemNao.MaDiem == "D" + maMH + hocSinhV.MaSoHS
                                               select diemNao;
                            List<Diem> soDiemKiemDC = timDiemHSNay.ToList();
                            Diem diemCuaHS = soDiemKiemDC[0];

                            var timLoaiDiemHSNay = from diemNao in db.TLoaiDiemCuaTungMons
                                                   where diemNao.MaDiemCuaLoaiDiem == diemCuaHS.MaDiem
                                                   select diemNao;
                            List<LoaiDiemCuaTungMon> loaiDiemKiemDuoc = timLoaiDiemHSNay.ToList();

                            double diem15view = 0;
                            double diem45view = 0;
                            double diemHKview = 0;
                            foreach (var diemV in loaiDiemKiemDuoc)
                            {
                                if (diemV.MaLoaiDiem == "D" + maMH + "15" + hocSinhV.MaSoHS)
                                {
                                    diem15view = diemV.SoDiem;
                                }
                                else if (diemV.MaLoaiDiem == "D" + maMH + "45" + hocSinhV.MaSoHS)
                                {
                                    diem45view = diemV.SoDiem;
                                }
                                else
                                {
                                    diemHKview = diemV.SoDiem;
                                }
                            }
                            view.Diem15CuaMonDuocChon = diem15view;
                            view.Diem45CuaMonDuocChon = diem45view;
                            view.DiemHKCuaMonDuocChon = diemHKview;
                            view.DiemTBCuaMonDuocChon = diemCuaHS.SoDiem;
                            dshocSinhViews.Add(view);
                        }
                        dtHocSinh.ItemsSource = dshocSinhViews;
                    }
                }
                else
                {
                    MessageBox.Show("Bạn phải chọn lớp để cập nhật!", "Thông báo!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btTim_Click(object sender, RoutedEventArgs e)
        {
            if (cbLopDay.Text != "")
            {
                MyEntity db = new MyEntity();
                //Tìm ra môn GV này dạy
                var giaoVien = from ai in db.TGiaoViens
                               where ai.MaGV == maGVTrongNay
                               select ai;
                List<GiaoVien> dsGiaoViens = giaoVien.ToList();
                string monHoc = dsGiaoViens[0].MonDay;

                var maMon = from monNao in db.TMonHocs
                            where monNao.TenMH == monHoc
                            select monNao;
                List<MonHoc> dsMons = maMon.ToList();
                string maMH = dsMons[0].MaMH;

                var nhungHocSinhLopNay = from ai in db.THocSinhs
                                         where ai.LopCuaHS == cbLopDay.Text
                                         select ai;
                List<HocSinh> dsHocSinh = nhungHocSinhLopNay.ToList();
                List<HocSinhView> dshocSinhViews = new List<HocSinhView>();

                if (dsHocSinh.Count != 0)
                {
                    foreach (var hocSinh in dsHocSinh)
                    {
                        HocSinhView a = new HocSinhView(hocSinh.MaSoHS, hocSinh.HoTen, hocSinh.XLHanhKiem, hocSinh.LopCuaHS);
                        var timDiemHSNay = from diemNao in db.TDiems
                                           where diemNao.MaDiem == "D" + maMH + hocSinh.MaSoHS
                                           select diemNao;
                        List<Diem> soDiemKiemDC = timDiemHSNay.ToList();
                        Diem diemCuaHS = soDiemKiemDC[0];

                        var timLoaiDiemHSNay = from diemNao in db.TLoaiDiemCuaTungMons
                                               where diemNao.MaDiemCuaLoaiDiem == diemCuaHS.MaDiem
                                               select diemNao;
                        List<LoaiDiemCuaTungMon> loaiDiemKiemDuoc = timLoaiDiemHSNay.ToList();

                        double diem15 = 0;
                        double diem45 = 0;
                        double diemHK = 0;
                        foreach (var diem in loaiDiemKiemDuoc)
                        {
                            if (diem.MaLoaiDiem == "D" + maMH + "15" + hocSinh.MaSoHS)
                            {
                                diem15 = diem.SoDiem;
                            }
                            else if (diem.MaLoaiDiem == "D" + maMH + "45" + hocSinh.MaSoHS)
                            {
                                diem45 = diem.SoDiem;
                            }
                            else
                            {
                                diemHK = diem.SoDiem;
                            }
                        }

                        a.Diem15CuaMonDuocChon = diem15;
                        a.Diem45CuaMonDuocChon = diem45;
                        a.DiemHKCuaMonDuocChon = diemHK;
                        a.DiemTBCuaMonDuocChon = diemCuaHS.SoDiem;
                        dshocSinhViews.Add(a);
                    }
                }

                List<HocSinhView> dsHocSinhShowTrenDataGrid = new List<HocSinhView>();
                foreach (var hocSinh in dshocSinhViews)
                {
                    if (hocSinh.MaSoHS == tbTim.Text || hocSinh.HoTen == tbTim.Text || hocSinh.XLHanhKiem == tbTim.Text || hocSinh.Diem15CuaMonDuocChon.ToString() == tbTim.Text || hocSinh.Diem45CuaMonDuocChon.ToString() == tbTim.Text || hocSinh.DiemHKCuaMonDuocChon.ToString() == tbTim.Text || hocSinh.DiemTBCuaMonDuocChon.ToString() == tbTim.Text)
                    {
                        dsHocSinhShowTrenDataGrid.Add(hocSinh);
                    }
                }
                dtHocSinh.ItemsSource = dsHocSinhShowTrenDataGrid;
            }
            else
            {
                MessageBox.Show("Bạn phải chọn lớp để tìm kiếm!", "Thông báo!!!", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void tbTim_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbTim.Text == "")
            {
                MyEntity db = new MyEntity();
                //Tìm ra môn GV này dạy
                var giaoVien = from ai in db.TGiaoViens
                               where ai.MaGV == maGVTrongNay
                               select ai;
                List<GiaoVien> dsGiaoViens = giaoVien.ToList();
                string monHoc = dsGiaoViens[0].MonDay;

                var maMon = from monNao in db.TMonHocs
                            where monNao.TenMH == monHoc
                            select monNao;
                List<MonHoc> dsMons = maMon.ToList();
                string maMH = dsMons[0].MaMH;

                var nhungHocSinhLopNay = from ai in db.THocSinhs
                                         where ai.LopCuaHS == cbLopDay.Text
                                         select ai;
                List<HocSinh> dsHocSinh = nhungHocSinhLopNay.ToList();
                List<HocSinhView> dshocSinhViews = new List<HocSinhView>();

                if (dsHocSinh.Count != 0)
                {
                    foreach (var hocSinh in dsHocSinh)
                    {
                        HocSinhView a = new HocSinhView(hocSinh.MaSoHS, hocSinh.HoTen, hocSinh.XLHanhKiem, hocSinh.LopCuaHS);
                        var timDiemHSNay = from diemNao in db.TDiems
                                           where diemNao.MaDiem == "D" + maMH + hocSinh.MaSoHS
                                           select diemNao;
                        List<Diem> soDiemKiemDC = timDiemHSNay.ToList();
                        Diem diemCuaHS = soDiemKiemDC[0];

                        var timLoaiDiemHSNay = from diemNao in db.TLoaiDiemCuaTungMons
                                               where diemNao.MaDiemCuaLoaiDiem == diemCuaHS.MaDiem
                                               select diemNao;
                        List<LoaiDiemCuaTungMon> loaiDiemKiemDuoc = timLoaiDiemHSNay.ToList();

                        double diem15 = 0;
                        double diem45 = 0;
                        double diemHK = 0;
                        foreach (var diem in loaiDiemKiemDuoc)
                        {
                            if (diem.MaLoaiDiem == "D" + maMH + "15" + hocSinh.MaSoHS)
                            {
                                diem15 = diem.SoDiem;
                            }
                            else if (diem.MaLoaiDiem == "D" + maMH + "45" + hocSinh.MaSoHS)
                            {
                                diem45 = diem.SoDiem;
                            }
                            else
                            {
                                diemHK = diem.SoDiem;
                            }
                        }

                        a.Diem15CuaMonDuocChon = diem15;
                        a.Diem45CuaMonDuocChon = diem45;
                        a.DiemHKCuaMonDuocChon = diemHK;
                        a.DiemTBCuaMonDuocChon = diemCuaHS.SoDiem;
                        dshocSinhViews.Add(a);
                    }
                }
                dtHocSinh.ItemsSource = dshocSinhViews;
            }
        }
    }
}
