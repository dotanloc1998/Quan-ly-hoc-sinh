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
using System.Windows.Shapes;

namespace HSM2
{
    /// <summary>
    /// Interaction logic for DangKy.xaml
    /// </summary>
    public partial class DangKy : Window
    {
        public DangKy()
        {
            InitializeComponent();
            MyEntity db = new MyEntity();
            var link = from linkNao in db.TDuongDans
                       where linkNao.MaDuongDan == "HALG" || linkNao.MaDuongDan == "HA1"
                       select linkNao;
            List<DuongDan> dsDuongDan = link.ToList();
            DuongDan timDuocLogo = new DuongDan();
            DuongDan timDuocHinh1 = new DuongDan();
            foreach (var item in dsDuongDan)
            {
                if (item.MaDuongDan == "HALG")
                {
                    timDuocLogo = item;
                }
                else
                {
                    timDuocHinh1 = item;
                }
            }
            string pathLogo = timDuocLogo.DuongDanDenFile;
            string pathHinh1 = timDuocHinh1.DuongDanDenFile;
            try
            {
                ImageSource imageSourceLogo = new BitmapImage(new Uri(pathLogo));
                hinhLogo.Source = imageSourceLogo;
            }
            catch (Exception)
            {


            }
            try
            {
                ImageSource imageSourceHinh1 = new BitmapImage(new Uri(pathHinh1));
                hinh1DangKy.ImageSource = imageSourceHinh1;
            }
            catch (Exception)
            {


            }
        }
        //Họ
        private void TxtHoTenGV_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtHoTenGV.Text == "" && txtHoTenGV.IsFocused == false)
            {
                txtHoTenGV.Text = "Không được để trống.";
                txtHoTenGV.Foreground = Brushes.Red;
            }
        }

        private void TxtHoTenGV_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (txtHoTenGV.Text == "" || txtHoTenGV.Text == "Không được để trống.")
            {
                txtHoTenGV.Foreground = Brushes.Red;
                txtHoTenGV.Text = "Không được để trống.";
            }
        }

        private void TxtHoTenGV_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (txtHoTenGV.Text == "Không được để trống.")
            {
                txtHoTenGV.Text = "";
                txtHoTenGV.Foreground = Brushes.Black;
            }
        }

        //Địa Chỉ
        private void TxtDCGV_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtDCGV.Text == "" && txtDCGV.IsFocused == false)
            {
                txtDCGV.Text = "Không được để trống.";
                txtDCGV.Foreground = Brushes.Red;
            }
        }

        private void TxtDCGV_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (txtDCGV.Text == "Không được để trống.")
            {
                txtDCGV.Text = "";
                txtDCGV.Foreground = Brushes.Black;
            }
        }

        private void TxtDCGV_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDCGV.Text == "" || txtDCGV.Text == "Không được để trống.")
            {
                txtDCGV.Foreground = Brushes.Red;
                txtDCGV.Text = "Không được để trống.";
            }
        }
        //So dien thoai
        private void TxtSDTGV_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSDTGV.Text == "Không được để trống.")
            {
                txtSDTGV.Text = "";
                txtSDTGV.Foreground = Brushes.Black;
            }
        }

        private void TxtSDTGV_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (txtSDTGV.Text == "" || txtSDTGV.Text == "Không được để trống.")
            {
                txtSDTGV.Foreground = Brushes.Red;
                txtSDTGV.Text = "Không được để trống.";
            }
        }

        private void TxtSDTGV_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSDTGV.Text == "" && txtSDTGV.IsFocused == false)
            {
                txtSDTGV.Text = "Không được để trống.";
                txtSDTGV.Foreground = Brushes.Red;
            }
        }
        //Que quan
        private void TxtQueQuanGV_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (txtQueQuanGV.Text == "Không được để trống.")
            {
                txtQueQuanGV.Text = "";
                txtQueQuanGV.Foreground = Brushes.Black;
            }
        }

        private void TxtQueQuanGV_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (txtQueQuanGV.Text == "" || txtQueQuanGV.Text == "Không được để trống.")
            {
                txtQueQuanGV.Foreground = Brushes.Red;
                txtQueQuanGV.Text = "Không được để trống.";
            }
        }

        private void TxtQueQuanGV_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtQueQuanGV.Text == "" && txtQueQuanGV.IsFocused == false)
            {
                txtQueQuanGV.Text = "Không được để trống.";
                txtQueQuanGV.Foreground = Brushes.Red;
            }
        }
        //Ngay sinh
        private void DpNgaySinhGV_OnTextInput(object sender, TextCompositionEventArgs e)
        {
            if (dpNgaySinhGV.Text == "" && dpNgaySinhGV.IsFocused == false)
            {
                dpNgaySinhGV.Foreground = Brushes.Red;
            }
        }

        private void DpNgaySinhGV_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (dpNgaySinhGV.Text == "")
            {
                dpNgaySinhGV.Text = "";
                dpNgaySinhGV.Foreground = Brushes.Black;
            }
        }

        private void DpNgaySinhGV_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (dpNgaySinhGV.Text == "")
            {
                dpNgaySinhGV.Foreground = Brushes.Red;
                dpNgaySinhGV.Text = "";
            }
        }

        //Lop Chu Nhiem
        private void TxtLopChuNhiem_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtLopChuNhiem.Text == "" && txtLopChuNhiem.IsFocused == false)
            {
                txtLopChuNhiem.Text = "Không được để trống.";
                txtLopChuNhiem.Foreground = Brushes.Red;
            }
        }

        private void TxtLopChuNhiem_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (txtLopChuNhiem.Text == "Không được để trống.")
            {
                txtLopChuNhiem.Text = "";
                txtLopChuNhiem.Foreground = Brushes.Black;
            }
        }

        private void TxtLopChuNhiem_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (txtLopChuNhiem.Text == "" || txtLopChuNhiem.Text == "Không được để trống.")
            {
                txtLopChuNhiem.Foreground = Brushes.Red;
                txtLopChuNhiem.Text = "Không được để trống.";
            }
        }

        //Mat khau
        private void TxtMatKhau_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (txtMatKhau.Password == "")
            {
                txtMatKhau.Password = "";
                txtMatKhau.Foreground = Brushes.Black;
            }
        }

        private void TxtMatKhau_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (txtMatKhau.Password == "")
            {
                txtMatKhau.Foreground = Brushes.Red;
                txtMatKhau.Password = "";
            }
        }

        private void TxtMatKhau_OnTextInput(object sender, TextCompositionEventArgs e)
        {
            if (txtMatKhau.Password == "" && txtMatKhau.IsFocused == false)
            {
                txtMatKhau.Foreground = Brushes.Red;
            }
        }
        //Nhap lai mk
        private void TxtNhapLaiMatKhau_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNhapLaiMatKhau.Password == "")
            {
                txtNhapLaiMatKhau.Password = "";
                txtNhapLaiMatKhau.Foreground = Brushes.Black;
            }
        }

        private void TxtNhapLaiMatKhau_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (txtNhapLaiMatKhau.Password == "")
            {
                txtNhapLaiMatKhau.Foreground = Brushes.Red;
                txtNhapLaiMatKhau.Password = "";
            }
        }

        private void TxtNhapLaiMatKhau_OnTextInput(object sender, TextCompositionEventArgs e)
        {
            if (txtNhapLaiMatKhau.Password == "" && txtNhapLaiMatKhau.IsFocused == false)
            {
                txtNhapLaiMatKhau.Foreground = Brushes.Red;
            }
        }
        private void btDong_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn thực sự muốn thoát ?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
            {
                Close();
            }
        }

        private void btPhongTo_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState != WindowState.Maximized)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }

        }

        private void btThuNho_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Normal;
            DragMove();
        }

        private void btThuNho_MouseEnter(object sender, MouseEventArgs e)
        {
            btThuNho.Background = Brushes.LightGray;
        }

        private void btThuNho_MouseLeave(object sender, MouseEventArgs e)
        {
            btThuNho.Background = Brushes.Black;
        }

        private void btDong_MouseEnter(object sender, MouseEventArgs e)
        {
            btDong.Background = Brushes.DarkRed;
        }

        private void btDong_MouseLeave(object sender, MouseEventArgs e)
        {
            btDong.Background = Brushes.Black;
        }

        private void btChapNhan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dpNgaySinhGV.Text != "" && txtDCGV.Text != "" && txtHoTenGV.Text != "" && txtMatKhau.Password != "" && txtNhapLaiMatKhau.Password != "" && txtQueQuanGV.Text != "" && txtSDTGV.Text != "" && txtLopChuNhiem.Text != "")
                {
                    MyEntity db = new MyEntity();
                    var danhSachLop = from lopNao in db.TGiaoViens
                                      where txtLopChuNhiem.Text.ToUpper() == lopNao.LopChuNhiem.ToUpper()
                                      select lopNao;
                    List<GiaoVien> dayLopNay = danhSachLop.ToList();
                    if (txtMatKhau.Password != txtNhapLaiMatKhau.Password)
                    {
                        if (MessageBox.Show("Nhập lại mật khẩu phải trùng với mật khẩu", "Có lỗi", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK) == MessageBoxResult.OK)
                        {
                            txtNhapLaiMatKhau.Password = "";
                            txtNhapLaiMatKhau.Focus();
                        }

                    }
                    else if (txtMatKhau.Password.Length < 6)
                    {
                        if (MessageBox.Show("Dạo này trộm cấp nhiều lắm \nđặt mật khẩu từ 6 \nkí tự trở lên nhé!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
                        {
                            txtMatKhau.Password = "";
                            txtNhapLaiMatKhau.Password = "";
                            txtMatKhau.Focus();
                        }
                    }
                    else if (dayLopNay.Count != 0)
                    {
                        if (MessageBox.Show("Lớp này đã có giáo viên dạy vui lòng kiểm tra lại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
                        {
                            txtLopChuNhiem.Text = "";
                            txtLopChuNhiem.Focus();
                        }
                    }
                    else if (!(txtLopChuNhiem.Text.Substring(0, 3).ToUpper() == "10A" || txtLopChuNhiem.Text.Substring(0, 3).ToUpper() == "11A" || txtLopChuNhiem.Text.Substring(0, 3).ToUpper() == "12A") || txtLopChuNhiem.Text.Length < 4 || txtLopChuNhiem.Text.Length > 5)
                    {
                        if (MessageBox.Show("Mã lớp không hợp lệ!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
                        {
                            txtLopChuNhiem.Text = "";
                            txtLopChuNhiem.Focus();
                        }
                    }
                    else
                    {
                        DateTime thoiDiemNhap = DateTime.Now;
                        string[] b = thoiDiemNhap.ToString("HH:mm:ss").Split(':');
                        string nam = thoiDiemNhap.Year.ToString();
                        GiaoVien a = new GiaoVien(nam[2].ToString() + nam[3].ToString() + "GV" + b[0] + b[1] + b[2], txtHoTenGV.Text, DateTime.Parse(dpNgaySinhGV.Text), txtQueQuanGV.Text, txtDCGV.Text, txtSDTGV.Text, "", txtLopChuNhiem.Text.ToUpper());
                        Random rd = new Random();
                        string maPin = rd.Next(1000, 9999).ToString();

                        DangNhap c = new DangNhap(nam[2].ToString() + nam[3].ToString() + "GV" + b[0] + b[1] + b[2], txtMatKhau.Password, maPin);
                        db.TDangNhaps.Add(c);
                        db.TGiaoViens.Add(a);
                        db.SaveChanges();
                        string tenDangNhap = nam[2].ToString() + nam[3].ToString() + "GV" + b[0] + b[1] + b[2];
                        if (MessageBox.Show("Đăng ký thành công" + "\nMã số giáo viên của bạn là:  " + tenDangNhap + "\nNhớ kĩ mã pin để quên mật khẩu còn tìm lại nhé! \nMã pin của bạn là: " + maPin, "Thành công", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK) == MessageBoxResult.OK)
                        {
                            Close();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Nhớ nhập hết đừng để trống ô nào nhé!", "Có lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Có lỗi trong quá trình đăng ký vui lòng thử lại!!", "Thông báo!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btHuyBo_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn thực sự muốn thoát ?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
            {
                Close();
            }
        }
    }
}

