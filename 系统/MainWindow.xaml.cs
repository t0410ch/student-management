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

namespace 系统
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            lsb.Items.Add("学生查询");
            lsb.Items.Add("学生宿舍管理");
            lsb.Items.Add("教师信息汇总");
            lsb.Items.Add("新增教师");
            lsb.Items.Add("教师密码修改");
            lsb.Items.Add("帮助");
            this.lsb.AddHandler(UIElement.MouseDownEvent,
                          new MouseButtonEventHandler(StencilMouseDown), true);
        }
        Db1Entities x = new Db1Entities();


        private void StencilMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (lsb.SelectedItem != null)
                {
                    string sq = lsb.SelectedItem.ToString();
                    
                    if (sq == "学生宿舍管理")
                    {
                        fr.Source = new Uri("pages/Page2.xaml", UriKind.Relative);
                    }
                    else if (sq == "学生查询")
                    {
                        fr.Source = new Uri("pages/Page1.xaml", UriKind.Relative);
                    }
                    else if(sq == "教师信息汇总")
                    {
                        fr.Source = new Uri("pages/Page3.xaml", UriKind.Relative);
                    }
                    else if (sq == "新增教师")
                    {
                        fr.Source = new Uri("pages/Page4.xaml", UriKind.Relative);
                    }
                    else if (sq == "教师密码修改")
                    {
                        fr.Source = new Uri("pages/Page5.xaml", UriKind.Relative);
                    }
                    else if (sq == "帮助")
                    {
                        fr.Source = new Uri("pages/Page6.xaml", UriKind.Relative);
                    }
                }

            }
            catch (Exception)
            {

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

            private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var s = from q in x.Stu
                    select q;
            foreach (var item in s)
            {
                MessageBox.Show(item.Sno);

            }
            
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
        }
    }
}
