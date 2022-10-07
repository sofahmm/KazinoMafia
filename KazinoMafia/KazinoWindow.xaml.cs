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
    /// Interaction logic for KazinoWindow.xaml
    /// </summary>
    public partial class KazinoWindow : Window
    {
        public static User user { get; set; }
        public KazinoWindow()
        {
            InitializeComponent();
            string log = Properties.Settings.Default.Login;
            string pas = Properties.Settings.Default.Password;
            List<User> users = new List<User>(Connection.kazinoEntities.User.ToList());
            user = users.Where(user => user.Login == log && user.Password == pas).FirstOrDefault();
            tb_count.Text = user.Count.ToString();
            tb_name.Text = user.Name;
        }

        private void krutBtn_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int r1 = rnd.Next(1, 6);
            int r2 = rnd.Next(1, 6);
            int r3 = rnd.Next(1, 6);


            if (r1 == 1)
            {
                img1.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\source\\repos\\KazinoMafia\\img\\1.jpg"));
            }
            else if (r1 == 2)
            {
                img1.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\source\\repos\\KazinoMafia\\img\\2.jpg"));
            }
            else if (r1 == 3)
            {
                img1.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\source\\repos\\KazinoMafia\\img\\3.jpg"));
            }
            else if (r1 == 4)
            {
                img1.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\source\\repos\\KazinoMafia\\img\\4.jpg"));
            }
            else
            {
                img1.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\source\\repos\\KazinoMafia\\img\\5.jpg"));
            }

            if (r2 == 1)
            {
                img2.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\source\\repos\\KazinoMafia\\img\\1.jpg"));
            }
            else if (r2 == 2)
            {
                img2.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\source\\repos\\KazinoMafia\\img\\2.jpg"));
            }
            else if (r2 == 3)
            {
                img2.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\source\\repos\\KazinoMafia\\img\\3.jpg"));
            }
            else if (r2 == 4)
            {
                img2.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\source\\repos\\KazinoMafia\\img\\4.jpg"));
            }
            else
            {
                img2.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\source\\repos\\KazinoMafia\\img\\5.jpg"));
            }

            if (r3 == 1)
            {
                img3.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\source\\repos\\KazinoMafia\\img\\1.jpg"));
            }
            else if (r3 == 2)
            {
                img3.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\source\\repos\\KazinoMafia\\img\\2.jpg"));
            }
            else if (r3 == 3)
            {
                img3.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\source\\repos\\KazinoMafia\\img\\3.jpg"));
            }
            else if (r3 == 4)
            {
                img3.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\source\\repos\\KazinoMafia\\img\\4.jpg"));
            }
            else
            {
                img3.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\source\\repos\\KazinoMafia\\img\\5.jpg"));
            }
            if (r1 == r2 && r2 == r3)
            {
                user.Count += 1000;
            }
            else
            {
                if (r1 == r2 || r2 == r3 || r1 == r3)
                {
                    user.Count += 100;
                }
                else
                {
                    user.Count -= 10;
                }
            }

            Connection.kazinoEntities.SaveChanges();
            tb_count.Text = user.Count.ToString();
        }
    }
}
