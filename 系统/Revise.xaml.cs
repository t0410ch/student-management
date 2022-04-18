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
    /// Revise.xaml 的交互逻辑
    /// </summary>
    public partial class Revise : Window
    {
        public string reseve = "";
        string[] reseva_s;
        string sno;
        Db1Entities x = new Db1Entities();
        public Revise(string s)
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            reseve = s;
            reseva_s = reseve.Split('，');
            string[] sp=new string[2];
            sp = reseva_s[0].Split('：');
            Sname.Text = sp[1];
            sp = reseva_s[1].Split('：');
            Sgen.Text = sp[1];
            sp = reseva_s[2].Split('：');
            Sbri.Text = sp[1];
            sp = reseva_s[3].Split('：');
            Sno.Text = sp[1];
            sno= sp[1];
            sp = reseva_s[4].Split('：');
            string qian, hou;
            if(sp[1].ToString().Length==6)
            {
                qian = sp[1].Remove(1);
                hou = sp[1].Remove(0, 4);
            }
            else
            {
                qian = sp[1].Remove(2);
                hou = sp[1].Remove(0, 4);
            }
            Sco1.Text = qian;
            Sco.Text = hou;
            sp = reseva_s[5].Split('：');
            Stel.Text = sp[1];
            sp = reseva_s[6].Split('：');
            Smajor.Text = sp[1];
            sp = reseva_s[7].Split('：');
            Sdate.Text = sp[1];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from t in x.Stu
                        where t.Sno == sno
                        select t;
            foreach (var v in query)
            {

                x.Stu.Remove(v);
               
            }
            try
            {
                if (Stel.Text.ToString().Length == 11)
                {
                    x.SaveChanges();
                    Stu xp1 = new Stu()
                    {
                        Sno = this.Sno.Text,
                        Sbrithday = Convert.ToDateTime(this.Sbri.Text),
                        Sdate = Convert.ToDateTime(this.Sdate.Text),
                        Sdormitory = this.Sco1.Text + "," + this.Sco.Text,
                        Sgender = this.Sgen.Text,
                        Smajor = this.Smajor.Text,
                        Sname = this.Sname.Text,
                        Stel = this.Stel.Text

                    };
                    x.Stu.Add(xp1);
                    x.SaveChanges();
                    MessageBox.Show("修改成功！");
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
