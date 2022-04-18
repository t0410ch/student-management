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

namespace 系统
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        
        bool panduan = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Change c = new Change(no.Text.ToString());
            c.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(!panduan)
            App.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Db1Entities x = new Db1Entities();
            var s = from q in x.Tea
                    where q.Id == no.Text
                    select q;
            if (s.Count() > 0)
            {
                foreach (var item in s)
                {
                    if (item.Password == this.password.Password)
                    {
                        panduan = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("密码错误！");
                    }
                }
            }
            else
            {
                MessageBox.Show("未检索到此工号！");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
