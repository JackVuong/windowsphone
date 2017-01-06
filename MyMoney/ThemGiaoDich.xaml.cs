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
    
    public partial class ThemGiaoDich : PhoneApplicationPage
    {
        public ThemGiaoDich()
        {
            InitializeComponent();
        }

        private void btnChi_Click(object sender, RoutedEventArgs e)
        {
            
           NavigationService.Navigate(new Uri("/Chi.xaml",UriKind.Relative));
        }

        private void btnThu_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new Uri("/Thu.xaml",UriKind.Relative));
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/User.xaml", UriKind.Relative));
        }
    }
}