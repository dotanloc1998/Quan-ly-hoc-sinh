using HSM2.CSDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HSM2
{
    /// <summary>
    /// Interaction logic for CuaSoChinh.xaml
    /// </summary>
    public partial class CuaSoChinh : Window
    {
        public string maDangNhap;
        public CuaSoChinh(string maGV)
        {

            InitializeComponent();
            maDangNhap = maGV;
            btThongTinGiaoVien.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            MyEntity db = new MyEntity();
            //Hình từ đường dẫn database
            var link = from linkNao in db.TDuongDans
                       where linkNao.MaDuongDan == "HA2"
                       select linkNao;
            List<DuongDan> dsDuongDan = link.ToList();
            DuongDan timDuocHinh1 = dsDuongDan[0];
            string pathHinh1 = timDuocHinh1.DuongDanDenFile;
            try
            {
                ImageSource imageSourceHinh1 = new BitmapImage(new Uri(pathHinh1));
                hinh2.ImageSource = imageSourceHinh1;
            }
            catch (Exception)
            {


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
            if (Left != 0 && Top != 0)
            {
                Height = SystemParameters.MaximizedPrimaryScreenHeight;
                Width = SystemParameters.MaximizedPrimaryScreenWidth;
                Left = 0;
                Top = 0;
            }
            else
            {
                WindowState = WindowState.Normal;
                Height = 770; Width = 1050;
                double screenWidth = SystemParameters.PrimaryScreenWidth;
                double screenHeight = SystemParameters.PrimaryScreenHeight;
                double windowWidth = Width;
                double windowHeight = Height;
                Left = (screenWidth / 2) - (windowWidth / 2);
                Top = (screenHeight / 2) - (windowHeight / 2);
            }

        }

        private void btThuNho_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (e.ClickCount == 2)
            {
                if (Left != 0 && Top != 0)
                {
                    Height = SystemParameters.MaximizedPrimaryScreenHeight;
                    Width = SystemParameters.MaximizedPrimaryScreenWidth;
                    Left = 0;
                    Top = 0;
                }
                else
                {
                    WindowState = WindowState.Normal;
                    Height = 770; Width = 1050;
                    double screenWidth = SystemParameters.PrimaryScreenWidth;
                    double screenHeight = SystemParameters.PrimaryScreenHeight;
                    double windowWidth = Width;
                    double windowHeight = Height;
                    Left = (screenWidth / 2) - (windowWidth / 2);
                    Top = (screenHeight / 2) - (windowHeight / 2);
                }

            }
            else
            {
                if (Left == 0 && Top == 0)
                {
                    WindowState = WindowState.Normal;
                    Height = 770; Width = 1050;
                    double screenWidth = SystemParameters.PrimaryScreenWidth;
                    double screenHeight = SystemParameters.PrimaryScreenHeight;
                    double windowWidth = Width;
                    double windowHeight = Height;
                    Left = (screenWidth / 2) - (windowWidth / 2);
                    Top = (screenHeight / 2) - (windowHeight / 2);
                    DragMove();
                }
                else
                {
                    WindowState = WindowState.Normal;
                    Height = 770; Width = 1050;
                    DragMove();
                }
            }
        }

        private void btLopChuNhiem_Click(object sender, RoutedEventArgs e)
        {
            MyEntity db = new MyEntity();
            var dsGiaoVien = from ai in db.TGiaoViens
                             where maDangNhap == ai.MaGV
                             select ai;
            List<GiaoVien> listGV = dsGiaoVien.ToList();
            GiaoVien b = listGV[0];
            if (b.MonDay == "")
            {
                MessageBox.Show("Xin vui lòng cập nhật MÔN DẠY", "Yêu cầu thông tin!!!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                LopChuNhiem a = new LopChuNhiem(maDangNhap);
                GridThongTin.Children.Clear();
                GridThongTin.Children.Add(a);
                tbForChange.Text = "Lớp chủ nhiệm";
            }
        }

        private void btThongTinGiaoVien_Click(object sender, RoutedEventArgs e)
        {
            ThongTinGiaoVien a = new ThongTinGiaoVien(maDangNhap);
            GridThongTin.Children.Clear();
            GridThongTin.Children.Add(a);
            tbForChange.Text = "Thông tin giáo viên";

        }

        private void btLopDay_Click(object sender, RoutedEventArgs e)
        {
            MyEntity db = new MyEntity();
            var dsGiaoVien = from ai in db.TGiaoViens
                             where maDangNhap == ai.MaGV
                             select ai;
            List<GiaoVien> listGV = dsGiaoVien.ToList();
            GiaoVien b = listGV[0];
            if (b.MonDay == "")
            {
                MessageBox.Show("Xin vui lòng cập nhật MÔN DẠY", "Yêu cầu thông tin!!!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                LopDay a = new LopDay(maDangNhap);
                GridThongTin.Children.Clear();
                GridThongTin.Children.Add(a);
                tbForChange.Text = "Lớp dạy";
            }
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {

            ButtonClose.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));

        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            GridThongTin.IsEnabled = true;
        }

        private void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {

            GridThongTin.IsEnabled = false;
        }

        private void btVeChungToi_Click(object sender, RoutedEventArgs e)
        {
            VeChungToi a = new VeChungToi();
            GridThongTin.Children.Clear();
            GridThongTin.Children.Add(a);
            tbForChange.Text = "Về chúng tôi";
        }

        private void btCaiDat_Click(object sender, RoutedEventArgs e)
        {
            CaiDat a = new CaiDat(maDangNhap);
            GridThongTin.Children.Clear();
            GridThongTin.Children.Add(a);
            tbForChange.Text = "Cài đặt";
        }

        private void btThuNho_MouseEnter(object sender, MouseEventArgs e)
        {
            btThuNho.Background = Brushes.LightGray;
        }

        private void btThuNho_MouseLeave(object sender, MouseEventArgs e)
        {
            btThuNho.Background = Brushes.Black;
        }

        private void btPhongTo_MouseEnter(object sender, MouseEventArgs e)
        {
            btPhongTo.Background = Brushes.LightGray;
        }

        private void btPhongTo_MouseLeave(object sender, MouseEventArgs e)
        {
            btPhongTo.Background = Brushes.Black;
        }

        private void btDong_MouseEnter(object sender, MouseEventArgs e)
        {
            btDong.Background = Brushes.DarkRed;
        }

        private void btDong_MouseLeave(object sender, MouseEventArgs e)
        {
            btDong.Background = Brushes.Black;
        }

        private void btDangXuat_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Đồng ý đăng xuất?", "Thông báo!!!", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                MainWindow a = new MainWindow();
                Close();
                a.ShowDialog();
            }
        }

        private void btAdmin_Click(object sender, RoutedEventArgs e)
        {
            AdminDangNhap admin = new AdminDangNhap();
            admin.ShowDialog();
            if (admin.NhapDung())
            {
                ChonLoaiXemAdmin chon = new ChonLoaiXemAdmin();
                chon.ShowDialog();
                if (chon.IsClicked())
                {
                    if (chon.IsSua())
                    {
                        Admin a = new Admin();
                        GridThongTin.Children.Clear();
                        GridThongTin.Children.Add(a);
                        tbForChange.Text = "ADMIN";
                    }
                    else
                    {
                        AdminXoa a = new AdminXoa();
                        GridThongTin.Children.Clear();
                        GridThongTin.Children.Add(a);
                        tbForChange.Text = "ADMIN";
                    }
                }
            }
        }
    }
}
