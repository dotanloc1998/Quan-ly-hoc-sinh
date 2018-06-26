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
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyEntity db = new MyEntity();
            var tenNho = from tenNao in db.TGhiNhoDangNhaps
                         select tenNao;
            List<GhiNhoDangNhap> kiemTra = tenNho.ToList();
            if (kiemTra.Count!=0)
            {
                txtDangNhap.Text = kiemTra[0].MaDangNhapTruoc;
                checkDangNhap.IsChecked = true;
                txtMatKhau.Focus();
            }
            else
            {
                txtDangNhap.Focus();
            }
            //Hình từ đường dẫn database
            var link = from linkNao in db.TDuongDans
                       where  linkNao.MaDuongDan == "HA1"
                       select linkNao;
            List<DuongDan> dsDuongDan = link.ToList();
            DuongDan timDuocHinh1 = dsDuongDan[0];
            string pathHinh1 = timDuocHinh1.DuongDanDenFile;
            try
            {
                ImageSource imageSourceHinh1 = new BitmapImage(new Uri(pathHinh1));
                hinh1DangNhap.ImageSource = imageSourceHinh1;
            }
            catch (Exception)
            {


            }
        }

        private void BtDangKy_OnClick(object sender, RoutedEventArgs e)
        {
            DangKy a = new DangKy();
            a.ShowDialog();
        }

        private void btDongY_Click(object sender, RoutedEventArgs e)
        {
            if (txtDangNhap.Text != "" && txtMatKhau.Password != "")
            {
                MyEntity db = new MyEntity();
                var listTaiKhoan = from taikhoans in db.TDangNhaps
                                   select taikhoans;
                List<DangNhap> dangNhaps = listTaiKhoan.ToList();
                foreach (var item in dangNhaps)
                {
                    if (txtDangNhap.Text.ToUpper() == item.MaTaiKhoan)
                    {
                        if (txtMatKhau.Password == item.MatKhau)
                        {
                            if (checkDangNhap.IsChecked == true)
                            {
                                GhiNhoDangNhap moi = new GhiNhoDangNhap(txtDangNhap.Text);
                                var tenNho = from tenNao in db.TGhiNhoDangNhaps
                                             select tenNao;
                                List<GhiNhoDangNhap> kiemTra = tenNho.ToList();
                                if (kiemTra.Count!=0)
                                {
                                    if (txtDangNhap.Text.ToUpper() != kiemTra[0].MaDangNhapTruoc.ToUpper())
                                    {
                                        db.TGhiNhoDangNhaps.Remove(kiemTra[0]);
                                        db.TGhiNhoDangNhaps.Add(moi);
                                        db.SaveChanges();
                                    }
                                }
                                else
                                {
                                    db.TGhiNhoDangNhaps.Add(moi);
                                    db.SaveChanges();
                                }
                            }
                            else
                            {
                                var tenNho = from tenNao in db.TGhiNhoDangNhaps
                                             select tenNao;
                                List<GhiNhoDangNhap> kiemTra = tenNho.ToList();
                                db.TGhiNhoDangNhaps.Remove(kiemTra[0]);
                                db.SaveChanges();
                            }
                            CuaSoChinh a = new CuaSoChinh(txtDangNhap.Text);
                            Close();
                            a.ShowDialog();
                            return;
                        }
                        else
                        {
                            if (MessageBox.Show("Mật khẩu không chính xác \nBạn quên mật khẩu?", "Có lỗi", MessageBoxButton.OKCancel, MessageBoxImage.Error, MessageBoxResult.OK) == MessageBoxResult.OK)
                            {

                                QuenMatKhau quen = new QuenMatKhau();
                                txtDangNhap.Text = "";
                                txtMatKhau.Password = "";
                                quen.ShowDialog();
                                return;
                            }
                            else
                            {
                                txtMatKhau.Password = "";
                                txtMatKhau.Focus();
                                return;
                            }
                        }
                    }

                }
                if (MessageBox.Show("Không tìm thấy tài khoản này \nBạn muốn đăng ký?", "Có lỗi", MessageBoxButton.OKCancel, MessageBoxImage.Error, MessageBoxResult.OK) == MessageBoxResult.OK)
                {

                    DangKy dk = new DangKy();
                    txtDangNhap.Text = "";
                    txtMatKhau.Password = "";
                    dk.ShowDialog();

                }
                else
                {
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
        //Title Bar
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

        private void btQuenMatKhau_Click(object sender, RoutedEventArgs e)
        {
            QuenMatKhau a = new QuenMatKhau();
            a.ShowDialog();
        }
    }
}
