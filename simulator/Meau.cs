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
    public partial class Meau : Form
    {
        public Meau()
        {
            InitializeComponent();
        }
       
        public static double balence;

        //刷新balence
        private void Meau_load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM user_data where id=" + Form1_init.id, Connect.conn);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            balence = (double)reader.GetDouble(2);

            reader.Close();

            //启动倒计时
            this.timer1.Start();
            label3.Text = "30 s";
        }

        //查询
        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            (new Inquire()).Show();
            this.timer1.Stop();
        }

        //存款
        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            (new Deposit()).Show();
            this.timer1.Stop();
        }

        //退卡
        private void button5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            (new Form1_init()).Show();
            this.timer1.Stop();
        }

        //倒计时
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (second >= 1)
                label3.Text = --second + " s";
            else
            {
                (new Form1_init()).Show();
                this.Visible = false;
                this.timer1.Stop();
            }
        }

        int second = 30;     

        //转账
        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            (new Tansfer()).Show();
            this.timer1.Stop();
        }

        //取款
        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            (new Withdraw()).Show();
            this.timer1.Stop();
        }
    }
}
