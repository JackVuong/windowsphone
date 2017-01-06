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
    public partial class ThongKeHomNay : PhoneApplicationPage
    {
        public ThongKeHomNay()
        {
            InitializeComponent();
            using (QLChiTieuContext c = new QLChiTieuContext(QLChiTieuContext.ConnectionString))
            {
                c.CreateIfNotExists();
                c.LogDebug = true;
                List<GiaoDich> lst = c.GiaoDich.ToList();
                List<ChartData> list = new List<ChartData>();
                decimal tongThu = 0;
                decimal tongChi = 0;
                for (int i = lst.Count - 1; i >= 1; i--)
                {
                    if (lst[i].NgayGD.ToShortDateString().Equals(DateTime.Now.ToShortDateString()))
                    {
                        if (lst[i].LoaiGD.Equals("Thu"))
                        {
                            tongThu += lst[i].SoTien;
                        }
                        else
                        {
                            list.Add(new ChartData() { Name = lst[i].TenGD, Value = (Double)(-lst[i].SoTien) });
                            tongChi += lst[i].SoTien;
                        }
                        //list.Add(lst[i]);
                    }
                }
                //listGiaoDich.ItemsSource = list;
                txtTongThu.Text = tongThu.ToString() + " VND";
                txtTongChi.Text = (-tongChi).ToString() + " VND";
                Pie.DataSource = list;
                List<ChartData> list2 = new List<ChartData>();
                list2.Add(new ChartData() { Name = "Còn lại", Value = (Double)(lst[lst.Count-1].TienConLai) });
                list2.Add(new ChartData() { Name = "Đã chi", Value = (Double)(-tongChi) });
                Pie2.DataSource = list2;

            }
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/User.xaml", UriKind.Relative));
        }
    }
}