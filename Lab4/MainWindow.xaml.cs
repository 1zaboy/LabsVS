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

namespace Lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int m_X;
        private int m_Y;
        private double[,] data;

        public MainWindow()
        {
            InitializeComponent();
        }
        private double FindMax(double[] arr)
        {
            double res = double.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (res < arr[i])
                    res = arr[i];
            }
            return res;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int ii = 0; ii < m_X; ii++)
                for (int i = 0; i < m_X - 1; i++)
                {
                    if (FindMax(data.GetRow(i)) > FindMax(data.GetRow(i + 1)))
                    {
                        for (int j = 0; j < m_Y; j++)
                        {
                            var item = data[i + 1, j];
                            data[i + 1, j] = data[i, j];
                            data[i, j] = item;
                        }
                    }
                }
            aaa.ItemsSource = data.AsTupleList();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            m_X = Convert.ToInt32(val1.Text);
            m_Y = Convert.ToInt32(val2.Text);

            var ran = new Random();
            data = new double[m_X, m_Y];
            for (int i = 0; i < m_X; i++)
            {
                for (int j = 0; j < m_Y; j++)
                {
                    data[i, j] = ran.Next(1, 100);
                }
            }
            aaa.ItemsSource = data.AsTupleList();
        }
    }
    public static class ArrayExtensions
    {
        public static T[] GetRow<T>(this T[,] data, int i)
        {
            return Enumerable.Range(0, data.GetLength(1)).Select(j => data[i, j]).ToArray();
        }
    }
    public static class DataGridExtensions
    {
        public static List<object> AsTupleList<T>(this T[,] matrix)
        {
            var col = matrix.GetLength(1);
            var result = new List<object>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                T[] values = new T[col];

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    values[j] = matrix[i, j];
                }

                result.Add(GetTuple(values));
            }

            return result;
        }
        private static object GetTuple<T>(params T[] values)
        {
            Type genericType = Type.GetType("System.Tuple`" + values.Length);
            Type[] typeArgs = values.Select(_ => typeof(T)).ToArray();
            Type specificType = genericType.MakeGenericType(typeArgs);
            object[] constructorArguments = values.Cast<object>().ToArray();
            return Activator.CreateInstance(specificType, constructorArguments);
        }

    }
}
