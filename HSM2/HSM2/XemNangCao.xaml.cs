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
    /// Interaction logic for XemNangCao.xaml
    /// </summary>
    public partial class XemNangCao : Window
    {
        public static HocSinh b;
        public static string maGVTrongNay;
        public bool nhanCapNhat = false;
        public XemNangCao(HocSinh hocSinhB, string maGV)
        {
            InitializeComponent();
            b = hocSinhB;
            maGVTrongNay = maGV;
            MyEntity db = new MyEntity();

            var diemsCuaHocSinh = from diemNao in db.TDiems
                                  where diemNao.MaHSCuaDiemA.ToUpper() == hocSinhB.MaSoHS.ToUpper()
                                  select diemNao;
            List<Diem> listDiem = diemsCuaHocSinh.ToList();

            var loaiDiemsCuaHocSinh = from diemNao in db.TLoaiDiemCuaTungMons
                                      where diemNao.MaDiemCuaLoaiDiem.Substring(3).ToUpper() == hocSinhB.MaSoHS.ToUpper()
                                      select diemNao;
            List<LoaiDiemCuaTungMon> listLoaiDiemCuaTungMons = loaiDiemsCuaHocSinh.ToList();

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

            foreach (var item in listDiem)
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


            LoaiDiemCuaTungMon diemToan15 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemToan45 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemToanHK = new LoaiDiemCuaTungMon();

            LoaiDiemCuaTungMon diemNguVan15 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemNguVan45 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemNguVanHK = new LoaiDiemCuaTungMon();

            LoaiDiemCuaTungMon diemSinh15 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemSinh45 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemSinhHK = new LoaiDiemCuaTungMon();

            LoaiDiemCuaTungMon diemVL15 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemVL45 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemVLHK = new LoaiDiemCuaTungMon();

            LoaiDiemCuaTungMon diemHoa15 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemHoa45 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemHoaHK = new LoaiDiemCuaTungMon();

            LoaiDiemCuaTungMon diemSu15 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemSu45 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemSuHK = new LoaiDiemCuaTungMon();

            LoaiDiemCuaTungMon diemDia15 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemDia45 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemDiaHK = new LoaiDiemCuaTungMon();

            LoaiDiemCuaTungMon diemNgoaiNgu15 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemNgoaiNgu45 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemNgoaiNguHK = new LoaiDiemCuaTungMon();

            LoaiDiemCuaTungMon diemCongDan15 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemCongDan45 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemCongDanHK = new LoaiDiemCuaTungMon();

            LoaiDiemCuaTungMon diemQuocPhong15 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemQuocPhong45 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemQuocPhongHK = new LoaiDiemCuaTungMon();

            LoaiDiemCuaTungMon diemTheDuc15 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemTheDuc45 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemTheDucHK = new LoaiDiemCuaTungMon();

            LoaiDiemCuaTungMon diemCongNghe15 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemCongNghe45 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemCongNgheHK = new LoaiDiemCuaTungMon();

            LoaiDiemCuaTungMon diemTinHoc15 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemTinHoc45 = new LoaiDiemCuaTungMon();
            LoaiDiemCuaTungMon diemTinHocHK = new LoaiDiemCuaTungMon();

            foreach (var item in listLoaiDiemCuaTungMons)
            {
                if (item.MaLoaiDiem.Substring(0, 5) == "DCD15")
                {
                    diemCongDan15 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DCD45")
                {
                    diemCongDan45 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DCDHK")
                {
                    diemCongDanHK = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DCN15")
                {
                    diemCongNghe15 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DCN45")
                {
                    diemCongNghe45 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DCNHK")
                {
                    diemCongNgheHK = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DDI15")
                {
                    diemDia15 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DDI45")
                {
                    diemDia45 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DDIHK")
                {
                    diemDiaHK = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DHO15")
                {
                    diemHoa15 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DHO45")
                {
                    diemHoa45 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DHOHK")
                {
                    diemHoaHK = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DNN15")
                {
                    diemNgoaiNgu15 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DNN45")
                {
                    diemNgoaiNgu45 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DNNHK")
                {
                    diemNgoaiNguHK = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DNV15")
                {
                    diemNguVan15 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DNV45")
                {
                    diemNguVan45 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DNVHK")
                {
                    diemNguVanHK = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DQP15")
                {
                    diemQuocPhong15 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DQP45")
                {
                    diemQuocPhong45 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DQPHK")
                {
                    diemQuocPhongHK = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DSI15")
                {
                    diemSinh15 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DSI45")
                {
                    diemSinh45 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DSIHK")
                {
                    diemSinhHK = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DSU15")
                {
                    diemSu15 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DSU45")
                {
                    diemSu45 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DSUHK")
                {
                    diemSuHK = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DTD15")
                {
                    diemTheDuc15 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DTD45")
                {
                    diemTheDuc45 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DTDHK")
                {
                    diemTheDucHK = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DTH15")
                {
                    diemTinHoc15 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DTH45")
                {
                    diemTinHoc45 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DTHHK")
                {
                    diemTinHocHK = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DTO15")
                {
                    diemToan15 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DTO45")
                {
                    diemToan45 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DTOHK")
                {
                    diemToanHK = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DVL15")
                {
                    diemVL15 = item;
                }
                else if (item.MaLoaiDiem.Substring(0, 5) == "DVL45")
                {
                    diemVL45 = item;
                }
                else
                {
                    diemVLHK = item;
                }
            }

            //Đổ dữ liệu vào các textbox
            CD15.Text = diemCongDan15.SoDiem.ToString();
            CD45.Text = diemCongDan45.SoDiem.ToString();
            CDHK.Text = diemCongDanHK.SoDiem.ToString();

            CN15.Text = diemCongNghe15.SoDiem.ToString();
            CN45.Text = diemCongNghe45.SoDiem.ToString();
            CNHK.Text = diemCongNgheHK.SoDiem.ToString();

            Dia15.Text = diemDia15.SoDiem.ToString();
            Dia45.Text = diemDia45.SoDiem.ToString();
            DiaHK.Text = diemDiaHK.SoDiem.ToString();

            Hoa15.Text = diemHoa15.SoDiem.ToString();
            Hoa45.Text = diemHoa45.SoDiem.ToString();
            HoaHK.Text = diemHoaHK.SoDiem.ToString();

            NN15.Text = diemNgoaiNgu15.SoDiem.ToString();
            NN45.Text = diemNgoaiNgu45.SoDiem.ToString();
            NNHK.Text = diemNgoaiNguHK.SoDiem.ToString();

            Van15.Text = diemNguVan15.SoDiem.ToString();
            Van45.Text = diemNguVan45.SoDiem.ToString();
            VanHK.Text = diemNguVanHK.SoDiem.ToString();

            QP15.Text = diemQuocPhong15.SoDiem.ToString();
            QP45.Text = diemQuocPhong45.SoDiem.ToString();
            QPHK.Text = diemQuocPhongHK.SoDiem.ToString();

            Sinh15.Text = diemSinh15.SoDiem.ToString();
            Sinh45.Text = diemSinh45.SoDiem.ToString();
            SinhHK.Text = diemSinhHK.SoDiem.ToString();

            Su15.Text = diemSu15.SoDiem.ToString();
            Su45.Text = diemSu45.SoDiem.ToString();
            SuHK.Text = diemSuHK.SoDiem.ToString();

            TD15.Text = diemTheDuc15.SoDiem.ToString();
            TD45.Text = diemTheDuc45.SoDiem.ToString();
            TDHK.Text = diemTheDucHK.SoDiem.ToString();

            TH15.Text = diemTinHoc15.SoDiem.ToString();
            TH45.Text = diemTinHoc45.SoDiem.ToString();
            THHK.Text = diemTinHocHK.SoDiem.ToString();

            Toan15.Text = diemToan15.SoDiem.ToString();
            Toan45.Text = diemToan45.SoDiem.ToString();
            ToanHK.Text = diemToanHK.SoDiem.ToString();

            VL15.Text = diemVL15.SoDiem.ToString();
            VL45.Text = diemVL45.SoDiem.ToString();
            VLHK.Text = diemVLHK.SoDiem.ToString();

            //Các textbox điểm TB
            CDTB.Text = diemCD.SoDiem.ToString();

            CNTB.Text = diemCN.SoDiem.ToString();

            DiaTB.Text = diemDia.SoDiem.ToString();

            HoaTB.Text = diemHoa.SoDiem.ToString();

            NNTB.Text = diemNN.SoDiem.ToString();

            VanTB.Text = diemNV.SoDiem.ToString();

            QPTB.Text = diemQP.SoDiem.ToString();

            SinhTB.Text = diemSinh.SoDiem.ToString();

            SuTB.Text = diemSu.SoDiem.ToString();

            TDTB.Text = diemTD.SoDiem.ToString();

            THTB.Text = diemTH.SoDiem.ToString();

            ToanTB.Text = diemToan.SoDiem.ToString();

            VLTB.Text = diemVatLy.SoDiem.ToString();
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
            if (MessageBox.Show("Bạn thực sự muốn thoát ?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
            {
                Close();
            }
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

        private void btHuy_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn thực sự muốn thoát ?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
            {
                Close();
            }
        }

        private void btSua_Click(object sender, RoutedEventArgs e)
        {
            AdminDangNhap admin = new AdminDangNhap();
            admin.ShowDialog();
            if (admin.NhapDung())
            {
                try
                {
                    //Lấy học sinh đang coi điểm từ CSDL 
                    MyEntity db = new MyEntity();
                    var hocSinhDuocChon = from ai in db.THocSinhs
                                          where ai.MaSoHS == b.MaSoHS
                                          select ai;
                    List<HocSinh> timDuoc = hocSinhDuocChon.ToList();

                    HocSinh a = timDuoc[0];

                    //Tạo ra một lịch sử chỉnh sửa 
                    DateTime thoiDiemNhap = DateTime.Now;
                    string[] gioPhutGiay = thoiDiemNhap.ToString("HH:mm:ss").Split(':');
                    string nam = thoiDiemNhap.Year.ToString();
                    LichSuChinhSua suaHocSinh = new LichSuChinhSua("Sua" + a.MaSoHS.ToUpper() + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], DateTime.Now, maGVTrongNay);
                    db.TLichSuChinhSuas.Add(suaHocSinh);

                    //Lưu lại các thông tin trước khi sửa của HS 
                    LuuTruHSSua truocKhiSua = new LuuTruHSSua("TS" + a.MaSoHS.ToUpper() + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], a, suaHocSinh.MaChinhSua);
                    db.TLuuTruHSSuas.Add(truocKhiSua);
                    db.SaveChanges();

                    //Lưu trữ lại tất cả điểm trước khi sửa
                    var timDiemCuaA = from diemNao in db.TDiems
                                      where diemNao.MaHSCuaDiemA == a.MaSoHS
                                      select diemNao;
                    List<Diem> listDiemCuaA = timDiemCuaA.ToList();
                    foreach (var diemCuaA in listDiemCuaA)
                    {
                        LuuTruDiemHSSua diemTruocSua = new LuuTruDiemHSSua("TS" + diemCuaA.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], a.MaSoHS, diemCuaA.SoDiem);
                        db.TLuuTruDiemHSSuas.Add(diemTruocSua);
                    }

                    //Lưu trữ lại tất cả loại điểm trước khi sửa
                    var timLoaiDiemCuaA = from diemNao in db.TLoaiDiemCuaTungMons
                                          where diemNao.MaDiemCuaLoaiDiem.Substring(3).ToUpper() == a.MaSoHS.ToUpper()
                                          select diemNao;
                    List<LoaiDiemCuaTungMon> listLoaiDiemTungMonA = timLoaiDiemCuaA.ToList();
                    foreach (var loaiDiemCuaA in listLoaiDiemTungMonA)
                    {
                        LuuTruLoaiDiemHSSua diemCanLuu = new LuuTruLoaiDiemHSSua("TS" + loaiDiemCuaA.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], loaiDiemCuaA.SoDiem, loaiDiemCuaA.MaDiemCuaLoaiDiem);
                        db.TLuuTruLoaiDiemHSSuas.Add(diemCanLuu);
                    }
                    db.SaveChanges();

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

                    db.SaveChanges();
                    //Đã đưa vào học sinh B

                    //Điểm toán của học sinh
                    Diem diemToan = new Diem();
                    diemToan.MaDiem = "DTO" + b.MaSoHS;
                    diemToan.MaHSCuaDiemA = b.MaSoHS;
                    //Thêm vào 3 loại điểm toán
                    LoaiDiemCuaTungMon diemToan15 = new LoaiDiemCuaTungMon("DTO15" + b.MaSoHS, double.Parse(Toan15.Text), diemToan.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemToan15);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemToan15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemToan15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemToan15.SoDiem, diemToan15.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemToan15SauSua);

                    LoaiDiemCuaTungMon diemToan45 = new LoaiDiemCuaTungMon("DTO45" + b.MaSoHS, double.Parse(Toan45.Text), diemToan.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemToan45);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemToan45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemToan45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemToan45.SoDiem, diemToan45.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemToan45SauSua);

                    LoaiDiemCuaTungMon diemToanHK = new LoaiDiemCuaTungMon("DTOHK" + b.MaSoHS, double.Parse(ToanHK.Text), diemToan.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemToanHK);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemToanHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemToanHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemToanHK.SoDiem, diemToanHK.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemToanHKSauSua);

                    //Tính điểm trung bình của môn Toán
                    diemToan.SoDiem = Math.Round((diemToan15.SoDiem * 1 + diemToan45.SoDiem * 2 + diemToanHK.SoDiem * 2) / 5, 2);
                    db.TDiems.Add(diemToan);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruDiemHSSua diemToanSauSua = new LuuTruDiemHSSua("SS" + diemToan.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemToan.MaHSCuaDiemA, diemToan.SoDiem);
                    db.TLuuTruDiemHSSuas.Add(diemToanSauSua);

                    //Điểm Văn của học sinh
                    Diem diemNV = new Diem();
                    diemNV.MaDiem = "DNV" + b.MaSoHS;
                    diemNV.MaHSCuaDiemA = b.MaSoHS;
                    //Thêm vào 3 loại điểm 
                    LoaiDiemCuaTungMon diemNV15 = new LoaiDiemCuaTungMon("DNV15" + b.MaSoHS, double.Parse(Van15.Text), diemNV.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemNV15);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemNV15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemNV15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemNV15.SoDiem, diemNV15.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemNV15SauSua);

                    LoaiDiemCuaTungMon diemNV45 = new LoaiDiemCuaTungMon("DNV45" + b.MaSoHS, double.Parse(Van45.Text), diemNV.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemNV45);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemNV45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemNV45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemNV45.SoDiem, diemNV45.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemNV45SauSua);

                    LoaiDiemCuaTungMon diemNVHK = new LoaiDiemCuaTungMon("DNVHK" + b.MaSoHS, double.Parse(VanHK.Text), diemNV.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemNVHK);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemNVHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemNVHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemNVHK.SoDiem, diemNVHK.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemNVHKSauSua);

                    //Tính điểm trung bình của môn 
                    diemNV.SoDiem = Math.Round((diemNV15.SoDiem * 1 + diemNV45.SoDiem * 2 + diemNVHK.SoDiem * 2) / 5, 2);
                    db.TDiems.Add(diemNV);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruDiemHSSua diemNVSauSua = new LuuTruDiemHSSua("SS" + diemNV.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemNV.MaHSCuaDiemA, diemNV.SoDiem);
                    db.TLuuTruDiemHSSuas.Add(diemNVSauSua);

                    //Điểm Sinh học của học sinh
                    Diem diemSinh = new Diem();
                    diemSinh.MaDiem = "DSI" + b.MaSoHS;
                    diemSinh.MaHSCuaDiemA = b.MaSoHS;
                    //Thêm vào 3 loại điểm 
                    LoaiDiemCuaTungMon diemSinh15 = new LoaiDiemCuaTungMon("DSI15" + b.MaSoHS, double.Parse(Sinh15.Text), diemSinh.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemSinh15);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemSinh15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemSinh15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemSinh15.SoDiem, diemSinh15.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemSinh15SauSua);

                    LoaiDiemCuaTungMon diemSinh45 = new LoaiDiemCuaTungMon("DSI45" + b.MaSoHS, double.Parse(Sinh45.Text), diemSinh.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemSinh45);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemSinh45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemSinh45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemSinh45.SoDiem, diemSinh45.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemSinh45SauSua);

                    LoaiDiemCuaTungMon diemSinhHK = new LoaiDiemCuaTungMon("DSIHK" + b.MaSoHS, double.Parse(SinhHK.Text), diemSinh.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemSinhHK);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemSinhHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemSinhHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemSinhHK.SoDiem, diemSinhHK.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemSinhHKSauSua);

                    //Tính điểm trung bình của môn
                    diemSinh.SoDiem = Math.Round((diemSinh15.SoDiem * 1 + diemSinh45.SoDiem * 2 + diemSinhHK.SoDiem * 2) / 5, 2);
                    db.TDiems.Add(diemSinh);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruDiemHSSua diemSinhSauSua = new LuuTruDiemHSSua("SS" + diemSinh.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemSinh.MaHSCuaDiemA, diemSinh.SoDiem);
                    db.TLuuTruDiemHSSuas.Add(diemSinhSauSua);

                    //Điểm Vật lý của học sinh
                    Diem diemVatLy = new Diem();
                    diemVatLy.MaDiem = "DVL" + b.MaSoHS;
                    diemVatLy.MaHSCuaDiemA = b.MaSoHS;
                    //Thêm vào 3 loại điểm 
                    LoaiDiemCuaTungMon diemVatLy15 = new LoaiDiemCuaTungMon("DVL15" + b.MaSoHS, double.Parse(VL15.Text), diemVatLy.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemVatLy15);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemVatLy15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemVatLy15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemVatLy15.SoDiem, diemVatLy15.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemVatLy15SauSua);

                    LoaiDiemCuaTungMon diemVatLy45 = new LoaiDiemCuaTungMon("DVL45" + b.MaSoHS, double.Parse(VL45.Text), diemVatLy.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemVatLy45);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemVatLy45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemVatLy45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemVatLy45.SoDiem, diemVatLy45.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemVatLy45SauSua);

                    LoaiDiemCuaTungMon diemVatLyHK = new LoaiDiemCuaTungMon("DVLHK" + b.MaSoHS, double.Parse(VLHK.Text), diemVatLy.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemVatLyHK);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemVatLyHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemVatLyHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemVatLyHK.SoDiem, diemVatLyHK.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemVatLyHKSauSua);

                    //Tính điểm trung bình của môn 
                    diemVatLy.SoDiem = Math.Round((diemVatLy15.SoDiem * 1 + diemVatLy45.SoDiem * 2 + diemVatLyHK.SoDiem * 2) / 5, 2);
                    db.TDiems.Add(diemVatLy);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruDiemHSSua diemVatLySauSua = new LuuTruDiemHSSua("SS" + diemVatLy.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemVatLy.MaHSCuaDiemA, diemVatLy.SoDiem);
                    db.TLuuTruDiemHSSuas.Add(diemVatLySauSua);

                    //Điểm Hóa của học sinh
                    Diem diemHoa = new Diem();
                    diemHoa.MaDiem = "DHO" + b.MaSoHS;
                    diemHoa.MaHSCuaDiemA = b.MaSoHS;
                    //Thêm vào 3 loại điểm 
                    LoaiDiemCuaTungMon diemHoa15 = new LoaiDiemCuaTungMon("DHO15" + b.MaSoHS, double.Parse(Hoa15.Text), diemHoa.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemHoa15);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemHoa15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemHoa15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemHoa15.SoDiem, diemHoa15.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemHoa15SauSua);

                    LoaiDiemCuaTungMon diemHoa45 = new LoaiDiemCuaTungMon("DHO45" + b.MaSoHS, double.Parse(Hoa45.Text), diemHoa.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemHoa45);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemHoa45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemHoa45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemHoa45.SoDiem, diemHoa45.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemHoa45SauSua);

                    LoaiDiemCuaTungMon diemHoaHK = new LoaiDiemCuaTungMon("DHOHK" + b.MaSoHS, double.Parse(HoaHK.Text), diemHoa.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemHoaHK);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemHoaHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemHoaHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemHoaHK.SoDiem, diemHoaHK.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemHoaHKSauSua);

                    //Tính điểm trung bình của môn 
                    diemHoa.SoDiem = Math.Round((diemHoa15.SoDiem * 1 + diemHoa45.SoDiem * 2 + diemHoaHK.SoDiem * 2) / 5, 2);
                    db.TDiems.Add(diemHoa);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruDiemHSSua diemHoaSauSua = new LuuTruDiemHSSua("SS" + diemHoa.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemHoa.MaHSCuaDiemA, diemHoa.SoDiem);
                    db.TLuuTruDiemHSSuas.Add(diemHoaSauSua);

                    //Điểm Sử của học sinh
                    Diem diemSu = new Diem();
                    diemSu.MaDiem = "DSU" + b.MaSoHS;
                    diemSu.MaHSCuaDiemA = b.MaSoHS;
                    //Thêm vào 3 loại điểm 
                    LoaiDiemCuaTungMon diemSu15 = new LoaiDiemCuaTungMon("DSU15" + b.MaSoHS, double.Parse(Su15.Text), diemSu.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemSu15);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemSu15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemSu15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemSu15.SoDiem, diemSu15.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemSu15SauSua);

                    LoaiDiemCuaTungMon diemSu45 = new LoaiDiemCuaTungMon("DSU45" + b.MaSoHS, double.Parse(Su45.Text), diemSu.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemSu45);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemSu45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemSu45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemSu45.SoDiem, diemSu45.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemSu45SauSua);

                    LoaiDiemCuaTungMon diemSuHK = new LoaiDiemCuaTungMon("DSUHK" + b.MaSoHS, double.Parse(SuHK.Text), diemSu.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemSuHK);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemSuHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemSuHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemSuHK.SoDiem, diemSuHK.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemSuHKSauSua);

                    //Tính điểm trung bình của môn 
                    diemSu.SoDiem = Math.Round((diemSu15.SoDiem * 1 + diemSu45.SoDiem * 2 + diemSuHK.SoDiem * 2) / 5, 2);
                    db.TDiems.Add(diemSu);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruDiemHSSua diemSuSauSua = new LuuTruDiemHSSua("SS" + diemSu.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemSu.MaHSCuaDiemA, diemSu.SoDiem);
                    db.TLuuTruDiemHSSuas.Add(diemSuSauSua);

                    //Điểm Địa của học sinh
                    Diem diemDia = new Diem();
                    diemDia.MaDiem = "DDI" + b.MaSoHS;
                    diemDia.MaHSCuaDiemA = b.MaSoHS;
                    //Thêm vào 3 loại điểm 
                    LoaiDiemCuaTungMon diemDia15 = new LoaiDiemCuaTungMon("DDI15" + b.MaSoHS, double.Parse(Dia15.Text), diemDia.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemDia15);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemDia15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemDia15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemDia15.SoDiem, diemDia15.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemDia15SauSua);

                    LoaiDiemCuaTungMon diemDia45 = new LoaiDiemCuaTungMon("DDI45" + b.MaSoHS, double.Parse(Dia45.Text), diemDia.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemDia45);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemDia45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemDia45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemDia45.SoDiem, diemDia45.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemDia45SauSua);

                    LoaiDiemCuaTungMon diemDiaHK = new LoaiDiemCuaTungMon("DDIHK" + b.MaSoHS, double.Parse(DiaHK.Text), diemDia.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemDiaHK);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemDiaHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemDiaHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemDiaHK.SoDiem, diemDiaHK.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemDiaHKSauSua);

                    //Tính điểm trung bình của môn 
                    diemDia.SoDiem = Math.Round((diemDia15.SoDiem * 1 + diemDia45.SoDiem * 2 + diemDiaHK.SoDiem * 2) / 5, 2);
                    db.TDiems.Add(diemDia);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruDiemHSSua diemDiaSauSua = new LuuTruDiemHSSua("SS" + diemDia.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemDia.MaHSCuaDiemA, diemDia.SoDiem);
                    db.TLuuTruDiemHSSuas.Add(diemDiaSauSua);

                    //Điểm Ngoại ngữ của học sinh
                    Diem diemNN = new Diem();
                    diemNN.MaDiem = "DNN" + b.MaSoHS;
                    diemNN.MaHSCuaDiemA = b.MaSoHS;
                    //Thêm vào 3 loại điểm 
                    LoaiDiemCuaTungMon diemNN15 = new LoaiDiemCuaTungMon("DNN15" + b.MaSoHS, double.Parse(NN15.Text), diemNN.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemNN15);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemNN15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemNN15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemNN15.SoDiem, diemNN15.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemNN15SauSua);

                    LoaiDiemCuaTungMon diemNN45 = new LoaiDiemCuaTungMon("DNN45" + b.MaSoHS, double.Parse(NN45.Text), diemNN.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemNN45);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemNN45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemNN45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemNN45.SoDiem, diemNN45.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemNN45SauSua);

                    LoaiDiemCuaTungMon diemNNHK = new LoaiDiemCuaTungMon("DNNHK" + b.MaSoHS, double.Parse(NNHK.Text), diemNN.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemNNHK);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemNNHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemNNHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemNNHK.SoDiem, diemNNHK.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemNNHKSauSua);

                    //Tính điểm trung bình của môn 
                    diemNN.SoDiem = Math.Round((diemNN15.SoDiem * 1 + diemNN45.SoDiem * 2 + diemNNHK.SoDiem * 2) / 5, 2);
                    db.TDiems.Add(diemNN);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruDiemHSSua diemNNSauSua = new LuuTruDiemHSSua("SS" + diemNN.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemNN.MaHSCuaDiemA, diemNN.SoDiem);
                    db.TLuuTruDiemHSSuas.Add(diemNNSauSua);

                    //Điểm Công dân của học sinh
                    Diem diemCD = new Diem();
                    diemCD.MaDiem = "DCD" + b.MaSoHS;
                    diemCD.MaHSCuaDiemA = b.MaSoHS;
                    //Thêm vào 3 loại điểm 
                    LoaiDiemCuaTungMon diemCD15 = new LoaiDiemCuaTungMon("DCD15" + b.MaSoHS, double.Parse(CD15.Text), diemCD.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemCD15);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemCD15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemCD15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemCD15.SoDiem, diemCD15.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemCD15SauSua);

                    LoaiDiemCuaTungMon diemCD45 = new LoaiDiemCuaTungMon("DCD45" + b.MaSoHS, double.Parse(CD45.Text), diemCD.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemCD45);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemCD45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemCD45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemCD45.SoDiem, diemCD45.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemCD45SauSua);

                    LoaiDiemCuaTungMon diemCDHK = new LoaiDiemCuaTungMon("DCDHK" + b.MaSoHS, double.Parse(CDHK.Text), diemCD.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemCDHK);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemCDHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemCDHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemCDHK.SoDiem, diemCDHK.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemCDHKSauSua);

                    //Tính điểm trung bình của môn 
                    diemCD.SoDiem = Math.Round((diemCD15.SoDiem * 1 + diemCD45.SoDiem * 2 + diemCDHK.SoDiem * 2) / 5, 2);
                    db.TDiems.Add(diemCD);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruDiemHSSua diemCDSauSua = new LuuTruDiemHSSua("SS" + diemCD.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemCD.MaHSCuaDiemA, diemCD.SoDiem);
                    db.TLuuTruDiemHSSuas.Add(diemCDSauSua);

                    //Điểm Quốc phòng của học sinh
                    Diem diemQP = new Diem();
                    diemQP.MaDiem = "DQP" + b.MaSoHS;
                    diemQP.MaHSCuaDiemA = b.MaSoHS;
                    //Thêm vào 3 loại điểm 
                    LoaiDiemCuaTungMon diemQP15 = new LoaiDiemCuaTungMon("DQP15" + b.MaSoHS, double.Parse(QP15.Text), diemQP.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemQP15);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemQP15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemQP15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemQP15.SoDiem, diemQP15.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemQP15SauSua);

                    LoaiDiemCuaTungMon diemQP45 = new LoaiDiemCuaTungMon("DQP45" + b.MaSoHS, double.Parse(QP45.Text), diemQP.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemQP45);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemQP45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemQP45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemQP45.SoDiem, diemQP45.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemQP45SauSua);

                    LoaiDiemCuaTungMon diemQPHK = new LoaiDiemCuaTungMon("DQPHK" + b.MaSoHS, double.Parse(QPHK.Text), diemQP.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemQPHK);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemQPHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemQPHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemQPHK.SoDiem, diemQPHK.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemQPHKSauSua);

                    //Tính điểm trung bình của môn 
                    diemQP.SoDiem = Math.Round((diemQP15.SoDiem * 1 + diemQP45.SoDiem * 2 + diemQPHK.SoDiem * 2) / 5, 2);
                    db.TDiems.Add(diemQP);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruDiemHSSua diemQPSauSua = new LuuTruDiemHSSua("SS" + diemQP.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemQP.MaHSCuaDiemA, diemQP.SoDiem);
                    db.TLuuTruDiemHSSuas.Add(diemQPSauSua);

                    //Điểm Thể dục của học sinh
                    Diem diemTD = new Diem();
                    diemTD.MaDiem = "DTD" + b.MaSoHS;
                    diemTD.MaHSCuaDiemA = b.MaSoHS;
                    //Thêm vào 3 loại điểm 
                    LoaiDiemCuaTungMon diemTD15 = new LoaiDiemCuaTungMon("DTD15" + b.MaSoHS, double.Parse(TD15.Text), diemTD.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemTD15);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemTD15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemTD15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemTD15.SoDiem, diemTD15.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemTD15SauSua);

                    LoaiDiemCuaTungMon diemTD45 = new LoaiDiemCuaTungMon("DTD45" + b.MaSoHS, double.Parse(TD45.Text), diemTD.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemTD45);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemTD45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemTD45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemTD45.SoDiem, diemTD45.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemTD45SauSua);

                    LoaiDiemCuaTungMon diemTDHK = new LoaiDiemCuaTungMon("DTDHK" + b.MaSoHS, double.Parse(TDHK.Text), diemTD.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemTDHK);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemTDHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemTDHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemTDHK.SoDiem, diemTDHK.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemTDHKSauSua);

                    //Tính điểm trung bình của môn 
                    diemTD.SoDiem = Math.Round((diemTD15.SoDiem * 1 + diemTD45.SoDiem * 2 + diemTDHK.SoDiem * 2) / 5, 2);
                    db.TDiems.Add(diemTD);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruDiemHSSua diemTDSauSua = new LuuTruDiemHSSua("SS" + diemTD.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemTD.MaHSCuaDiemA, diemTD.SoDiem);
                    db.TLuuTruDiemHSSuas.Add(diemTDSauSua);

                    //Điểm Công nghệ của học sinh
                    Diem diemCN = new Diem();
                    diemCN.MaDiem = "DCN" + b.MaSoHS;
                    diemCN.MaHSCuaDiemA = b.MaSoHS;
                    //Thêm vào 3 loại điểm 
                    LoaiDiemCuaTungMon diemCN15 = new LoaiDiemCuaTungMon("DCN15" + b.MaSoHS, double.Parse(CN15.Text), diemCN.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemCN15);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemCN15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemCN15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemCN15.SoDiem, diemCN15.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemCN15SauSua);

                    LoaiDiemCuaTungMon diemCN45 = new LoaiDiemCuaTungMon("DCN45" + b.MaSoHS, double.Parse(CN45.Text), diemCN.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemCN45);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemCN45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemCN45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemCN45.SoDiem, diemCN45.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemCN45SauSua);

                    LoaiDiemCuaTungMon diemCNHK = new LoaiDiemCuaTungMon("DCNHK" + b.MaSoHS, double.Parse(CNHK.Text), diemCN.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemCNHK);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemCNHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemCNHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemCNHK.SoDiem, diemCNHK.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemCNHKSauSua);

                    //Tính điểm trung bình của môn 
                    diemCN.SoDiem = Math.Round((diemCN15.SoDiem * 1 + diemCN45.SoDiem * 2 + diemCNHK.SoDiem * 2) / 5, 2);
                    db.TDiems.Add(diemCN);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruDiemHSSua diemCNSauSua = new LuuTruDiemHSSua("SS" + diemCN.MaDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemCN.MaHSCuaDiemA, diemCN.SoDiem);
                    db.TLuuTruDiemHSSuas.Add(diemCNSauSua);

                    //Điểm Tin học của học sinh
                    Diem diemTH = new Diem();
                    diemTH.MaDiem = "DTH" + b.MaSoHS;
                    diemTH.MaHSCuaDiemA = b.MaSoHS;
                    //Thêm vào 3 loại điểm 
                    LoaiDiemCuaTungMon diemTH15 = new LoaiDiemCuaTungMon("DTH15" + b.MaSoHS, double.Parse(TH15.Text), diemTH.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemTH15);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemTH15SauSua = new LuuTruLoaiDiemHSSua("SS" + diemTH15.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemTH15.SoDiem, diemTH15.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemTH15SauSua);

                    LoaiDiemCuaTungMon diemTH45 = new LoaiDiemCuaTungMon("DTH45" + b.MaSoHS, double.Parse(TH45.Text), diemTH.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemTH45);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemTH45SauSua = new LuuTruLoaiDiemHSSua("SS" + diemTH45.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemTH45.SoDiem, diemTH45.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemTH45SauSua);

                    LoaiDiemCuaTungMon diemTHHK = new LoaiDiemCuaTungMon("DTHHK" + b.MaSoHS, double.Parse(THHK.Text), diemTH.MaDiem);
                    db.TLoaiDiemCuaTungMons.Add(diemTHHK);

                    //Tạo 1 bảng copy của điểm vừa mới sửa để lưu vào kết quả sau khi sửa
                    LuuTruLoaiDiemHSSua diemTHHKSauSua = new LuuTruLoaiDiemHSSua("SS" + diemTHHK.MaLoaiDiem + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], diemTHHK.SoDiem, diemTHHK.MaDiemCuaLoaiDiem);
                    db.TLuuTruLoaiDiemHSSuas.Add(diemTHHKSauSua);

                    //Tính điểm trung bình của môn 
                    diemTH.SoDiem = Math.Round((diemTH15.SoDiem * 1 + diemTH45.SoDiem * 2 + diemTHHK.SoDiem * 2) / 5, 2);
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
                    db.THocSinhs.Attach(a);
                    db.THocSinhs.Remove(a);
                    db.THocSinhs.Add(b);
                    //Và gán b vào bảng sau khi sửa
                    LuuTruHSSua sauKhiSua = new LuuTruHSSua("SS" + b.MaSoHS.ToUpper() + gioPhutGiay[0] + gioPhutGiay[1] + gioPhutGiay[2], b, suaHocSinh.MaChinhSua);
                    db.TLuuTruHSSuas.Add(sauKhiSua);
                    db.SaveChanges();
                    nhanCapNhat = true;
                    MessageBox.Show("Đã cập nhật học sinh", "Thông báo!!!", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Để bên giao diện LopChuNhiem biết giáo viên có nhân nút cập nhật không 
        public bool CoNhanCapNhatKhong()
        {
            return nhanCapNhat;
        }

        private void Van15_GotFocus(object sender, RoutedEventArgs e)
        {
            Van15.Text = "";
        }

        private void Van15_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Van15.Text == "")
            {
                Van15.Text = "0";
            }
        }

        private void Van15_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(Van15.Text, out diem);
            if (laDouble || Van15.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Van15.Text = "";
                    Van15.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                Van15.Text = "";
            }
        }

        private void Van45_GotFocus(object sender, RoutedEventArgs e)
        {
            Van45.Text = "";
        }

        private void Van45_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Van45.Text == "")
            {
                Van45.Text = "0";
            }
        }

        private void Van45_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(Van45.Text, out diem);
            if (laDouble || Van45.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Van45.Text = "";
                    Van45.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                Van45.Text = "";
            }
        }

        private void VanHK_GotFocus(object sender, RoutedEventArgs e)
        {
            VanHK.Text = "";
        }

        private void VanHK_LostFocus(object sender, RoutedEventArgs e)
        {
            if (VanHK.Text == "")
            {
                VanHK.Text = "0";
            }
        }

        private void VanHK_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(VanHK.Text, out diem);
            if (laDouble || VanHK.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    VanHK.Text = "";
                    VanHK.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                VanHK.Text = "";
            }
        }

        // Toán
        private void Toan15_GotFocus(object sender, RoutedEventArgs e)
        {
            Toan15.Text = "";
        }

        private void Toan45_GotFocus(object sender, RoutedEventArgs e)
        {
            Toan45.Text = "";
        }

        private void ToanHK_GotFocus(object sender, RoutedEventArgs e)
        {
            ToanHK.Text = "";
        }

        private void Toan15_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Toan15.Text == "")
            {
                Toan15.Text = "0";
            }
        }

        private void Toan45_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Toan45.Text == "")
            {
                Toan45.Text = "0";
            }
        }

        private void ToanHK_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ToanHK.Text == "")
            {
                ToanHK.Text = "0";
            }
        }

        private void Toan15_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(Toan15.Text, out diem);
            if (laDouble || Toan15.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Toan15.Text = "";
                    Toan15.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                Toan15.Text = "";
            }
        }

        private void Toan45_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(Toan45.Text, out diem);
            if (laDouble || Toan45.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Toan45.Text = "";
                    Toan45.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                Toan45.Text = "";
            }
        }

        private void ToanHK_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(ToanHK.Text, out diem);
            if (laDouble || ToanHK.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ToanHK.Text = "";
                    ToanHK.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                ToanHK.Text = "";
            }
        }

        //Sinh
        private void Sinh15_GotFocus(object sender, RoutedEventArgs e)
        {
            Sinh15.Text = "";
        }

        private void Sinh45_GotFocus(object sender, RoutedEventArgs e)
        {
            Sinh45.Text = "";
        }

        private void SinhHK_GotFocus(object sender, RoutedEventArgs e)
        {
            SinhHK.Text = "";
        }

        private void Sinh15_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Sinh15.Text == "")
            {
                Sinh15.Text = "0";
            }
        }

        private void Sinh45_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Sinh45.Text == "")
            {
                Sinh45.Text = "0";
            }
        }

        private void SinhHK_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SinhHK.Text == "")
            {
                SinhHK.Text = "0";
            }
        }

        private void Sinh15_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(Sinh15.Text, out diem);
            if (laDouble || Sinh15.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Sinh15.Text = "";
                    Sinh15.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                Sinh15.Text = "";
            }
        }

        private void Sinh45_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(Sinh45.Text, out diem);
            if (laDouble || Sinh45.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Sinh45.Text = "";
                    Sinh45.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                Sinh45.Text = "";
            }
        }

        private void SinhHK_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(SinhHK.Text, out diem);
            if (laDouble || SinhHK.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    SinhHK.Text = "";
                    SinhHK.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                SinhHK.Text = "";
            }
        }

        //Vat ly
        private void VL15_GotFocus(object sender, RoutedEventArgs e)
        {
            VL15.Text = "";
        }

        private void VL45_GotFocus(object sender, RoutedEventArgs e)
        {
            VL45.Text = "";
        }

        private void VLHK_GotFocus(object sender, RoutedEventArgs e)
        {
            VLHK.Text = "";
        }

        private void VL15_LostFocus(object sender, RoutedEventArgs e)
        {
            if (VL15.Text == "")
            {
                VL15.Text = "0";
            }
        }

        private void VL45_LostFocus(object sender, RoutedEventArgs e)
        {
            if (VL45.Text == "")
            {
                VL45.Text = "0";
            }
        }

        private void VLHK_LostFocus(object sender, RoutedEventArgs e)
        {
            if (VLHK.Text == "")
            {
                VLHK.Text = "0";
            }
        }

        private void VL15_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(VL15.Text, out diem);
            if (laDouble || VL15.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    VL15.Text = "";
                    VL15.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                VL15.Text = "";
            }
        }

        private void VL45_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(VL45.Text, out diem);
            if (laDouble || VL45.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    VL45.Text = "";
                    VL45.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                VL45.Text = "";
            }
        }

        private void VLHK_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(VLHK.Text, out diem);
            if (laDouble || VLHK.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    VLHK.Text = "";
                    VLHK.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                VLHK.Text = "";
            }
        }

        //Hoa
        private void Hoa15_GotFocus(object sender, RoutedEventArgs e)
        {
            Hoa15.Text = "";
        }

        private void Hoa45_GotFocus(object sender, RoutedEventArgs e)
        {
            Hoa45.Text = "";
        }

        private void HoaHK_GotFocus(object sender, RoutedEventArgs e)
        {
            HoaHK.Text = "";
        }

        private void Hoa15_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Hoa15.Text == "")
            {
                Hoa15.Text = "0";
            }
        }

        private void Hoa45_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Hoa45.Text == "")
            {
                Hoa45.Text = "0";
            }
        }

        private void HoaHK_LostFocus(object sender, RoutedEventArgs e)
        {
            if (HoaHK.Text == "")
            {
                HoaHK.Text = "0";
            }
        }

        private void Hoa15_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(Hoa15.Text, out diem);
            if (laDouble || Hoa15.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Hoa15.Text = "";
                    Hoa15.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                Hoa15.Text = "";
            }
        }

        private void Hoa45_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(Hoa45.Text, out diem);
            if (laDouble || Hoa45.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Hoa45.Text = "";
                    Hoa45.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                Hoa45.Text = "";
            }
        }

        private void HoaHK_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(HoaHK.Text, out diem);
            if (laDouble || HoaHK.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    HoaHK.Text = "";
                    HoaHK.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                HoaHK.Text = "";
            }
        }

        //Su
        private void Su15_GotFocus(object sender, RoutedEventArgs e)
        {
            Su15.Text = "";
        }

        private void Su45_GotFocus(object sender, RoutedEventArgs e)
        {
            Su45.Text = "";
        }

        private void SuHK_GotFocus(object sender, RoutedEventArgs e)
        {
            SuHK.Text = "";
        }

        private void Su15_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Su15.Text == "")
            {
                Su15.Text = "0";
            }
        }

        private void Su45_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Su45.Text == "")
            {
                Su45.Text = "0";
            }
        }

        private void SuHK_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SuHK.Text == "")
            {
                SuHK.Text = "0";
            }
        }

        private void Su15_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(Su15.Text, out diem);
            if (laDouble || Su15.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Su15.Text = "";
                    Su15.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                Su15.Text = "";
            }
        }

        private void Su45_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(Su45.Text, out diem);
            if (laDouble || Su45.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Su45.Text = "";
                    Su45.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                Su45.Text = "";
            }
        }

        private void SuHK_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(SuHK.Text, out diem);
            if (laDouble || SuHK.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    SuHK.Text = "";
                    SuHK.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                SuHK.Text = "";
            }
        }

        //Dia
        private void Dia15_GotFocus(object sender, RoutedEventArgs e)
        {
            Dia15.Text = "";
        }

        private void Dia45_GotFocus(object sender, RoutedEventArgs e)
        {
            Dia45.Text = "";
        }

        private void DiaHK_GotFocus(object sender, RoutedEventArgs e)
        {
            DiaHK.Text = "";
        }

        private void Dia15_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Dia15.Text == "")
            {
                Dia15.Text = "0";
            }
        }

        private void Dia45_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Dia45.Text == "")
            {
                Dia45.Text = "0";
            }
        }

        private void DiaHK_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DiaHK.Text == "")
            {
                DiaHK.Text = "0";
            }
        }

        private void Dia15_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(Dia15.Text, out diem);
            if (laDouble || Dia15.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Dia15.Text = "";
                    Dia15.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                Dia15.Text = "";
            }
        }

        private void Dia45_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(Dia45.Text, out diem);
            if (laDouble || Dia45.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Dia45.Text = "";
                    Dia45.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                Dia45.Text = "";
            }
        }

        private void DiaHK_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(DiaHK.Text, out diem);
            if (laDouble || DiaHK.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    DiaHK.Text = "";
                    DiaHK.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                DiaHK.Text = "";
            }
        }

        //Ngoai ngu
        private void NN15_GotFocus(object sender, RoutedEventArgs e)
        {
            NN15.Text = "";
        }

        private void NN45_GotFocus(object sender, RoutedEventArgs e)
        {
            NN45.Text = "";
        }

        private void NNHK_GotFocus(object sender, RoutedEventArgs e)
        {
            NNHK.Text = "";
        }

        private void NN15_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NN15.Text == "")
            {
                NN15.Text = "0";
            }
        }

        private void NN45_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NN45.Text == "")
            {
                NN45.Text = "0";
            }
        }

        private void NNHK_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NNHK.Text == "")
            {
                NNHK.Text = "0";
            }
        }

        private void NN15_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(NN15.Text, out diem);
            if (laDouble || NN15.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    NN15.Text = "";
                    NN15.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                NN15.Text = "";
            }
        }

        private void NN45_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(NN45.Text, out diem);
            if (laDouble || NN45.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    NN45.Text = "";
                    NN45.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                NN45.Text = "";
            }
        }

        private void NNHK_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(NNHK.Text, out diem);
            if (laDouble || NNHK.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    NNHK.Text = "";
                    NNHK.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                NNHK.Text = "";
            }
        }

        //GDCD
        private void CD15_GotFocus(object sender, RoutedEventArgs e)
        {
            CD15.Text = "";
        }

        private void CD45_GotFocus(object sender, RoutedEventArgs e)
        {
            CD45.Text = "";
        }

        private void CDHK_GotFocus(object sender, RoutedEventArgs e)
        {
            CDHK.Text = "";
        }

        private void CD15_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CD15.Text == "")
            {
                CD15.Text = "0";
            }
        }

        private void CD45_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CD45.Text == "")
            {
                CD45.Text = "0";
            }
        }

        private void CDHK_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CDHK.Text == "")
            {
                CDHK.Text = "0";
            }
        }

        private void CD15_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(CD15.Text, out diem);
            if (laDouble || CD15.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    CD15.Text = "";
                    CD15.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                CD15.Text = "";
            }
        }

        private void CD45_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(CD45.Text, out diem);
            if (laDouble || CD45.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    CD45.Text = "";
                    CD45.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                CD45.Text = "";
            }
        }

        private void CDHK_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(CDHK.Text, out diem);
            if (laDouble || CDHK.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    CDHK.Text = "";
                    CDHK.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                CDHK.Text = "";
            }
        }

        //Quoc phong
        private void QP15_GotFocus(object sender, RoutedEventArgs e)
        {
            QP15.Text = "";
        }

        private void QP45_GotFocus(object sender, RoutedEventArgs e)
        {
            QP45.Text = "";
        }

        private void QPHK_GotFocus(object sender, RoutedEventArgs e)
        {
            QPHK.Text = "";
        }

        private void QP15_LostFocus(object sender, RoutedEventArgs e)
        {
            if (QP15.Text == "")
            {
                QP15.Text = "0";
            }
        }

        private void QP45_LostFocus(object sender, RoutedEventArgs e)
        {
            if (QP45.Text == "")
            {
                QP45.Text = "0";
            }
        }

        private void QPHK_LostFocus(object sender, RoutedEventArgs e)
        {
            if (QPHK.Text == "")
            {
                QPHK.Text = "0";
            }
        }

        private void QP15_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(QP15.Text, out diem);
            if (laDouble || QP15.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    QP15.Text = "";
                    QP15.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                QP15.Text = "";
            }
        }

        private void QP45_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(QP45.Text, out diem);
            if (laDouble || QP45.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    QP45.Text = "";
                    QP45.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                QP45.Text = "";
            }
        }

        private void QPHK_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(QPHK.Text, out diem);
            if (laDouble || QPHK.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    QPHK.Text = "";
                    QPHK.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                QPHK.Text = "";
            }
        }

        //The duc
        private void TD15_GotFocus(object sender, RoutedEventArgs e)
        {
            TD15.Text = "";
        }

        private void TD45_GotFocus(object sender, RoutedEventArgs e)
        {
            TD45.Text = "";
        }

        private void TDHK_GotFocus(object sender, RoutedEventArgs e)
        {
            TDHK.Text = "";
        }

        private void TD15_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TD15.Text == "")
            {
                TD15.Text = "0";
            }
        }

        private void TD45_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TD45.Text == "")
            {
                TD45.Text = "0";
            }
        }

        private void TDHK_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TDHK.Text == "")
            {
                TDHK.Text = "0";
            }
        }

        private void TD15_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(TD15.Text, out diem);
            if (laDouble || TD15.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    TD15.Text = "";
                    TD15.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                TD15.Text = "";
            }
        }

        private void TD45_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(TD45.Text, out diem);
            if (laDouble || TD45.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    TD45.Text = "";
                    TD45.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                TD45.Text = "";
            }
        }

        private void TDHK_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(TDHK.Text, out diem);
            if (laDouble || TDHK.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    TDHK.Text = "";
                    TDHK.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                TDHK.Text = "";
            }
        }

        //Cong nghe
        private void CN15_GotFocus(object sender, RoutedEventArgs e)
        {
            CN15.Text = "";
        }

        private void CN45_GotFocus(object sender, RoutedEventArgs e)
        {
            CN45.Text = "";
        }

        private void CNHK_GotFocus(object sender, RoutedEventArgs e)
        {
            CNHK.Text = "";
        }

        private void CN15_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CN15.Text == "")
            {
                CN15.Text = "0";
            }
        }

        private void CN45_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CN45.Text == "")
            {
                CN45.Text = "0";
            }
        }

        private void CNHK_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CNHK.Text == "")
            {
                CNHK.Text = "0";
            }
        }

        private void CN15_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(CN15.Text, out diem);
            if (laDouble || CN15.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    CN15.Text = "";
                    CN15.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                CN15.Text = "";
            }
        }

        private void CN45_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(CN45.Text, out diem);
            if (laDouble || CN45.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    CN45.Text = "";
                    CN45.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                CN45.Text = "";
            }
        }

        private void CNHK_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(CNHK.Text, out diem);
            if (laDouble || CNHK.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    CNHK.Text = "";
                    CNHK.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                CNHK.Text = "";
            }
        }

        //Tin hoc
        private void TH15_GotFocus(object sender, RoutedEventArgs e)
        {
            TH15.Text = "";
        }

        private void TH45_GotFocus(object sender, RoutedEventArgs e)
        {
            TH45.Text = "";
        }

        private void THHK_GotFocus(object sender, RoutedEventArgs e)
        {
            THHK.Text = "";
        }

        private void TH15_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TH15.Text == "")
            {
                TH15.Text = "0";
            }
        }

        private void TH45_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TH45.Text == "")
            {
                TH45.Text = "0";
            }
        }

        private void THHK_LostFocus(object sender, RoutedEventArgs e)
        {
            if (THHK.Text == "")
            {
                THHK.Text = "0";
            }
        }

        private void TH15_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(TH15.Text, out diem);
            if (laDouble || TH15.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    TH15.Text = "";
                    TH15.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                TH15.Text = "";
            }
        }

        private void TH45_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(TH45.Text, out diem);
            if (laDouble || TH45.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    TH45.Text = "";
                    TH45.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                TH45.Text = "";
            }
        }

        private void THHK_TextChanged(object sender, TextChangedEventArgs e)
        {
            double diem;
            bool laDouble = Double.TryParse(THHK.Text, out diem);
            if (laDouble || THHK.Text == "")
            {
                if (diem > 10 || diem < 0)
                {
                    MessageBox.Show("Phải nhập vào số từ 0 đến 10", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    THHK.Text = "";
                    THHK.Focus();
                }
            }
            else
            {
                MessageBox.Show("Phải nhập vào số thực", "Thông báo !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                THHK.Text = "";
            }
        }

    }
}
