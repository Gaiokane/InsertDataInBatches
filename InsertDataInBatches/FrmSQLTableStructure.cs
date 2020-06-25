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
        public FrmSQLTableStructure()
        {
            InitializeComponent();
        }

        private void FrmSQLTableStructure_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources._20200417083355795_easyicon_net_128;

            treeView1.Nodes.Add("节点1");
            treeView1.Nodes[0].Nodes.Add("节点1的子节点1");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("节点1的子节点1的子子节点1");

            treeView1.ExpandAll();//展开所有树节点
            treeView1.CollapseAll();//折叠所有树节点
        }
    }
}