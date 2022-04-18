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
    /// Page4.xaml 的交互逻辑
    /// </summary>
    public partial class Page4 : Page
    {
        Db1Entities x = new Db1Entities();
        string lastid;
        public Page4()
        {
            InitializeComponent();
            var q = from t in x.Tea
                    select t;
            string id = "";
            foreach (var item in q)
            {
                id = item.Id;
            }
            lastid= (int.Parse(id) + 1).ToString();
            no.Text = lastid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pas.Password == pas1.Password&& tel.Text.ToString().Length == 11)
            {
                ComboBoxItem item = doyuan.SelectedItem as ComboBoxItem;
                string content = item.Content.ToString();
                ComboBoxItem item1 = gender.SelectedItem as ComboBoxItem;
                string content1 = item1.Content.ToString();
                Tea tea = new Tea()
                {
                    Id = no.Text,
                    Gender = content1,
                    Major = content,
                    Name = name.Text,
                    Password = pas.Password,
                    Tel = tel.Text
                };
                try
                {
                    x.Tea.Add(tea);
                    x.SaveChanges();
                    MessageBox.Show("老师信息添加成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (tel.Text.ToString().Length != 11)
            {
                MessageBox.Show("电话号码必须为十一位");
            }
            else
            {
                MessageBox.Show("两次密码不一致！");
            }
        }
    }
}
