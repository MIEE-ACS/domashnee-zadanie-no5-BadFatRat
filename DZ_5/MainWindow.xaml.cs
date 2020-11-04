using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace DZ_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Counter counter = new Counter();
        public MainWindow()
        {
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            Grid1.Visibility = Visibility.Hidden;
            Grid2.Visibility = Visibility.Visible;
        }

        private void Btn1_Click(object sender, RoutedEventArgs e) // начало работы
        {
            Grid1.Visibility = Visibility.Visible;
            Grid2.Visibility = Visibility.Hidden;
            lowerLimit.Text = counter.Min.ToString();
            upperLimit.Text = counter.Max.ToString();
            TextBlockCount.Text = counter.Count.ToString();
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e) // уменьшить значение счётчика
        {
            bool flag = true;
            try
            {
                counter--;
            }
            catch
            {
                flag = false;
                MessageBox.Show("Счётчик дошёл до граничного значения", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (flag)
                TextBlockCount.Text = counter.Count.ToString();
        }
        private void BtnPlus_Click(object sender, RoutedEventArgs e) // увеличить значение счётчика
        {
            bool flag = true;
            try
            {
                counter++;
            }
            catch
            {
                flag = false;
                MessageBox.Show("Счётчик дошёл до граничного значения", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (flag)
                TextBlockCount.Text = counter.Count.ToString();
        }
        private void BtnLimits_Click(object sender, RoutedEventArgs e) // изменить диапазон значений счётчика
        {
            int min = 0, max = 0;
            bool flag = true;
            try
            {
                min = int.Parse(lowerLimit.Text);
                max = int.Parse(upperLimit.Text);
            }
            catch
            {
                MessageBox.Show("Проверьте введенные значения", "Ошибка данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                flag = false;
            }
            if (flag)
            {
                if (min >= max)
                {
                    MessageBox.Show("Верхняя граница диапазона должна быть больше нижней", "Ошибка данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                    lowerLimit.Text = counter.Min.ToString();
                    upperLimit.Text = counter.Max.ToString();
                }
                else
                {
                    counter.Min = min;
                    counter.Max = max;
                    counter.Count = 1;
                    TextBlockCount.Text = counter.Count.ToString();
                }
            }
        }
        class Counter
        {
            private int m_count;
            private int m_min;
            private int m_max;
            public Counter()
            {
                Random rnd = new Random();
                m_min = 0;
                m_max = 100;
                m_count = rnd.Next(m_min, m_max + 1);
            }
            public int Count
            {
                get
                {
                    return m_count;
                }
                set
                {
                    Random rnd = new Random();
                    m_count = rnd.Next(m_min, m_max + 1);
                }
            }
            public int Min
            {
                get
                {
                    return m_min;
                }
                set
                {
                    m_min = value;
                }
            }
            public int Max
            {
                get
                {
                    return m_max;
                }
                set
                {
                    m_max = value;
                }
            }
            public static Counter operator ++(Counter obj)
            {
                if (++obj.m_count > obj.m_max)
                    throw new Exception("RangeError");
                return obj;
            }
            public static Counter operator --(Counter obj)
            {
                if (--obj.m_count < obj.m_min)
                    throw new Exception("RangeError");
                return obj;
            }
        }
    }
    
}
