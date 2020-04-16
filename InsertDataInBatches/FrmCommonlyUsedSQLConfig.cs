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

        #region 新增按钮单击事件，设置新增窗口标题
        private void FCUSC_New_Click(object sender, EventArgs e)
        {
            //设置只能打开一个，配合FrmCommonlyUsedSQLConfig中的GetFrmCommonlyUsedSQLConfig()设置
            FrmCommonlyUsedSQLConfigNewEdit.GetFrmCommonlyUsedSQLConfigNewEdit().Activate();

            FrmCommonlyUsedSQLConfigNewEdit fcuscne = new FrmCommonlyUsedSQLConfigNewEdit();
            fcuscne.Text = "新增常用SQL";
            fcuscne.type = 0;//(type 0：新增，1：编辑)
            //fqic.Show();

            //接收FrmQuickInsertConfig返回的DialogResult，刷新右侧常用按钮功能Text
            if (fcuscne.ShowDialog() == DialogResult.OK)
            {
                RefreshDG();
            }
        }
        #endregion

        #region 编辑按钮单击事件，将所选行传值过去
        private void FCUSC_Edit_Click(object sender, EventArgs e)
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
                    //设置只能打开一个，配合FrmCommonlyUsedSQLConfig中的GetFrmCommonlyUsedSQLConfig()设置
                    FrmCommonlyUsedSQLConfigNewEdit.GetFrmCommonlyUsedSQLConfigNewEdit().Activate();

                    FrmCommonlyUsedSQLConfigNewEdit fcuscne = new FrmCommonlyUsedSQLConfigNewEdit();
                    fcuscne.Text = "编辑常用SQL";
                    fcuscne.type = 1;//(type 0：新增，1：编辑)
                    fcuscne.code = dataGridView1.SelectedCells[0].Value.ToString();
                    fcuscne.name = dataGridView1.SelectedCells[1].Value.ToString();
                    fcuscne.value = dataGridView1.SelectedCells[2].Value.ToString();
                    //fqic.Show();

                    //接收FrmQuickInsertConfig返回的DialogResult，刷新右侧常用按钮功能Text
                    if (fcuscne.ShowDialog() == DialogResult.OK)
                    {
                        RefreshDG();
                    }
                }
            }
        }
        #endregion

        #region 窗体加载事件，dg配置默认表头、宽度，加载常用SQL数据
        private void FrmCommonlyUsedSQLConfig_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("CommonlyUsedSQLCode", "常用SQL编码");
            dataGridView1.Columns.Add("CommonlyUsedSQLName", "常用SQL名称");
            dataGridView1.Columns.Add("CommonlyUsedSQLValue", "常用SQL语句");

            dataGridView1.Columns["CommonlyUsedSQLCode"].Width = 160;
            dataGridView1.Columns["CommonlyUsedSQLName"].Width = 130;
            dataGridView1.Columns["CommonlyUsedSQLValue"].Width = 200;

            RefreshDG();
        }
        #endregion

        #region 刷新dg常用SQL配置信息
        private void RefreshDG()
        {
            dataGridView1.Rows.Clear();

            try
            {
                //普通写法
                foreach (var item in ConfigSettings.getCommonlyUsedSQLAllCodes())
                {
                    string[] str = ConfigSettings.getCommonlyUsedSQLNameValueByCode(item);
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells["CommonlyUsedSQLCode"].Value = item;
                    dataGridView1.Rows[index].Cells["CommonlyUsedSQLName"].Value = str[0];
                    dataGridView1.Rows[index].Cells["CommonlyUsedSQLValue"].Value = str[1];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dataGridView1.ClearSelection();
        }
        #endregion

        #region 删除按钮单击事件，删除所选行
        private void FCUSC_Del_Click(object sender, EventArgs e)
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
                        string result = ConfigSettings.delCommonlyUsedSQLCodeNameValue(dataGridView1.SelectedCells[0].Value.ToString());
                        MessageBox.Show(result);
                        RefreshDG();
                    }
                }
            }
        }
        #endregion

        #region 刷新按钮单击事件，刷新dg数据
        private void FCUSC_Refresh_Click(object sender, EventArgs e)
        {
            RefreshDG();
        }
        #endregion

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
                    //设置只能打开一个，配合FrmCommonlyUsedSQLConfig中的GetFrmCommonlyUsedSQLConfig()设置
                    FrmCommonlyUsedSQLConfigNewEdit.GetFrmCommonlyUsedSQLConfigNewEdit().Activate();

                    FrmCommonlyUsedSQLConfigNewEdit fcuscne = new FrmCommonlyUsedSQLConfigNewEdit();
                    fcuscne.Text = "编辑常用SQL";
                    fcuscne.type = 1;//(type 0：新增，1：编辑)
                    fcuscne.code = dataGridView1.SelectedCells[0].Value.ToString();
                    fcuscne.name = dataGridView1.SelectedCells[1].Value.ToString();
                    fcuscne.value = dataGridView1.SelectedCells[2].Value.ToString();
                    //fqic.Show();

                    //接收FrmQuickInsertConfig返回的DialogResult，刷新右侧常用按钮功能Text
                    if (fcuscne.ShowDialog() == DialogResult.OK)
                    {
                        RefreshDG();
                    }
                }
            }
        }
        #endregion
    }
}