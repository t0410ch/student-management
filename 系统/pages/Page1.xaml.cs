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
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            Find();
            
        }
        Db1Entities x = new Db1Entities();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cb.SelectedItem != null)
            {
                string str = cb.SelectedItem.ToString();
                string[] sp = str.Split(':');
                str = sp[1];
                switch (str)
                {
                    case " 姓名":
                        var s = from q in x.Stu
                                where q.Sname == tb.Text.ToString()
                                select q;
                        if (s.Count() > 0)
                        {
                            lb.Items.Clear();
                            int ppp = 0;
                            foreach (var item in s)
                            {
                                ppp++;
                                string[] zz = item.Sdormitory.Split(',');
                                string pz = zz[0] + "号楼" + zz[1];
                                lb.Items.Add(string.Format("姓名：{0}，性别：{1}，出生日期：{6}，学号：{5}，宿舍号：{2}，电话：{3}，学院：{4}，入学日期：{7}", item.Sname, item.Sgender, pz, item.Stel, item.Smajor, item.Sno, item.Sbrithday, item.Sdate));

                            }
                            label.Content = "共检索到了" + ppp + "条学生的数据";
                        }
                        else
                        {
                            lb.Items.Clear();
                            lb.Items.Add(string.Format("未查询到姓名为“{0}”的有关内容", tb.Text.ToString()));
                            label.Content = "";
                        }
                        break;
                    case " 学号":
                        var s1 = from q in x.Stu
                                 where q.Sno == tb.Text.ToString()
                                 select q;
                        lb.Items.Clear();
                        if (s1.Count() > 0)
                        {
                            int ppp1 = 0;
                            foreach (var item in s1)
                            {
                                ppp1++;
                                string[] zz = item.Sdormitory.Split(',');
                                string pz = zz[0] + "号楼" + zz[1];
                                lb.Items.Add(string.Format("姓名：{0}，性别：{1}，出生日期：{6}，学号：{5}，宿舍号：{2}，电话：{3}，学院：{4}，入学日期：{7}", item.Sname, item.Sgender, pz, item.Stel, item.Smajor, item.Sno, item.Sbrithday, item.Sdate));
                            }
                            label.Content = "共检索到了" + ppp1 + "条学生的数据";
                        }
                        else
                        {
                            lb.Items.Add(string.Format("未查询到学号为“{0}”的有关内容", tb.Text.ToString()));
                            label.Content = "";
                        }
                        break;
                    case " 学院":
                        var s2 = from q in x.Stu
                                 where q.Smajor == tb.Text.ToString()
                                 select q;
                        lb.Items.Clear();

                        if (s2.Count() > 0)
                        {
                            int ppp2 = 0;
                            foreach (var item in s2)
                            {
                                ppp2++;
                                string[] zz = item.Sdormitory.Split(',');
                                string pz = zz[0] + "号楼" + zz[1];
                                lb.Items.Add(string.Format("姓名：{0}，性别：{1}，出生日期：{6}，学号：{5}，宿舍号：{2}，电话：{3}，学院：{4}，入学日期：{7}", item.Sname, item.Sgender, pz, item.Stel, item.Smajor, item.Sno, item.Sbrithday, item.Sdate));
                            }
                            label.Content = "共检索到了" + ppp2 + "条学生的数据";
                        }
                        else
                        {
                            lb.Items.Add(string.Format("未查询到宿舍为“{0}”的有关内容", tb.Text.ToString()));
                            label.Content = "";
                        }
                        break;
                    case " 性别":
                        var s3 = from q in x.Stu
                                 where q.Sgender == tb.Text.ToString()
                                 select q;
                        lb.Items.Clear();
                        if (s3.Count() > 0)
                        {
                            int ppp3 = 0;
                            foreach (var item in s3)
                            {
                                ppp3++;
                                string[] zz = item.Sdormitory.Split(',');
                                string pz = zz[0] + "号楼" + zz[1];
                                lb.Items.Add(string.Format("姓名：{0}，性别：{1}，出生日期：{6}，学号：{5}，宿舍号：{2}，电话：{3}，学院：{4}，入学日期：{7}", item.Sname, item.Sgender, pz, item.Stel, item.Smajor, item.Sno, item.Sbrithday, item.Sdate));
                            }
                            label.Content = "共检索到了" + ppp3 + "条学生的数据";
                        }
                        else
                        {
                            lb.Items.Add(string.Format("未查询到性别为“{0}”的有关内容", tb.Text.ToString()));
                            label.Content = "";
                        }
                        break;
                    case " 宿舍号":
                        string qian, hou;
                        string zhan = "";
                        if (tb.Text.ToString().Length == 6)
                        {
                            qian = tb.Text.ToString().Remove(1);
                            hou = tb.Text.ToString().Remove(0, 4);
                            zhan = qian + "," + hou;
                        }
                        else
                        {
                            qian = tb.Text.ToString().Remove(2);
                            hou = tb.Text.ToString().Remove(0, 4);
                            zhan = qian + "," + hou;
                        }
                       
                        var s4 = from q in x.Stu
                                 where q.Sdormitory == zhan
                                 select q;
                        lb.Items.Clear();
                        if (s4.Count() > 0)
                        {
                            int ppp4 = 0;
                            foreach (var item in s4)
                            {
                                ppp4++;
                                string[] zz = item.Sdormitory.Split(',');
                                string pz = zz[0] + "号楼" + zz[1];
                                lb.Items.Add(string.Format("姓名：{0}，性别：{1}，出生日期：{6}，学号：{5}，宿舍号：{2}，电话：{3}，学院：{4}，入学日期：{7}", item.Sname, item.Sgender, pz, item.Stel, item.Smajor, item.Sno, item.Sbrithday, item.Sdate));
                            }
                            label.Content = "共检索到了" + ppp4 + "条学生的数据";
                        }
                        else
                        {
                            lb.Items.Add(string.Format("未查询到宿舍号为“{0}”的有关内容", tb.Text.ToString()));
                            label.Content = "";
                        }
                        break;
                    default:
                        lb.Items.Clear();
                        lb.Items.Add("请选择你想查询的内容");
                        label.Content = "";
                        break;

                }
            }
            else
            {
                lb.Items.Clear();
                lb.Items.Add("请选择你想查询的内容");
                label.Content = "";
            }
            
        }

        private void Find()
        {
            var s = from q in x.Stu
                    select q;
            int ppp = 0;
            foreach (var item in s)
            {
                ppp++;
                string[] zz = item.Sdormitory.Split(',');
                string pz = zz[0] + "号楼" + zz[1];
                lb.Items.Add(string.Format("姓名：{0}，性别：{1}，出生日期：{6}，学号：{5}，宿舍号：{2}，电话：{3}，学院：{4}，入学日期：{7}", item.Sname, item.Sgender, pz, item.Stel, item.Smajor, item.Sno, item.Sbrithday, item.Sdate));
            }
            label.Content = "共检索到了" + ppp + "条学生的数据";
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void cb_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string str = cb.SelectedItem.ToString();
            string[] sp = str.Split(':');
            str = sp[1];
            if (str == " 宿舍号")
            {
                showlb.Visibility = Visibility.Visible;
            }
            else
            {
                showlb.Visibility = Visibility.Hidden;
            }
        }
    }
}
