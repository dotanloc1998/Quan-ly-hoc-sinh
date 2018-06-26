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
    /// Interaction logic for ChonLoaiXemAdmin.xaml
    /// </summary>
    public partial class ChonLoaiXemAdmin : Window
    {
        private bool suaHayXoa = true;
        private bool clicked = false;
        public ChonLoaiXemAdmin()
        {
            InitializeComponent();
            cbLoaiXem.SelectedIndex = 0;
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
            if (cbLoaiXem.Text == "Sửa")
            {
                suaHayXoa = true;
            }
            else
            {
                suaHayXoa = false;
            }
            clicked = true;
            Close();
        }

        public bool IsSua()
        {
            return suaHayXoa;
        }
        public bool IsClicked()
        {
            return clicked;
        }
    }
}
