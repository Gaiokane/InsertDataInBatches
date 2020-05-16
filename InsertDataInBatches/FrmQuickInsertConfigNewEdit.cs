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
        public string code, name, value, instruction;
        public int type;//(type 0：新增，1：编辑)

        public FrmQuickInsertConfigNewEdit()
        {
            InitializeComponent();
        }

        #region 窗体加载事件 新增：三文本框为空，编辑：三文本框取所选行记录、编码不能修改
        private void FrmQuickInsertConfigNewEdit_Load(object sender, EventArgs e)
        {
            if (type == 0)//新增
            {
                code = "QuickInsert_";
                txtbox_Code.Text = code;
                txtbox_Name.Text = name;
                txtbox_Value.Text = value;
                richtxtbox_Instruction.Text = instruction;
                this.Icon = Properties.Resources._20200417084031982_easyicon_net_128;
            }
            else
            {
                if (type == 1)//编辑
                {
                    txtbox_Code.Text = code;
                    txtbox_Name.Text = name;
                    txtbox_Value.Text = value;
                    richtxtbox_Instruction.Text = instruction;
                    txtbox_Code.Enabled = false;
                    this.Icon = Properties.Resources._20200417084103500_easyicon_net_128;
                }
                else
                {
                    MessageBox.Show("出错！");
                    this.Close();
                }
            }
        }
        #endregion

        #region 保存按钮单击事件 新增/编辑
        private void btn_Save_Click(object sender, EventArgs e)
        {
            #region 新增
            if (type == 0)//新增
            {
                if (string.IsNullOrEmpty(txtbox_Code.Text) || string.IsNullOrWhiteSpace(txtbox_Code.Text))
                {
                    MessageBox.Show("快捷插入模块编码不能为空！");
                    txtbox_Code.Focus();
                }
                else
                {
                    if (string.IsNullOrEmpty(txtbox_Name.Text) || string.IsNullOrWhiteSpace(txtbox_Name.Text))
                    {
                        MessageBox.Show("快捷插入模块名称不能为空！");
                        txtbox_Name.Focus();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtbox_Value.Text) || string.IsNullOrWhiteSpace(txtbox_Value.Text))
                        {
                            MessageBox.Show("快捷插入模块值不能为空！");
                            txtbox_Value.Focus();
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(richtxtbox_Instruction.Text) || string.IsNullOrWhiteSpace(richtxtbox_Instruction.Text))
                            {
                                MessageBox.Show("快捷插入使用说明不能为空！");
                                richtxtbox_Instruction.Focus();
                            }
                            else
                            {
                                code = txtbox_Code.Text.Trim();
                                name = txtbox_Name.Text.Trim();
                                value = txtbox_Value.Text.Trim();
                                instruction = richtxtbox_Instruction.Text.Trim();

                                string result = ConfigSettings.setQuickInsertModelCodeNameValue(code, name, value, instruction);

                                if (result == "新增成功")
                                {
                                    MessageBox.Show(code + result);
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show(result);
                                    txtbox_Code.Focus();
                                    txtbox_Code.SelectAll();
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            #region 非新增
            else
            {
                #region 编辑
                if (type == 1)//编辑
                {
                    if (string.IsNullOrEmpty(txtbox_Code.Text) || string.IsNullOrWhiteSpace(txtbox_Code.Text))
                    {
                        MessageBox.Show("快捷插入模块编码不能为空！");
                        txtbox_Code.Focus();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtbox_Name.Text) || string.IsNullOrWhiteSpace(txtbox_Name.Text))
                        {
                            MessageBox.Show("快捷插入模块名称不能为空！");
                            txtbox_Name.Focus();
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(txtbox_Value.Text) || string.IsNullOrWhiteSpace(txtbox_Value.Text))
                            {
                                MessageBox.Show("快捷插入模块值不能为空！");
                                txtbox_Value.Focus();
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(richtxtbox_Instruction.Text) || string.IsNullOrWhiteSpace(richtxtbox_Instruction.Text))
                                {
                                    MessageBox.Show("快捷插入使用说明不能为空！");
                                    richtxtbox_Instruction.Focus();
                                }
                                else
                                {
                                    code = txtbox_Code.Text.Trim();
                                    name = txtbox_Name.Text.Trim();
                                    value = txtbox_Value.Text.Trim();
                                    instruction = richtxtbox_Instruction.Text.Trim();

                                    string result = ConfigSettings.editQuickInsertModelCodeNameValue(code, name, value, instruction);

                                    if (result == "修改成功")
                                    {
                                        MessageBox.Show(code + result);
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show(result);
                                        txtbox_Name.Focus();
                                        txtbox_Name.SelectAll();
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion
                else
                {
                    MessageBox.Show("出错！");
                    this.Close();
                }
            }
            #endregion
        }
        #endregion

        #region 取消按钮单击事件 窗口关闭
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 设置该窗口只能打开一个，配合按钮设置
        private static FrmQuickInsertConfigNewEdit fqicne = new FrmQuickInsertConfigNewEdit();
        public static FrmQuickInsertConfigNewEdit GetFrmQuickInsertConfigNewEdit()
        {
            if (fqicne.IsDisposed)
            {
                fqicne = new FrmQuickInsertConfigNewEdit();
                return fqicne;
            }
            else
            {
                return fqicne;
            }
        }
        #endregion

        #region 窗体关闭时返回一个DialogResult，FrmQuickInsertConfig接收返回值
        private void FrmQuickInsertConfigNewEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        #endregion

        #region 按ESC关闭窗体
        //重写ProcessCmdKey的方法
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;

            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Escape:
                        this.Close();//esc关闭窗体
                        break;
                }
            }
            return false;
        }
        #endregion
    }
}