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
    /// Interaction logic for ChonLoaiIn.xaml
    /// </summary>
    public partial class ChonLop : Window
    {
        public static string maGVTrongNay;
        public static string monDayTrongNay;
        public ChonLop(string maGV, string monGVDay)
        {
            InitializeComponent();
            maGVTrongNay = maGV;
            monDayTrongNay = monGVDay;
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

        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            if (tbLop.Text != "" && tbLop.Text.Substring(0, 3).ToUpper() == "10A" || tbLop.Text != "" && tbLop.Text.Length > 4 || tbLop.Text != "" && tbLop.Text.Length < 5 || tbLop.Text != "" && tbLop.Text.Substring(0, 3).ToUpper() == "11A" || tbLop.Text != "" && tbLop.Text.Substring(0, 3).ToUpper() == "12A")
            {
                //Kiếm các lớp có trong CSDL
                MyEntity db = new MyEntity();
                var lops = (from lopNao in db.THocSinhs
                            select lopNao.LopCuaHS).Distinct();
                List<string> dslops = lops.ToList();
                bool chuaCoTrongCSDL = true;

                foreach (var lop in dslops)
                {
                    if (tbLop.Text.ToUpper() == lop.ToUpper())
                    {
                        chuaCoTrongCSDL = false;
                        //Kiểm tra xem lớp đó đã có giáo viên nào dạy môn này chưa?
                        var kiemTra = (from coChua in db.TGiaoVienDayHocSinhs
                                       where coChua.MaLopCuaSV == tbLop.Text.ToUpper()
                                       select coChua.MonMaLopDuocDay).Distinct();
                        List<string> cacMonDuocDay = kiemTra.ToList();
                        bool chuaCoAiDay = true;

                        if (cacMonDuocDay.Count!=0)
                        {
                            foreach (var mon in cacMonDuocDay)
                            {
                                if (monDayTrongNay == mon)
                                {
                                    chuaCoAiDay = false;
                                    break;
                                }
                            }
                            if (chuaCoAiDay)
                            {
                                GiaoVienDayHocSinh a = new GiaoVienDayHocSinh(maGVTrongNay, tbLop.Text.ToUpper(), monDayTrongNay);
                                db.TGiaoVienDayHocSinhs.Add(a);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Lớp này đã có giáo viên dạy môn: " + monDayTrongNay, "Thông báo!!!", MessageBoxButton.OK, MessageBoxImage.Information);
                                break;
                            }
                        }
                        else
                        {
                            chuaCoTrongCSDL = false;
                            GiaoVienDayHocSinh a = new GiaoVienDayHocSinh(maGVTrongNay, tbLop.Text.ToUpper(), monDayTrongNay);
                            db.TGiaoVienDayHocSinhs.Add(a);
                        }
                        
                    }
                }
                //Chưa có trong CSDL thì cho người dùng tùy chọn thêm hoặc không
                if (chuaCoTrongCSDL)
                {
                    if (MessageBox.Show("Vẫn chưa có lớp đó trong CSDL bạn muốn nhập file?", "Thông báo!!!", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
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

                        if (openFileDialog.FileName != "")
                        {
                            //Tạo đối tượng Excel 
                            Excel.Application app = new Excel.Application();
                            //Mở file Excel Học Sinh
                            Excel.Workbook wb = app.Workbooks.Open(openFileDialog.FileName);
                            //Mở sheet đầu tiên là sheet thông tin học sinh
                            try
                            {
                                //Trong này chỉ số đầu tiên bắt đầu từ 1
                                Excel._Worksheet sheetCanMo = wb.Sheets[1];
                                //Truy cập vùng dữ liệu sử dụng
                                Excel.Range range = sheetCanMo.UsedRange;
                                //Bắt đầu đọc dữ liệu
                                int dong = range.Rows.Count;
                                //Chúng ta bắt đầu đọc dữ liệu từ dòng 2 vì dòng 1 là tiêu đề
                                for (int i = 2; i <= dong; i++)
                                {
                                    HocSinh a = new HocSinh(range.Cells[i, 1].Value.ToString().ToUpper(), range.Cells[i, 2].Value.ToString(), range.Cells[i, 3].Value, range.Cells[i, 4].Value.ToString(), range.Cells[i, 5].Value.ToString(), range.Cells[i, 6].Value.ToString(), tbLop.Text);
                                    //Còn thiếu điểm TB và học lực
                                    hocSinhs.Add(a);
                                }

                                //Tiếp theo kiểm tra mã của môn giáo viên này dạy
                                var mons = from monNao in db.TMonHocs
                                           where monNao.TenMH == monDayTrongNay
                                           select monNao.MaMH;
                                List<string> monTimDC = mons.ToList();
                                string maMonDay = monTimDC[0];

                                //Mở sheet tiếp theo là điểm Môn giáo viên này dạy
                                sheetCanMo = wb.Sheets[2];
                                //Truy cập vùng dữ liệu sử dụng
                                range = sheetCanMo.UsedRange;
                                //Bắt đầu đọc dữ liệu
                                dong = range.Rows.Count;
                                for (int i = 2; i <= dong; i++)
                                {
                                    //Ta có được các loại điểm của 1 học sinh
                                    LoaiDiemCuaTungMon diem15 = new LoaiDiemCuaTungMon("D" + maMonDay + "15" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 2].Value.ToString()), "D" + maMonDay + range.Cells[i, 1].Value.ToString().ToUpper());
                                    loaiDiemCuaTungMons.Add(diem15);
                                    LoaiDiemCuaTungMon diem45 = new LoaiDiemCuaTungMon("D" + maMonDay + "45" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 3].Value.ToString()), "D" + maMonDay + range.Cells[i, 1].Value.ToString().ToUpper());
                                    loaiDiemCuaTungMons.Add(diem45);
                                    LoaiDiemCuaTungMon diemHK = new LoaiDiemCuaTungMon("D" + maMonDay + "HK" + range.Cells[i, 1].Value.ToString().ToUpper(), double.Parse(range.Cells[i, 4].Value.ToString()), "D" + maMonDay + range.Cells[i, 1].Value.ToString().ToUpper());
                                    loaiDiemCuaTungMons.Add(diemHK);

                                    //Ta có được điểm trung bình của loại điểm đó
                                    Diem diemMH = new Diem();
                                    diemMH.MaDiem = "D" + maMonDay + range.Cells[i, 1].Value.ToString().ToUpper();
                                    diemMH.MaHSCuaDiemA = range.Cells[i, 1].Value.ToString().ToUpper();
                                    diemMH.SoDiem = Math.Round((diem15.SoDiem + diem45.SoDiem * 2 + diemHK.SoDiem * 2) / 5, 2);
                                    diems.Add(diemMH);
                                }

                                //Thêm vào CSDL
                                foreach (var hocSinh in hocSinhs)
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
                                MessageBox.Show("Thêm thành công!", "Thông báo!!!", MessageBoxButton.OK, MessageBoxImage.Information);
                                GiaoVienDayHocSinh lienKetMoi = new GiaoVienDayHocSinh(maGVTrongNay, tbLop.Text.ToUpper(), monDayTrongNay);
                                db.TGiaoVienDayHocSinhs.Add(lienKetMoi);
                                db.SaveChanges();
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

                    }
                }
                db.SaveChanges();
                Close();
            }
            else
            {
                if (MessageBox.Show("Mã lớp không hợp lệ!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
                {
                    tbLop.Text = "";
                    tbLop.Focus();
                }
            }

        }
    }
}
