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
    /// Логика взаимодействия для Vasilisk.xaml
    /// </summary>
    public partial class Vasilisk : Window
    {
        public Vasilisk()
        {
            InitializeComponent();
            te.IsReadOnly = true;
            tes.Visibility = Visibility.Hidden;
        }
        int i = 29;

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            while (i == 56) { i = 55; tes.Visibility = Visibility.Visible; }
            i++;
            te.Clear();
            string connection1 = @"Data Source =LAPTOP-J0AL0OMK\SQLEXPRESS; Initial Catalog = diplom; Integrated Security = True";
            SqlConnection sqlConnection = new SqlConnection(connection1);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Guide2]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if (Convert.ToInt64(sqlReader["id_guide"]) == i && Convert.ToInt64(sqlReader["id_topic"]) == 2)
                    {
                        te.AppendText(i-29 + "  " + sqlReader["Text_guide"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                if (sqlReader != null) sqlReader.Close();
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            while (i <= 30) { MessageBox.Show("Граница"); i = 31; }
            i--;
            te.Clear();
            string connection1 = @"Data Source =LAPTOP-J0AL0OMK\SQLEXPRESS; Initial Catalog = diplom; Integrated Security = True";
            SqlConnection sqlConnection = new SqlConnection(connection1);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Guide2]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if (Convert.ToInt64(sqlReader["id_guide"]) == i)
                        te.AppendText(i-29 + "  " + sqlReader["Text_guide"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                if (sqlReader != null) sqlReader.Close();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void tes_Click(object sender, RoutedEventArgs e)
        {
            TestVasiliy testVasiliy = new TestVasiliy();
            testVasiliy.Show();
            this.Close();
        }
    }
}
