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
using System.Text.RegularExpressions;

namespace InsertDataInBatches
{
    public partial class FrmMain : Form
    {
        /* 先把输入的SQL按照执行次数转成数组
         * 对数组中的每个元素判断是否有指定格式的字符串
         * -有就执行相应的逻辑操作：替换，累加等
         * -没有就返回
         * 多种情况写多个方法
         * ......
         */
        SqlConnection mssqlconn;
        SqlCommand mssqlcmd = new SqlCommand();

        MySqlConnection mysqlconn;
        //MySqlCommand mysqlcmd = new MySqlCommand();

        Regex rgGetID = new Regex("{{id:\\d\\d*}}");//{{id:7}}取整块
        Regex rgGetNum = new Regex("(?<={{id:).*?(?=}})");//{{id:7}}取冒号后的数字

        Regex rgGetRandom = new Regex("{{\\[(\\d+)(\\.\\d+)?-(\\d+)(\\.\\d+)?]}}");//{{[1.22-22]}}取整块
        Regex rgGetRandomRange = new Regex("(?<={{\\[)(\\d+)(\\.\\d+)?-(\\d+)(\\.\\d+)?(?=]}})");//{{[1.22-22]}}取[]中的随机范围

        Regex rgGetNewID = new Regex("{{newid}}");//{{newid}}取整块

        string[] sqlQuerys;

        public FrmMain()
        {
            InitializeComponent();
        }

        #region 窗体加载事件
        private void FrmMain_Load(object sender, EventArgs e)
        {
            radiobtnMYSQL.Checked = true;

            txtboxHost.Text = "127.0.0.1";
            txtboxPort.Text = "3306";
            txtboxDatabase.Text = "pagination";
            txtboxUsername.Text = "qkk";
            txtboxPassword.Text = "qkk";

            txtboxNumberOfExecutions.Text = "2";
            //richtxtboxInsertSQL.Text = "INSERT INTO `pagination`.`info`(`xxx`) VALUES ('{{id:7}}'){{id:7}}";
            richtxtboxInsertSQL.Text = "INSERT INTO `pagination`.`info`(`xxx`) VALUES ('test{{id:7}}')";
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
                string sqlconn = string.Empty;
                if (chkboxPort.Checked == true)//指定端口
                {
                    sqlconn = "server=" + host + "," + port + "; database=" + database + "; uid=" + username + "; pwd=" + password + "";
                }
                else//不指定端口
                {
                    sqlconn = "server=" + host + "; database=" + database + "; uid=" + username + "; pwd=" + password + "";
                }
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
                        txtboxHost.Enabled = false;
                        chkboxPort.Enabled = false;
                        txtboxPort.Enabled = false;
                        txtboxDatabase.Enabled = false;
                        txtboxUsername.Enabled = false;
                        txtboxPassword.Enabled = false;
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
                string sqlconn = string.Empty;
                if (chkboxPort.Checked == true)//指定端口
                {
                    sqlconn = "Host = " + host + "; Port = " + port + "; Database = " + database + "; Username = " + username + "; Password = " + password + "";
                }
                else//不指定端口
                {
                    sqlconn = "Host = " + host + "; Database = " + database + "; Username = " + username + "; Password = " + password + "";
                }
                try
                {
                    mysqlconn = new MySqlConnection(sqlconn);
                    mysqlconn.Open();
                    //MessageBox.Show(mysqlconn.ConnectionTimeout.ToString());
                    //MessageBox.Show(mysqlconn.State.ToString());//Open
                    if (mysqlconn.State == ConnectionState.Open)
                    {
                        labConnectStatus.Text = "状态：已连接";
                        btnConnect.Enabled = false;
                        radiobtnMSSQL.Enabled = false;
                        radiobtnMYSQL.Enabled = false;
                        txtboxHost.Enabled = false;
                        chkboxPort.Enabled = false;
                        txtboxPort.Enabled = false;
                        txtboxDatabase.Enabled = false;
                        txtboxUsername.Enabled = false;
                        txtboxPassword.Enabled = false;
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
                txtboxHost.Enabled = true;
                chkboxPort.Enabled = true;
                txtboxPort.Enabled = true;
                txtboxDatabase.Enabled = true;
                txtboxUsername.Enabled = true;
                txtboxPassword.Enabled = true;
            }
            if (radiobtnMYSQL.Checked == true)
            {
                mysqlconn.Close();
                labConnectStatus.Text = "状态：已断开";
                btnConnect.Enabled = true;
                radiobtnMSSQL.Enabled = true;
                radiobtnMYSQL.Enabled = true;
                txtboxHost.Enabled = true;
                chkboxPort.Enabled = true;
                txtboxPort.Enabled = true;
                txtboxDatabase.Enabled = true;
                txtboxUsername.Enabled = true;
                txtboxPassword.Enabled = true;
            }
        }
        #endregion

        #region 数据库_单选按钮切换默认端口改变
        private void radiobtnMSSQL_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtnMSSQL.Checked == true)
            {
                txtboxPort.Text = "1433";

                txtboxHost.Text = "127.0.0.1";
                txtboxPort.Text = "1433";
                txtboxDatabase.Text = "qktest";
                txtboxUsername.Text = "sa";
                txtboxPassword.Text = "11111";
                richtxtboxInsertSQL.Text = "INSERT INTO [qktest].[dbo].[forinsert]([xxx]) VALUES ('test{{id:7}}');";
            }
            else
            {
                txtboxPort.Text = "3306";

                txtboxHost.Text = "127.0.0.1";
                txtboxPort.Text = "3306";
                txtboxDatabase.Text = "pagination";
                txtboxUsername.Text = "qkk";
                txtboxPassword.Text = "qkk";
                richtxtboxInsertSQL.Text = "INSERT INTO `pagination`.`info`(`xxx`) VALUES ('test{{id:7}}');";
            }
        }
        #endregion

        private void btnStartInserting_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(getRegexSQL(richtxtboxInsertSQL.Text.Trim(), Convert.ToInt32(txtboxNumberOfExecutions.Text.Trim())));
            //MessageBox.Show(rgGetNewID.IsMatch(richtxtboxInsertSQL.Text).ToString());
            //MessageBox.Show(getRegexSQL(richtxtboxInsertSQL.Text.Trim(), Convert.ToInt32(txtboxNumberOfExecutions.Text.Trim())));

            if (checkConnect(labConnectStatus.Text) == false)
            {
                MessageBox.Show("请先连接数据库！");
                btnConnect.Focus();
            }
            else
            {
                if (string.IsNullOrEmpty(richtxtboxInsertSQL.Text.Trim()))
                {
                    MessageBox.Show("insert语句不能为空！");
                    richtxtboxInsertSQL.Focus();
                }
                else
                {
                    //SqlHelper sqlhelp = new SqlHelper();
                    /*int NumberOfExecutions = Convert.ToInt32(txtboxNumberOfExecutions.Text);
                    string[] sqlQuerys = new string[NumberOfExecutions];
                    for (int i = 0; i < NumberOfExecutions; i++)
                    {
                        //sqlQuerys[i] = richtxtboxInsertSQL.Text.Trim();
                        sqlQuerys[i] = getRegexSQL(richtxtboxInsertSQL.Text.Trim(), Convert.ToInt32(txtboxNumberOfExecutions.Text.Trim()));
                    }*/

                    #region 换方法实现，已注释
                    /*if (rgGetID.IsMatch(richtxtboxInsertSQL.Text.Trim()) == true)
                    {
                        sqlQuerys = getRegexSQL(richtxtboxInsertSQL.Text.Trim(), Convert.ToInt32(txtboxNumberOfExecutions.Text.Trim())).Trim().Split('\n');
                        //MessageBox.Show(sqlQuerys.Length.ToString() + "\n" + sqlQuerys[0]);
                    }
                    else
                    {
                        int n = Convert.ToInt32(txtboxNumberOfExecutions.Text.Trim());
                        sqlQuerys = new string[n];
                        for (int i = 0; i < n; i++)
                        {
                            sqlQuerys[i] = richtxtboxInsertSQL.Text.Trim();
                        }
                        //sqlQuerys = richtxtboxInsertSQL.Text.Trim().Split('\n');
                        MessageBox.Show(sqlQuerys.Length.ToString() + "\n" + sqlQuerys[0]);
                    }*/
                    #endregion

                    int times = Convert.ToInt32(txtboxNumberOfExecutions.Text.Trim());
                    sqlQuerys = new string[times];
                    for (int i = 0; i < times; i++)
                    {
                        sqlQuerys[i] = richtxtboxInsertSQL.Text.Trim();
                    }

                    #region 判断是否有匹配{{id:x}}
                    //判断是否有匹配{{id:x}}
                    if (rgGetID.IsMatch(sqlQuerys[0]))
                    {
                        //MessageBox.Show("true");
                        getResultID(sqlQuerys);
                    }
                    else
                    {
                        MessageBox.Show("没有匹配项{{id:x}}");
                    }
                    #endregion

                    #region 判断是否有匹配{{newid}}
                    //判断是否有匹配{{newid}}
                    if (rgGetNewID.IsMatch(sqlQuerys[0]))
                    {
                        //MessageBox.Show("true");
                        getGetNewID(sqlQuerys);
                    }
                    else
                    {
                        MessageBox.Show("没有匹配项{{newid}}");
                    }
                    #endregion

                    

                    //遍历数组
                    string q = ""; ;
                    foreach (var item in sqlQuerys)
                    {
                        q += item + "\n";
                    }
                    MessageBox.Show(q);

                    #region 使用MSSQL
                    if (radiobtnMSSQL.Checked == true)
                    {
                        try
                        {
                            richtxtboxResult.Text = "";
                            int result = getAffectRowsTransactionMSSQL(sqlQuerys, mssqlconn);
                            if (result == 1)
                            {
                                richtxtboxResult.Text += "\n插入成功，插入结束";
                            }
                            else
                            {
                                richtxtboxResult.Text += "\n插入失败，插入结束";
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
                        try
                        {
                            richtxtboxResult.Text = "";
                            int result = getAffectRowsTransactionMySQL(sqlQuerys, mysqlconn);
                            if (result == 1)
                            {
                                richtxtboxResult.Text += "\n插入成功，插入结束";
                            }
                            else
                            {
                                richtxtboxResult.Text += "\n插入失败，插入结束";
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    #endregion
                }
            }
        }

        #region 将{{id:x}}替换为x
        /// <summary>
        /// 将{{id:x}}替换为x
        /// </summary>
        /// <param name="sourceSQL">原始SQL数组</param>
        /// <returns>替换完的数组</returns>
        private string[] getResultID(string[] sourceSQL)
        {

            Match matchrgGetID;
            Match matchGetNum;
            for (int i = 0; i < sourceSQL.Length; i++)
            {
                matchrgGetID = rgGetID.Match(sourceSQL[i]);//{{id:7}}取整块
                matchGetNum = rgGetNum.Match(sourceSQL[i]);//{{id:7}}取冒号后的数字
                sourceSQL[i] = sourceSQL[i].Replace(matchrgGetID.Groups[0].Value, (Convert.ToInt32(matchGetNum.Groups[0].Value) + i).ToString());
            }

            return sourceSQL;
        }
        #endregion

        #region 将{{newid}}替换为uuid
        /// <summary>
        /// 将{{newid}}替换为uuid
        /// </summary>
        /// <param name="sourceSQL">原始SQL数组</param>
        /// <returns>替换完的数组</returns>
        private string[] getGetNewID(string[] sourceSQL)
        {

            Match matchrgGetNewID;
            for (int i = 0; i < sourceSQL.Length; i++)
            {
                matchrgGetNewID = rgGetNewID.Match(sourceSQL[i]);//{{newid}}取整块
                sourceSQL[i] = sourceSQL[i].Replace(matchrgGetNewID.Groups[0].Value, Guid.NewGuid().ToString());
            }

            return sourceSQL;
        }
        #endregion

        #region 替换{{id:x}}为指定数字，换流程，已注释
        /*private string getRegexSQL(string sourceSQL, int times)
        {
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
        }*/
        #endregion

        #region 判断是否连接数据库
        /// <summary>
        /// 判断是否连接数据库
        /// </summary>
        /// <param name="connectStatus">连接状态</param>
        /// <returns>true：已连接，false：已断开</returns>
        private bool checkConnect(string connectStatus)
        {
            if (connectStatus == "状态：已连接")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region MSSQL、MySQL插数据事务
        #region MSSQL
        /// <summary>
        /// （支持事务）传入SQL，返回该命令所影响行数，其他类型语句（建表）、回滚，返回值为-1
        /// </summary>
        /// <param name="Querys">sql数组</param>
        /// <param name="SQLConn">SqlConnection连接</param>
        /// <returns></returns>
        public int getAffectRowsTransactionMSSQL(string[] Querys, SqlConnection SQLConn)
        {
            int result = 0;
            int i = 0;
            string temp = string.Empty;
            SqlCommand comm = new SqlCommand();
            comm.Connection = SQLConn;
            comm.Transaction = SQLConn.BeginTransaction();
            try
            {
                for (i = 0; i < Querys.Length; i++)
                {
                    comm.CommandText = Querys[i];
                    result = comm.ExecuteNonQuery();
                    temp = "执行成功：" + Querys[i];
                    if (i + 1 < Querys.Length)
                    {
                        temp += "\n" + temp;
                    }
                }
                comm.Transaction.Commit();

                return result;
            }
            catch (Exception ex)
            {
                comm.Transaction.Rollback();
                if (result == 1)
                {
                    temp += "\n";
                }
                result = 0;
                temp += "\n执行失败：" + Querys[i] + "\n失败原因：" + ex.Message;
                return result;
                //throw ex;
            }
            finally
            {
                richtxtboxResult.Text = temp;
                //MySQLConn.Close();
            }
        }
        #endregion

        #region MySQL
        /// <summary>
        /// （支持事务）传入SQL，返回该命令所影响行数，其他类型语句（建表）、回滚，返回值为-1
        /// </summary>
        /// <param name="Querys">sql数组</param>
        /// <param name="MySQLConn">MySqlConnection连接</param>
        /// <returns></returns>
        public int getAffectRowsTransactionMySQL(string[] Querys, MySqlConnection MySQLConn)
        {
            int result = 0;
            int i = 0;
            string temp = string.Empty;
            MySqlCommand comm = new MySqlCommand();
            comm.Connection = MySQLConn;
            comm.Transaction = MySQLConn.BeginTransaction();
            try
            {
                for (i = 0; i < Querys.Length; i++)
                {
                    comm.CommandText = Querys[i];
                    result = comm.ExecuteNonQuery();
                    temp = "执行成功：" + Querys[i];
                    if (i + 1 < Querys.Length)
                    {
                        temp += "\n" + temp;
                    }
                }
                comm.Transaction.Commit();

                return result;
            }
            catch (Exception ex)
            {
                comm.Transaction.Rollback();
                if (result == 1)
                {
                    temp += "\n";
                }
                result = 0;
                temp += "执行失败：" + Querys[i] + "\n失败原因：" + ex.Message;
                return result;
                //throw ex;

            }
            finally
            {
                richtxtboxResult.Text = temp;
                //MySQLConn.Close();
            }
        }
        #endregion

        #endregion

        #region {{id:x}}按钮快速插入操作
        private void fastbtn_idIncreasing_Click(object sender, EventArgs e)
        {
            string str = "{{id:x}}";
            int i = richtxtboxInsertSQL.SelectionStart;
            string s = richtxtboxInsertSQL.Text;
            s = s.Insert(i, str);
            richtxtboxInsertSQL.Text = s;
            richtxtboxInsertSQL.SelectionStart = i + str.Length;
            richtxtboxInsertSQL.Focus();
        }
        #endregion
    }
}