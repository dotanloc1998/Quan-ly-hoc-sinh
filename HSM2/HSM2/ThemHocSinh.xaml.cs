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
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace HSM2
{
    /// <summary>
    /// Interaction logic for ThemHocSinh.xaml
    /// </summary>
    /// 
    public partial class ThemHocSinh : Window
    {
        public static string maGVTrongNay;
        public static string lopCuaHSTrongNay;
        public ThemHocSinh(string maGV, string lopCuaHS)
        {
            InitializeComponent();
            maGVTrongNay = maGV;
            lopCuaHSTrongNay = lopCuaHS;
            txtMaHS.Focus();
            MyEntity db = new MyEntity();
            var link = from linkNao in db.TDuongDans
                       where linkNao.MaDuongDan == "HALG"
                       select linkNao;
            List<DuongDan> dsDuongDan = link.ToList();
            DuongDan timDuocLogo = dsDuongDan[0];
            string pathLogo = timDuocLogo.DuongDanDenFile;
            try
            {
                ImageSource imageSourceLogo = new BitmapImage(new Uri(pathLogo));
                hinhLogo.Source = imageSourceLogo;
            }
            catch (Exception)
            {


            }
        }

        private void btDong_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
                Height = 550; Width = 800;
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
                    Height = 550; Width = 800;
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
                    Height = 550; Width = 800;
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
                    Height = 550; Width = 800;
                    DragMove();
                }
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

        private void btThemDiem_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra xem mã số học sinh đó có thuộc về học sinh đã từng bị xóa hay không ?
            MyEntity db = new MyEntity();
            var hocSinhDaBiXoa = from ai in db.TLuuTruHSXoas
                                 where ai.MaSoHSXoa == txtMaHS.Text
                                 select ai;
            List<LuuTruHSXoa> hocSinhTimDuoc = hocSinhDaBiXoa.ToList();
            if (hocSinhTimDuoc.Count == 0)
            {
                try
                {
                    if (txtMaHS.Text != "" && txtHoTenHS.Text != "" && dpNgaySinhHS.Text != "" && txtDiaChiHS.Text != "" && txtHanhKiem.Text != "" && txtQueQuanHS.Text != "")
                    {
                        HocSinh canThem = new HocSinh(txtMaHS.Text.ToUpper(), txtHoTenHS.Text, dpNgaySinhHS.DisplayDate, txtDiaChiHS.Text, "", txtHanhKiem.Text, txtQueQuanHS.Text, lopCuaHSTrongNay, 0.0);
                        bool isClick = false;
                        ThemDiem a = new ThemDiem(canThem);
                        a.ShowDialog();
                        if (a.IsActive == false && a.BtThemIsClick())
                        {
                            txtMaHS.Text = "";
                            txtHoTenHS.Text = "";
                            dpNgaySinhHS.Text = "";
                            txtDiaChiHS.Text = "";
                            txtHanhKiem.Text = "";
                            txtQueQuanHS.Text = "";
                            txtMaHS.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhớ nhập hết đừng để trống ô nào nhé!", "Có lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Đã xảy ra lỗi vui lòng kiểm tra lại!", "Có lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Mã số học sinh này thuộc về một học sinh đã bị xóa \nnếu muốn khôi phục lại học sinh này \n xin vui lòng liên hệ Admin , xin cám ơn!", "Thông báo!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                txtMaHS.Text = "";
                txtMaHS.Focus();
            }

        }

        private void btHuy_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn thực sự muốn thoát ?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
            {
                Close();
            }
        }

        private void btNhapFile_Click(object sender, RoutedEventArgs e)
        {
            //Mở ra giao diện chọn file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Các tệp Excel (*.xls;*.xlsx)|*.xls;*.xlsx|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            //Xử lí
            //Tạo cái list để tạm lưu trữ thông tin học sinh , điểm và loại điểm
            List<HocSinh> hocSinhs = new List<HocSinh>();
            List<Diem> diems = new List<Diem>();
            List<LoaiDiemCuaTungMon> loaiDiemCuaTungMons = new List<LoaiDiemCuaTungMon>();
            MyEntity db = new MyEntity();
            if (openFileDialog.FileName != "")
            {
                //Tạo đối tượng Excel 
                Excel.Application app = new Excel.Application();
                //Mở file Excel Học Sinh
                Excel.Workbook wb = app.Workbooks.Open(openFileDialog.FileName);

                try
                {
                    //Mở sheet đầu tiên là sheet thông tin học sinh
                    //Trong này chỉ số đầu tiên bắt đầu từ 1
                    Excel._Worksheet sheetCanMo = wb.Sheets[1];
                    //Truy cập vùng dữ liệu sử dụng
                    Excel.Range range = sheetCanMo.UsedRange;
                    //Bắt đầu đọc dữ liệu
                    int dong = range.Rows.Count;

                    //Chúng ta bắt đầu đọc dữ liệu từ dòng 2 vì dòng 1 là tiêu đề
                    for (int i = 2; i <= dong; i++)
                    {
                        HocSinh a = new HocSinh(range.Cells[i, 1].Value.ToString().ToUpper(), range.Cells[i, 2].Value.ToString(), range.Cells[i, 3].Value, range.Cells[i, 4].Value.ToString(), range.Cells[i, 5].Value.ToString(), range.Cells[i, 6].Value.ToString(), lopCuaHSTrongNay);
                        //Còn thiếu điểm TB và học lực
                        hocSinhs.Add(a);
                    }

                    //Mở sheet tiếp theo là điểm Toán
                    sheetCanMo = wb.Sheets[2];
                    //Truy cập vùng dữ liệu sử dụng
                    range = sheetCanMo.UsedRange;
                    //Bắt đầu đọc dữ liệu
                    dong = range.Rows.Count;
                    for (int i = 2; i <= dong; i++)
                    {
                        //Ta có được các loại điểm của 1 học sinh
                        LoaiDiemCuaTungMon diem15 = new LoaiDiemCuaTungMon("DTO15" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 2].Value.ToString()), "DTO" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem15);
                        LoaiDiemCuaTungMon diem45 = new LoaiDiemCuaTungMon("DTO45" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 3].Value.ToString()), "DTO" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem45);
                        LoaiDiemCuaTungMon diemHK = new LoaiDiemCuaTungMon("DTOHK" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 4].Value.ToString()), "DTO" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diemHK);

                        //Ta có được điểm trung bình của loại điểm đó
                        Diem diemTO = new Diem();
                        diemTO.MaDiem = "DTO" + range.Cells[i, 1].Value.ToString().ToUpper();
                        diemTO.MaHSCuaDiemA = range.Cells[i, 1].Value.ToString().ToUpper();
                        diemTO.SoDiem = Math.Round((diem15.SoDiem + diem45.SoDiem * 2 + diemHK.SoDiem * 2) / 5, 2);
                        diems.Add(diemTO);
                    }

                    //Mở sheet tiếp theo là điểm Ngữ văn
                    sheetCanMo = wb.Sheets[3];
                    //Truy cập vùng dữ liệu sử dụng
                    range = sheetCanMo.UsedRange;
                    //Bắt đầu đọc dữ liệu
                    dong = range.Rows.Count;
                    for (int i = 2; i <= dong; i++)
                    {
                        LoaiDiemCuaTungMon diem15 = new LoaiDiemCuaTungMon("DNV15" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 2].Value.ToString()), "DNV" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem15);
                        LoaiDiemCuaTungMon diem45 = new LoaiDiemCuaTungMon("DNV45" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 3].Value.ToString()), "DNV" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem45);
                        LoaiDiemCuaTungMon diemHK = new LoaiDiemCuaTungMon("DNVHK" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 4].Value.ToString()), "DNV" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diemHK);

                        Diem diemNV = new Diem();
                        diemNV.MaDiem = "DNV" + range.Cells[i, 1].Value.ToString().ToUpper();
                        diemNV.MaHSCuaDiemA = range.Cells[i, 1].Value.ToString().ToUpper();
                        diemNV.SoDiem = Math.Round((diem15.SoDiem + diem45.SoDiem * 2 + diemHK.SoDiem * 2) / 5, 2);
                        diems.Add(diemNV);
                    }

                    //Mở sheet tiếp theo là điểm Sinh
                    sheetCanMo = wb.Sheets[4];
                    //Truy cập vùng dữ liệu sử dụng
                    range = sheetCanMo.UsedRange;
                    //Bắt đầu đọc dữ liệu
                    dong = range.Rows.Count;
                    for (int i = 2; i <= dong; i++)
                    {
                        LoaiDiemCuaTungMon diem15 = new LoaiDiemCuaTungMon("DSI15" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 2].Value.ToString()), "DSI" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem15);
                        LoaiDiemCuaTungMon diem45 = new LoaiDiemCuaTungMon("DSI45" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 3].Value.ToString()), "DSI" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem45);
                        LoaiDiemCuaTungMon diemHK = new LoaiDiemCuaTungMon("DSIHK" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 4].Value.ToString()), "DSI" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diemHK);

                        Diem diemSI = new Diem();
                        diemSI.MaDiem = "DSI" + range.Cells[i, 1].Value.ToString().ToUpper();
                        diemSI.MaHSCuaDiemA = range.Cells[i, 1].Value.ToString().ToUpper();
                        diemSI.SoDiem = Math.Round((diem15.SoDiem + diem45.SoDiem * 2 + diemHK.SoDiem * 2) / 5, 2);
                        diems.Add(diemSI);
                    }

                    //Mở sheet tiếp theo là điểm Ngữ văn
                    sheetCanMo = wb.Sheets[5];
                    //Truy cập vùng dữ liệu sử dụng
                    range = sheetCanMo.UsedRange;
                    //Bắt đầu đọc dữ liệu
                    dong = range.Rows.Count;
                    for (int i = 2; i <= dong; i++)
                    {
                        LoaiDiemCuaTungMon diem15 = new LoaiDiemCuaTungMon("DVL15" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 2].Value.ToString()), "DVL" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem15);
                        LoaiDiemCuaTungMon diem45 = new LoaiDiemCuaTungMon("DVL45" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 3].Value.ToString()), "DVL" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem45);
                        LoaiDiemCuaTungMon diemHK = new LoaiDiemCuaTungMon("DVLHK" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 4].Value.ToString()), "DVL" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diemHK);

                        Diem diemVL = new Diem();
                        diemVL.MaDiem = "DVL" + range.Cells[i, 1].Value.ToString().ToUpper();
                        diemVL.MaHSCuaDiemA = range.Cells[i, 1].Value.ToString().ToUpper();
                        diemVL.SoDiem = Math.Round((diem15.SoDiem + diem45.SoDiem * 2 + diemHK.SoDiem * 2) / 5, 2);
                        diems.Add(diemVL);
                    }

                    //Mở sheet tiếp theo là điểm Hóa
                    sheetCanMo = wb.Sheets[6];
                    //Truy cập vùng dữ liệu sử dụng
                    range = sheetCanMo.UsedRange;
                    //Bắt đầu đọc dữ liệu
                    dong = range.Rows.Count;
                    for (int i = 2; i <= dong; i++)
                    {
                        LoaiDiemCuaTungMon diem15 = new LoaiDiemCuaTungMon("DHO15" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 2].Value.ToString()), "DHO" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem15);
                        LoaiDiemCuaTungMon diem45 = new LoaiDiemCuaTungMon("DHO45" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 3].Value.ToString()), "DHO" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem45);
                        LoaiDiemCuaTungMon diemHK = new LoaiDiemCuaTungMon("DHOHK" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 4].Value.ToString()), "DHO" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diemHK);

                        Diem diemHO = new Diem();
                        diemHO.MaDiem = "DHO" + range.Cells[i, 1].Value.ToString().ToUpper();
                        diemHO.MaHSCuaDiemA = range.Cells[i, 1].Value.ToString().ToUpper();
                        diemHO.SoDiem = Math.Round((diem15.SoDiem + diem45.SoDiem * 2 + diemHK.SoDiem * 2) / 5, 2);
                        diems.Add(diemHO);
                    }

                    //Mở sheet tiếp theo là điểm Sử
                    sheetCanMo = wb.Sheets[7];
                    //Truy cập vùng dữ liệu sử dụng
                    range = sheetCanMo.UsedRange;
                    //Bắt đầu đọc dữ liệu
                    dong = range.Rows.Count;
                    for (int i = 2; i <= dong; i++)
                    {
                        LoaiDiemCuaTungMon diem15 = new LoaiDiemCuaTungMon("DSU15" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 2].Value.ToString()), "DSU" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem15);
                        LoaiDiemCuaTungMon diem45 = new LoaiDiemCuaTungMon("DSU45" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 3].Value.ToString()), "DSU" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem45);
                        LoaiDiemCuaTungMon diemHK = new LoaiDiemCuaTungMon("DSUHK" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 4].Value.ToString()), "DSU" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diemHK);

                        Diem diemSU = new Diem();
                        diemSU.MaDiem = "DSU" + range.Cells[i, 1].Value.ToString().ToUpper();
                        diemSU.MaHSCuaDiemA = range.Cells[i, 1].Value.ToString().ToUpper();
                        diemSU.SoDiem = Math.Round((diem15.SoDiem + diem45.SoDiem * 2 + diemHK.SoDiem * 2) / 5, 2);
                        diems.Add(diemSU);
                    }

                    //Mở sheet tiếp theo là điểm Địa
                    sheetCanMo = wb.Sheets[8];
                    //Truy cập vùng dữ liệu sử dụng
                    range = sheetCanMo.UsedRange;
                    //Bắt đầu đọc dữ liệu
                    dong = range.Rows.Count;
                    for (int i = 2; i <= dong; i++)
                    {
                        LoaiDiemCuaTungMon diem15 = new LoaiDiemCuaTungMon("DDI15" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 2].Value.ToString()), "DDI" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem15);
                        LoaiDiemCuaTungMon diem45 = new LoaiDiemCuaTungMon("DDI45" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 3].Value.ToString()), "DDI" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem45);
                        LoaiDiemCuaTungMon diemHK = new LoaiDiemCuaTungMon("DDIHK" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 4].Value.ToString()), "DDI" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diemHK);

                        Diem diemDI = new Diem();
                        diemDI.MaDiem = "DDI" + range.Cells[i, 1].Value.ToString().ToUpper();
                        diemDI.MaHSCuaDiemA = range.Cells[i, 1].Value.ToString().ToUpper();
                        diemDI.SoDiem = Math.Round((diem15.SoDiem + diem45.SoDiem * 2 + diemHK.SoDiem * 2) / 5, 2);
                        diems.Add(diemDI);
                    }

                    //Mở sheet tiếp theo là điểm Ngoại ngữ
                    sheetCanMo = wb.Sheets[9];
                    //Truy cập vùng dữ liệu sử dụng
                    range = sheetCanMo.UsedRange;
                    //Bắt đầu đọc dữ liệu
                    dong = range.Rows.Count;
                    for (int i = 2; i <= dong; i++)
                    {
                        LoaiDiemCuaTungMon diem15 = new LoaiDiemCuaTungMon("DNN15" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 2].Value.ToString()), "DNN" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem15);
                        LoaiDiemCuaTungMon diem45 = new LoaiDiemCuaTungMon("DNN45" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 3].Value.ToString()), "DNN" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem45);
                        LoaiDiemCuaTungMon diemHK = new LoaiDiemCuaTungMon("DNNHK" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 4].Value.ToString()), "DNN" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diemHK);

                        Diem diemNN = new Diem();
                        diemNN.MaDiem = "DNN" + range.Cells[i, 1].Value.ToString().ToUpper();
                        diemNN.MaHSCuaDiemA = range.Cells[i, 1].Value.ToString().ToUpper();
                        diemNN.SoDiem = Math.Round((diem15.SoDiem + diem45.SoDiem * 2 + diemHK.SoDiem * 2) / 5, 2);
                        diems.Add(diemNN);
                    }

                    //Mở sheet tiếp theo là điểm Công dân
                    sheetCanMo = wb.Sheets[10];
                    //Truy cập vùng dữ liệu sử dụng
                    range = sheetCanMo.UsedRange;
                    //Bắt đầu đọc dữ liệu
                    dong = range.Rows.Count;
                    for (int i = 2; i <= dong; i++)
                    {
                        LoaiDiemCuaTungMon diem15 = new LoaiDiemCuaTungMon("DCD15" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 2].Value.ToString()), "DCD" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem15);
                        LoaiDiemCuaTungMon diem45 = new LoaiDiemCuaTungMon("DCD45" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 3].Value.ToString()), "DCD" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem45);
                        LoaiDiemCuaTungMon diemHK = new LoaiDiemCuaTungMon("DCDHK" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 4].Value.ToString()), "DCD" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diemHK);

                        Diem diemCD = new Diem();
                        diemCD.MaDiem = "DCD" + range.Cells[i, 1].Value.ToString().ToUpper();
                        diemCD.MaHSCuaDiemA = range.Cells[i, 1].Value.ToString().ToUpper();
                        diemCD.SoDiem = Math.Round((diem15.SoDiem + diem45.SoDiem * 2 + diemHK.SoDiem * 2) / 5, 2);
                        diems.Add(diemCD);
                    }

                    //Mở sheet tiếp theo là điểm Quốc phòng
                    sheetCanMo = wb.Sheets[11];
                    //Truy cập vùng dữ liệu sử dụng
                    range = sheetCanMo.UsedRange;
                    //Bắt đầu đọc dữ liệu
                    dong = range.Rows.Count;
                    for (int i = 2; i <= dong; i++)
                    {
                        LoaiDiemCuaTungMon diem15 = new LoaiDiemCuaTungMon("DQP15" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 2].Value.ToString()), "DQP" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem15);
                        LoaiDiemCuaTungMon diem45 = new LoaiDiemCuaTungMon("DQP45" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 3].Value.ToString()), "DQP" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem45);
                        LoaiDiemCuaTungMon diemHK = new LoaiDiemCuaTungMon("DQPHK" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 4].Value.ToString()), "DQP" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diemHK);

                        Diem diemQP = new Diem();
                        diemQP.MaDiem = "DQP" + range.Cells[i, 1].Value.ToString().ToUpper();
                        diemQP.MaHSCuaDiemA = range.Cells[i, 1].Value.ToString().ToUpper();
                        diemQP.SoDiem = Math.Round((diem15.SoDiem + diem45.SoDiem * 2 + diemHK.SoDiem * 2) / 5, 2);
                        diems.Add(diemQP);
                    }

                    //Mở sheet tiếp theo là điểm Thể dục
                    sheetCanMo = wb.Sheets[12];
                    //Truy cập vùng dữ liệu sử dụng
                    range = sheetCanMo.UsedRange;
                    //Bắt đầu đọc dữ liệu
                    dong = range.Rows.Count;
                    for (int i = 2; i <= dong; i++)
                    {
                        LoaiDiemCuaTungMon diem15 = new LoaiDiemCuaTungMon("DTD15" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 2].Value.ToString()), "DTD" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem15);
                        LoaiDiemCuaTungMon diem45 = new LoaiDiemCuaTungMon("DTD45" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 3].Value.ToString()), "DTD" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem45);
                        LoaiDiemCuaTungMon diemHK = new LoaiDiemCuaTungMon("DTDHK" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 4].Value.ToString()), "DTD" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diemHK);

                        Diem diemTD = new Diem();
                        diemTD.MaDiem = "DTD" + range.Cells[i, 1].Value.ToString().ToUpper();
                        diemTD.MaHSCuaDiemA = range.Cells[i, 1].Value.ToString().ToUpper();
                        diemTD.SoDiem = Math.Round((diem15.SoDiem + diem45.SoDiem * 2 + diemHK.SoDiem * 2) / 5, 2);
                        diems.Add(diemTD);
                    }

                    //Mở sheet tiếp theo là điểm Công nghệ
                    sheetCanMo = wb.Sheets[13];
                    //Truy cập vùng dữ liệu sử dụng
                    range = sheetCanMo.UsedRange;
                    //Bắt đầu đọc dữ liệu
                    dong = range.Rows.Count;
                    for (int i = 2; i <= dong; i++)
                    {
                        LoaiDiemCuaTungMon diem15 = new LoaiDiemCuaTungMon("DCN15" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 2].Value.ToString()), "DCN" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem15);
                        LoaiDiemCuaTungMon diem45 = new LoaiDiemCuaTungMon("DCN45" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 3].Value.ToString()), "DCN" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem45);
                        LoaiDiemCuaTungMon diemHK = new LoaiDiemCuaTungMon("DCNHK" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 4].Value.ToString()), "DCN" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diemHK);

                        Diem diemCN = new Diem();
                        diemCN.MaDiem = "DCN" + range.Cells[i, 1].Value.ToString().ToUpper();
                        diemCN.MaHSCuaDiemA = range.Cells[i, 1].Value.ToString().ToUpper();
                        diemCN.SoDiem = Math.Round((diem15.SoDiem + diem45.SoDiem * 2 + diemHK.SoDiem * 2) / 5, 2);
                        diems.Add(diemCN);
                    }

                    //Mở sheet tiếp theo là điểm Tin học
                    sheetCanMo = wb.Sheets[14];
                    //Truy cập vùng dữ liệu sử dụng
                    range = sheetCanMo.UsedRange;
                    //Bắt đầu đọc dữ liệu
                    dong = range.Rows.Count;
                    for (int i = 2; i <= dong; i++)
                    {
                        LoaiDiemCuaTungMon diem15 = new LoaiDiemCuaTungMon("DTH15" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 2].Value.ToString()), "DTH" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem15);
                        LoaiDiemCuaTungMon diem45 = new LoaiDiemCuaTungMon("DTH45" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 3].Value.ToString()), "DTH" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diem45);
                        LoaiDiemCuaTungMon diemHK = new LoaiDiemCuaTungMon("DTHHK" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 4].Value.ToString()), "DTH" + range.Cells[i, 1].Value.ToString().ToUpper());
                        loaiDiemCuaTungMons.Add(diemHK);

                        Diem diemTH = new Diem();
                        diemTH.MaDiem = "DTH" + range.Cells[i, 1].Value.ToString().ToUpper();
                        diemTH.MaHSCuaDiemA = range.Cells[i, 1].Value.ToString().ToUpper();
                        diemTH.SoDiem = Math.Round((diem15.SoDiem + diem45.SoDiem * 2 + diemHK.SoDiem * 2) / 5, 2);
                        diems.Add(diemTH);
                    }

                    //Chúng ta bắt đầu cập nhật ĐTB và Học lực cho từng học sinh 
                    foreach (var hocSinh in hocSinhs)
                    {
                        List<Diem> listDiemCuaHocSinh = new List<Diem>();
                        foreach (var diem in diems)
                        {
                            if (diem.MaHSCuaDiemA == hocSinh.MaSoHS)
                            {
                                listDiemCuaHocSinh.Add(diem);
                            }
                        }
                        //Các loại điểm để xét học lực
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
                        double diemTBHS = 0;
                        foreach (var item in listDiemCuaHocSinh)
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

                        diemTBHS = Math.Round((diemToan.SoDiem * 2 + diemNV.SoDiem * 2 + diemSinh.SoDiem + diemVatLy.SoDiem + diemHoa.SoDiem + diemSu.SoDiem + diemDia.SoDiem + diemNN.SoDiem + diemCD.SoDiem + diemQP.SoDiem + diemTD.SoDiem + diemCN.SoDiem + diemTH.SoDiem) / 15, 2);

                        //Cập nhật được điểm
                        hocSinh.DiemTBCuaHS = diemTBHS;

                        string hocLuc = "";
                        if (diemTBHS >= 8 && diemNV.SoDiem >= 8 && diemTH.SoDiem >= 6.5 && diemCN.SoDiem >= 6.5 && diemTD.SoDiem >= 6.5 && diemQP.SoDiem >= 6.5 && diemCD.SoDiem >= 6.5 && diemNN.SoDiem >= 6.5 && diemDia.SoDiem >= 6.5 && diemSu.SoDiem >= 6.5 && diemHoa.SoDiem >= 6.5 && diemToan.SoDiem >= 6.5 && diemSinh.SoDiem >= 6.5 && diemVatLy.SoDiem >= 6.5 || diemTBHS >= 8 && diemToan.SoDiem >= 8 && diemTH.SoDiem >= 6.5 && diemCN.SoDiem >= 6.5 && diemTD.SoDiem >= 6.5 && diemQP.SoDiem >= 6.5 && diemCD.SoDiem >= 6.5 && diemNN.SoDiem >= 6.5 && diemDia.SoDiem >= 6.5 && diemSu.SoDiem >= 6.5 && diemHoa.SoDiem >= 6.5 && diemNV.SoDiem >= 6.5 && diemSinh.SoDiem >= 6.5 && diemVatLy.SoDiem >= 6.5)
                        {
                            hocLuc = "Giỏi";
                        }
                        else if (diemTBHS >= 6.5 && diemNV.SoDiem >= 6.5 && diemTH.SoDiem >= 5 && diemCN.SoDiem >= 5 && diemTD.SoDiem >= 5 && diemQP.SoDiem >= 5 && diemCD.SoDiem >= 5 && diemNN.SoDiem >= 5 && diemDia.SoDiem >= 5 && diemSu.SoDiem >= 5 && diemHoa.SoDiem >= 5 && diemToan.SoDiem >= 5 && diemSinh.SoDiem >= 5 && diemVatLy.SoDiem >= 5 || diemTBHS >= 6.5 && diemToan.SoDiem >= 6.5 && diemTH.SoDiem >= 5 && diemCN.SoDiem >= 5 && diemTD.SoDiem >= 5 && diemQP.SoDiem >= 5 && diemCD.SoDiem >= 5 && diemNN.SoDiem >= 5 && diemDia.SoDiem >= 5 && diemSu.SoDiem >= 5 && diemHoa.SoDiem >= 5 && diemNV.SoDiem >= 5 && diemSinh.SoDiem >= 5 && diemVatLy.SoDiem >= 5)
                        {
                            hocLuc = "Khá";
                        }
                        else if (diemTBHS >= 5 && diemNV.SoDiem >= 5 && diemTH.SoDiem >= 3.5 && diemCN.SoDiem >= 3.5 && diemTD.SoDiem >= 3.5 && diemQP.SoDiem >= 3.5 && diemCD.SoDiem >= 3.5 && diemNN.SoDiem >= 3.5 && diemDia.SoDiem >= 3.5 && diemSu.SoDiem >= 3.5 && diemHoa.SoDiem >= 3.5 && diemToan.SoDiem >= 3.5 && diemSinh.SoDiem >= 3.5 && diemVatLy.SoDiem >= 3.5 || diemTBHS >= 5 && diemToan.SoDiem >= 5 && diemTH.SoDiem >= 3.5 && diemCN.SoDiem >= 3.5 && diemTD.SoDiem >= 3.5 && diemQP.SoDiem >= 3.5 && diemCD.SoDiem >= 3.5 && diemNN.SoDiem >= 3.5 && diemDia.SoDiem >= 3.5 && diemSu.SoDiem >= 3.5 && diemHoa.SoDiem >= 3.5 && diemNV.SoDiem >= 3.5 && diemSinh.SoDiem >= 3.5 && diemVatLy.SoDiem >= 3.5)
                        {
                            hocLuc = "Trung bình";
                        }
                        else if (diemTBHS >= 3.5 && diemNV.SoDiem >= 2 && diemTH.SoDiem >= 2 && diemCN.SoDiem >= 2 && diemTD.SoDiem >= 2 && diemQP.SoDiem >= 2 && diemCD.SoDiem >= 2 && diemNN.SoDiem >= 2 && diemDia.SoDiem >= 2 && diemSu.SoDiem >= 2 && diemHoa.SoDiem >= 2 && diemToan.SoDiem >= 2 && diemSinh.SoDiem >= 2 && diemVatLy.SoDiem >= 2 || diemTBHS >= 3.5 && diemToan.SoDiem >= 2 && diemTH.SoDiem >= 2 && diemCN.SoDiem >= 2 && diemTD.SoDiem >= 2 && diemQP.SoDiem >= 2 && diemCD.SoDiem >= 2 && diemNN.SoDiem >= 2 && diemDia.SoDiem >= 2 && diemSu.SoDiem >= 2 && diemHoa.SoDiem >= 2 && diemNV.SoDiem >= 2 && diemSinh.SoDiem >= 2 && diemVatLy.SoDiem >= 2)
                        {
                            hocLuc = "Yếu";
                        }
                        else
                        {
                            hocLuc = "Kém";
                        }

                        //Cập nhật được học lực
                        hocSinh.XLHocLuc = hocLuc;
                    }

                    //Giờ chúng ta thêm vào CSDL

                    //Thêm học sinh       
                    foreach (var hocSinh in hocSinhs)
                    {
                        //Kiểm tra xem mã của học sinh đó có sẵn trong CSDL chưa hoặc nằm trong lịch sử xóa

                        var hocSinhTrongCSDL = from hocSinhNao in db.THocSinhs
                                               where hocSinh.MaSoHS == hocSinhNao.MaSoHS
                                               select hocSinhNao;
                        List<HocSinh> coKhong = hocSinhTrongCSDL.ToList();
                        var hocSinhTrongLichSuXoa = from hocSinhNao in db.TLuuTruHSXoas
                                                    where hocSinh.MaSoHS == hocSinhNao.MaSoHSXoa
                                                    select hocSinhNao;
                        List<LuuTruHSXoa> coXoaKhong = hocSinhTrongLichSuXoa.ToList();
                        if (coKhong.Count == 0 && coXoaKhong.Count == 0)
                        {
                            db.THocSinhs.Add(hocSinh);
                            //Tìm các điểm của HS này
                            List<Diem> listDiemCuaHocSinh = new List<Diem>();
                            foreach (var diem in diems)
                            {
                                if (diem.MaHSCuaDiemA == hocSinh.MaSoHS)
                                {
                                    listDiemCuaHocSinh.Add(diem);
                                }
                            }
                            foreach (var diemCuaHSNay in listDiemCuaHocSinh)
                            {
                                db.TDiems.Add(diemCuaHSNay);
                            }

                            //Tìm các loại điểm của học sinh này
                            List<LoaiDiemCuaTungMon> listLoaiDiemTungMon = new List<LoaiDiemCuaTungMon>();
                            foreach (var loaiDiem in loaiDiemCuaTungMons)
                            {
                                if (loaiDiem.MaDiemCuaLoaiDiem.Substring(3).ToUpper() == hocSinh.MaSoHS.ToUpper())
                                {
                                    listLoaiDiemTungMon.Add(loaiDiem);
                                }
                            }
                            foreach (var loaiDiemHSNay in listLoaiDiemTungMon)
                            {
                                db.TLoaiDiemCuaTungMons.Add(loaiDiemHSNay);
                            }
                            db.SaveChanges();
                        }
                        else
                        {
                            if (MessageBox.Show("Học sinh" + " có mã số là: " + hocSinh.MaSoHS + " mà bạn định thêm vào đã có trong CSDL \nHoặc đã bị xóa \nNếu muốn khôi phục vui lòng liên hệ Admin \nNhấn OK để tiếp tục quá trình thêm học sinh. \nCancel để ngừng quá trình thêm học sinh.", "Thông báo!!!", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    MessageBox.Show("Hoàn thành!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Có lỗi xảy ra!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    app.Quit();
                    wb = null;
                }
            }

            ////Tìm môn giáo viên này dạy
            //var giaoViens = from ai in db.TGiaoViens
            //                where ai.MaGV == maGVTrongNay
            //                select ai;
            //List<GiaoVien> kiemMonGVNay = giaoViens.ToList();
            ////Tạo liên kết GV dạy HS
            //GiaoVienDayHocSinh lienKetMoi = new GiaoVienDayHocSinh(maGVTrongNay, lopCuaHSTrongNay, kiemMonGVNay[0].MonDay);
            //db.TGiaoVienDayHocSinhs.Add(lienKetMoi);
            //db.SaveChanges();

        }
    }
}
