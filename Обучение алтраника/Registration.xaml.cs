using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;

namespace Обучение_алтраника
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        string connection1 = @"Data Source =LAPTOP-J0AL0OMK\SQLEXPRESS; Initial Catalog = diplom; Integrated Security = True";

        public Boolean isUserCheckLogin()
        {
            SqlConnection connection = new SqlConnection(connection1);

            SqlCommand command = new SqlCommand(@"SELECT * FROM users WHERE Login = @loginUser", connection);
            command.Parameters.AddWithValue("@loginUser", log.Text);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show("Такой логин уже есть, введите другой логин");
                return true;
            }
            else return false;
        }

        public Boolean isUserCheckPassword()
        {
            SqlConnection connection = new SqlConnection(connection1);

            SqlCommand command = new SqlCommand(@"SELECT * FROM users WHERE Password = @pasUser", connection);
            command.Parameters.AddWithValue("@pasUser", pas.Text);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show("Такой пароль уже есть, введите другой пароль");
                return true;
            }
            else return false;
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            Regex em = new Regex("[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}");
            Regex words = new Regex("^[а-яА-Я]*$");
            bool num = false;
            num = long.TryParse(PhoneNumber.Text, out long number);
            if (!words.IsMatch(Name.Text) || Name.Text == "") { Error.Text = "Пустая строка или не вернный формат ввода имени"; return; }
            if (!words.IsMatch(Surname.Text) || Surname.Text == "") { Error.Text = "Пустая строка или не вернный формат ввода фамилии"; return; }
            if (!words.IsMatch(Lastname.Text) || Lastname.Text == "") { Error.Text = "Пустая строка или не вернный формат ввода отчества"; return; }
            if (!em.IsMatch(Email.Text) || Email.Text == "") { Error.Text = "Пустая строка или не вернный формат ввода почты(ex@mail.ru)"; return; }
            if (!num || PhoneNumber.Text == "" || PhoneNumber.Text.Length != 12) { Error.Text = "Пустая строка или не вернный формат ввода номера телефона"; return; }
            if (log.Text == "" || log.Text.Length > 15) { Error.Text = "Пустая строка или не вернный формат ввода логина"; return; }
            if (pas.Text == "" || pas.Text.Length > 15) { Error.Text = "Пустая строка или не вернный формат ввода пароля"; return; }

            if (isUserCheckLogin()) return;
            if (isUserCheckPassword()) return;

            SqlConnection connection = new SqlConnection(connection1);

            SqlCommand command = new SqlCommand(@"INSERT INTO users (Name, Surname, Lastname, Mail, Phone, Login, Password) 
            VALUES (@nameUser, @surnameUser, @lastnameUser, @emailUser, @phoneUser, @loginUser, @pasUser)", connection);
            command.Parameters.AddWithValue("@nameUser", Name.Text);
            command.Parameters.AddWithValue("@surnameUser", Surname.Text);
            command.Parameters.AddWithValue("@lastnameUser", Lastname.Text);
            command.Parameters.AddWithValue("@emailUser", Email.Text);
            command.Parameters.AddWithValue("@phoneUser", PhoneNumber.Text);
            command.Parameters.AddWithValue("@loginUser", log.Text);
            command.Parameters.AddWithValue("@pasUser", pas.Text);

            connection.Open();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт создан, добро пожаловать " + Name.Text);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else MessageBox.Show("Аккаунт не создан");
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
