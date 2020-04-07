using Gaiokane;
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
    public partial class FrmQuickInsertConfig : Form
    {
        public FrmQuickInsertConfig()
        {
            InitializeComponent();
        }

        private void FQIC_New_Click(object sender, EventArgs e)
        {
            FrmQuickInsertConfigNewEdit fqic = new FrmQuickInsertConfigNewEdit();
            fqic.Text = "新增";
            fqic.Show();
        }

        private void FQIC_Edit_Click(object sender, EventArgs e)
        {
            FrmQuickInsertConfigNewEdit fqic = new FrmQuickInsertConfigNewEdit();
            fqic.Text = "编辑";
            fqic.Show();
        }

        private void FrmQuickInsertConfig_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("QuickInsertModelCode", "快捷插入模块编码");
            dataGridView1.Columns.Add("QuickInsertModelName", "快捷插入模块名称");
            dataGridView1.Columns.Add("QuickInsertModelValue", "快捷插入模块值");

            dataGridView1.Columns["QuickInsertModelCode"].Width = 150;
            dataGridView1.Columns["QuickInsertModelName"].Width = 150;
            dataGridView1.Columns["QuickInsertModelValue"].Width = 150;

            foreach (var item in ConfigSettings.getQuickInsertSettingsAllCodes())
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells["QuickInsertModelCode"].Value = item;
                dataGridView1.Rows[index].Cells["QuickInsertModelName"].Value = item;
                dataGridView1.Rows[index].Cells["QuickInsertModelValue"].Value = item;
            }
        }
    }
}