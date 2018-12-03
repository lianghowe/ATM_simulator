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
    public partial class Form1_init : Form
    {
        public Form1_init()
        {
            InitializeComponent();
        }

        //插卡提交
        private void button1_Click(object sender, EventArgs e)
        {
            id = comboBox1.SelectedIndex + 1;
            this.Hide();
            (new Check()).Show();
        }

        //加载id
        private void form1_load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM user_data", Connect.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            

            while (reader.Read())
                comboBox1.Items.Add(reader.GetInt32(0)+"");
            comboBox1.SelectedIndex = 0;
            reader.Close();
        }

        public static int id;
    }
}
