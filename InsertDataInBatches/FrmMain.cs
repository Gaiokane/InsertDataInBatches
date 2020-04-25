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
using Gaiokane;

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

        /* 此块同rgGetDateTimeAll
         * Regex rgGetDateTimeDayAll = new Regex("{{timed(\\+|\\-)\\d:\\d{4}-(0?[1-9]|1[0-2])-((0?[1-9])|((1|2)[0-9])|30|31) (((0|1)[0-9])|(2[0-3])):((0|1|2|3|4|5)[0-9]):((0|1|2|3|4|5)[0-9])}}");//{{timed+-7:2020-03-29 20:00:00}}取整块 日
         * Regex rgGetDateTimeHourAll = new Regex("{{timeh(\\+|\\-)\\d:\\d{4}-(0?[1-9]|1[0-2])-((0?[1-9])|((1|2)[0-9])|30|31) (((0|1)[0-9])|(2[0-3])):((0|1|2|3|4|5)[0-9]):((0|1|2|3|4|5)[0-9])}}");//{{timeh+-7:2020-03-29 20:00:00}}取整块 小时
         * Regex rgGetDateTimeMinAll = new Regex("{{timem(\\+|\\-)\\d:\\d{4}-(0?[1-9]|1[0-2])-((0?[1-9])|((1|2)[0-9])|30|31) (((0|1)[0-9])|(2[0-3])):((0|1|2|3|4|5)[0-9]):((0|1|2|3|4|5)[0-9])}}");//{{timem+-7:2020-03-29 20:00:00}}取整块 分钟
         * Regex rgGetDateTimeSecAll = new Regex("{{times(\\+|\\-)\\d:\\d{4}-(0?[1-9]|1[0-2])-((0?[1-9])|((1|2)[0-9])|30|31) (((0|1)[0-9])|(2[0-3])):((0|1|2|3|4|5)[0-9]):((0|1|2|3|4|5)[0-9])}}");//{{times+-7:2020-03-29 20:00:00}}取整块 秒
         */

        Regex rgGetDateTimeAll = new Regex("{{time(d|h|m|s)(\\+|\\-)\\d*:\\d{4}-(0?[1-9]|1[0-2])-((0?[1-9])|((1|2)[0-9])|30|31) (((0|1)[0-9])|(2[0-3])):((0|1|2|3|4|5)[0-9]):((0|1|2|3|4|5)[0-9])}}");//{{time(d|h|m|s)(+|-)7:2020-03-29 20:00:00}}取整块 日、小时、分钟、秒
        Regex rgGetDateTimeDiff = new Regex("(d|h|m|s)(\\+|\\-)\\d*");//{{timed+-7:2020-03-29 20:00:00}}取(d|h|m|s)(+|-)数字
        Regex rgGetDateTime = new Regex("\\d{4}-(0?[1-9]|1[0-2])-((0?[1-9])|((1|2)[0-9])|30|31) (((0|1)[0-9])|(2[0-3])):((0|1|2|3|4|5)[0-9]):((0|1|2|3|4|5)[0-9])");//{{timed+-7:2020-03-29 20:00:00}}取时间

        string[] sqlQuerys;

        public FrmMain()
        {
            InitializeComponent();
        }

        #region 窗体加载事件
        private void FrmMain_Load(object sender, EventArgs e)
        {
            /*
             * 登录成功后根据所选数据库类型，先查询是否有过，有的话+=，没有新增
             * <add key="MSSQL_Host" value="192.168.1.1;192.168.1.1\SQL2012" />
             * <add key="MySQL_Host" value="127.0.0.1" />
             * 登录成功后根据所选数据库类型，先查询是否有值，有的话+=，没有新增
             * <add key="MSSQL_DB_192.168.1.1" value="DB1;DB2" />
             * <add key="MySQL_DB_127.0.0.1" value="DB1" />
             * 登录成功后根据所选数据库类型，先查询是否有值，有的话+=，没有新增
             * <add key="MSSQL_Host_192.168.1.1" value="False;1433;testdb;q;qq" />
             * <add key="MySQL_Host_127.0.0.1" value="False;3306;systemstatus;qkk;qkk" />
             * 
             * 根据所选radiobtn，点击host文本框显示MSSQL_Host/MySQL_Host下的所有连接过的记录
             * 根据所选host，isport、port、username、password分别显示对应记录
             * 根据所选host，点击database文本框显示对应host下连接过的数据库记录
             */
            //MessageBox.Show(ConfigSettings.getSameValueLenth("MySQL_Host", "1").ToString());
            /*
             * 解决方案资源管理器
             * Properties->Resources.resx打开
             * 添加资源->添加现有文件
             * 添加完后使用以下代码调用
             */
            this.Icon = Properties.Resources._20200417083355795_easyicon_net_128;

            //MessageBox.Show(getDotLength(1.1).ToString());

            setTestConn();

            #region 读取并设置上一次数据库连接
            string[] LastConnectionStrings = ConfigSettings.getLastConnectionStrings();
            if (LastConnectionStrings.Length != 7)
            {
                ConfigSettings.setLastConnectionStrings(1, "127.0.0.1", false, "3306", "pagination", "qkk", "qkk");
                MessageBox.Show("最新数据库连接值不正确，已重置为默认值，请重新运行该程序！");
                Application.Exit();
            }
            else
            {
                bool isPort = false;
                if (LastConnectionStrings[2] == "True")
                {
                    isPort = true;
                }
                else if (LastConnectionStrings[2] == "False")
                {
                    isPort = false;
                }
                else
                {
                    isPort = false;
                }
                //int sqlType, string Host, bool isPort, string Port, string Database, string Username, string Password
                if (LastConnectionStrings[0] == "0")
                {
                    radiobtnMSSQL.Checked = true;
                    txtboxHost.Text = LastConnectionStrings[1];
                    chkboxPort.Checked = isPort;
                    txtboxPort.Text = LastConnectionStrings[3];
                    txtboxDatabase.Text = LastConnectionStrings[4];
                    txtboxUsername.Text = LastConnectionStrings[5];
                    txtboxPassword.Text = LastConnectionStrings[6];
                }
                else if (LastConnectionStrings[0] == "1")
                {
                    radiobtnMYSQL.Checked = true;
                    txtboxHost.Text = LastConnectionStrings[1];
                    chkboxPort.Checked = isPort;
                    txtboxPort.Text = LastConnectionStrings[3];
                    txtboxDatabase.Text = LastConnectionStrings[4];
                    txtboxUsername.Text = LastConnectionStrings[5];
                    txtboxPassword.Text = LastConnectionStrings[6];
                }
                else
                {
                    setTestConn();
                }
            }
            #endregion

            txtboxNumberOfExecutions.Text = "2";
            //richtxtboxInsertSQL.Text = "INSERT INTO `pagination`.`info`(`xxx`) VALUES ('{{id:7}}'){{id:7}}";
            richtxtboxInsertSQL.Text = "INSERT INTO `pagination`.`info`(`xxx`) VALUES ('test{{id:7}}'){{timed+777:2020-04-04 11:47:07}}";

            //快捷插入配置
            ConfigSettings.getQuickInsertSettingsByappSettings();
            ConfigSettings.setDefaultQuickInsertSettingsIfIsNullOrEmptyByappSettings();
            ConfigSettings.getQuickInsertSettingsByappSettings();
            RefreshQuickInsertCombox();

            //常用SQL配置
            ConfigSettings.getCommonlyUsedSQLByappSettings();
            ConfigSettings.setDefaultCommonlyUsedSQLIfIsNullOrEmptyByappSettings();
            ConfigSettings.getCommonlyUsedSQLByappSettings();
            RefreshCommonlyUsedSQLCombox();

            //RichTextBox增加右键菜单
            RichTextBoxMenu richTextBoxMenu_richtxtboxInsertSQL = new RichTextBoxMenu(richtxtboxInsertSQL);
            RichTextBoxMenu richTextBoxMenu_richtxtboxResult = new RichTextBoxMenu(richtxtboxResult);
        }
        #endregion

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                RefreshConnectionHistory();
                //自动弹出下拉框
                comboBox1.DroppedDown = true;
                //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
                Cursor = Cursors.Default;
            }
            else
            {
                comboBox1_DropDown(sender, e);
                comboBox1.DroppedDown = true;
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                RefreshConnectionHistory();
                //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
                Cursor = Cursors.Default;
            }
            else
            {
                comboBox1.Items.Clear();
                //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
                Cursor = Cursors.Default;
                string[] connectionItem = ConfigSettings.getConfigValueByKey("MySQL_Host");
                List<string> listNew = new List<string>();
                //遍历全部备查数据
                foreach (var item in connectionItem)
                {
                    if (item.Contains(comboBox1.Text))
                    {
                        //符合，插入ListNew
                        listNew.Add(item);
                    }
                }
                //combobox添加已经查到的关键词
                comboBox1.Items.AddRange(listNew.ToArray());
                //设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
                comboBox1.SelectionStart = comboBox1.Text.Length;
                //输入不匹配项，关闭下拉框，打开下拉框应根据输入的值模糊搜索，当前显示全部
            }
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            //当下拉框没值时，下拉框关闭时会报错，赋值就行
            if (comboBox1.Items.Count == 0)
            {
                RefreshConnectionHistory();
            }
        }

        private void RefreshConnectionHistory()
        {
            try
            {
                string[] connectionItem = ConfigSettings.getConfigValueByKey("MySQL_Host");
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(connectionItem);
                comboBox1.SelectionStart = comboBox1.Text.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region 设置测试用默认数据库连接
        private void setTestConn()
        {
            radiobtnMYSQL.Checked = true;
            txtboxHost.Text = "127.0.0.1";
            txtboxPort.Text = "3306";
            txtboxDatabase.Text = "pagination";
            txtboxUsername.Text = "qkk";
            txtboxPassword.Text = "qkk";
        }
        #endregion

        #region 快捷插入配置下拉框重新获取数据
        public void RefreshQuickInsertCombox()
        {
            cmbox_QuickInsert_List.Items.Clear();
            //string[] QuickInsert = ConfigSettings.QuickInsert.Split(';');
            string[] QuickInsert = ConfigSettings.getQuickInsertSettingsAllCodes();
            if (string.IsNullOrEmpty(QuickInsert[0]) == false)
            {
                foreach (var item in QuickInsert)
                {
                    string[] QuickInsertKeyValue = RWConfig.GetappSettingsValue(item, ConfigSettings.ConfigPath).Split(';');
                    cmbox_QuickInsert_List.Items.Add(QuickInsertKeyValue[0]);
                }
                if (cmbox_QuickInsert_List.Items.Count > 0)
                {
                    cmbox_QuickInsert_List.SelectedIndex = 0;
                }
            }
        }
        #endregion

        #region 常用SQL下拉框重新获取数据
        public void RefreshCommonlyUsedSQLCombox()
        {
            cmbox_CommonlyUsedSQL_List.Items.Clear();
            //string[] CommonlyUsedSQL = ConfigSettings.CommonlyUsedSQL.Split(';');
            string[] CommonlyUsedSQL = ConfigSettings.getCommonlyUsedSQLAllCodes();
            if (string.IsNullOrEmpty(CommonlyUsedSQL[0]) == false)
            {
                foreach (var item in CommonlyUsedSQL)
                {
                    string[] CommonlyUsedSQLKeyValue = RWConfig.GetappSettingsValue(item, ConfigSettings.ConfigPath).Split(';');
                    cmbox_CommonlyUsedSQL_List.Items.Add(CommonlyUsedSQLKeyValue[0]);
                }
                if (cmbox_CommonlyUsedSQL_List.Items.Count > 0)
                {
                    cmbox_CommonlyUsedSQL_List.SelectedIndex = 0;
                }
            }
        }
        #endregion

        #region 快捷插入-插入按钮点击事件 根据下拉框所选快捷功能，执行插入操作
        private void btn_QuickInsert_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(cmbox_QuickInsert_List.SelectedItem.ToString());
                string[] QuickInsert = ConfigSettings.QuickInsert.Split(';');
                foreach (var item in QuickInsert)
                {
                    string[] QuickInsertKeyValue = RWConfig.GetappSettingsValue(item, ConfigSettings.ConfigPath).Split(';');
                    if (cmbox_QuickInsert_List.SelectedItem.ToString() == QuickInsertKeyValue[0])
                    {
                        string str = QuickInsertKeyValue[1];
                        int index = richtxtboxInsertSQL.SelectionStart;
                        string s = richtxtboxInsertSQL.Text;
                        s = s.Insert(index, str);
                        richtxtboxInsertSQL.Text = s;
                        richtxtboxInsertSQL.SelectionStart = index + str.Length;
                        richtxtboxInsertSQL.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

                    //设置上一次连接字符串
                    if (ConfigSettings.setLastConnectionStrings(0, host, chkboxPort.Checked, port, database, username, password) == false)
                    {
                        MessageBox.Show("更新最后连接字符串出错！");
                    }

                    //保存连接成功的记录
                    if (ConfigSettings.saveConnectionString(0, host, chkboxPort.Checked, port, database, username, password) == false)
                    {
                        MessageBox.Show("保存连接记录出错！");
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

                    //设置上一次连接字符串
                    if (ConfigSettings.setLastConnectionStrings(1, host, chkboxPort.Checked, port, database, username, password) == false)
                    {
                        MessageBox.Show("更新最后连接字符串出错！");
                    }

                    //保存连接成功的记录
                    if (ConfigSettings.saveConnectionString(1, host, chkboxPort.Checked, port, database, username, password) == false)
                    {
                        MessageBox.Show("保存连接记录出错！");
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
            if (labConnectStatus.Text == "状态：已断开")
            {

            }
            else
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

                    #region 判断是否有匹配{{[1.22-22]}}
                    //判断是否有匹配{{id:x}}
                    if (rgGetRandom.IsMatch(sqlQuerys[0]))
                    {
                        //MessageBox.Show("true");
                        getRandomNum(sqlQuerys);
                    }
                    else
                    {
                        MessageBox.Show("没有匹配项{{[x-y]}}");
                    }
                    #endregion

                    #region 判断是否有匹配{{newid}}
                    //判断是否有匹配{{newid}}
                    if (rgGetNewID.IsMatch(sqlQuerys[0]))
                    {
                        //MessageBox.Show("true");
                        getNewID(sqlQuerys);
                    }
                    else
                    {
                        MessageBox.Show("没有匹配项{{newid}}");
                    }
                    #endregion

                    #region 判断是否有匹配{{time(d|h|m|s)(+|-)7:datetime}}
                    //判断是否有匹配{{time(d|h|m|s)(+|-)7:datetime}}
                    if (rgGetDateTimeAll.IsMatch(sqlQuerys[0]))
                    {
                        //MessageBox.Show("true");
                        getNewDateTime(sqlQuerys);
                    }
                    else
                    {
                        MessageBox.Show("没有匹配项{{time(d|h|m|s)(+|-)7:datetime}}");
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
            //以下有bug，只支持替换第一个匹配的正则，现更新为下方，while判断是否有匹配正则
            /*Match matchrgGetID;
            Match matchGetNum;
            for (int i = 0; i < sourceSQL.Length; i++)
            {
                matchrgGetID = rgGetID.Match(sourceSQL[i]);//{{id:7}}取整块
                matchGetNum = rgGetNum.Match(sourceSQL[i]);//{{id:7}}取冒号后的数字
                sourceSQL[i] = sourceSQL[i].Replace(matchrgGetID.Groups[0].Value, (Convert.ToInt32(matchGetNum.Groups[0].Value) + i).ToString());
            }*/

            Match matchrgGetID;
            Match matchGetNum;
            while (rgGetID.Match(sourceSQL[0]).Success == true)
            {
                for (int i = 0; i < sourceSQL.Length; i++)
                {
                    matchrgGetID = rgGetID.Match(sourceSQL[i]);//{{id:7}}取整块
                    matchGetNum = rgGetNum.Match(sourceSQL[i]);//{{id:7}}取冒号后的数字
                    //用这条，替换的时候 如果有相同匹配对象，会全部替换成同一个值
                    //sourceSQL[i] = sourceSQL[i].Replace(matchrgGetID.Groups[0].Value, (Convert.ToInt32(matchGetNum.Groups[0].Value) + i).ToString());
                    //用这条，仅替换第一个匹配对象
                    sourceSQL[i] = rgGetID.Replace(sourceSQL[i], (Convert.ToInt32(matchGetNum.Groups[0].Value) + i).ToString(), 1);
                }
            }

            return sourceSQL;
        }
        #endregion

        #region 将{{[1.22-22]}}替换为指定范围内的随机数
        /// <summary>
        /// 将{{[1.22-22]}}替换为指定范围内的随机数
        /// </summary>
        /// <param name="sourceSQL">原始SQL数组</param>
        /// <returns>替换完的数组</returns>
        private string[] getRandomNum(string[] sourceSQL)
        {
            Match matchRandom;
            Match matchRandomRange;
            Random rand = new Random();
            while (rgGetRandom.Match(sourceSQL[0]).Success == true)
            {
                for (int i = 0; i < sourceSQL.Length; i++)
                {
                    matchRandom = rgGetRandom.Match(sourceSQL[i]);//{{[1.22-22]}}取整块
                    matchRandomRange = rgGetRandomRange.Match(sourceSQL[i]);//{{[1.22-22]}}取[]中的随机范围
                    double x = Convert.ToDouble(matchRandomRange.Groups[0].Value.Split('-')[0]);
                    double y = Convert.ToDouble(matchRandomRange.Groups[0].Value.Split('-')[1]);
                    /*int xdotlength = getDotLength(x);
                    int ydotlength = getDotLength(y);
                    double randvalue = NextDouble(rand, x, y);
                    if (xdotlength>ydotlength)
                    {
                        sourceSQL[i] = sourceSQL[i].Replace(matchRandom.Groups[0].Value, Math.Round(randvalue,xdotlength).ToString());
                    }
                    else
                    {
                        sourceSQL[i] = sourceSQL[i].Replace(matchRandom.Groups[0].Value, Math.Round(randvalue, ydotlength).ToString());
                    }*/
                    //用这条，替换的时候 如果有相同匹配对象，会全部替换成同一个值
                    //sourceSQL[i] = sourceSQL[i].Replace(matchRandom.Groups[0].Value, NextDouble(rand, x, y).ToString());
                    //用这条，仅替换第一个匹配对象
                    sourceSQL[i] = rgGetRandom.Replace(sourceSQL[i], NextDouble(rand, x, y).ToString(), 1);
                }
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
        private string[] getNewID(string[] sourceSQL)
        {
            Match matchrgGetNewID;
            while (rgGetNewID.Match(sourceSQL[0]).Success == true)
            {
                for (int i = 0; i < sourceSQL.Length; i++)
                {
                    matchrgGetNewID = rgGetNewID.Match(sourceSQL[i]);//{{newid}}取整块
                    //用这条，替换的时候 如果有相同匹配对象，会全部替换成同一个值
                    //sourceSQL[i] = sourceSQL[i].Replace(matchrgGetNewID.Groups[0].Value, Guid.NewGuid().ToString());
                    //用这条，仅替换第一个匹配对象
                    sourceSQL[i] = rgGetNewID.Replace(sourceSQL[i], Guid.NewGuid().ToString(), 1);
                }
            }

            return sourceSQL;
        }
        #endregion

        #region 将time(d|h|m|s)(+|-)7:2020-03-29 20:00:00}}指定时间并递增
        /// <summary>
        /// 将time(d|h|m|s)(+|-)7:2020-03-29 20:00:00}}指定时间并递增
        /// </summary>
        /// <param name="sourceSQL">原始SQL数组</param>
        /// <returns>替换完的数组</returns>
        private string[] getNewDateTime(string[] sourceSQL)
        {
            //{{timed+777:2020-04-04 11:47:07}}

            Match matchDateTimeAll;
            Match matchDateTimeDiff;
            Match matchDateTime;

            while (rgGetDateTimeAll.Match(sourceSQL[0]).Success == true)
            {
                for (int i = 0; i < sourceSQL.Length; i++)
                {
                    matchDateTimeAll = rgGetDateTimeAll.Match(sourceSQL[i]);//{{time(d|h|m|s)(+|-)7:2020-03-29 20:00:00}}取整块 日、小时、分钟、秒
                    //matchDateTimeDiff = rgGetDateTimeDiff.Match(sourceSQL[i]);//{{timed+-7:2020-03-29 20:00:00}}取(d|h|m|s)(+|-)数字
                    matchDateTimeDiff = rgGetDateTimeDiff.Match(matchDateTimeAll.Groups[0].Value);//{{timed+-7:2020-03-29 20:00:00}}取(d|h|m|s)(+|-)数字
                    //matchDateTime = rgGetDateTime.Match(sourceSQL[i]);//{{timed+-7:2020-03-29 20:00:00}}取时间
                    matchDateTime = rgGetDateTime.Match(matchDateTimeAll.Groups[0].Value);//{{timed+-7:2020-03-29 20:00:00}}取时间
                    //DateTime dt = new DateTime();
                    DateTime dt = Convert.ToDateTime(matchDateTime.Groups[0].Value);
                    string str = matchDateTimeDiff.Groups[0].Value;//取(d|h|m|s)(+|-)数字
                    string type = str.Substring(0, 1);//(d|h|m|s)
                    string symbol = str.Substring(1, 1);//(+|-)
                    int length = Convert.ToInt32(str.Substring(2, str.Length - 2));//数字

                    //MessageBox.Show(type+"\n"+symbol+"\n"+length.ToString());
                    //MessageBox.Show(dt.AddHours(7).ToString("yyyy-MM-dd HH:mm:ss"));

                    if (type == "d")//日+/-
                    {
                        if (symbol == "+")//+
                        {
                            //用这条，替换的时候 如果有相同匹配对象，会全部替换成同一个值
                            //sourceSQL[i] = sourceSQL[i].Replace(matchDateTimeAll.Groups[0].Value, dt.AddDays(length * i).ToString("yyyy-MM-dd HH:mm:ss"));//日+
                            //用这条，仅替换第一个匹配对象
                            sourceSQL[i] = rgGetDateTimeAll.Replace(sourceSQL[i], dt.AddDays(length * i).ToString("yyyy-MM-dd HH:mm:ss"), 1);
                        }
                        if (symbol == "-")//-
                        {
                            //用这条，替换的时候 如果有相同匹配对象，会全部替换成同一个值
                            //sourceSQL[i] = sourceSQL[i].Replace(matchDateTimeAll.Groups[0].Value, dt.AddDays(-(length * i)).ToString("yyyy-MM-dd HH:mm:ss"));//日-
                            //用这条，仅替换第一个匹配对象
                            sourceSQL[i] = rgGetDateTimeAll.Replace(sourceSQL[i], dt.AddDays(-(length * i)).ToString("yyyy-MM-dd HH:mm:ss"), 1);
                        }
                    }
                    if (type == "h")//小时+/-
                    {
                        if (symbol == "+")//+
                        {
                            //用这条，替换的时候 如果有相同匹配对象，会全部替换成同一个值
                            //sourceSQL[i] = sourceSQL[i].Replace(matchDateTimeAll.Groups[0].Value, dt.AddHours(length * i).ToString("yyyy-MM-dd HH:mm:ss"));//小时+
                            //用这条，仅替换第一个匹配对象
                            sourceSQL[i] = rgGetDateTimeAll.Replace(sourceSQL[i], dt.AddHours(length * i).ToString("yyyy-MM-dd HH:mm:ss"), 1);
                        }
                        if (symbol == "-")//-
                        {
                            //用这条，替换的时候 如果有相同匹配对象，会全部替换成同一个值
                            //sourceSQL[i] = sourceSQL[i].Replace(matchDateTimeAll.Groups[0].Value, dt.AddHours(-(length * i)).ToString("yyyy-MM-dd HH:mm:ss"));//小时-
                            //用这条，仅替换第一个匹配对象
                            sourceSQL[i] = rgGetDateTimeAll.Replace(sourceSQL[i], dt.AddHours(-(length * i)).ToString("yyyy-MM-dd HH:mm:ss"), 1);
                        }
                    }
                    if (type == "m")//分钟+/-
                    {
                        if (symbol == "+")//+
                        {
                            //用这条，替换的时候 如果有相同匹配对象，会全部替换成同一个值
                            //sourceSQL[i] = sourceSQL[i].Replace(matchDateTimeAll.Groups[0].Value, dt.AddMinutes(length * i).ToString("yyyy-MM-dd HH:mm:ss"));//分钟+
                            //用这条，仅替换第一个匹配对象
                            sourceSQL[i] = rgGetDateTimeAll.Replace(sourceSQL[i], dt.AddMinutes(length * i).ToString("yyyy-MM-dd HH:mm:ss"), 1);
                        }
                        if (symbol == "-")//-
                        {
                            //用这条，替换的时候 如果有相同匹配对象，会全部替换成同一个值
                            //sourceSQL[i] = sourceSQL[i].Replace(matchDateTimeAll.Groups[0].Value, dt.AddMinutes(-(length * i)).ToString("yyyy-MM-dd HH:mm:ss"));//分钟-
                            //用这条，仅替换第一个匹配对象
                            sourceSQL[i] = rgGetDateTimeAll.Replace(sourceSQL[i], dt.AddMinutes(-(length * i)).ToString("yyyy-MM-dd HH:mm:ss"), 1);
                        }
                    }
                    if (type == "s")//秒+/-
                    {
                        if (symbol == "+")//+
                        {
                            //用这条，替换的时候 如果有相同匹配对象，会全部替换成同一个值
                            //sourceSQL[i] = sourceSQL[i].Replace(matchDateTimeAll.Groups[0].Value, dt.AddSeconds(length * i).ToString("yyyy-MM-dd HH:mm:ss"));//秒+
                            //用这条，仅替换第一个匹配对象
                            sourceSQL[i] = rgGetDateTimeAll.Replace(sourceSQL[i], dt.AddSeconds(length * i).ToString("yyyy-MM-dd HH:mm:ss"), 1);
                        }
                        if (symbol == "-")//-
                        {
                            //用这条，替换的时候 如果有相同匹配对象，会全部替换成同一个值
                            //sourceSQL[i] = sourceSQL[i].Replace(matchDateTimeAll.Groups[0].Value, dt.AddSeconds(-(length * i)).ToString("yyyy-MM-dd HH:mm:ss"));//秒-
                            //用这条，仅替换第一个匹配对象
                            sourceSQL[i] = rgGetDateTimeAll.Replace(sourceSQL[i], dt.AddSeconds(-(length * i)).ToString("yyyy-MM-dd HH:mm:ss"), 1);
                        }
                    }
                }
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
                    temp += "执行成功：" + Querys[i];
                    if (i + 1 < Querys.Length)
                    {
                        temp += "\n";
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
                    temp += "执行成功：" + Querys[i];
                    if (i + 1 < Querys.Length)
                    {
                        temp += "\n";
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

        #region 生成设置范围内的Double的随机数 生成指定范围内随机数用到
        /// <summary>
        /// 生成设置范围内的Double的随机数
        /// eg:_random.NextDouble(1.5,2.5)
        /// </summary>
        /// <param name="random">Random</param>
        /// <param name="miniDouble">生成随机数的最大值</param>
        /// <param name="maxiDouble">生成随机数的最小值</param>
        /// <returns>当Random等于NULL的时候返回0;</returns>
        private static double NextDouble(Random random, double miniDouble, double maxiDouble)
        {
            int mindotlength = getDotLength(miniDouble);
            int maxdotlength = getDotLength(maxiDouble);
            int length = 0;
            if (maxdotlength > mindotlength)
            {
                length = maxdotlength;
            }
            else
            {
                length = mindotlength;
            }
            if (random != null)
            {
                return Math.Round(random.NextDouble() * (maxiDouble - miniDouble) + miniDouble, length);
            }
            else
            {
                return 0.0d;
            }
        }
        #endregion

        #region 获取小数点后的位数 生成指定范围内随机数用到
        /// <summary>
        /// 获取小数点后的位数
        /// </summary>
        /// <param name="num">需要判断的数字</param>
        /// <returns>返回小数点后位数 int</returns>
        private static int getDotLength(double num)
        {
            string temp = num.ToString();
            int index = 0;
            if (temp.Contains('.'))
            {
                index = temp.IndexOf(".");
                return temp.Length - index - 1;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region （该部分注释）快捷按钮插入操作 已通过下拉替换
        /*
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

        #region {{[1-2]}}按钮快速插入操作
        private void fastbtn_randomNum_Click(object sender, EventArgs e)
        {
            string str = "{{[1-2]}}";
            int i = richtxtboxInsertSQL.SelectionStart;
            string s = richtxtboxInsertSQL.Text;
            s = s.Insert(i, str);
            richtxtboxInsertSQL.Text = s;
            richtxtboxInsertSQL.SelectionStart = i + str.Length;
            richtxtboxInsertSQL.Focus();
        }
        #endregion

        #region {{newid}}按钮快速插入操作
        private void fastbtn_newid_Click(object sender, EventArgs e)
        {
            string str = "{{newid}}";
            int i = richtxtboxInsertSQL.SelectionStart;
            string s = richtxtboxInsertSQL.Text;
            s = s.Insert(i, str);
            richtxtboxInsertSQL.Text = s;
            richtxtboxInsertSQL.SelectionStart = i + str.Length;
            richtxtboxInsertSQL.Focus();
        }
        #endregion

        #region {{time(d|h|m|s)(+|-)7:2020-03-29 20:00:00}}按钮快速插入操作
        private void fastbtn_newdatetime_Click(object sender, EventArgs e)
        {
            string str = "{{timed+7:2020-04-04 11:47:07}}";
            int i = richtxtboxInsertSQL.SelectionStart;
            string s = richtxtboxInsertSQL.Text;
            s = s.Insert(i, str);
            richtxtboxInsertSQL.Text = s;
            richtxtboxInsertSQL.SelectionStart = i + str.Length;
            richtxtboxInsertSQL.Focus();
        }
        #endregion
        */
        #endregion

        #region 快捷插入配置按钮单击事件 打开快捷插入配置窗口 设置只能打开一个
        private void btn_QuickInsert_Settings_Click(object sender, EventArgs e)
        {
            //设置只能打开一个，配合FrmQuickInsertConfig中的GetFrmQuickInsertConfig()设置
            FrmQuickInsertConfig.GetFrmQuickInsertConfig().Activate();

            //接收FrmQuickInsertConfig返回的DialogResult，刷新右侧常用按钮功能Text
            FrmQuickInsertConfig fqic = new FrmQuickInsertConfig();
            if (fqic.ShowDialog() == DialogResult.OK)
            {
                RefreshQuickInsertCombox();
            }
        }
        #endregion

        #region 常用SQL插入按钮单击事件 将下拉框所选常用SQL插入到文本框中
        private void btn_CommonlyUsedSQL_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                string[] CommonlyUsedSQL = ConfigSettings.CommonlyUsedSQL.Split(';');
                foreach (var item in CommonlyUsedSQL)
                {
                    string[] CommonlyUsedSQLKeyValue = RWConfig.GetappSettingsValue(item, ConfigSettings.ConfigPath).Split(';');
                    if (cmbox_CommonlyUsedSQL_List.SelectedItem.ToString() == CommonlyUsedSQLKeyValue[0])
                    {
                        string str = CommonlyUsedSQLKeyValue[1];
                        richtxtboxInsertSQL.Text = str;
                        richtxtboxInsertSQL.SelectionStart = richtxtboxInsertSQL.Text.Length;
                        richtxtboxInsertSQL.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 常用SQL新增按钮单击事件 将SQL文本框中的语句作为值新增
        private void btn_CommonlyUsedSQL_New_Click(object sender, EventArgs e)
        {
            //设置只能打开一个，配合FrmCommonlyUsedSQLConfigNewEdit中的GetFrmQuickInsertConfig()设置
            FrmCommonlyUsedSQLConfigNewEdit.GetFrmCommonlyUsedSQLConfigNewEdit().Activate();

            //接收FrmCommonlyUsedSQLConfigNewEdit返回的DialogResult，刷新右侧常用按钮功能Text
            FrmCommonlyUsedSQLConfigNewEdit fcuscne = new FrmCommonlyUsedSQLConfigNewEdit();

            fcuscne.Text = "新增常用SQL";
            fcuscne.type = 0;//(type 0：新增，1：编辑)
            fcuscne.value = richtxtboxInsertSQL.Text.Trim();

            if (fcuscne.ShowDialog() == DialogResult.OK)
            {
                RefreshCommonlyUsedSQLCombox();
            }
        }
        #endregion

        #region 常用SQL配置按钮单击事件 打开常用SQL配置窗口
        private void btn_CommonlyUsedSQL_Settings_Click(object sender, EventArgs e)
        {
            //设置只能打开一个，配合FrmCommonlyUsedSQLConfig中的GetFrmQuickInsertConfig()设置
            FrmCommonlyUsedSQLConfig.GetFrmCommonlyUsedSQLConfig().Activate();

            //接收FrmCommonlyUsedSQLConfig返回的DialogResult，刷新右侧常用按钮功能Text
            FrmCommonlyUsedSQLConfig fcusc = new FrmCommonlyUsedSQLConfig();
            if (fcusc.ShowDialog() == DialogResult.OK)
            {
                RefreshCommonlyUsedSQLCombox();
            }
        }
        #endregion
    }
}