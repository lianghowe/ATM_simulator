using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simulator
{
    public partial class Check : Form
    {
        public Check()
        {
            InitializeComponent();
        }

        //倒计时
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (second > 0)
                label3.Text = --second + " s";
            else
            {
                (new Form1_init()).Show();
                this.Visible = false;
                this.timer1.Stop();
            }
        }

        int second = 30;

        //启动倒计时
        private void Check_load(object sender, EventArgs e)
        {
            this.timer1.Start();
            label3.Text = "30 s";
        }

        //确认
        private void button11_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM user_data where id="+Form1_init.id, Connect.conn);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            password = (string)reader.GetString(1);
            balence = (double)reader.GetDouble(2);

            reader.Close();

            //密码正确
            if (password == user_password)
            {
                this.Visible = false;
                (new Meau()).Show();
                this.timer1.Stop();
            }

            //错误
            else
            {
                count++;
                textBox2.Text = "";
                user_password = "";
            }

            //吞卡
            if(count==3)
            {
                MessageBox.Show("卡已吞！", "小AI提醒");
                this.Visible = false;
                (new Form1_init()).Show();
                this.timer1.Stop();
            }
            

        }

        //计数3次吞卡
        int count = 0;

        //密码与余额
        public static string password;
        public static double balence;

        //输入密码
        string user_password;

        //1
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text += "*";
            user_password += 1;
        }

        //2
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text += "*";
            user_password += 2;
        }

        //3
        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text += "*";
            user_password += 3;
        }

        //4
        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text += "*";
            user_password += 4;
        }

        //5
        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text += "*";
            user_password += 5;
        }

        //6
        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text += "*";
            user_password += 6;
        }

        //7
        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text += "*";
            user_password += 7;
        }

        //8
        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Text += "*";
            user_password += 8;
        }

        //9
        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Text += "*";
            user_password += 9;
        }

        //0
        private void button10_Click(object sender, EventArgs e)
        {
            textBox2.Text += "*";
            user_password += 0;
        }

        //重置
        private void button12_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            user_password = "";
        }

        //退卡
        private void button13_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            (new Form1_init()).Show();
            this.timer1.Stop();
        }
    }
}
