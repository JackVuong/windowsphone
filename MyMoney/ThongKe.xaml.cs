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
    public partial class ThongKe : PhoneApplicationPage
    {
        public ThongKe()
        {
            InitializeComponent();
        }

        private void btnHomNay_Click(object sender, RoutedEventArgs e)
        {
            Uri newPage = new Uri("/ThongKeNgay.xaml", UriKind.Relative);
            NavigationService.Navigate(newPage);
        }

        private void btnThang_Click(object sender, RoutedEventArgs e)
        {
            Uri newPage = new Uri("/ThongKeThang.xaml", UriKind.Relative);
            NavigationService.Navigate(newPage);
        }

        private void btnNam_Click(object sender, RoutedEventArgs e)
        {
            Uri newPage = new Uri("/ThongKeNam.xaml", UriKind.Relative);
            NavigationService.Navigate(newPage);
        }
    }
}