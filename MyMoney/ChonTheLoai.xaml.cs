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
    public partial class ChonTheLoai : PhoneApplicationPage
    {
        public static string hinh = "./img/question.jpg";
        public static string tenTheloai = "Chọn Thể Loại";
        public static int thuHayChi = 0; // Bằng 1 là Chi bằng 2 là Thu.
        public ChonTheLoai()
        {
            InitializeComponent();
            using (QLChiTieuContext c = new QLChiTieuContext(QLChiTieuContext.ConnectionString))
            {
                c.CreateIfNotExists();
                c.LogDebug = true;
                List<TheLoai> theLoai = c.TheLoai.ToList();
                List<TheLoai> theLoaiChi = new List<TheLoai>();
                List<TheLoai> theLoaiThu = new List<TheLoai>();
                for (int i = 0; i < 9; i++)
                {
                    theLoaiChi.Add(theLoai[i]);
                }
                theLoaiChi.Add(theLoai[12]);
                for (int i = 9; i < 13; i++)
                {
                    theLoaiThu.Add(theLoai[i]);
                }
                if (thuHayChi == 1)
                {
                    listTheLoai.ItemsSource = theLoaiChi;
                }
                else
                {
                    listTheLoai.ItemsSource = theLoaiThu;
                }
            }
        }

        private void StackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Image hinhanh;
            hinhanh = ((sender as StackPanel).FindName("imgTL") as Image);
            hinh = ((BitmapImage)hinhanh.Source).UriSource.ToString();
            tenTheloai = ((sender as StackPanel).FindName("txtTenTL") as TextBlock).Text;    
            NavigationService.GoBack();

        }
    }
}