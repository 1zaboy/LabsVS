using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var x = Convert.ToDouble(this.val1.Text);
            var y = Convert.ToDouble(this.val2.Text);
            var z = Convert.ToDouble(this.val3.Text);
            var f1 = Math.Abs(Math.Pow(x, y / x) - Math.Pow(y / x, 1.0 / 3));
            var f2 = (y - x) * ( (Math.Cos(y) - (z / (y - x)) / 1 + Math.Pow(y - x, 2)) );
            this.res.Text = Convert.ToString(f1 + f2);
        }
    }
}
