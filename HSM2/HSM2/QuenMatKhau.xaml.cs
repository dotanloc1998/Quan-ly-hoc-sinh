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
    /// Interaction logic for QuenMatKhau.xaml
    /// </summary>
    public partial class QuenMatKhau : Window
    {
        public QuenMatKhau()
        {
            InitializeComponent();
            MyEntity db = new MyEntity();
            //Hình từ đường dẫn database
            var link = from linkNao in db.TDuongDans
                       where linkNao.MaDuongDan == "HA1"
                       select linkNao;
            List<DuongDan> dsDuongDan = link.ToList();
            DuongDan timDuocHinh1 = dsDuongDan[0];
            string pathHinh1 = timDuocHinh1.DuongDanDenFile;
            try
            {
                ImageSource imageSourceHinh1 = new BitmapImage(new Uri(pathHinh1));
                hinh1QuenMK.ImageSource = imageSourceHinh1;
            }
            catch (Exception)
            {


            }
        }
        private void btThuNho_MouseEnter(object sender, MouseEventArgs e)
        {
            btThuNho.Background = Brushes.LightGray;
        }

        private void btThuNho_MouseLeave(object sender, MouseEventArgs e)
        {
            btThuNho.Background = Brushes.Black;
        }

        private void TitleBar_OnMouseDown(object sender, MouseButtonEventArgs e)
        {

            DragMove();
        }

        private void btDong_Click(object sender, RoutedEventArgs e)
        {

            Close();

        }

        private void btThuNho_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btDong_MouseEnter(object sender, MouseEventArgs e)
        {
            btDong.Background = Brushes.DarkRed;
        }

        private void btDong_MouseLeave(object sender, MouseEventArgs e)
        {
            btDong.Background = Brushes.Black;
        }


        private void btDongY_Click(object sender, RoutedEventArgs e)
        {
            MyEntity db = new MyEntity();
            var listTaiKhoan = from taikhoans in db.TDangNhaps
                               where taikhoans.MaTaiKhoan == tbTenTaiKhoan.Text
                               select taikhoans;
            List<DangNhap> dangNhaps = listTaiKhoan.ToList();
            foreach (var item in dangNhaps)
            {
                if (item.MaTaiKhoan == tbTenTaiKhoan.Text.ToUpper())
                {
                    if (item.MaPin == tbMaPin.Password)
                    {

                        if (MessageBox.Show("Mật khẩu của bạn là: " + item.MatKhau, "Kiếm ra rồi !!!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK) == MessageBoxResult.OK)
                        {
                            Close();
                            break;
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Sai mã pin rồi bạn kiểm tra lại xem :((", "Không thấy", MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK) == MessageBoxResult.OK)
                        {
                            tbMaPin.Password = "";
                            tbMaPin.Focus();
                            break;
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("Không kiếm thấy tài khoản này \nHay là bạn chưa đăng ký ??", "Không thấy", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.OK) == MessageBoxResult.OK)
                    {
                        DangKy a = new DangKy();
                        Close();
                        a.ShowDialog();
                        break;
                    }
                    else
                    {
                        tbTenTaiKhoan.Text = "";
                        tbMaPin.Password = "";
                        tbTenTaiKhoan.Focus();
                        break;
                    }
                }
            }
        }

        private void btHuy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
