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
    public partial class SoChiTIeu : PhoneApplicationPage
    {
        public SoChiTIeu()
        {
            InitializeComponent();
            using (QLChiTieuContext c = new QLChiTieuContext(QLChiTieuContext.ConnectionString))
            {
                c.CreateIfNotExists();
                c.LogDebug = true;
                List<GiaoDich> lst = c.GiaoDich.ToList();
                //if (lst.Count == 0)
                //{
                //    listGiaoDich = null;
                //    return;
                //}
                List<GiaoDich> list = new List<GiaoDich>();
                for (int i = lst.Count - 1; i >= 1; i--)
                {
                    list.Add(lst[i]);
                }
                listGiaoDich.ItemsSource = list;

            }
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/User.xaml", UriKind.Relative));
        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/User.xaml", UriKind.Relative));
        }

        private void listGiaoDich_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            SuaXoaGD.gd = listGiaoDich.SelectedItem as GiaoDich;
            NavigationService.Navigate(new Uri("/SuaXoaGD.xaml", UriKind.Relative));
        }
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    if (e.NavigationMode == NavigationMode.Back)
        //    {
        //        NavigationService.Navigate(new Uri("/User.xaml", UriKind.Relative));
        //    }
        //}
    }
}