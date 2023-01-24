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
    /// Логика взаимодействия для Authorizations.xaml
    /// </summary>
    public partial class Authorizations : Window
    {
        public Authorizations()
        {
            InitializeComponent();
        }

        private void auto_Click(object sender, RoutedEventArgs e)
        {
            string connection1 = @"Data Source =LAPTOP-J0AL0OMK\SQLEXPRESS; Initial Catalog = diplom; Integrated Security = True";
            SqlConnection connection = new SqlConnection(connection1);
            SqlCommand command = new SqlCommand(@"SELECT * FROM users WHERE Login = @loginUser AND Password = @pasUser", connection);
            command.Parameters.AddWithValue("@loginUser", log.Text);
            command.Parameters.AddWithValue("@pasUser", pas.Text);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show("Вы авторизованы, здравствуйте " + log.Text);
                string userName = log.Text;
                UsersPage userPage = new UsersPage(userName);
                Test test = new Test();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else MessageBox.Show("Такого аккаунта не существует");
            connection.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
