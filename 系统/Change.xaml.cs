using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Change.xaml 的交互逻辑
    /// </summary>
    public partial class Change : Window
    {
        Db1Entities x = new Db1Entities();
        public Change(string no)
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.no.Text = no;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var s = from q in x.Tea
                    where q.Id == no.Text
                    select q;
            if (s.Count() > 0)
            {
                Tea tea=new Tea();
                string name1="";
                bool t = false;
                foreach (var item in s)
                {
                    if (item.Name == this.neme.Text && item.Tel == tel.Text)
                    {
                        t = true;
                        tea = new Tea()
                        {
                            Gender = item.Gender,
                            Id = item.Id,
                            Major = item.Major,
                            Name = item.Name,
                            Password = "12345",
                            Tel = item.Tel
                            
                        };
                        name1 = item.Name;
                        x.Tea.Remove(item);
                    }
                    else
                    {
                        MessageBox.Show("验证错误！");
                    }
                    
                }
                if (t)
                {
                    MessageBoxResult dr = MessageBox.Show("确定要重置密码吗?", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (dr == MessageBoxResult.OK)
                    {
                        try
                        {
                            x.SaveChanges();
                            x.Tea.Add(tea);
                            x.SaveChanges();
                            MessageBox.Show(string.Format(name1 + "重置密码成功！默认密码12345"));
                            //this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                    }
                }
                
               


            }
        }
    }
}
