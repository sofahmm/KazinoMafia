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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KazinoMafia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string log = tb_login.Text.Trim();
            string pas = pb_pass.Password.Trim();
            List<User> users = new List<User>(Connection.kazinoEntities.User.ToList());
            var userExsist = users.Where(user => user.Login == log && user.Password == pas).FirstOrDefault();
            if (userExsist != null)
            {
                Properties.Settings.Default.Login = userExsist.Login;
                Properties.Settings.Default.Login = userExsist.Password;
                KazinoWindow playWindow = new KazinoWindow();
                playWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Невернвый логин или пароль");
            }
        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            RegistrWindow registrationWindow = new RegistrWindow();
            registrationWindow.Show();
            this.Close();
        }
    }
}
