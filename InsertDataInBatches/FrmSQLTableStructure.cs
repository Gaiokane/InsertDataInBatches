using MySql.Data.MySqlClient;
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

namespace InsertDataInBatches
{
    public partial class FrmSQLTableStructure : Form
    {
        public TreeNode tn;
        public TreeView tv;
        public string databasename = "NULL";

        private Point pi;

        public string tablename;

        private string sqlGetTableStructureForMSSQL;
        private string sqlGetTableStructureForMySQL;

        public SqlConnection mssqlconn;
        public MySqlConnection mysqlconn;

        public string sqltype;

        public FrmSQLTableStructure()
        {
            InitializeComponent();
        }

        private void FrmSQLTableStructure_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources._20200417083355795_easyicon_net_128;

            treeView1.Nodes.Add(tn);

            treeView1.ExpandAll();//展开所有树节点
            //treeView1.CollapseAll();//折叠所有树节点
            treeView1.Nodes[0].EnsureVisible();//垂直滚动条在展开所有节点后回到顶端

            //MessageBox.Show(databasename);
            //MessageBox.Show(treeView1.Nodes[0].Text);

            //RichTextBox增加右键菜单
            RichTextBoxMenu richTextBoxMenu_richTextBox1 = new RichTextBoxMenu(richTextBox1);
        }

        #region treeview获取鼠标坐标 用来判断是否选中节点
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            pi = new Point(e.X, e.Y);
        }
        #endregion

        #region treeview双击事件 如果双击的是节点，传值到insert语句文本框光标处
        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = this.treeView1.GetNodeAt(pi);
            //获取深度，0：数据库名；1：表/视图；2：表名/视图名
            //MessageBox.Show(node.Level.ToString());
            if (node.Level == 2)
            {
                if (pi.X < node.Bounds.Left || pi.X > node.Bounds.Right)
                {
                    //不触发事件

                    //txtboxdatabase.Text = "no selected";
                    //this.Close();

                    return;
                }
                else
                {
                    //触发事件

                    //MessageBox.Show(treeView1.SelectedNode.Text);
                    tablename = treeView1.SelectedNode.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        #endregion

        #region 设置该窗口只能打开一个，配合按钮设置
        private static FrmSQLTableStructure fsts = new FrmSQLTableStructure();
        public static FrmSQLTableStructure GetFrmSQLTableStructure()
        {
            if (fsts.IsDisposed)
            {
                fsts = new FrmSQLTableStructure();
                return fsts;
            }
            else
            {
                return fsts;
            }
        }
        #endregion

        #region 窗体关闭时返回一个DialogResult，FrmMain接收返回值
        private void FrmSQLTableStructure_FormClosed(object sender, FormClosedEventArgs e)
        {
            //在这里处理 正常关闭也会返回值 改在treeView1_DoubleClick中处理
            //this.DialogResult = DialogResult.OK;
        }
        #endregion

        #region treeView1按下ESC键关闭当前窗口
        private void treeView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
        #endregion

        #region dataGridView1按下ESC键关闭当前窗口
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
        #endregion

        #region richTextBox1按下ESC键关闭当前窗口
        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
        #endregion

        #region 获取MSSQL/MySQL当前所选表的表结构消息
        /// <summary>
        /// 获取MSSQL/MySQL当前所选表的表结构消息
        /// </summary>
        /// <param name="sqlType">MSSQL/MySQL</param>
        /// <param name="DataBaseName">数据库名</param>
        /// <param name="TableName">表名</param>
        /// <returns></returns>
        private string GetsqlGetTableStructureForMSSQLORMySQL(string sqlType, string TableName)
        {
            string result = "SELECT 1;";

            if (string.IsNullOrEmpty(sqlType) == false && string.IsNullOrEmpty(TableName) == false)
            {
                //MSSQL
                if (sqlType == "MSSQL")
                {
                    result = "USE " + databasename + "; " +
                        "SELECT (case when a.colorder=1 then d.name else null end) 表名, " +
                        "a.colorder 字段序号, a.name 字段名, " +
                        "(case when COLUMNPROPERTY(a.id, a.name, 'IsIdentity') = 1 then '√'else '' end) 标识, " +
                        "(case when(SELECT count(*) FROM sysobjects " +
                        "WHERE(name in (SELECT name FROM sysindexes " +
                        "WHERE(id = a.id) AND(indid in " +
                        "(SELECT indid FROM sysindexkeys " +
                        "WHERE(id = a.id) AND(colid in " +
                        "(SELECT colid FROM syscolumns WHERE(id = a.id) AND(name = a.name))))))) " +
                        "AND(xtype = 'PK'))> 0 then '√' else '' end) 主键,b.name 类型, a.length 占用字节数, " +
                        "COLUMNPROPERTY(a.id, a.name, 'PRECISION') as 长度, " +
                        "isnull(COLUMNPROPERTY(a.id, a.name, 'Scale'), 0) as 小数位数,(case when a.isnullable = 1 then '√'else '' end) 允许空, " +
                        "isnull(e.text, '') 默认值,isnull(g.[value], ' ') AS[说明] " +
                        "FROM syscolumns a " +
                        "left join systypes b on a.xtype = b.xusertype " +
                        "inner join sysobjects d on a.id = d.id and d.xtype = 'U' and d.name <> 'dtproperties' " +
                        "left join syscomments e on a.cdefault = e.id " +
                        "left join sys.extended_properties g on a.id = g.major_id AND a.colid = g.minor_id " +
                        "left join sys.extended_properties f on d.id = f.class and f.minor_id=0 " +
                        "WHERE d.name= '" + TableName + "' " +
                        "order by a.id, a.colorder";
                    return result;
                }
                //MySQL
                if (sqlType == "MySQL")
                {
                    result = "SELECT COLUMN_NAME, COLUMN_TYPE, COLUMN_COMMENT FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = '" + databasename + "' AND TABLE_NAME = '" + TableName + "';";
                    //SELECT COLUMN_NAME AS 字段名, COLUMN_TYPE AS 字段类型, COLUMN_COMMENT AS 字段注释 FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = '" + DataBaseName + "' AND TABLE_NAME = '" + TableName + "';
                    return result;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return result;
            }
        }
        #endregion

        #region dg绑定数据，获取表结构信息
        /// <summary>
        /// dg绑定数据，获取表结构信息
        /// </summary>
        /// <param name="sqlType">MSSQL/MySQL</param>
        /// <param name="TableName">表名</param>
        private void dgBindData(string sqlType, string TableName)
        {
            if (string.IsNullOrEmpty(sqlType) == false && string.IsNullOrEmpty(TableName) == false)
            {
                sqlGetTableStructureForMSSQL = GetsqlGetTableStructureForMSSQLORMySQL("MSSQL", TableName);
                sqlGetTableStructureForMySQL = GetsqlGetTableStructureForMSSQLORMySQL("MySQL", TableName);

                //MSSQL
                if (sqlType == "MSSQL")
                {
                    dataGridView1.DataSource = SqlHelper.getDataSetMSSQL(sqlGetTableStructureForMSSQL, mssqlconn).Tables[0];
                }
                //MySQL
                if (sqlType == "MySQL")
                {
                    dataGridView1.DataSource = SqlHelper.getDataSetMySQL(sqlGetTableStructureForMySQL, mysqlconn).Tables[0];

                    dataGridView1.Columns[0].HeaderText = "列名";
                    dataGridView1.Columns[1].HeaderText = "类型";
                    dataGridView1.Columns[2].HeaderText = "注释";
                }
            }
        }
        #endregion

        #region 选定表节点后，调用dgBindData，获取所选表 表结构，并显示到dg中
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = this.treeView1.GetNodeAt(pi);
            //获取深度，0：数据库名；1：表/视图；2：表名/视图名
            //MessageBox.Show(node.Level.ToString());
            if (node.Level == 2)
            {
                if (pi.X < node.Bounds.Left || pi.X > node.Bounds.Right)
                {
                    //不触发事件

                    return;
                }
                else
                {
                    //触发事件
                    dgBindData(sqltype, treeView1.SelectedNode.Text);
                }
            }
        }
        #endregion
    }
}