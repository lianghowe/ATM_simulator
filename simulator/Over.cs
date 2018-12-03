using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simulator
{
    public partial class Over : Form
    {
        public Over()
        {
            InitializeComponent();
        }

        //返回
        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            (new Meau()).Show();
            this.timer1.Stop();
        }

        //退卡
        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            (new Form1_init()).Show();
            this.timer1.Stop();
        }      

        //打印凭条
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK,收好！");
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
        private void Over_load(object sender, EventArgs e)
        {
            this.timer1.Start();
            label3.Text = "30 s";
        }
    }
}
