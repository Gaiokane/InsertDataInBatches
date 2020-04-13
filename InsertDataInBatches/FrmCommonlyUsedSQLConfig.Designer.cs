namespace InsertDataInBatches
{
    partial class FrmCommonlyUsedSQLConfig
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
            this.FCUSC_Del = new System.Windows.Forms.Button();
            this.FCUSC_Refresh = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FCUSC_Edit = new System.Windows.Forms.Button();
            this.FCUSC_New = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // FCUSC_Del
            // 
            this.FCUSC_Del.Location = new System.Drawing.Point(255, 12);
            this.FCUSC_Del.Name = "FCUSC_Del";
            this.FCUSC_Del.Size = new System.Drawing.Size(75, 23);
            this.FCUSC_Del.TabIndex = 8;
            this.FCUSC_Del.Text = "删除";
            this.FCUSC_Del.UseVisualStyleBackColor = true;
            // 
            // FCUSC_Refresh
            // 
            this.FCUSC_Refresh.Location = new System.Drawing.Point(12, 12);
            this.FCUSC_Refresh.Name = "FCUSC_Refresh";
            this.FCUSC_Refresh.Size = new System.Drawing.Size(75, 23);
            this.FCUSC_Refresh.TabIndex = 5;
            this.FCUSC_Refresh.Text = "刷新";
            this.FCUSC_Refresh.UseVisualStyleBackColor = true;
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
            this.dataGridView1.TabIndex = 9;
            // 
            // FCUSC_Edit
            // 
            this.FCUSC_Edit.Location = new System.Drawing.Point(174, 12);
            this.FCUSC_Edit.Name = "FCUSC_Edit";
            this.FCUSC_Edit.Size = new System.Drawing.Size(75, 23);
            this.FCUSC_Edit.TabIndex = 7;
            this.FCUSC_Edit.Text = "编辑";
            this.FCUSC_Edit.UseVisualStyleBackColor = true;
            // 
            // FCUSC_New
            // 
            this.FCUSC_New.Location = new System.Drawing.Point(93, 12);
            this.FCUSC_New.Name = "FCUSC_New";
            this.FCUSC_New.Size = new System.Drawing.Size(75, 23);
            this.FCUSC_New.TabIndex = 6;
            this.FCUSC_New.Text = "新增";
            this.FCUSC_New.UseVisualStyleBackColor = true;
            // 
            // FrmCommonlyUsedSQLConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 253);
            this.Controls.Add(this.FCUSC_Del);
            this.Controls.Add(this.FCUSC_Refresh);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.FCUSC_Edit);
            this.Controls.Add(this.FCUSC_New);
            this.Name = "FrmCommonlyUsedSQLConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "常用SQL配置";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FCUSC_Del;
        private System.Windows.Forms.Button FCUSC_Refresh;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button FCUSC_Edit;
        private System.Windows.Forms.Button FCUSC_New;
    }
}