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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Window
    {
        
        public UserPage()
        {
            InitializeComponent();
            //Cab(userName);
        }
        /*
        public async void Cab(string userName)
        {
            string connection1 = @"Data Source =LAPTOP-J0AL0OMK\SQLEXPRESS; Initial Catalog = diplom; Integrated Security = True";
            SqlConnection sqlConnection = new SqlConnection(connection1);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM users ", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if (Convert.ToString(sqlReader["Login"]) == userName)
                    {
                        Name.Text = Convert.ToString(sqlReader["Name"]);
                        Surname.Text = Convert.ToString(sqlReader["Surname"]);
                        Lastname.Text = Convert.ToString(sqlReader["Lastname"]);
                        PhoneNumber.Text = Convert.ToString(sqlReader["Mail"]);
                        Email.Text = Convert.ToString(sqlReader["Phone"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        */
       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
