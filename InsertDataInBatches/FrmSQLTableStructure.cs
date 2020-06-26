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
        public TreeNode tn = new TreeNode();

        public FrmSQLTableStructure()
        {
            InitializeComponent();
        }

        private void FrmSQLTableStructure_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources._20200417083355795_easyicon_net_128;

            //treeView1.Nodes.Add("节点1");
            //treeView1.Nodes[0].Nodes.Add("节点1的子节点1");
            //treeView1.Nodes[0].Nodes[0].Nodes.Add("节点1的子节点1的子子节点1");

            MessageBox.Show(tn.Nodes[0].Text);
            MessageBox.Show(treeView1.Nodes.Count.ToString());
            treeView1.Nodes.Clear();
            //treeView1.Nodes.Add(tn);
            treeView1.Nodes.Insert(0, tn);
            treeView1.Nodes[0].Text = "111";
            MessageBox.Show(treeView1.Nodes[0].Text);

            treeView1.ExpandAll();//展开所有树节点
            //treeView1.CollapseAll();//折叠所有树节点
        }
    }
}