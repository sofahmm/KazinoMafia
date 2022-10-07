using KazinoMafia.DB;
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

namespace KazinoMafia
{
    /// <summary>
    /// Interaction logic for RegistrWindow.xaml
    /// </summary>
    public partial class RegistrWindow : Window
    {
        public RegistrWindow()
        {
            InitializeComponent();
        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            string name = tb_name.Text.Trim();
            string log = tb_login.Text.Trim();
            string pas = tb_pass.Text.Trim();

            List<User> users = Connection.kazinoEntities.User.ToList();
            bool login_unic = true;
            foreach (var i in users)
            {
                if (i.Login == log)
                {
                    login_unic = false;
                }
            }

            if (name.Length != 0 && log.Length != 0 && pas.Length != 0)
            {
                if (login_unic)
                {
                    user.Name = name;
                    user.Login = log;
                    user.Password = pas;
                    user.Count = 100;
                    Connection.kazinoEntities.User.Add(user);
                    Connection.kazinoEntities.SaveChanges();
                    MessageBox.Show("Авторизация прошла успешно");
                }
                else
                {
                    MessageBox.Show("Придумайте другой логин");
                }
            }
            else
            {
                MessageBox.Show("Введите все данные");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
