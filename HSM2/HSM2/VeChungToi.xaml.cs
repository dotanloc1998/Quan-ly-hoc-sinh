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
    /// Interaction logic for VeChungToi.xaml
    /// </summary>
    public partial class VeChungToi : UserControl
    {
        public VeChungToi()
        {
            InitializeComponent();
            MyEntity db = new MyEntity();
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
        }
    }
}
