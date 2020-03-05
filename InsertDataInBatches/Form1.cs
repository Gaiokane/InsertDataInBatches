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

        private void Main_Load(object sender, EventArgs e)
        {
            txtboxHost.Text = "127.0.0.1";
            txtboxDatabase.Text = "pagination";
            txtboxUsername.Text = "qkk";
            txtboxPassword.Text = "qkk";
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string host = txtboxHost.Text.Trim();
            string database = txtboxDatabase.Text.Trim();
            string username = txtboxUsername.Text.Trim();
            string password = txtboxPassword.Text.Trim();

            if (radiobtnMSSQL.Checked == true)
            {
                string sqlconn = "server=" + host + ";database=" + database + ";uid=" + username + ";pwd=" + password + "";
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
                string sqlconn = "Host = " + host + "; Database = " + database + "; Username = " + username + "; Password = " + password + "";
                try
                {
                    mysqlconn = new MySqlConnection(sqlconn);
                    mysqlconn.Open();
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
    }
}