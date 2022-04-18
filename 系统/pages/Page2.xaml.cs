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
    /// Page2.xaml 的交互逻辑
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            Find();
        }
        
        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listbox1.SelectedIndex >=0)
            {
                
                int p;
                p = listbox1.SelectedIndex;
                var item1 = listbox1.SelectedItem;
                string str = item1.ToString();
                Revise new_s = new Revise(str);
                new_s.ShowDialog();
                Db1Entities z = new Db1Entities();
                listbox1.Items.Clear();
                var qq = from t in z.Stu
                         select t;
                int ppp = 0;
                foreach (var item in qq)
                {
                    ppp++;
                    string[] zz = item.Sdormitory.Split(',');
                    string pz = zz[0] + "号楼" + zz[1];
                    listbox1.Items.Add(string.Format("姓名：{0}，性别：{1}，出生日期：{6}，学号：{5}，宿舍号：{2}，电话：{3}，学院：{4}，入学日期：{7}", item.Sname, item.Sgender, pz, item.Stel, item.Smajor, item.Sno, item.Sbrithday, item.Sdate));
                }
                lb.Content = "共检索到了" + ppp + "条学生的数据";
            }
        }
        private void Find()
        {
            Db1Entities x = new Db1Entities();
            listbox1.Items.Clear();
            var s = from q in x.Stu
                    select q;
            int ppp = 0;
            foreach (var item in s)
            {
                ppp++;
                string[] zz = item.Sdormitory.Split(',');
                string pz = zz[0] + "号楼" + zz[1];
                listbox1.Items.Add(string.Format("姓名：{0}，性别：{1}，出生日期：{6}，学号：{5}，宿舍号：{2}，电话：{3}，学院：{4}，入学日期：{7}", item.Sname, item.Sgender, pz, item.Stel, item.Smajor, item.Sno, item.Sbrithday, item.Sdate));
            }
            lb.Content = "共检索到了" + ppp + "条学生的数据";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Newstudents st = new Newstudents();
            st.ShowDialog();
            Db1Entities z = new Db1Entities();
            listbox1.Items.Clear();
            var qq = from t in z.Stu
                     select t;
            int ppp = 0;
            foreach (var item in qq)
            {
                ppp++;
                string[] zz = item.Sdormitory.Split(',');
                string pz = zz[0] + "号楼" + zz[1];
                listbox1.Items.Add(string.Format("姓名：{0}，性别：{1}，出生日期：{6}，学号：{5}，宿舍号：{2}，电话：{3}，学院：{4}，入学日期：{7}", item.Sname, item.Sgender, pz, item.Stel, item.Smajor, item.Sno, item.Sbrithday, item.Sdate));
            }
            lb.Content= "共检索到了" + ppp + "条学生的数据";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Db1Entities x = new Db1Entities();
            if (listbox1.SelectedIndex >= 0)
            {
                int p;
                p = listbox1.SelectedIndex;
                var item = listbox1.SelectedItem;
                string str = item.ToString();
                string[] str1 = str.Split('，');
                string[] sca1 = str1[3].Split('：');
                string sca = sca1[1];
                MessageBoxResult dr = MessageBox.Show("确定要删除吗?", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (dr == MessageBoxResult.OK)
                {

                    var qq = from t in x.Stu
                             where t.Sno == sca
                             select t;
                    foreach (var i in qq)
                    {
                        x.Stu.Remove(i);
                    }
                    try
                    {
                        x.SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    
                }
                Find();

            }

            else
            {
                MessageBox.Show("请选择正确的人员信息！");
            }
            
        }
    }
}
