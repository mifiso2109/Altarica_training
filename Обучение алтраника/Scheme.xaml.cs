using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Scheme.xaml
    /// </summary>
    public partial class Scheme : Window
    {
        public Scheme()
        {
            InitializeComponent();
            r.IsReadOnly = true;
        }
        
        private void End_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
