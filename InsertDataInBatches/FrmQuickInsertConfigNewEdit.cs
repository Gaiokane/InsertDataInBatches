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
    public partial class FrmQuickInsertConfigNewEdit : Form
    {
        public string code, name, value;

        public FrmQuickInsertConfigNewEdit()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void FrmQuickInsertConfigNewEdit_Load(object sender, EventArgs e)
        {
            //txtbox_Value.Text = "{{timed+777:2020-12-31 23:59:59}}";
            txtbox_Code.Text = code;
            txtbox_Name.Text = name;
            txtbox_Value.Text = value;
        }
    }
}
