using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            if (node.Level==2)
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
    }
}