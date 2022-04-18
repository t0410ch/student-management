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
    /// Newstudents.xaml 的交互逻辑
    /// </summary>
    public partial class Newstudents : Window
    {
        Db1Entities x = new Db1Entities();
        public Newstudents()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            gend.Items.Add("男");
            gend.Items.Add("女");
            doyuan.Items.Add("计算机与信息工程学院");
            doyuan.Items.Add("国际教育学院");
            doyuan.Items.Add("软件学院");
            doyuan.Items.Add("马克思主义学院");
            doyuan.Items.Add("英语学院");
            doyuan.Items.Add("音乐学院");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (stel.Text.ToString().Length == 11)
                {
                    Stu xp1 = new Stu()
                    {
                        Sno = this.sno.Text,
                        Sbrithday = Convert.ToDateTime(this.sbri.Text),
                        Sdate = Convert.ToDateTime(this.sdate.Text),
                        Sdormitory = this.sdo.Text + "," + this.sdo1.Text,
                        Sgender = this.gend.SelectedItem.ToString(),
                        Smajor = this.doyuan.SelectedItem.ToString(),
                        Sname = this.sname.Text,
                        Stel = this.stel.Text

                    };
                    x.Stu.Add(xp1);
                    x.SaveChanges();
                    MessageBox.Show("添加成功！");
                }
                else
                {
                    MessageBox.Show("电话号码应为11位！");
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
