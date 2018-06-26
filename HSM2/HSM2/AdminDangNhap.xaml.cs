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
    /// Interaction logic for AdminDangNhap.xaml
    /// </summary>
    public partial class AdminDangNhap : Window
    {
        private bool dungMatKhauAdmin = false;
        public AdminDangNhap()
        {
            InitializeComponent();
            txtDangNhap.Focus();
        }
        private void TitleBar_OnMouseDown(object sender, MouseButtonEventArgs e)
        {

            Application.Current.MainWindow.DragMove();
        }

        private void btDong_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn thực sự muốn thoát ?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
            {
                Close();
            }
        }

        private void btThuNho_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
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

        private void btDongY_Click(object sender, RoutedEventArgs e)
        {
            if (txtDangNhap.Text != "" && txtMatKhau.Password != "")
            {

                if (txtDangNhap.Text == "admin")
                {
                    DateTime thoiDiemNhap = DateTime.Now;
                    string[] b = thoiDiemNhap.ToString("HH:mm:ss").Split(':');
                    if (txtMatKhau.Password == b[0] + b[1])
                    {
                        dungMatKhauAdmin = true;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không chính xác", "Có lỗi", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                        txtMatKhau.Password = "";
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản này", "Có lỗi", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                    txtDangNhap.Text = "";
                    txtMatKhau.Password = "";
                    txtDangNhap.Focus();
                }
            }
            else
            {
                MessageBox.Show("Đừng để trống ô nào hết nhé~", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public bool NhapDung()
        {
            return dungMatKhauAdmin;
        }
    }
}
