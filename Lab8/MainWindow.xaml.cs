using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<EditPoly> EditPolies { get; set; }
        public ObservableCollection<EditPolyValue> EditPoliesValue { get; set; }
        public SeriesCollection SeriesCollection { get; set; }
        public double[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            EditPolies = new List<EditPoly>
            {
                new EditPoly{ Title = "Start X:" },
                new EditPoly{ Title = "Finish X:" },
                new EditPoly{ Title = "Y: " },
                new EditPoly{ Title = "Z:" },
                new EditPoly{ Title = "H (Steps): " },
            };
            SeriesCollection = new SeriesCollection();
            EditPoliesValue = new ObservableCollection<EditPolyValue>();
            Labels = new[] { 1.0, 2.0, 2.0 };
            YFormatter = value => value.ToString();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var listValue = CalcFun(EditPolies[0].Text, EditPolies[2].Text, EditPolies[3].Text, EditPolies[4].Text, EditPolies[1].Text);

            SeriesCollection.Add(new LineSeries
            {
                Title = string.Format("Calc {0}", SeriesCollection.Count + 1),
                Values = new ChartValues<double>(listValue)
            });

            listValue.Select((x, index) =>
            {
                var r = new EditPolyValue
                {
                    Title = string.Format("Value {0}", index),
                    Text = x
                };
                r.PropertyChanged += check;
                EditPoliesValue.Add(r);
                return r;
            }).ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SeriesCollection.Clear();
        }

        private void check(object sender, PropertyChangedEventArgs e)
        {
            SeriesCollection.RemoveAt(SeriesCollection.Count - 1);
            SeriesCollection.Add(new LineSeries
            {
                Title = string.Format("Calc {0}", SeriesCollection.Count + 1),
                Values = new ChartValues<double>(EditPoliesValue.Select(x => x.Text))
            });
        }

        private double Fun(double x, double y, double z)
        {
            var f1 = Math.Abs(Math.Pow(x, y / x) - Math.Pow(y / x, 1.0 / 3));
            var f2 = (y - x) * ((Math.Cos(y) - (z / (y - x)) / 1 + Math.Pow(y - x, 2)));
            return f1 + f2;
        }

        private List<double> CalcFun(double x, double y, double z, double h, double finish)
        {
            var res = new List<double>();
            for (double i = x; i < finish; i += h)
                res.Add(Fun(i, y, z));

            var r = res.Where(x => !(double.IsNaN(x) || double.IsInfinity(x) || double.IsNegativeInfinity(x) || double.IsPositiveInfinity(x)));

            var max = r.Max();
            var min = r.Min();

            var res1 = new List<double>();
            foreach (var item in res)
            {
                if (double.IsNaN(item))
                    res1.Add(0);
                else if (double.IsInfinity(item))
                    res1.Add(max * 3);
                else if (double.IsPositiveInfinity(item))
                    res1.Add(max * 3);
                else if (double.IsNegativeInfinity(item))
                    res1.Add(min * 3);
                else
                    res1.Add(item);
            }
            return res1;
        }
    }
    public class EditPolyValue : VM
    {
        public string Title { get; set; }
        private double m_Value;
        public double Text
        {
            get { return m_Value; }
            set
            {
                m_Value = value;
                OnPropertyChanged();
            }
        }
    }
    public class EditPoly : VM
    {
        public string Title { get; set; }
        private double m_Value;
        public double Text
        {
            get { return m_Value; }
            set
            {
                m_Value = value;
                OnPropertyChanged();
            }
        }
    }
    public class VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
