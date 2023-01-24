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
    /// Логика взаимодействия для Dvoeslov.xaml
    /// </summary>
    public partial class Dvoeslov : Window
    {

        int[] mas = new int[39];
        int y = 23;

        public Dvoeslov()
        {
            InitializeComponent();

            Random rnd = new Random();

            for (int i = 24; i < 36; i++)
            {
                int a = rnd.Next(25, 37);
                if (!mas.Contains(a))
                    mas[i] = a;
                else
                    i--;
            }
        }

        int c = 0;
        int j = 10;
        int count = 0;


        private async void Next_Click(object sender, RoutedEventArgs e)
        {
            y++;
            A1.Visibility = Visibility.Visible;
            A2.Visibility = Visibility.Visible;
            A3.Visibility = Visibility.Visible;
            txt.Visibility = Visibility.Hidden;
            ans.Visibility = Visibility.Hidden;

            while (c == 12)
            {
                A1.IsEnabled = false; A1.IsChecked = false;
                A2.IsEnabled = false; A2.IsChecked = false;
                A3.IsEnabled = false; A3.IsChecked = false;
                ans.IsEnabled = false;
                Next.IsEnabled = false;
                c = 9;
            }
            c++;
            Random random = new Random();
            j = mas[y];
            string connection1 = @"Data Source =LAPTOP-J0AL0OMK\SQLEXPRESS; Initial Catalog = diplom; Integrated Security = True";
            SqlConnection sqlConnection = new SqlConnection(connection1);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT Q.id_question, Q.text_question, A.* FROM Questions Q, Answer A WHERE Q.id_question = A.id_question", sqlConnection);
            try
            {
                if (A2.IsChecked == true || A3.IsChecked == true) MessageBox.Show("Правильны ответ: " + A1.Content);
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if (Convert.ToInt64(sqlReader["id_question"]) == mas[y] && Convert.ToInt64(sqlReader["id_test"]) == 2)
                    {
                        txt.Visibility = Visibility.Visible;
                        ans.Visibility = Visibility.Visible;
                        A1.Visibility = Visibility.Hidden;
                        A2.Visibility = Visibility.Hidden;
                        A3.Visibility = Visibility.Hidden;
                        Next.Visibility = Visibility.Hidden;
                        L.Content = Convert.ToString(sqlReader["text_question"]);
                    }

                    if (Convert.ToInt64(sqlReader["id_question"]) == mas[y])
                        L.Content = Convert.ToString(sqlReader["text_question"]);

                    if (Convert.ToInt64(sqlReader["id_answer"]) == 1 && Convert.ToInt64(sqlReader["id_question"]) == mas[y])
                        A1.Content = Convert.ToString(sqlReader["text_answer"]);

                    else if (Convert.ToInt64(sqlReader["id_answer"]) == 2 && Convert.ToInt64(sqlReader["id_question"]) == mas[y])
                        A2.Content = Convert.ToString(sqlReader["text_answer"]);

                    else if (Convert.ToInt64(sqlReader["id_answer"]) == 3 && Convert.ToInt64(sqlReader["id_question"]) == mas[y])
                        A3.Content = Convert.ToString(sqlReader["text_answer"]);
                }

                txt.Clear();
                if (mas[y] == 25 || mas[y] == 26 || mas[y] == 27)
                {
                    A1.Margin = new Thickness(224, 222, 0, 0);
                    A2.Margin = new Thickness(224, 164, 0, 0);
                    A3.Margin = new Thickness(224, 192, 0, 0);
                }
                else if (mas[y] == 28 || mas[y] == 29 || mas[y] == 30)
                {
                    A1.Margin = new Thickness(224, 192, 0, 0);
                    A2.Margin = new Thickness(224, 222, 0, 0);
                    A3.Margin = new Thickness(224, 164, 0, 0);
                }
                else if (mas[y] == 31 || mas[y] == 32 || mas[y] == 33)
                {
                    A1.Margin = new Thickness(224, 164, 0, 0);
                    A2.Margin = new Thickness(224, 222, 0, 0);
                    A3.Margin = new Thickness(224, 192, 0, 0);
                }

                if (A1.IsChecked == true) count = count + 5;

                A1.IsChecked = false;
                A2.IsChecked = false;
                A3.IsChecked = false;

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

        public void Coun(int count)
        {
            string connection1 = @"Data Source =LAPTOP-J0AL0OMK\SQLEXPRESS; Initial Catalog = diplom; Integrated Security = True";
            SqlConnection sqlConnection = new SqlConnection(connection1);
            SqlCommand command = new SqlCommand(@"INSERT INTO Results (results) VALUES (@res)", sqlConnection);
            command.Parameters.AddWithValue("@res", count);
            sqlConnection.Open();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Ваши баллы: " + count + "/60");
            else MessageBox.Show("BAD");
            sqlConnection.Close();
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            if (count / 12 <= 5 && count / 12 >= 4.5) MessageBox.Show("Вы сдали с отличием!");
            else if (count / 12 <= 4.4 && count / 12 >= 3.5) MessageBox.Show("Вы сдали на хорошо, результат не плох, но можно и лучше!");
            else if (count / 12 <= 3.4 && count / 12 >= 2.5) MessageBox.Show("Вы сдали на удовлетворительно, рекомендую почитать еще раз информацию, чтобы улучшить свои знания!");
            else if (count / 12 <= 2.4) MessageBox.Show("Вы не сдали, перепройдите тест еще раз!");
            Coun(count);
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private async void ans_Click(object sender, RoutedEventArgs e)
        {
            while (c == 12)
            {
                A1.IsEnabled = false; A1.IsChecked = false;
                A2.IsEnabled = false; A2.IsChecked = false;
                A3.IsEnabled = false; A3.IsChecked = false;
                ans.IsEnabled = false;
                Next.IsEnabled = false;
                c = 9;
            }
            c++;
            y++;
            string connection1 = @"Data Source =LAPTOP-J0AL0OMK\SQLEXPRESS; Initial Catalog = diplom; Integrated Security = True";
            SqlConnection sqlConnection = new SqlConnection(connection1);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT Q.id_question, Q.text_question, Q.id_test,  A.* FROM Questions Q, Answer A WHERE Q.id_question = A.id_question", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if (Convert.ToInt64(sqlReader["id_answer"]) == mas[y - 1] - 6 && txt.Text == Convert.ToString(sqlReader["text_answer"]))
                        count = count + 5;
                    
                    else if (Convert.ToInt64(sqlReader["id_answer"]) == mas[y - 1] - 6 && txt.Text != Convert.ToString(sqlReader["text_answer"]) && Convert.ToInt64(sqlReader["id_test"]) == 2)
                        MessageBox.Show("Правильный ответ: " + Convert.ToString(sqlReader["text_answer"]));

                    if (Convert.ToInt64(sqlReader["id_question"]) == mas[y]) L.Content = Convert.ToString(sqlReader["text_question"]);

                    if (Convert.ToInt64(sqlReader["id_answer"]) == 1 && Convert.ToInt64(sqlReader["id_question"]) == mas[y])
                        A1.Content = Convert.ToString(sqlReader["text_answer"]);

                    else if (Convert.ToInt64(sqlReader["id_answer"]) == 2 && Convert.ToInt64(sqlReader["id_question"]) == mas[y])
                        A2.Content = Convert.ToString(sqlReader["text_answer"]);

                    else if (Convert.ToInt64(sqlReader["id_answer"]) == 3 && Convert.ToInt64(sqlReader["id_question"]) == mas[y])
                        A3.Content = Convert.ToString(sqlReader["text_answer"]);

                    if (Convert.ToInt64(sqlReader["id_question"]) == mas[y] && Convert.ToInt64(sqlReader["id_test"]) == 2)
                    {
                        txt.Visibility = Visibility.Visible;
                        ans.Visibility = Visibility.Visible;
                        A1.Visibility = Visibility.Hidden;
                        A2.Visibility = Visibility.Hidden;
                        A3.Visibility = Visibility.Hidden;
                        Next.Visibility = Visibility.Hidden;
                        L.Content = Convert.ToString(sqlReader["text_question"]);
                        txt.Clear();
                    }

                    else if (Convert.ToInt64(sqlReader["id_question"]) == mas[y] && Convert.ToInt64(sqlReader["id_test"]) == 1)
                    {
                        ans.Visibility = Visibility.Hidden;
                        Next.Visibility = Visibility.Visible;
                        txt.Visibility = Visibility.Hidden;
                        A1.Visibility = Visibility.Visible;
                        A2.Visibility = Visibility.Visible;
                        A3.Visibility = Visibility.Visible;
                        L.Visibility = Visibility.Visible;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
