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
    /// Page3.xaml 的交互逻辑
    /// </summary>
    public partial class Page3 : Page
    {
        Db1Entities x = new Db1Entities();
        public Page3()
        {
            InitializeComponent();
            Find();
        }

        private void Find()
        {
            var s = from q in x.Tea
                    select q;
            int xp = 0;
            foreach (var item in s)
            {
                listbox1.Items.Add(string.Format("老师姓名：{0}，性别：{1}，专业：{2}，电话：{3}，工号：{4}",item.Name,item.Gender,item.Major,item.Tel,item.Id));
                xp++;
            }
            lb.Content = "共检索到了" + xp + "条老师的数据";
        }

       
    }
}
