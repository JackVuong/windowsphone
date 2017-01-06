using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
namespace MyMoney
{
    public class ChartData
    {
        public string Name { get; set; }
        public Double Value { get; set; }
    }

    public partial class ThongKeThang : PhoneApplicationPage
    {
        public ThongKeThang()
        {
            InitializeComponent();
            using (QLChiTieuContext c = new QLChiTieuContext(QLChiTieuContext.ConnectionString))
            {
                c.CreateIfNotExists();
                c.LogDebug = true;
                List<GiaoDich> lst = c.GiaoDich.ToList();
                //List<GiaoDich> list = new List<GiaoDich>();
                Double tongThu = 0;
                Double tongChi = 0;
                for (int i = lst.Count - 1; i >= 1; i--)
                {
                    if (lst[i].NgayGD.Month.Equals(DateTime.Now.Month) && lst[i].NgayGD.Year.Equals(DateTime.Now.Year))
                    {
                        if (lst[i].LoaiGD.Equals("Thu"))
                        {
                            tongThu += (Double)lst[i].SoTien;
                        }
                        else
                        {
                            tongChi += (Double)lst[i].SoTien;
                        }
                        //list.Add(lst[i]);
                    }
                }
                //listGiaoDich.ItemsSource = list;
                txtTongThu.Text = tongThu.ToString() + " VND";
                txtTongChi.Text = (-tongChi).ToString() + " VND";
                ObservableCollection<ChartData> ChartWP8List = new ObservableCollection<ChartData>() 
                { 
                    new ChartData{ Name = "Tổng Thu", Value = tongThu },
                    new ChartData{ Name = "Tổng Chi", Value = -tongChi },
                };
                /*ChartWP8List.Add(new ChartData() { Name = "Tổng Thu", Value = tongThu });
                ChartWP8List.Add(new ChartData() { Name = "Tổng Chi", Value = -tongChi });*/
                this.BarChart.DataSource = ChartWP8List;
            }
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/User.xaml", UriKind.Relative));
        }
    }
}