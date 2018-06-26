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
    /// Interaction logic for AdminXoa.xaml
    /// </summary>
    public partial class AdminXoa : UserControl
    {
        public AdminXoa()
        {
            InitializeComponent();
            MyEntity db = new MyEntity();
            var chinhSua = from lichSu in db.TLichSuChinhSuas
                           where lichSu.MaChinhSua.Substring(0, 3) != "Sua"
                           select lichSu;
            List<LichSuChinhSua> dsChinhSua = chinhSua.ToList();
            dtLichSuChinhSua.ItemsSource = dsChinhSua;
        }

        private void dtLichSuChinhSua_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LichSuChinhSua a = (LichSuChinhSua)dtLichSuChinhSua.SelectedItem;
            if (a != null)
            {
                try
                {
                    MyEntity db = new MyEntity();
                    //Tìm học sinh này trong CSDL Backup 
                    var hocSinhs = from ai in db.TLuuTruHSXoas
                                   where ai.MaSoHSXoa == a.MaChinhSua.Substring(3, 10)
                                   select ai;
                    List<LuuTruHSXoa> dsHocSinh = hocSinhs.ToList();
                    LuuTruHSXoa hocSinhTimDuoc = dsHocSinh[0];
                    //Tìm điểm học sinh này trong CSDL Backup
                    var diemHocSinhs = from diemNao in db.TLuuTruDiemHSXoas
                                       where diemNao.MaHSCuaDiemXoa == hocSinhTimDuoc.MaSoHSXoa
                                       select diemNao;
                    List<LuuTruDiemHSXoa> dsDiemHocSinh = diemHocSinhs.ToList();
                    //Tìm loại điểm học sinh này trong CSDL Backup
                    var loaiDiemHocSinhs = from diemNao in db.TLuuTruLoaiDiemHSXoas
                                           where diemNao.MaDiemCuaLoaiDiemXoa.Substring(3) == hocSinhTimDuoc.MaSoHSXoa
                                           select diemNao;
                    List<LuuTruLoaiDiemHSXoa> dsLoaiDiemHocSinh = loaiDiemHocSinhs.ToList();
                    //Đổ lên giao diện Admin
                    dtLuuHocSinhXoa.ItemsSource = dsHocSinh;
                    dtLuuDiemHocSinhXoa.ItemsSource = dsDiemHocSinh;
                    dtLuuLoaiDiemHocSinhXoa.ItemsSource = dsLoaiDiemHocSinh;
                }
                catch (Exception)
                {

                    MessageBox.Show("Học sinh " + a.MaChinhSua.Substring(3, 10) + " đã được khôi phục về CSDL chính", "Thông báo!!!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }

        private void btKhoiPhuc_Click(object sender, RoutedEventArgs e)
        {
            LichSuChinhSua a = (LichSuChinhSua)dtLichSuChinhSua.SelectedItem;
            if (a != null)
            {
                try
                {
                    MyEntity db = new MyEntity();
                    //Tìm học sinh này trong CSDL Backup 
                    var hocSinhs = from ai in db.TLuuTruHSXoas
                                   where ai.MaSoHSXoa == a.MaChinhSua.Substring(3, 10)
                                   select ai;
                    List<LuuTruHSXoa> dsHocSinh = hocSinhs.ToList();
                    LuuTruHSXoa hocSinhTimDuoc = dsHocSinh[0];
                    //Tìm điểm học sinh này trong CSDL Backup
                    var diemHocSinhs = from diemNao in db.TLuuTruDiemHSXoas
                                       where diemNao.MaHSCuaDiemXoa == hocSinhTimDuoc.MaSoHSXoa
                                       select diemNao;
                    List<LuuTruDiemHSXoa> dsDiemHocSinh = diemHocSinhs.ToList();
                    //Tìm loại điểm học sinh này trong CSDL Backup
                    var loaiDiemHocSinhs = from diemNao in db.TLuuTruLoaiDiemHSXoas
                                           where diemNao.MaDiemCuaLoaiDiemXoa.Substring(3) == hocSinhTimDuoc.MaSoHSXoa
                                           select diemNao;
                    List<LuuTruLoaiDiemHSXoa> dsLoaiDiemHocSinh = loaiDiemHocSinhs.ToList();


                    //Khởi tạo các thông tin
                    //Học sinh

                    HocSinh themLaiHocSinh = new HocSinh(hocSinhTimDuoc.MaSoHSXoa, hocSinhTimDuoc.HoTenXoa, hocSinhTimDuoc.NgaySinhXoa, hocSinhTimDuoc.DiaChiXoa, hocSinhTimDuoc.XLHocLucXoa, hocSinhTimDuoc.XLHanhKiemXoa, hocSinhTimDuoc.QueQuanXoa, hocSinhTimDuoc.LopCuaHSXoa, hocSinhTimDuoc.DiemTBCuaHSXoa);

                    //Điểm học sinh đó

                    List<Diem> themLaiDiem = new List<Diem>();

                    foreach (var diem in dsDiemHocSinh)
                    {
                        Diem diemDeThem = new Diem(diem.MaDiemXoa, diem.MaHSCuaDiemXoa, diem.SoDiemXoa);
                        themLaiDiem.Add(diemDeThem);
                    }
                    //Loại điểm học sinh đó

                    List<LoaiDiemCuaTungMon> themLaiLoaiDiem = new List<LoaiDiemCuaTungMon>();

                    foreach (var loaiDiem in dsLoaiDiemHocSinh)
                    {
                        LoaiDiemCuaTungMon loaiDiemDeThem = new LoaiDiemCuaTungMon(loaiDiem.MaLoaiDiemXoa, loaiDiem.SoDiemXoa, loaiDiem.MaDiemCuaLoaiDiemXoa);
                        themLaiLoaiDiem.Add(loaiDiemDeThem);
                    }

                    //Xóa trong CSDL Backup
                    db.TLuuTruHSXoas.Attach(hocSinhTimDuoc);
                    db.TLuuTruHSXoas.Remove(hocSinhTimDuoc);

                    foreach (var diem in dsDiemHocSinh)
                    {
                        db.TLuuTruDiemHSXoas.Attach(diem);
                        db.TLuuTruDiemHSXoas.Remove(diem);
                    }

                    foreach (var loaiDiem in dsLoaiDiemHocSinh)
                    {
                        db.TLuuTruLoaiDiemHSXoas.Attach(loaiDiem);
                        db.TLuuTruLoaiDiemHSXoas.Remove(loaiDiem);
                    }

                    //Thêm lại vào CSDL chính
                    db.THocSinhs.Add(themLaiHocSinh);
                    foreach (var diem in themLaiDiem)
                    {
                        db.TDiems.Add(diem);
                    }
                    foreach (var loaiDiem in themLaiLoaiDiem)
                    {
                        db.TLoaiDiemCuaTungMons.Add(loaiDiem);
                    }
                    db.SaveChanges();

                    var chinhSua = from lichSu in db.TLichSuChinhSuas
                                   where lichSu.MaChinhSua.Substring(0, 3) != "Sua"
                                   select lichSu;
                    List<LichSuChinhSua> dsChinhSua = chinhSua.ToList();

                    dtLichSuChinhSua.ItemsSource = dsChinhSua;
                    dtLuuDiemHocSinhXoa.ItemsSource = null;
                    dtLuuHocSinhXoa.ItemsSource = null;
                    dtLuuLoaiDiemHocSinhXoa.ItemsSource = null;
                }
                catch (Exception)
                {

                    MessageBox.Show("Học sinh " + a.MaChinhSua.Substring(3, 10) + " đã được khôi phục về CSDL chính", "Thông báo!!!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Cần chọn học sinh để khôi phục!", "Thông báo!!!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
