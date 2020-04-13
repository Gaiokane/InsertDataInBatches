namespace InsertDataInBatches
{
    partial class FrmCommonlyUsedSQLConfigNewEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txtbox_Value = new System.Windows.Forms.TextBox();
            this.txtbox_Name = new System.Windows.Forms.TextBox();
            this.txtbox_Code = new System.Windows.Forms.TextBox();
            this.lab_Value = new System.Windows.Forms.Label();
            this.lab_Name = new System.Windows.Forms.Label();
            this.lab_Code = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(199, 93);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 15;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(118, 93);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 14;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            // 
            // txtbox_Value
            // 
            this.txtbox_Value.Location = new System.Drawing.Point(101, 66);
            this.txtbox_Value.Name = "txtbox_Value";
            this.txtbox_Value.Size = new System.Drawing.Size(280, 21);
            this.txtbox_Value.TabIndex = 13;
            // 
            // txtbox_Name
            // 
            this.txtbox_Name.Location = new System.Drawing.Point(101, 39);
            this.txtbox_Name.Name = "txtbox_Name";
            this.txtbox_Name.Size = new System.Drawing.Size(280, 21);
            this.txtbox_Name.TabIndex = 11;
            // 
            // txtbox_Code
            // 
            this.txtbox_Code.Location = new System.Drawing.Point(101, 12);
            this.txtbox_Code.Name = "txtbox_Code";
            this.txtbox_Code.Size = new System.Drawing.Size(280, 21);
            this.txtbox_Code.TabIndex = 9;
            // 
            // lab_Value
            // 
            this.lab_Value.AutoSize = true;
            this.lab_Value.Location = new System.Drawing.Point(12, 70);
            this.lab_Value.Name = "lab_Value";
            this.lab_Value.Size = new System.Drawing.Size(83, 12);
            this.lab_Value.TabIndex = 12;
            this.lab_Value.Text = "常用SQL语句：";
            // 
            // lab_Name
            // 
            this.lab_Name.AutoSize = true;
            this.lab_Name.Location = new System.Drawing.Point(12, 43);
            this.lab_Name.Name = "lab_Name";
            this.lab_Name.Size = new System.Drawing.Size(83, 12);
            this.lab_Name.TabIndex = 10;
            this.lab_Name.Text = "常用SQL名称：";
            // 
            // lab_Code
            // 
            this.lab_Code.AutoSize = true;
            this.lab_Code.Location = new System.Drawing.Point(12, 16);
            this.lab_Code.Name = "lab_Code";
            this.lab_Code.Size = new System.Drawing.Size(83, 12);
            this.lab_Code.TabIndex = 8;
            this.lab_Code.Text = "常用SQL编码：";
            // 
            // FrmCommonlyUsedSQLConfigNewEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 128);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txtbox_Value);
            this.Controls.Add(this.txtbox_Name);
            this.Controls.Add(this.txtbox_Code);
            this.Controls.Add(this.lab_Value);
            this.Controls.Add(this.lab_Name);
            this.Controls.Add(this.lab_Code);
            this.Name = "FrmCommonlyUsedSQLConfigNewEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增/编辑，代码控制";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txtbox_Value;
        private System.Windows.Forms.TextBox txtbox_Name;
        private System.Windows.Forms.TextBox txtbox_Code;
        private System.Windows.Forms.Label lab_Value;
        private System.Windows.Forms.Label lab_Name;
        private System.Windows.Forms.Label lab_Code;
    }
}