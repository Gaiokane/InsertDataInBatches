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
    public partial class FrmDatabasesNameList : Form
    {
        public TextBox txtboxdatabase = new TextBox();

        private Point pi;

        public FrmDatabasesNameList()
        {
            InitializeComponent();
        }

        private void FrmDatabasesNameList_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Add("db1");
            treeView1.Nodes.Add("db2");
            treeView1.Nodes.Add("db3");
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            pi = new Point(e.X, e.Y);
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = this.treeView1.GetNodeAt(pi);
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

                txtboxdatabase.Text = treeView1.SelectedNode.Text;
                this.Close();
            }
        }

        #region 按下ESC键关闭当前窗口
        private void FrmDatabasesNameList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
        #endregion
    }
}