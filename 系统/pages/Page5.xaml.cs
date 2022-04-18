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

namespace 系统.pages
{
    /// <summary>
    /// Page5.xaml 的交互逻辑
    /// </summary>
    public partial class Page5 : Page
    {
        Db1Entities x = new Db1Entities();
        public Page5()
        {
            InitializeComponent();
            var s = from q in x.Tea
                    select q;
            foreach (var x in s)
            {
                cb.Items.Add(x.Id);
            
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            string content = cb.SelectedItem.ToString();
            var s = from q in x.Tea
                    where q.Id==content
                    select q;
            if (s.Count() > 0)
            {
                Tea tea = new Tea();
                string name1 = "";
                bool t = false;
                foreach (var item1 in s)
                {
                    if (pyuan.Password == item1.Password)
                    {
                        if (pxian.Password == pxian1.Password)
                        {
                            t = true;
                            tea = new Tea()
                            {
                                Gender = item1.Gender,
                                Id = item1.Id,
                                Major = item1.Major,
                                Name = item1.Name,
                                Password = pxian.Password,
                                Tel = item1.Tel

                            };
                            name1 = item1.Name;
                            x.Tea.Remove(item1);
                        }
                        else
                        {
                            MessageBox.Show("两次密码不一样！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("原密码错误！");
                    }

                }
                if (t)
                {
                    MessageBoxResult dr = MessageBox.Show("确定要修改密码吗?", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (dr == MessageBoxResult.OK)
                    {
                        try
                        {
                            x.SaveChanges();
                            x.Tea.Add(tea);
                            x.SaveChanges();
                            MessageBox.Show(string.Format(name1 + "密码更改成功！"));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                    }
                }




            }
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string content = cb.SelectedItem.ToString();
            var s = from q in x.Tea
                    where q.Id == content
                    select q;
            foreach (var item1 in s)
            {
                lb.Content = "您选择的是" + item1.Name + "老师";
            }
        }
    }
}
