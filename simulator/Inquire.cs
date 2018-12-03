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
    public partial class Inquire : Form
    {
        public Inquire()
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

        //初始化，启动倒计时
        private void Inquire_load(object sender, EventArgs e)
        {
            this.timer1.Start();
            label2.Text = Meau.balence + "";
            label3.Text = "30 s";
        }
    }
}
