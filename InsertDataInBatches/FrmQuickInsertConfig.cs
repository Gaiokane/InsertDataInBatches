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

        #region 新增按钮单击事件，设置新增窗口标题
        private void FQIC_New_Click(object sender, EventArgs e)
        {
            //设置只能打开一个，配合FrmQuickInsertConfig中的GetFrmQuickInsertConfig()设置
            FrmQuickInsertConfigNewEdit.GetFrmQuickInsertConfigNewEdit().Activate();

            FrmQuickInsertConfigNewEdit fqicne = new FrmQuickInsertConfigNewEdit();
            fqicne.Text = "新增快捷插入配置";
            fqicne.type = 0;//(type 0：新增，1：编辑)
            //fqic.Show();

            //接收FrmQuickInsertConfig返回的DialogResult，刷新右侧常用按钮功能Text
            if (fqicne.ShowDialog() == DialogResult.OK)
            {
                RefreshDG();
            }
        }
        #endregion

        #region 编辑按钮单击事件，将所选行传值过去
        private void FQIC_Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("没有要编辑的数据！");
            }
            else
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请选择要编辑的数据！");
                }
                else
                {
                    //设置只能打开一个，配合FrmQuickInsertConfig中的GetFrmQuickInsertConfig()设置
                    FrmQuickInsertConfigNewEdit.GetFrmQuickInsertConfigNewEdit().Activate();

                    FrmQuickInsertConfigNewEdit fqicne = new FrmQuickInsertConfigNewEdit();
                    fqicne.Text = "编辑快捷插入配置";
                    fqicne.type = 1;//(type 0：新增，1：编辑)
                    fqicne.code = dataGridView1.SelectedCells[0].Value.ToString();
                    fqicne.name = dataGridView1.SelectedCells[1].Value.ToString();
                    fqicne.value = dataGridView1.SelectedCells[2].Value.ToString();
                    //fqic.Show();

                    //接收FrmQuickInsertConfig返回的DialogResult，刷新右侧常用按钮功能Text
                    if (fqicne.ShowDialog() == DialogResult.OK)
                    {
                        RefreshDG();
                    }
                }
            }
        }
        #endregion

        #region 窗体加载事件，dg配置默认表头、宽度，加载快捷插入配置数据
        private void FrmQuickInsertConfig_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("QuickInsertModelCode", "快捷插入模块编码");
            dataGridView1.Columns.Add("QuickInsertModelName", "快捷插入模块名称");
            dataGridView1.Columns.Add("QuickInsertModelValue", "快捷插入模块值");

            dataGridView1.Columns["QuickInsertModelCode"].Width = 160;
            dataGridView1.Columns["QuickInsertModelName"].Width = 130;
            dataGridView1.Columns["QuickInsertModelValue"].Width = 200;

            RefreshDG();
        }
        #endregion

        #region 刷新dg快捷插入配置信息（一维数组、二位数组，当前使用一维数组）
        private void RefreshDG()
        {
            dataGridView1.Rows.Clear();

            try
            {
                //普通写法
                foreach (var item in ConfigSettings.getQuickInsertSettingsAllCodes())
                {
                    string[] str = ConfigSettings.getQuickInsertModelNameValueByCode(item);
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells["QuickInsertModelCode"].Value = item;
                    dataGridView1.Rows[index].Cells["QuickInsertModelName"].Value = str[0];
                    dataGridView1.Rows[index].Cells["QuickInsertModelValue"].Value = str[1];
                }

                //二维数组
                /*string[,] str = ConfigSettings.getQuickInsertModelCodeNameValue();
                for (int i = 0; i < str.Length / 3; i++)
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells["QuickInsertModelCode"].Value = str[i, 0];
                    dataGridView1.Rows[index].Cells["QuickInsertModelName"].Value = str[i, 1];
                    dataGridView1.Rows[index].Cells["QuickInsertModelValue"].Value = str[i, 2];
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dataGridView1.ClearSelection();
        }
        #endregion

        #region 删除按钮单击事件，删除所选行
        private void FQIC_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("没有要删除的数据！");
            }
            else
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请选择要删除的数据！");
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("确认删除：" + dataGridView1.SelectedCells[0].Value.ToString() + "？", "确认删除？", MessageBoxButtons.OKCancel))
                    {
                        string result = ConfigSettings.delQuickInsertModelCodeNameValue(dataGridView1.SelectedCells[0].Value.ToString());
                        MessageBox.Show(result);
                        RefreshDG();
                    }
                }
            }
        }
        #endregion

        #region 刷新按钮单击事件，刷新dg数据
        private void FQIC_Refresh_Click(object sender, EventArgs e)
        {
            RefreshDG();
        }
        #endregion

        #region 设置该窗口只能打开一个，配合按钮设置
        private static FrmQuickInsertConfig fqic = new FrmQuickInsertConfig();
        public static FrmQuickInsertConfig GetFrmQuickInsertConfig()
        {
            if (fqic.IsDisposed)
            {
                fqic = new FrmQuickInsertConfig();
                return fqic;
            }
            else
            {
                return fqic;
            }
        }
        #endregion

        #region 窗体关闭时返回一个DialogResult，FrmMain接收返回值
        private void FrmQuickInsertConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        #endregion

        #region dg双击事件 同编辑
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("没有要编辑的数据！");
            }
            else
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请选择要编辑的数据！");
                }
                else
                {
                    //设置只能打开一个，配合FrmQuickInsertConfig中的GetFrmQuickInsertConfig()设置
                    FrmQuickInsertConfigNewEdit.GetFrmQuickInsertConfigNewEdit().Activate();

                    FrmQuickInsertConfigNewEdit fqicne = new FrmQuickInsertConfigNewEdit();
                    fqicne.Text = "编辑快捷插入配置";
                    fqicne.type = 1;//(type 0：新增，1：编辑)
                    fqicne.code = dataGridView1.SelectedCells[0].Value.ToString();
                    fqicne.name = dataGridView1.SelectedCells[1].Value.ToString();
                    fqicne.value = dataGridView1.SelectedCells[2].Value.ToString();
                    //fqic.Show();

                    //接收FrmQuickInsertConfig返回的DialogResult，刷新右侧常用按钮功能Text
                    if (fqicne.ShowDialog() == DialogResult.OK)
                    {
                        RefreshDG();
                    }
                }
            }
        }
        #endregion
    }
}