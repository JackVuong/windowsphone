using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MyMoney.Resources;

namespace MyMoney
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            checkNameImg.Opacity = 0;
            checkMoneyImg.Opacity = 0;
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
            
        }

        private void newAccount_Click(object sender, RoutedEventArgs e)
        {
            int tien;
            bool b = Int32.TryParse(txtSoTien.Text, out tien);
            if (txtUserName.Text.Length ==0)
            {
                checkNameImg.Opacity = 1;
                return;
            }
            if (txtSoTien.Text.Length == 0 || !b)
            {
                checkMoneyImg.Opacity = 1;
                return;
            }
            App.settings.Add("isFirstTime", 1000);
            User.tenTK = txtUserName.Text;
            User.tienTK = txtSoTien.Text;
            User.kt = true;
            NavigationService.Navigate(new Uri("/User.xaml", UriKind.Relative));
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtUserName.Text.Length == 0)
            {
                checkNameImg.Opacity = 1;
            }
            else
            {
                checkNameImg.Opacity = 0;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
            }
        }
        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}