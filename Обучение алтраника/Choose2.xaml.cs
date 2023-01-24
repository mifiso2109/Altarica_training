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
    /// Логика взаимодействия для Choose2.xaml
    /// </summary>
    public partial class Choose2 : Window
    {
        public Choose2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Ion.IsChecked == true)
            {
                Test test= new Test();
                test.Show();
                this.Close();
            }

            if (Vasiliy.IsChecked == true)
            {
                TestVasiliy testVasiliy = new TestVasiliy();
                testVasiliy.Show();
                this.Close();
            }

            if (Dvoe.IsChecked == true)
            {
                Dvoeslov dvoeslov = new Dvoeslov();
                dvoeslov.Show();
                this.Close();
            }
        }
    }
}
