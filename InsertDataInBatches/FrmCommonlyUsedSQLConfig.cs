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
    public partial class FrmCommonlyUsedSQLConfig : Form
    {
        public FrmCommonlyUsedSQLConfig()
        {
            InitializeComponent();
        }

        private void FrmCommonlyUsedSQLConfig_Load(object sender, EventArgs e)
        {

        }

        #region 设置该窗口只能打开一个，配合按钮设置
        private static FrmCommonlyUsedSQLConfig fcusc = new FrmCommonlyUsedSQLConfig();
        public static FrmCommonlyUsedSQLConfig GetFrmCommonlyUsedSQLConfig()
        {
            if (fcusc.IsDisposed)
            {
                fcusc = new FrmCommonlyUsedSQLConfig();
                return fcusc;
            }
            else
            {
                return fcusc;
            }
        }
        #endregion

        #region 窗体关闭时返回一个DialogResult，FrmMain接收返回值
        private void FrmCommonlyUsedSQLConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        #endregion
    }
}