using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Обучение_алтраника
{
    /// <summary>
    /// Логика взаимодействия для Choose.xaml
    /// </summary>
    public partial class Choose : Window
    {
        public Choose()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Ion.IsChecked == true)
            {
                Guid guid = new Guid();
                guid.Show();
                this.Close();
            }

            if (Vasiliy.IsChecked == true)
            {
                Vasilisk vasilisk = new Vasilisk();
                vasilisk.Show();
                this.Close();
            }

            if (Dar.IsChecked == true)
            {
                Dar dar = new Dar();
                dar.Show();
                this.Close();
            }

            if (Church.IsChecked == true)
            {
                Scheme scheme = new Scheme();
                scheme.Show();
                this.Close();
            }

        }
    }
}
