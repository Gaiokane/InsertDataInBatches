namespace InsertDataInBatches
{
    partial class FrmQuickInsertConfig
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
            this.FQIC_New = new System.Windows.Forms.Button();
            this.FQIC_Edit = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FQIC_Refresh = new System.Windows.Forms.Button();
            this.FQIC_Del = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // FQIC_New
            // 
            this.FQIC_New.Location = new System.Drawing.Point(93, 12);
            this.FQIC_New.Name = "FQIC_New";
            this.FQIC_New.Size = new System.Drawing.Size(75, 23);
            this.FQIC_New.TabIndex = 1;
            this.FQIC_New.Text = "新增";
            this.FQIC_New.UseVisualStyleBackColor = true;
            this.FQIC_New.Click += new System.EventHandler(this.FQIC_New_Click);
            // 
            // FQIC_Edit
            // 
            this.FQIC_Edit.Location = new System.Drawing.Point(174, 12);
            this.FQIC_Edit.Name = "FQIC_Edit";
            this.FQIC_Edit.Size = new System.Drawing.Size(75, 23);
            this.FQIC_Edit.TabIndex = 2;
            this.FQIC_Edit.Text = "编辑";
            this.FQIC_Edit.UseVisualStyleBackColor = true;
            this.FQIC_Edit.Click += new System.EventHandler(this.FQIC_Edit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(500, 200);
            this.dataGridView1.TabIndex = 4;
            // 
            // FQIC_Refresh
            // 
            this.FQIC_Refresh.Location = new System.Drawing.Point(12, 12);
            this.FQIC_Refresh.Name = "FQIC_Refresh";
            this.FQIC_Refresh.Size = new System.Drawing.Size(75, 23);
            this.FQIC_Refresh.TabIndex = 0;
            this.FQIC_Refresh.Text = "刷新";
            this.FQIC_Refresh.UseVisualStyleBackColor = true;
            this.FQIC_Refresh.Click += new System.EventHandler(this.FQIC_Refresh_Click);
            // 
            // FQIC_Del
            // 
            this.FQIC_Del.Location = new System.Drawing.Point(255, 12);
            this.FQIC_Del.Name = "FQIC_Del";
            this.FQIC_Del.Size = new System.Drawing.Size(75, 23);
            this.FQIC_Del.TabIndex = 3;
            this.FQIC_Del.Text = "删除";
            this.FQIC_Del.UseVisualStyleBackColor = true;
            this.FQIC_Del.Click += new System.EventHandler(this.FQIC_Del_Click);
            // 
            // FrmQuickInsertConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 253);
            this.Controls.Add(this.FQIC_Del);
            this.Controls.Add(this.FQIC_Refresh);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.FQIC_Edit);
            this.Controls.Add(this.FQIC_New);
            this.Name = "FrmQuickInsertConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "快捷插入配置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmQuickInsertConfig_FormClosed);
            this.Load += new System.EventHandler(this.FrmQuickInsertConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FQIC_New;
        private System.Windows.Forms.Button FQIC_Edit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button FQIC_Refresh;
        private System.Windows.Forms.Button FQIC_Del;
    }
}