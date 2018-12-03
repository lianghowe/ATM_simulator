using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace simulator
{
    public class Connect
    {
        public static SqlConnection conn;
        public static void Connect_data()
        {
            try
            {   //声明一个用于存储连接数据库的字符串
                string ConStr = "server=.;database=atm_data;uid=sa;pwd=newpass";
                //创建一个SqlConnection对象
                conn = new SqlConnection(ConStr);
                //连接指定的数据库
                conn.Open();

                if (conn.State != ConnectionState.Open)            
                {
                    MessageBox.Show("连接数据库失败");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
