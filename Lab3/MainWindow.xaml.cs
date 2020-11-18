using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using System.Windows.Xps.Packaging;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private double Step(double s, double e, double n)
        {
            return (e - s) / n;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var value1 = Convert.ToDouble(val1.Text);
            var value2 = Convert.ToDouble(val2.Text);
            var value3 = Convert.ToDouble(val3.Text);
            List<MyData> res = new List<MyData>();
            var i = 0;

            double oldValue = 0;
            for (var x = value1; x < value2; x += Step(value1, value2, value3))
            {
                oldValue += S(x, i);

                string str = "S:" + oldValue + "\t";
                str += "Y: " + ((Math.Pow(x, 2) / 4) + (x / 2) + 1) * Math.Exp(x / 2);
                res.Add(new MyData() { Title = str });
                i += 1;
            }
            icTodoList.ItemsSource = res;
        }

        private double S(double value, int index)
        {
            if (index == 0)
            {
                return (value * (Math.Pow(value, 3) / 3));
            }

            return Math.Pow(-1, index) * (Math.Pow(value, 2 * index + 1) / 2 * index + 1);
        }
    }
    public class MyData
    {
        public string Title { get; set; }
    }
}
