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
    public class LineData
    {
        public string Category { get; set; }
        public double Line1 { get; set; }
        public double Line2 { get; set; }
    }

    public partial class ThongKeNam : PhoneApplicationPage
    {
        public ThongKeNam()
        {
            InitializeComponent();
            using (QLChiTieuContext c = new QLChiTieuContext(QLChiTieuContext.ConnectionString))
            {
                c.CreateIfNotExists();
                c.LogDebug = true;
                List<GiaoDich> lst = c.GiaoDich.ToList();
                List<GiaoDich> list = new List<GiaoDich>();
                decimal tongThu = 0;
                decimal tongChi = 0;
                for (int i = lst.Count - 1; i >= 1; i--)
                {
                    if (lst[i].NgayGD.Year.Equals(DateTime.Now.Year))
                    {
                        if (lst[i].LoaiGD.Equals("Thu"))
                        {
                            tongThu += lst[i].SoTien;
                        }
                        else
                        {
                            tongChi += lst[i].SoTien;
                        }
                        list.Add(lst[i]);
                    }
                }
                txtTongThu.Text = tongThu.ToString() + " VND";
                txtTongChi.Text = tongChi.ToString() + " VND";

                double tongThuThang1 = 0;
                double tongChiThang1 = 0;
                double tongThuThang2 = 0;
                double tongChiThang2 = 0;
                double tongThuThang3 = 0;
                double tongChiThang3 = 0;
                double tongThuThang4 = 0;
                double tongChiThang4 = 0;
                double tongThuThang5 = 0;
                double tongChiThang5 = 0;
                double tongThuThang6 = 0;
                double tongChiThang6 = 0;
                double tongThuThang7 = 0;
                double tongChiThang7 = 0;
                double tongThuThang8 = 0;
                double tongChiThang8 = 0;
                double tongThuThang9 = 0;
                double tongChiThang9 = 0;
                double tongThuThang10 = 0;
                double tongChiThang10 = 0;
                double tongThuThang11 = 0;
                double tongChiThang11 = 0;
                double tongThuThang12 = 0;
                double tongChiThang12 = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    int thang = 0;
                    thang = Int32.Parse(list[i].NgayGD.Month.ToString());
                    switch (thang)
                    {
                        case 1:
                            if (list[i].LoaiGD.Equals("Thu"))
                            {
                                tongThuThang1 += (Double)list[i].SoTien;
                            }
                            else
                            {
                                tongChiThang1 += (Double)list[i].SoTien;
                            }
                            break;
                        case 2:
                            if (list[i].LoaiGD.Equals("Thu"))
                            {
                                tongThuThang2 += (Double)list[i].SoTien;
                            }
                            else
                            {
                                tongChiThang2 += (Double)list[i].SoTien;
                            }
                            break;
                        case 3:
                            if (list[i].LoaiGD.Equals("Thu"))
                            {
                                tongThuThang3 += (Double)list[i].SoTien;
                            }
                            else
                            {
                                tongChiThang3 += (Double)list[i].SoTien;
                            }
                            break;
                        case 4:
                            if (list[i].LoaiGD.Equals("Thu"))
                            {
                                tongThuThang4 += (Double)list[i].SoTien;
                            }
                            else
                            {
                                tongChiThang4 += (Double)list[i].SoTien;
                            }
                            break;
                        case 5:
                            if (list[i].LoaiGD.Equals("Thu"))
                            {
                                tongThuThang5 += (Double)list[i].SoTien;
                            }
                            else
                            {
                                tongChiThang5 += (Double)list[i].SoTien;
                            }
                            break;
                        case 6:
                            if (list[i].LoaiGD.Equals("Thu"))
                            {
                                tongThuThang6 += (Double)list[i].SoTien;
                            }
                            else
                            {
                                tongChiThang6 += (Double)list[i].SoTien;
                            }
                            break;
                        case 7:
                            if (list[i].LoaiGD.Equals("Thu"))
                            {
                                tongThuThang7 += (Double)list[i].SoTien;
                            }
                            else
                            {
                                tongChiThang7 += (Double)list[i].SoTien;
                            }
                            break;
                        case 8:
                            if (list[i].LoaiGD.Equals("Thu"))
                            {
                                tongThuThang8 += (Double)list[i].SoTien;
                            }
                            else
                            {
                                tongChiThang8 += (Double)list[i].SoTien;
                            }
                            break;
                        case 9:
                            if (list[i].LoaiGD.Equals("Thu"))
                            {
                                tongThuThang9 += (Double)list[i].SoTien;
                            }
                            else
                            {
                                tongChiThang9 += (Double)list[i].SoTien;
                            }
                            break;
                        case 10:
                            if (list[i].LoaiGD.Equals("Thu"))
                            {
                                tongThuThang10 += (Double)list[i].SoTien;
                            }
                            else
                            {
                                tongChiThang10 += (Double)list[i].SoTien;
                            }
                            break;
                        case 11:
                            if (list[i].LoaiGD.Equals("Thu"))
                            {
                                tongThuThang11 += (Double)list[i].SoTien;
                            }
                            else
                            {
                                tongChiThang11 += (Double)list[i].SoTien;
                            }
                            break;
                        case 12:
                            if (list[i].LoaiGD.Equals("Thu"))
                            {
                                tongThuThang12 += (Double)list[i].SoTien;
                            }
                            else
                            {
                                tongChiThang12 += (Double)list[i].SoTien;
                            }
                            break;

                    }

                }
                ObservableCollection<LineData> LineChart = new ObservableCollection<LineData>() 
                { 
                    new LineData{ Category = "1", Line1 = -tongChiThang1,Line2 = tongThuThang1 },
                    new LineData{ Category = "2", Line1 = -tongChiThang2,Line2 = tongThuThang2 },
                    new LineData{ Category = "3", Line1 = -tongChiThang3,Line2 = tongThuThang3 },
                    new LineData{ Category = "4", Line1 = -tongChiThang4,Line2 = tongThuThang4 },
                    new LineData{ Category = "5", Line1 = -tongChiThang5,Line2 = tongThuThang5 },
                    new LineData{ Category = "6", Line1 = -tongChiThang6,Line2 = tongThuThang6 },
                    new LineData{ Category = "7", Line1 = -tongChiThang7,Line2 = tongThuThang7 },
                    new LineData{ Category = "8", Line1 = -tongChiThang8,Line2 = tongThuThang8 },
                    new LineData{ Category = "9", Line1 = -tongChiThang9,Line2 = tongThuThang9 },
                    new LineData{ Category = "10", Line1 = -tongChiThang10,Line2 = tongThuThang10 },
                    new LineData{ Category = "11", Line1 = -tongChiThang11,Line2 = tongThuThang11 },
                    new LineData{ Category = "12", Line1 = -tongChiThang12,Line2 = tongThuThang12 },
                };
                this.LineChart.DataSource = LineChart;
            }
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/User.xaml", UriKind.Relative));
        }
    }
}