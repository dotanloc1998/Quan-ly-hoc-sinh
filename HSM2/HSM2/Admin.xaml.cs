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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : UserControl
    {
        public Admin()
        {
            InitializeComponent();
            MyEntity db = new MyEntity();
            var chinhSua = from lichSu in db.TLichSuChinhSuas
                           where lichSu.MaChinhSua.Substring(0,3) != "Xoa"
                           select lichSu;
            List<LichSuChinhSua> dsChinhSua = chinhSua.ToList();
            dtLichSuChinhSua.ItemsSource = dsChinhSua;
        }

        private void dtLichSuChinhSua_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LichSuChinhSua a = (LichSuChinhSua)dtLichSuChinhSua.SelectedItem;
            if (a != null)
            {
                MyEntity db = new MyEntity();
                
                    dtLuuDiemHocSinh.ItemsSource = null;
                    dtLuuLoaiDiemHocSinh.ItemsSource = null;
                    var hocSinh = from ai in db.TLuuTruHSSuas
                                  where ai.MaChinhSuaCuaLuuTru == a.MaChinhSua
                                  select ai;
                    List<LuuTruHSSua> dsHSSua = hocSinh.ToList();
                    dtLuuHocSinh.ItemsSource = dsHSSua;
            }
        }

        private void dtLuuHocSinh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LuuTruHSSua a = (LuuTruHSSua)dtLuuHocSinh.SelectedItem;
            if (a!=null)
            {
                MyEntity db = new MyEntity();
                dtLuuLoaiDiemHocSinh.ItemsSource = null;
                var diems = from diemNao in db.TLuuTruDiemHSSuas
                            where diemNao.MaDiemSua.Substring(5) == a.MaSua.Substring(2)
                            select diemNao;
                List<LuuTruDiemHSSua> dsDiems = diems.ToList();
                dtLuuDiemHocSinh.ItemsSource = dsDiems;
            }
        }

        private void dtLuuDiemHocSinh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LuuTruDiemHSSua a = (LuuTruDiemHSSua)dtLuuDiemHocSinh.SelectedItem;
            if (a!=null)
            {
                MyEntity db = new MyEntity();
                var loaiDiems = from diemNao in db.TLuuTruLoaiDiemHSSuas
                                where diemNao.MaLoaiDiemSua.Substring(7) == a.MaDiemSua.Substring(5) && diemNao.MaLoaiDiemSua.Substring(2,3) == a.MaDiemSua.Substring(2,3)
                                select diemNao;
                List<LuuTruLoaiDiemHSSua> dsDiems = loaiDiems.ToList();
                dtLuuLoaiDiemHocSinh.ItemsSource = dsDiems;
            }
        }
    }
}
