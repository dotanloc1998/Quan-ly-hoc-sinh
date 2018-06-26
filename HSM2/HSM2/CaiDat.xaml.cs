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
using WinForms = System.Windows.Forms;

namespace HSM2
{
    /// <summary>
    /// Interaction logic for CaiDat.xaml
    /// </summary>
    public partial class CaiDat : UserControl
    {
        private static string maGVTrongNay;
        public CaiDat(string maGV)
        {
            InitializeComponent();
            maGVTrongNay = maGV;
            MyEntity db = new MyEntity();
            //Cho giáo viên đó thấy Mã pin của mình 
            var maPin = from maNao in db.TDangNhaps
                        where maNao.MaTaiKhoan == maGV
                        select maNao;
            List<DangNhap> timDuoc = maPin.ToList();
            tbMaPin.Text = "Mã Pin: " + timDuoc[0].MaPin;


            //Hình từ đường dẫn database
            var link = from linkNao in db.TDuongDans
                       where linkNao.MaDuongDan == "HA5"
                       select linkNao;
            List<DuongDan> dsDuongDan1 = link.ToList();
            DuongDan timDuocHinh5a = dsDuongDan1[0];
            string pathHinh5 = timDuocHinh5a.DuongDanDenFile;
            try
            {
                ImageSource imageSourceHinh5 = new BitmapImage(new Uri(pathHinh5));
                hinh5.ImageSource = imageSourceHinh5;
            }
            catch (Exception)
            {


            }
            var duongDan = from linkNao in db.TDuongDans
                           select linkNao;
            List<DuongDan> dsDuongDan = duongDan.ToList();
            DuongDan timDuocLogo = new DuongDan();
            DuongDan timDuocHinh1 = new DuongDan();
            DuongDan timDuocHinh2 = new DuongDan();
            DuongDan timDuocHinh3 = new DuongDan();
            DuongDan timDuocHinh4 = new DuongDan();
            DuongDan timDuocHinh5 = new DuongDan();
            DuongDan timDuocFolderHS = new DuongDan();

            foreach (var item in dsDuongDan)
            {
                if (item.MaDuongDan == "HALG")
                {
                    timDuocLogo = item;
                }
                else if (item.MaDuongDan == "HA1")
                {
                    timDuocHinh1 = item;
                }
                else if (item.MaDuongDan == "HA2")
                {
                    timDuocHinh2 = item;
                }
                else if (item.MaDuongDan == "HA3")
                {
                    timDuocHinh3 = item;
                }
                else if (item.MaDuongDan == "HA4")
                {
                    timDuocHinh4 = item;
                }
                else if (item.MaDuongDan == "HA5")
                {
                    timDuocHinh5 = item;
                }
                else
                {
                    timDuocFolderHS = item;

                }
            }

            linkLogo.Text = timDuocLogo.DuongDanDenFile;
            linkHinh1.Text = timDuocHinh1.DuongDanDenFile;
            linkHinh2.Text = timDuocHinh2.DuongDanDenFile;
            linkHinh3.Text = timDuocHinh3.DuongDanDenFile;
            linkHinh4.Text = timDuocHinh4.DuongDanDenFile;
            linkHinh5.Text = timDuocHinh5.DuongDanDenFile;
            linkHocSinh.Text = timDuocFolderHS.DuongDanDenFile;
        }

        private void btLogo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ảnh (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                string path = openFileDialog.FileName;
                MyEntity db = new MyEntity();
                var duongDan = from linkNao in db.TDuongDans
                               where linkNao.MaDuongDan == "HALG"
                               select linkNao;
                List<DuongDan> dsDuongDan = duongDan.ToList();
                DuongDan timDuoc = dsDuongDan[0];
                DuongDan linkMoi = new DuongDan(timDuoc.MaDuongDan, path);
                db.TDuongDans.Attach(timDuoc);
                db.TDuongDans.Remove(timDuoc);
                db.TDuongDans.Add(linkMoi);
                db.SaveChanges();
                linkLogo.Text = linkMoi.DuongDanDenFile;
            }

        }

        private void btAnh1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ảnh (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                string path = openFileDialog.FileName;
                MyEntity db = new MyEntity();
                var duongDan = from linkNao in db.TDuongDans
                               where linkNao.MaDuongDan == "HA1"
                               select linkNao;
                List<DuongDan> dsDuongDan = duongDan.ToList();
                DuongDan timDuoc = dsDuongDan[0];
                DuongDan linkMoi = new DuongDan(timDuoc.MaDuongDan, path);
                db.TDuongDans.Attach(timDuoc);
                db.TDuongDans.Remove(timDuoc);
                db.TDuongDans.Add(linkMoi);
                db.SaveChanges();
                linkHinh1.Text = linkMoi.DuongDanDenFile;
            }

        }

        private void btAnh2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ảnh (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {

            }
            string path = openFileDialog.FileName;
            MyEntity db = new MyEntity();
            var duongDan = from linkNao in db.TDuongDans
                           where linkNao.MaDuongDan == "HA2"
                           select linkNao;
            List<DuongDan> dsDuongDan = duongDan.ToList();
            DuongDan timDuoc = dsDuongDan[0];
            DuongDan linkMoi = new DuongDan(timDuoc.MaDuongDan, path);
            db.TDuongDans.Attach(timDuoc);
            db.TDuongDans.Remove(timDuoc);
            db.TDuongDans.Add(linkMoi);
            db.SaveChanges();
            linkHinh2.Text = linkMoi.DuongDanDenFile;
        }

        private void btAnh3_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ảnh (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                string path = openFileDialog.FileName;
                MyEntity db = new MyEntity();
                var duongDan = from linkNao in db.TDuongDans
                               where linkNao.MaDuongDan == "HA3"
                               select linkNao;
                List<DuongDan> dsDuongDan = duongDan.ToList();
                DuongDan timDuoc = dsDuongDan[0];
                DuongDan linkMoi = new DuongDan(timDuoc.MaDuongDan, path);
                db.TDuongDans.Attach(timDuoc);
                db.TDuongDans.Remove(timDuoc);
                db.TDuongDans.Add(linkMoi);
                db.SaveChanges();
                linkHinh3.Text = linkMoi.DuongDanDenFile;
            }
        }

        private void btAnh4_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ảnh (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                string path = openFileDialog.FileName;
                MyEntity db = new MyEntity();
                var duongDan = from linkNao in db.TDuongDans
                               where linkNao.MaDuongDan == "HA4"
                               select linkNao;
                List<DuongDan> dsDuongDan = duongDan.ToList();
                DuongDan timDuoc = dsDuongDan[0];
                DuongDan linkMoi = new DuongDan(timDuoc.MaDuongDan, path);
                db.TDuongDans.Attach(timDuoc);
                db.TDuongDans.Remove(timDuoc);
                db.TDuongDans.Add(linkMoi);
                db.SaveChanges();
                linkHinh4.Text = linkMoi.DuongDanDenFile;
            }
        }

        private void btAnh5_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ảnh (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                string path = openFileDialog.FileName;
                MyEntity db = new MyEntity();
                var duongDan = from linkNao in db.TDuongDans
                               where linkNao.MaDuongDan == "HA5"
                               select linkNao;
                List<DuongDan> dsDuongDan = duongDan.ToList();
                DuongDan timDuoc = dsDuongDan[0];
                DuongDan linkMoi = new DuongDan(timDuoc.MaDuongDan, path);
                db.TDuongDans.Attach(timDuoc);
                db.TDuongDans.Remove(timDuoc);
                db.TDuongDans.Add(linkMoi);
                db.SaveChanges();
                linkHinh5.Text = linkMoi.DuongDanDenFile;
                try
                {
                    ImageSource imageSourceHinh1 = new BitmapImage(new Uri(linkMoi.DuongDanDenFile));
                    hinh5.ImageSource = imageSourceHinh1;
                }
                catch (Exception)
                {


                }
            }
        }

        private void btAnhHocSinh_Click(object sender, RoutedEventArgs e)
        {
            //Wpf không có Class giúp mở folder nên chúng ta phải mượn từ Winform
            WinForms.FolderBrowserDialog openFolder = new WinForms.FolderBrowserDialog();
            openFolder.ShowDialog();
            if (openFolder.SelectedPath != "")
            {
                string path = openFolder.SelectedPath;
                MyEntity db = new MyEntity();
                var duongDan = from linkNao in db.TDuongDans
                               where linkNao.MaDuongDan == "HAHS"
                               select linkNao;
                List<DuongDan> dsDuongDan = duongDan.ToList();
                DuongDan timDuoc = dsDuongDan[0];
                DuongDan linkMoi = new DuongDan(timDuoc.MaDuongDan, path);
                db.TDuongDans.Attach(timDuoc);
                db.TDuongDans.Remove(timDuoc);
                db.TDuongDans.Add(linkMoi);
                db.SaveChanges();
                linkHocSinh.Text = linkMoi.DuongDanDenFile;
            }
        }

        private void btDoiMatKhau_Click(object sender, RoutedEventArgs e)
        {
            if (tbMatKhauCu.Password != "" && tbMatKhauMoi.Password != "" && tbNhapLaiMatKhauMoi.Password != "")
            {
                MyEntity db = new MyEntity();
                var taiKhoanCuaGV = from ai in db.TDangNhaps
                                    where ai.MaTaiKhoan == maGVTrongNay
                                    select ai;
                List<DangNhap> dsTaiKhoan = taiKhoanCuaGV.ToList();
                DangNhap taiKhoanKiemDuoc = dsTaiKhoan[0];
                if (tbMatKhauMoi.Password != tbNhapLaiMatKhauMoi.Password)
                {
                    MessageBox.Show("Nhập lại Mật khẩu và Mật khẩu phải trùng nhau!", "Thông báo!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (tbMatKhauMoi.Password.Length < 6)
                {
                    if (MessageBox.Show("Dạo này trộm cấp nhiều lắm \nđặt mật khẩu từ 6 \nkí tự trở lên nhé!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
                    {
                        tbMatKhauMoi.Password = "";
                        tbNhapLaiMatKhauMoi.Password = "";
                        tbMatKhauMoi.Focus();
                    }
                }
                else if (taiKhoanKiemDuoc.MatKhau != tbMatKhauCu.Password)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!", "Thông báo!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    DangNhap taiKhoanMoi = new DangNhap(taiKhoanKiemDuoc.MaTaiKhoan, tbMatKhauMoi.Password, taiKhoanKiemDuoc.MaPin);
                    db.TDangNhaps.Attach(taiKhoanKiemDuoc);
                    db.TDangNhaps.Remove(taiKhoanKiemDuoc);
                    db.TDangNhaps.Add(taiKhoanMoi);
                    db.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Không được để trống!", "Thông báo!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
