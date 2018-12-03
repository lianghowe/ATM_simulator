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
    public partial class Tansfer : Form
    {
        public Tansfer()
        {
            InitializeComponent();
        }

        //重置
        private void button12_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }


        //退卡
        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            (new Form1_init()).Show();
            this.timer1.Stop();
        }

        //1
        private void button14_Click(object sender, EventArgs e)
        {
            textBox2.Text += 1;
        }

        //2
        private void button13_Click(object sender, EventArgs e)
        {
            textBox2.Text += 2;
        }

        //3
        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text += 3;
        }

        //4
        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text += 4;
        }

        //5
        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text += 5;
        }

        //6
        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text += 6;
        }

        //7
        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text += 7;
        }

        //8
        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Text += 8;
        }

        //9
        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Text += 9;
        }

        //0
        private void button10_Click(object sender, EventArgs e)
        {
            textBox2.Text += 0;
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
        private void Tansfer_load(object sender, EventArgs e)
        {
            this.timer1.Start();
            label3.Text = "30 s";

            //加载id
            SqlCommand cmd = new SqlCommand("SELECT * FROM user_data", Connect.conn);
            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
                if(reader.GetInt32(0)!=Form1_init.id)
                    comboBox1.Items.Add(reader.GetInt32(0) + "");
            comboBox1.SelectedIndex = 0;
            reader.Close();
        }

        //确认
        private void button11_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox2.Text) > Meau.balence)
                MessageBox.Show("余额不足!");
            else
            {
                SqlCommand cmd = new SqlCommand("update user_data set balence=balence-" + int.Parse(textBox2.Text) + "where id=" + Form1_init.id, Connect.conn);
                cmd.ExecuteNonQuery();
                this.Visible = false;
                (new Over()).Show();
                this.timer1.Stop();
            }
        }
    }
}
