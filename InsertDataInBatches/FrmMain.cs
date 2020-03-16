﻿using System;
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
using System.Text.RegularExpressions;

namespace InsertDataInBatches
{
    public partial class FrmMain : Form
    {
        SqlConnection mssqlconn;
        SqlCommand mssqlcmd = new SqlCommand();

        MySqlConnection mysqlconn;
        //MySqlCommand mysqlcmd = new MySqlCommand();


        public FrmMain()
        {
            InitializeComponent();
        }

        #region 窗体加载事件
        private void FrmMain_Load(object sender, EventArgs e)
        {
            txtboxHost.Text = "127.0.0.1";
            txtboxPort.Text = "1433";
            txtboxDatabase.Text = "pagination";
            txtboxUsername.Text = "qkk";
            txtboxPassword.Text = "qkk";

            txtboxNumberOfExecutions.Text = "2";
            richtxtboxInsertSQL.Text = "INSERT INTO `pagination`.`info`(`xxx`) VALUES ('{{id:7}}'){{id:7}}";
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

            #region 使用MSSQL
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
            #endregion
            #region 使用MYSQL
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
            #endregion
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

        private void btnStartInserting_Click(object sender, EventArgs e)
        {
            MessageBox.Show(getRegexSQL(richtxtboxInsertSQL.Text.Trim(), Convert.ToInt32(txtboxNumberOfExecutions.Text.Trim())));

            SqlHelper sqlhelp = new SqlHelper();
            int NumberOfExecutions = Convert.ToInt32(txtboxNumberOfExecutions.Text);
            string[] sqlQuerys = new string[NumberOfExecutions];
            for (int i = 0; i < NumberOfExecutions; i++)
            {
                sqlQuerys[i] = richtxtboxInsertSQL.Text.Trim();
            }
            richtxtboxResult.Text = sqlhelp.getAffectRowsTransaction(sqlQuerys, mysqlconn).ToString();
        }

        private string getRegexSQL(string sourceSQL, int times)
        {
            Regex rgGetNum = new Regex("(?<={{id:).*?(?=}})");//{{id:7}}取冒号后的数字
            Regex rgGetID = new Regex("{{id:[0-9]*}}");//{{id:7}}取{{}}

            Match matchGetNum = rgGetNum.Match(sourceSQL);
            Match matchrgGetID = rgGetID.Match(sourceSQL);

            string regexSQL = "";
            string result = "";
            //int count = GetCountByAppointString(sourceSQL, matchrgGetID.Groups[0].Value, "for");
            int count = Regex.Matches(sourceSQL, matchrgGetID.Groups[0].Value).Count;
            regexSQL = sourceSQL;
            for (int i = 0; i < times; i++)
            {
                for (int x = 0; x < count; x++)
                {
                    regexSQL = sourceSQL.Replace(matchrgGetID.Groups[0].Value, (Convert.ToInt32(matchGetNum.Groups[0].Value) + i).ToString());
                }
                result += regexSQL + "\n";
            }

            return result;
        }
    }
}