using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace InsertDataInBatches
{
    public partial class Main : Form
    {
        SqlConnection mssqlconn;
        SqlCommand mssqlcmd = new SqlCommand();

        MySqlConnection mysqlconn;
        MySqlCommand mysqlcmd = new MySqlCommand();


        public Main()
        {
            InitializeComponent();
        }

        #region 窗体加载事件
        private void Main_Load(object sender, EventArgs e)
        {
            txtboxHost.Text = "127.0.0.1";
            txtboxPort.Text = "1433";
            txtboxDatabase.Text = "pagination";
            txtboxUsername.Text = "qkk";
            txtboxPassword.Text = "qkk";
        }
        #endregion

        #region 数据库_连接按钮单击事件
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string host = txtboxHost.Text.Trim();
            string port = txtboxPort.Text.Trim();
            string database = txtboxDatabase.Text.Trim();
            string username = txtboxUsername.Text.Trim();
            string password = txtboxPassword.Text.Trim();

            if (radiobtnMSSQL.Checked == true)
            {
                string sqlconn = "server=" + host + "," + port + "; database=" + database + "; uid=" + username + "; pwd=" + password + "";
                try
                {
                    mssqlconn = new SqlConnection(sqlconn);
                    mssqlconn.Open();
                    //MessageBox.Show(mssqlconn.State.ToString());//Open
                    if (mssqlconn.State == ConnectionState.Open)
                    {
                        labConnectStatus.Text = "状态：已连接";
                        btnConnect.Enabled = false;
                        radiobtnMSSQL.Enabled = false;
                        radiobtnMYSQL.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (radiobtnMYSQL.Checked == true)
            {
                string sqlconn = "Host = " + host + "; Port = " + port + "; Database = " + database + "; Username = " + username + "; Password = " + password + "";
                try
                {
                    mysqlconn = new MySqlConnection(sqlconn);
                    mysqlconn.Open();
                    MessageBox.Show(mysqlconn.ConnectionTimeout.ToString());
                    //MessageBox.Show(mysqlconn.State.ToString());//Open
                    if (mysqlconn.State == ConnectionState.Open)
                    {
                        labConnectStatus.Text = "状态：已连接";
                        btnConnect.Enabled = false;
                        radiobtnMSSQL.Enabled = false;
                        radiobtnMYSQL.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region 数据库_断开按钮单击事件
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (radiobtnMSSQL.Checked == true)
            {
                mssqlconn.Close();
                labConnectStatus.Text = "状态：已断开";
                btnConnect.Enabled = true;
                radiobtnMSSQL.Enabled = true;
                radiobtnMYSQL.Enabled = true;
            }
            if (radiobtnMYSQL.Checked == true)
            {
                mysqlconn.Close();
                labConnectStatus.Text = "状态：已断开";
                btnConnect.Enabled = true;
                radiobtnMSSQL.Enabled = true;
                radiobtnMYSQL.Enabled = true;
            }
        }
        #endregion

        #region 数据库_单选按钮切换默认端口改变
        private void radiobtnMSSQL_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnMSSQL.Checked == true)
            {
                txtboxPort.Text = "1433";
            }
            else
            {
                txtboxPort.Text = "3306";
            }
        }
        #endregion
    }
}