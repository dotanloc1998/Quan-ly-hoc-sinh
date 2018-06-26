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
    /// Interaction logic for ThemDiem.xaml
    /// </summary>
    public partial class ThemDiem : Window
    {
        public HocSinh hocSinhTrongNay;
        private bool buttonThemIClicked = false;
        public ThemDiem(HocSinh hocSinh)
        {
            InitializeComponent();            
            hocSinhTrongNay = hocSinh;
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

        private void btThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MyEntity db = new MyEntity();

                //Tạo một học sinh với thông tin đã được truyền vào từ giao diện ThemHocSinh
                //Còn thiếu ĐTB và Xếp loại Học Lực
                HocSinh a = new HocSinh(hocSinhTrongNay.MaSoHS, hocSinhTrongNay.HoTen, hocSinhTrongNay.NgaySinh, hocSinhTrongNay.DiaChi, hocSinhTrongNay.XLHanhKiem, hocSinhTrongNay.QueQuan, hocSinhTrongNay.LopCuaHS);

                //Điểm toán của học sinh
                Diem diemToan = new Diem();
                diemToan.MaDiem = "DTO" + a.MaSoHS;
                diemToan.MaHSCuaDiemA = a.MaSoHS;
                //Thêm vào 3 loại điểm toán
                LoaiDiemCuaTungMon diemToan15 = new LoaiDiemCuaTungMon("DTO15" + a.MaSoHS, double.Parse(Toan15.Text), diemToan.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemToan15);
                LoaiDiemCuaTungMon diemToan45 = new LoaiDiemCuaTungMon("DTO45" + a.MaSoHS, double.Parse(Toan45.Text), diemToan.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemToan45);
                LoaiDiemCuaTungMon diemToanHK = new LoaiDiemCuaTungMon("DTOHK" + a.MaSoHS, double.Parse(ToanHK.Text), diemToan.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemToanHK);
                //Tính điểm trung bình của môn Toán
                diemToan.SoDiem = Math.Round((diemToan15.SoDiem * 1 + diemToan45.SoDiem * 2 + diemToanHK.SoDiem * 2) / 5, 2);
                db.TDiems.Add(diemToan);

                //Điểm Ngữ văn của học sinh
                Diem diemNV = new Diem();
                diemNV.MaDiem = "DNV" + a.MaSoHS;
                diemNV.MaHSCuaDiemA = a.MaSoHS;
                //Thêm vào 3 loại điểm Văn
                LoaiDiemCuaTungMon diemNV15 = new LoaiDiemCuaTungMon("DNV15" + a.MaSoHS, double.Parse(Van15.Text), diemNV.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemNV15);
                LoaiDiemCuaTungMon diemNV45 = new LoaiDiemCuaTungMon("DNV45" + a.MaSoHS, double.Parse(Van45.Text), diemNV.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemNV45);
                LoaiDiemCuaTungMon diemNVHK = new LoaiDiemCuaTungMon("DNVHK" + a.MaSoHS, double.Parse(VanHK.Text), diemNV.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemNVHK);
                //Tính điểm trung bình của môn Văn
                diemNV.SoDiem = Math.Round((diemNV15.SoDiem * 1 + diemNV45.SoDiem * 2 + diemNVHK.SoDiem * 2) / 5, 2);
                db.TDiems.Add(diemNV);

                //Điểm Sinh của học sinh
                Diem diemSinh = new Diem();
                diemSinh.MaDiem = "DSI" + a.MaSoHS;
                diemSinh.MaHSCuaDiemA = a.MaSoHS;
                //Thêm vào 3 loại điểm Sinh
                LoaiDiemCuaTungMon diemSinh15 = new LoaiDiemCuaTungMon("DSI15" + a.MaSoHS, double.Parse(Sinh15.Text), diemSinh.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemSinh15);
                LoaiDiemCuaTungMon diemSinh45 = new LoaiDiemCuaTungMon("DSI45" + a.MaSoHS, double.Parse(Sinh45.Text), diemSinh.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemSinh45);
                LoaiDiemCuaTungMon diemSinhHK = new LoaiDiemCuaTungMon("DSIHK" + a.MaSoHS, double.Parse(SinhHK.Text), diemSinh.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemSinhHK);
                //Tính điểm trung bình của môn Sinh
                diemSinh.SoDiem = Math.Round((diemSinh15.SoDiem * 1 + diemSinh45.SoDiem * 2 + diemSinhHK.SoDiem * 2) / 5, 2);
                db.TDiems.Add(diemSinh);

                //Điểm Vật lý của học sinh
                Diem diemVatLy = new Diem();
                diemVatLy.MaDiem = "DVL" + a.MaSoHS;
                diemVatLy.MaHSCuaDiemA = a.MaSoHS;
                //Thêm vào 3 loại điểm Vật lý
                LoaiDiemCuaTungMon diemVatLy15 = new LoaiDiemCuaTungMon("DVL15" + a.MaSoHS, double.Parse(VL15.Text), diemVatLy.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemVatLy15);
                LoaiDiemCuaTungMon diemVatLy45 = new LoaiDiemCuaTungMon("DVL45" + a.MaSoHS, double.Parse(VL45.Text), diemVatLy.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemVatLy45);
                LoaiDiemCuaTungMon diemVatLyHK = new LoaiDiemCuaTungMon("DVLHK" + a.MaSoHS, double.Parse(VLHK.Text), diemVatLy.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemVatLyHK);
                //Tính điểm trung bình của môn Vật lý
                diemVatLy.SoDiem = Math.Round((diemVatLy15.SoDiem * 1 + diemVatLy45.SoDiem * 2 + diemVatLyHK.SoDiem * 2) / 5, 2);
                db.TDiems.Add(diemVatLy);

                //Điểm Hóa của học sinh
                Diem diemHoa = new Diem();
                diemHoa.MaDiem = "DHO" + a.MaSoHS;
                diemHoa.MaHSCuaDiemA = a.MaSoHS;
                //Thêm vào 3 loại điểm Hóa
                LoaiDiemCuaTungMon diemHoa15 = new LoaiDiemCuaTungMon("DHO15" + a.MaSoHS, double.Parse(Hoa15.Text), diemHoa.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemHoa15);
                LoaiDiemCuaTungMon diemHoa45 = new LoaiDiemCuaTungMon("DHO45" + a.MaSoHS, double.Parse(Hoa45.Text), diemHoa.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemHoa45);
                LoaiDiemCuaTungMon diemHoaHK = new LoaiDiemCuaTungMon("DHOHK" + a.MaSoHS, double.Parse(HoaHK.Text), diemHoa.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemHoaHK);
                //Tính điểm trung bình của môn Hóa
                diemHoa.SoDiem = Math.Round((diemHoa15.SoDiem * 1 + diemHoa45.SoDiem * 2 + diemHoaHK.SoDiem * 2) / 5, 2);
                db.TDiems.Add(diemHoa);

                //Điểm Sử của học sinh
                Diem diemSu = new Diem();
                diemSu.MaDiem = "DSU" + a.MaSoHS;
                diemSu.MaHSCuaDiemA = a.MaSoHS;
                //Thêm vào 3 loại điểm Sử
                LoaiDiemCuaTungMon diemSu15 = new LoaiDiemCuaTungMon("DSU15" + a.MaSoHS, double.Parse(Su15.Text), diemSu.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemSu15);
                LoaiDiemCuaTungMon diemSu45 = new LoaiDiemCuaTungMon("DSU45" + a.MaSoHS, double.Parse(Su45.Text), diemSu.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemSu45);
                LoaiDiemCuaTungMon diemSuHK = new LoaiDiemCuaTungMon("DSUHK" + a.MaSoHS, double.Parse(SuHK.Text), diemSu.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemSuHK);
                //Tính điểm trung bình của môn Sử
                diemSu.SoDiem = Math.Round((diemSu15.SoDiem * 1 + diemSu45.SoDiem * 2 + diemSuHK.SoDiem * 2) / 5, 2);
                db.TDiems.Add(diemSu);

                //Điểm Địa của học sinh
                Diem diemDia = new Diem();
                diemDia.MaDiem = "DDI" + a.MaSoHS;
                diemDia.MaHSCuaDiemA = a.MaSoHS;
                //Thêm vào 3 loại điểm Địa
                LoaiDiemCuaTungMon diemDia15 = new LoaiDiemCuaTungMon("DDI15" + a.MaSoHS, double.Parse(Dia15.Text), diemDia.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemDia15);
                LoaiDiemCuaTungMon diemDia45 = new LoaiDiemCuaTungMon("DDI45" + a.MaSoHS, double.Parse(Dia45.Text), diemDia.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemDia45);
                LoaiDiemCuaTungMon diemDiaHK = new LoaiDiemCuaTungMon("DDIHK" + a.MaSoHS, double.Parse(DiaHK.Text), diemDia.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemDiaHK);
                //Tính điểm trung bình của môn Địa
                diemDia.SoDiem = Math.Round((diemDia15.SoDiem * 1 + diemDia45.SoDiem * 2 + diemDiaHK.SoDiem * 2) / 5, 2);
                db.TDiems.Add(diemDia);

                //Điểm Ngoại ngữ của học sinh
                Diem diemNN = new Diem();
                diemNN.MaDiem = "DNN" + a.MaSoHS;
                diemNN.MaHSCuaDiemA = a.MaSoHS;
                //Thêm vào 3 loại điểm Ngoại ngữ
                LoaiDiemCuaTungMon diemNN15 = new LoaiDiemCuaTungMon("DNN15" + a.MaSoHS, double.Parse(NN15.Text), diemNN.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemNN15);
                LoaiDiemCuaTungMon diemNN45 = new LoaiDiemCuaTungMon("DNN45" + a.MaSoHS, double.Parse(NN45.Text), diemNN.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemNN45);
                LoaiDiemCuaTungMon diemNNHK = new LoaiDiemCuaTungMon("DNNHK" + a.MaSoHS, double.Parse(NNHK.Text), diemNN.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemNNHK);
                //Tính điểm trung bình của môn Ngoại ngữ
                diemNN.SoDiem = Math.Round((diemNN15.SoDiem * 1 + diemNN45.SoDiem * 2 + diemNNHK.SoDiem * 2) / 5, 2);
                db.TDiems.Add(diemNN);

                //Điểm Công dân của học sinh
                Diem diemCD = new Diem();
                diemCD.MaDiem = "DCD" + a.MaSoHS;
                diemCD.MaHSCuaDiemA = a.MaSoHS;
                //Thêm vào 3 loại điểm Công dân
                LoaiDiemCuaTungMon diemCD15 = new LoaiDiemCuaTungMon("DCD15" + a.MaSoHS, double.Parse(CD15.Text), diemCD.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemCD15);
                LoaiDiemCuaTungMon diemCD45 = new LoaiDiemCuaTungMon("DCD45" + a.MaSoHS, double.Parse(CD45.Text), diemCD.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemCD45);
                LoaiDiemCuaTungMon diemCDHK = new LoaiDiemCuaTungMon("DCDHK" + a.MaSoHS, double.Parse(CDHK.Text), diemCD.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemCDHK);
                //Tính điểm trung bình của môn Công dân
                diemCD.SoDiem = Math.Round((diemCD15.SoDiem * 1 + diemCD45.SoDiem * 2 + diemCDHK.SoDiem * 2) / 5, 2);
                db.TDiems.Add(diemCD);

                //Điểm Quốc phòng của học sinh
                Diem diemQP = new Diem();
                diemQP.MaDiem = "DQP" + a.MaSoHS;
                diemQP.MaHSCuaDiemA = a.MaSoHS;
                //Thêm vào 3 loại điểm Quốc phòng
                LoaiDiemCuaTungMon diemQP15 = new LoaiDiemCuaTungMon("DQP15" + a.MaSoHS, double.Parse(QP15.Text), diemQP.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemQP15);
                LoaiDiemCuaTungMon diemQP45 = new LoaiDiemCuaTungMon("DQP45" + a.MaSoHS, double.Parse(QP45.Text), diemQP.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemQP45);
                LoaiDiemCuaTungMon diemQPHK = new LoaiDiemCuaTungMon("DQPHK" + a.MaSoHS, double.Parse(QPHK.Text), diemQP.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemQPHK);
                //Tính điểm trung bình của môn Quốc phòng
                diemQP.SoDiem = Math.Round((diemQP15.SoDiem * 1 + diemQP45.SoDiem * 2 + diemQPHK.SoDiem * 2) / 5, 2);
                db.TDiems.Add(diemQP);

                //Điểm Thể dục của học sinh               
                Diem diemTD = new Diem();
                diemTD.MaDiem = "DTD" + a.MaSoHS;
                diemTD.MaHSCuaDiemA = a.MaSoHS;
                //Thêm vào 3 loại điểm Thể dục
                LoaiDiemCuaTungMon diemTD15 = new LoaiDiemCuaTungMon("DTD15" + a.MaSoHS, double.Parse(TD15.Text), diemTD.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemTD15);
                LoaiDiemCuaTungMon diemTD45 = new LoaiDiemCuaTungMon("DTD45" + a.MaSoHS, double.Parse(TD45.Text), diemTD.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemTD45);
                LoaiDiemCuaTungMon diemTDHK = new LoaiDiemCuaTungMon("DTDHK" + a.MaSoHS, double.Parse(TDHK.Text), diemTD.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemTDHK);
                //Tính điểm trung bình của môn Thể dục
                diemTD.SoDiem = Math.Round((diemTD15.SoDiem * 1 + diemTD45.SoDiem * 2 + diemTDHK.SoDiem * 2) / 5, 2);
                db.TDiems.Add(diemTD);

                //Điểm Công nghệ của học sinh
                Diem diemCN = new Diem();
                diemCN.MaDiem = "DCN" + a.MaSoHS;
                diemCN.MaHSCuaDiemA = a.MaSoHS;
                //Thêm vào 3 loại điểm Công nghệ
                LoaiDiemCuaTungMon diemCN15 = new LoaiDiemCuaTungMon("DCN15" + a.MaSoHS, double.Parse(CN15.Text), diemCN.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemCN15);
                LoaiDiemCuaTungMon diemCN45 = new LoaiDiemCuaTungMon("DCN45" + a.MaSoHS, double.Parse(CN45.Text), diemCN.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemCN45);
                LoaiDiemCuaTungMon diemCNHK = new LoaiDiemCuaTungMon("DCNHK" + a.MaSoHS, double.Parse(CNHK.Text), diemCN.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemCNHK);
                //Tính điểm trung bình của môn Công nghệ
                diemCN.SoDiem = Math.Round((diemCN15.SoDiem * 1 + diemCN45.SoDiem * 2 + diemCNHK.SoDiem * 2) / 5, 2);
                db.TDiems.Add(diemCN);

                //Điểm Tin học của học sinh
                Diem diemTH = new Diem();
                diemTH.MaDiem = "DTH" + a.MaSoHS;
                diemTH.MaHSCuaDiemA = a.MaSoHS;
                //Thêm vào 3 loại điểm Tin học
                LoaiDiemCuaTungMon diemTH15 = new LoaiDiemCuaTungMon("DTH15" + a.MaSoHS, double.Parse(TH15.Text), diemTH.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemTH15);
                LoaiDiemCuaTungMon diemTH45 = new LoaiDiemCuaTungMon("DTH45" + a.MaSoHS, double.Parse(TH45.Text), diemTH.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemTH45);
                LoaiDiemCuaTungMon diemTHHK = new LoaiDiemCuaTungMon("DTHHK" + a.MaSoHS, double.Parse(THHK.Text), diemTH.MaDiem);
                db.TLoaiDiemCuaTungMons.Add(diemTHHK);
                //Tính điểm trung bình của môn Tin học
                diemTH.SoDiem = Math.Round((diemTH15.SoDiem * 1 + diemTH45.SoDiem * 2 + diemTHHK.SoDiem * 2) / 5, 2);
                db.TDiems.Add(diemTH);

                //Chúng ta còn thiếu ĐTB và Xếp loại học lực nên chúng ta sẽ bổ sung
                double diemTBHS = Math.Round((diemToan.SoDiem * 2 + diemNV.SoDiem * 2 + diemSinh.SoDiem + diemVatLy.SoDiem + diemHoa.SoDiem + diemSu.SoDiem + diemDia.SoDiem + diemNN.SoDiem + diemCD.SoDiem + diemQP.SoDiem + diemTD.SoDiem + diemCN.SoDiem + diemTH.SoDiem) / 15, 2);
                //Như vậy điểm TB của Hs này là
                a.DiemTBCuaHS = diemTBHS;
                //Giờ đến tiêu chí xét
                string xepLoai = "";
                if (diemTBHS >= 8 && diemNV.SoDiem >= 8 && diemTH.SoDiem >= 6.5 && diemCN.SoDiem >= 6.5 && diemTD.SoDiem >= 6.5 && diemQP.SoDiem >= 6.5 && diemCD.SoDiem >= 6.5 && diemNN.SoDiem >= 6.5 && diemDia.SoDiem >= 6.5 && diemSu.SoDiem >= 6.5 && diemHoa.SoDiem >= 6.5 && diemToan.SoDiem >=6.5 && diemSinh.SoDiem >= 6.5 && diemVatLy.SoDiem >= 6.5 || diemTBHS >= 8 && diemToan.SoDiem >= 8 && diemTH.SoDiem >= 6.5 && diemCN.SoDiem >= 6.5 && diemTD.SoDiem >= 6.5 && diemQP.SoDiem >= 6.5 && diemCD.SoDiem >= 6.5 && diemNN.SoDiem >= 6.5 && diemDia.SoDiem >= 6.5 && diemSu.SoDiem >= 6.5 && diemHoa.SoDiem >= 6.5 && diemNV.SoDiem >= 6.5 && diemSinh.SoDiem >= 6.5 && diemVatLy.SoDiem >= 6.5)
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
                a.XLHocLuc = xepLoai;
                //Đến đây ta thêm học sinh a vào CSDL
                db.THocSinhs.Add(a);
                db.SaveChanges();
                //Thông báo cho người dùng biết
                if (MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information,MessageBoxResult.OK)==MessageBoxResult.OK)
                {
                    buttonThemIClicked = true;
                    Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi vui lòng kiểm tra lại!", "Có lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Hàm này có chức năng giúp giao diện ThemHocSinh biết là giáo viên đã thêm học sinh hay chỉ tắt giao diện ThemDiem
        public bool BtThemIsClick()
        {
            return buttonThemIClicked;
        }
        //Phần xử lý giao diện

        //Ngữ văn
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
