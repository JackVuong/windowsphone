using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace MyMoney
{
    public partial class User : PhoneApplicationPage
    {
        public static string tenTK;
        public static string tienTK;
        public static bool kt = false;
        public User()
        {
            InitializeComponent();
            using (QLChiTieuContext c = new QLChiTieuContext(QLChiTieuContext.ConnectionString))
            {
                c.CreateIfNotExists();
                c.LogDebug = true;
                if (kt)
                {
                    kt = false;
                    GiaoDich gd = new GiaoDich();
                    gd.TenGD = "123";
                    gd.LoaiGD = "Tao";
                    gd.SoTien = 0;
                    gd.NgayGD = (DateTime)DateTime.Now;
                    gd.GhiChu = " ";
                    gd.Hinh = " ";
                    gd.TenTaiKhoan = tenTK;
                    gd.TienConLai = Int32.Parse(tienTK);
                    DatabaseAdd dadd = new DatabaseAdd();
                    dadd.AddGiaoDich(gd);
                }
                List<GiaoDich> lst = c.GiaoDich.ToList();
                tenTK = lst[lst.Count - 1].TenTaiKhoan;
                tienTK = lst[lst.Count - 1].TienConLai.ToString();
                double tienHomNay = 0;
                if (lst.Count > 1)
                {
                    for (int i = 1; i < lst.Count; i++)
                    {
                        if (lst[i].NgayGD.ToShortDateString().Equals(DateTime.Now.ToShortDateString()))
                        {
                            tienHomNay += Double.Parse(lst[i].SoTien.ToString());
                        }
                    }
                }
                txtTienHomNay.Text = tienHomNay.ToString() + " VND";
                txtTenTaiKhoan.Text = tenTK;
                txtTaiKhoan.Text = tienTK + " VND";
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Uri newPage = new Uri("/ThemGiaoDich.xaml", UriKind.Relative);
            NavigationService.Navigate(newPage);
        }

        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            Uri newPage2 = new Uri("/ThongKe.xaml", UriKind.Relative);
            NavigationService.Navigate(newPage2);
        }

        private void btnQLTK_Click(object sender, RoutedEventArgs e)
        {
            Uri newPage2 = new Uri("/QuanLyTaiKhoan.xaml", UriKind.Relative);
            NavigationService.Navigate(newPage2);
        }

        private void btnSoChiTieu_Click(object sender, RoutedEventArgs e)
        {
            Uri newPage2 = new Uri("/SoChiTieu.xaml", UriKind.Relative);
            NavigationService.Navigate(newPage2);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                QLChiTieuContext c = new QLChiTieuContext(QLChiTieuContext.ConnectionString);
                List<GiaoDich> lst = c.GiaoDich.ToList();
                if (lst.Count == 0)
                {
                    txtTaiKhoan.Text = tienTK.ToString() + " VND";
                }
                else
                {
                    txtTaiKhoan.Text = lst[lst.Count - 1].TienConLai.ToString() + " VND";
                }
                double tienHomNay = 0;
                string now = DateTime.Now.ToShortDateString();
                for (int i = 1; i < lst.Count; i++ )
                {
                    if (lst[i].NgayGD.ToShortDateString().Equals(DateTime.Now.ToShortDateString()))
                    {
                        tienHomNay += Double.Parse(lst[i].SoTien.ToString());
                    }
                }
                txtTienHomNay.Text = tienHomNay.ToString() + " VND";
            }
        }
    }
}