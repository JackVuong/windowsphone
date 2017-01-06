using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;

namespace MyMoney
{
    public partial class Chi : PhoneApplicationPage
    {
        public Chi()
        {
            InitializeComponent();
            ChonTheLoai.thuHayChi = 1;
        }



        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            double tienConLai = 0;
            List<GiaoDich> lst;
            using (QLChiTieuContext c = new QLChiTieuContext(QLChiTieuContext.ConnectionString))
            {
                c.CreateIfNotExists();
                c.LogDebug = true;
                lst = c.GiaoDich.ToList();
            }
            tienConLai = Double.Parse(lst[lst.Count - 1].TienConLai.ToString());
            GiaoDich gd = new GiaoDich();
            gd.TenGD = txtTenGD.Text;
            gd.LoaiGD = "Chi";
            int tien;
            bool b = Int32.TryParse(txtSoTien.Text, out tien);
            if (txtSoTien.Text.Length == 0 || !b)
            {
                MessageBox.Show("Số tiền bạn nhập không hợp lệ, xin vui lòng nhập lại", "Thông Báo", MessageBoxButton.OK);
                return;
            }
            gd.SoTien = -tien;
            gd.NgayGD = (DateTime)datimepicker.Value;
            gd.GhiChu = txtCmt.Text;
            gd.Hinh = ChonTheLoai.hinh;
            gd.TenTaiKhoan = User.tenTK;
            gd.TienConLai = Decimal.Parse(tienConLai.ToString()) + gd.SoTien;
            DatabaseAdd dadd = new DatabaseAdd();
            dadd.AddGiaoDich(gd);
            if (MessageBox.Show("Thêm Thành Công! Bạn Có Muốn Tiếp Tục", "Thông Báo", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                txtTenGD.Text = "";
                txtCmt.Text = "";
                txtSoTien.Text = "";
                btnTheLoai.Content = "Chọn Thể Loại";
                imgTheLoai.Source = new BitmapImage(new Uri("./img/question.jpg", UriKind.Relative));
            }
            else
            {
                NavigationService.Navigate(new Uri("/User.xaml", UriKind.Relative));
            }
        }

        private void btnTheLoai_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ChonTheLoai.xaml", UriKind.Relative));
        }

        private void btnTheLoai_LostFocus(object sender, RoutedEventArgs e)
        {
            
            //imgTheLoai.Source = new BitmapImage(new Uri(ChonTheLoai.hinh));
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                btnTheLoai.Content = ChonTheLoai.tenTheloai;
                imgTheLoai.Source = new BitmapImage(new Uri(ChonTheLoai.hinh, UriKind.Relative));
            }
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/User.xaml", UriKind.Relative));
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ThemGiaoDich.xaml", UriKind.Relative));
        }
    }
}