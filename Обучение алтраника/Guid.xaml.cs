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
    /// Логика взаимодействия для Guid.xaml
    /// </summary>
    public partial class Guid : Window
    {
        public Guid()
        {
            InitializeComponent();
            te.IsReadOnly = true;
            hi.Visibility = Visibility.Hidden;
        }
        int i = 0;
        
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            while (i <= 1) { MessageBox.Show("Граница"); i = 2; }
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
                        te.AppendText(i + "  " + sqlReader["Text_guide"]);
                    
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

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            while (i == 29) {i = 28; hi.Visibility = Visibility.Visible; }
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
                    if (Convert.ToInt64(sqlReader["id_guide"]) == i && Convert.ToInt64(sqlReader["id_topic"]) == 1)
                        te.AppendText(i + "  " + sqlReader["Text_guide"]);
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

        private void hi_Click(object sender, RoutedEventArgs e)
        {
            Test test = new Test();
            test.Show();
            this.Close();
        }
    }
}
