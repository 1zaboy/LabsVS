using System;
using System.Windows;
using System.Windows.Controls;

namespace Lab2
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
            var p = Convert.ToDouble(this.val2.Text);
            double funValue = 0;
            switch (m_SelctedFun)
            {
                case "fun1":
                    funValue = 1;
                    break;
                case "fun2":
                    funValue = Math.Pow(x, 2);
                    break;
                case "fun3":
                    funValue = Math.Exp(x);
                    break;
                default: return;
            }

            var result = 0.0;
            if (x > p)
            {
                result = 2 * Math.Pow(funValue, 3) + 3 * Math.Pow(p, 2);
            }
            else if (3 < x && x < Math.Abs(p))
            {
                result = Math.Abs(funValue - p);
            }
            else if (x == p)
            {
                result = Math.Pow(funValue - p, 2);
            }

            res.Text = result.ToString();
        }
        private string m_SelctedFun;

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            m_SelctedFun = radioButton.Name;
        }
    }
}
