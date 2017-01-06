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
    public partial class SuaXoaGD : PhoneApplicationPage
    {
        public static GiaoDich gd;
        public static int id;
        public static decimal tienCu;

        public SuaXoaGD()
        {
            InitializeComponent();
            id = gd.Id;
            txtTenGD.Text = gd.TenGD;
            txtCmt.Text = gd.GhiChu;
            if (gd.LoaiGD.Equals("Chi"))
            {
                txtSoTien.Text = (-gd.SoTien).ToString();
                tienCu = -gd.SoTien;
            }
            else
            {
                txtSoTien.Text = gd.SoTien.ToString();
                tienCu = -gd.SoTien;
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                btnTheLoai.Content = ChonTheLoai.tenTheloai;
                imgTheLoai.Source = new BitmapImage(new Uri(ChonTheLoai.hinh, UriKind.Relative));
            }
        }

        private void btnTheLoai_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ChonTheLoai.xaml", UriKind.Relative));
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/User.xaml", UriKind.Relative));
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn Có Muốn Xóa?", "Thông Báo", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                DatabaseDelete del = new DatabaseDelete();
                del.DelGiaoDich(id);
                DatabaseUpdate update = new DatabaseUpdate();
                List<GiaoDich> lstMoi;
                using (QLChiTieuContext c = new QLChiTieuContext(QLChiTieuContext.ConnectionString))
                {
                    c.CreateIfNotExists();
                    c.LogDebug = true;
                    lstMoi = c.GiaoDich.ToList();
                }
                GiaoDich giaodich = lstMoi[lstMoi.Count - 1];
                if (lstMoi.Count > 1)
                {
                    giaodich.TienConLai += tienCu;
                }
                update.UpdateGiaoDich(giaodich.Id, giaodich);
                for (int i = 1; i < lstMoi.Count - 1; i++)
                {
                    GiaoDich gdich = lstMoi[i];
                    gdich.TienConLai = giaodich.TienConLai;
                    update.UpdateGiaoDich(gdich.Id, gdich);
                }
                //List<GiaoDich> listmoi = new List<GiaoDich>();
                //for (int i = lstmoi.Count - 1; i >= 1; i--)
                //{
                //    listmoi.Add(lstmoi[i]);
                //}
                //listGiaoDich.ItemsSource = listmoi;
                NavigationService.Navigate(new Uri("/SoChiTIeu.xaml", UriKind.Relative));
            }
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            int tien;
            bool b = Int32.TryParse(txtSoTien.Text, out tien);
            if (txtSoTien.Text.Length == 0 || !b)
            {
                MessageBox.Show("Số tiền bạn nhập không hợp lệ, xin vui lòng nhập lại", "Thông Báo", MessageBoxButton.OK);
                return;
            }
            GiaoDich gdMoi = new GiaoDich();
            gdMoi.Id = id;
            if (gd.LoaiGD.Equals("Chi"))
            {
                gdMoi.SoTien = -Decimal.Parse(txtSoTien.Text);
            }
            else
            {
                gdMoi.SoTien = Decimal.Parse(txtSoTien.Text);
            }
            if (ChonTheLoai.hinh.Equals("question.jpg"))
            {
                gdMoi.Hinh = gd.Hinh;
            }
            else
            {
                gdMoi.Hinh = ChonTheLoai.hinh;
            }
            gdMoi.TenGD = txtTenGD.Text;
            gdMoi.GhiChu = txtCmt.Text;
            gdMoi.NgayGD = (DateTime)datimepicker.Value;
            gdMoi.TenTaiKhoan = User.tenTK;
            gdMoi.LoaiGD = gd.LoaiGD;
            gdMoi.TienConLai = gd.TienConLai - tienCu + gdMoi.SoTien;
            DatabaseUpdate update = new DatabaseUpdate();
            update.UpdateGiaoDich(gdMoi.Id, gdMoi);
            List<GiaoDich> lstmoi;
            using (QLChiTieuContext c = new QLChiTieuContext(QLChiTieuContext.ConnectionString))
            {
                c.CreateIfNotExists();
                c.LogDebug = true;
                lstmoi = c.GiaoDich.ToList();
            }
            GiaoDich gdCuoi = lstmoi[lstmoi.Count - 1];
            if (lstmoi.Count > 1)
            {
                gdCuoi.TienConLai = gdCuoi.TienConLai + tienCu + gdMoi.SoTien;
            }
            for (int i = 1; i < lstmoi.Count; i++)
            {
                GiaoDich gdich = lstmoi[i];
                gdich.TienConLai = gdCuoi.TienConLai;
                update.UpdateGiaoDich(gdich.Id, gdich);
            }

            NavigationService.Navigate(new Uri("/SoChiTIeu.xaml", UriKind.Relative));
        }
    }
}