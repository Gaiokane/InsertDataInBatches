namespace InsertDataInBatches
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupbox_DataBase = new System.Windows.Forms.GroupBox();
            this.comBoxDatabase = new System.Windows.Forms.ComboBox();
            this.comBoxHost = new System.Windows.Forms.ComboBox();
            this.chkboxPort = new System.Windows.Forms.CheckBox();
            this.txtboxPort = new System.Windows.Forms.TextBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.radiobtnMYSQL = new System.Windows.Forms.RadioButton();
            this.radiobtnMSSQL = new System.Windows.Forms.RadioButton();
            this.txtboxPassword = new System.Windows.Forms.TextBox();
            this.txtboxUsername = new System.Windows.Forms.TextBox();
            this.txtboxDatabase = new System.Windows.Forms.TextBox();
            this.txtboxHost = new System.Windows.Forms.TextBox();
            this.labPassword = new System.Windows.Forms.Label();
            this.labUsername = new System.Windows.Forms.Label();
            this.labDatabase = new System.Windows.Forms.Label();
            this.labConnectStatus = new System.Windows.Forms.Label();
            this.labHost = new System.Windows.Forms.Label();
            this.richtxtboxInsertSQL = new System.Windows.Forms.RichTextBox();
            this.labInsertSQL = new System.Windows.Forms.Label();
            this.richtxtboxResult = new System.Windows.Forms.RichTextBox();
            this.labNumberOfExecutions = new System.Windows.Forms.Label();
            this.txtboxNumberOfExecutions = new System.Windows.Forms.TextBox();
            this.btnStartInserting = new System.Windows.Forms.Button();
            this.labResult = new System.Windows.Forms.Label();
            this.groupbox_QuickInsert = new System.Windows.Forms.GroupBox();
            this.btn_QuickInsert_Insert = new System.Windows.Forms.Button();
            this.btn_QuickInsert_Settings = new System.Windows.Forms.Button();
            this.cmbox_QuickInsert_List = new System.Windows.Forms.ComboBox();
            this.groupbox_CommonlyUsedSQL = new System.Windows.Forms.GroupBox();
            this.btn_CommonlyUsedSQL_Settings = new System.Windows.Forms.Button();
            this.btn_CommonlyUsedSQL_New = new System.Windows.Forms.Button();
            this.btn_CommonlyUsedSQL_Insert = new System.Windows.Forms.Button();
            this.cmbox_CommonlyUsedSQL_List = new System.Windows.Forms.ComboBox();
            this.btn_QuickInsert_Instruction = new System.Windows.Forms.Button();
            this.groupbox_DataBase.SuspendLayout();
            this.groupbox_QuickInsert.SuspendLayout();
            this.groupbox_CommonlyUsedSQL.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupbox_DataBase
            // 
            this.groupbox_DataBase.Controls.Add(this.comBoxDatabase);
            this.groupbox_DataBase.Controls.Add(this.comBoxHost);
            this.groupbox_DataBase.Controls.Add(this.chkboxPort);
            this.groupbox_DataBase.Controls.Add(this.txtboxPort);
            this.groupbox_DataBase.Controls.Add(this.btnDisconnect);
            this.groupbox_DataBase.Controls.Add(this.btnConnect);
            this.groupbox_DataBase.Controls.Add(this.radiobtnMYSQL);
            this.groupbox_DataBase.Controls.Add(this.radiobtnMSSQL);
            this.groupbox_DataBase.Controls.Add(this.txtboxPassword);
            this.groupbox_DataBase.Controls.Add(this.txtboxUsername);
            this.groupbox_DataBase.Controls.Add(this.txtboxDatabase);
            this.groupbox_DataBase.Controls.Add(this.txtboxHost);
            this.groupbox_DataBase.Controls.Add(this.labPassword);
            this.groupbox_DataBase.Controls.Add(this.labUsername);
            this.groupbox_DataBase.Controls.Add(this.labDatabase);
            this.groupbox_DataBase.Controls.Add(this.labConnectStatus);
            this.groupbox_DataBase.Controls.Add(this.labHost);
            this.groupbox_DataBase.Location = new System.Drawing.Point(12, 12);
            this.groupbox_DataBase.Name = "groupbox_DataBase";
            this.groupbox_DataBase.Size = new System.Drawing.Size(894, 83);
            this.groupbox_DataBase.TabIndex = 0;
            this.groupbox_DataBase.TabStop = false;
            this.groupbox_DataBase.Text = "数据库";
            // 
            // comBoxDatabase
            // 
            this.comBoxDatabase.FormattingEnabled = true;
            this.comBoxDatabase.Location = new System.Drawing.Point(496, 16);
            this.comBoxDatabase.Name = "comBoxDatabase";
            this.comBoxDatabase.Size = new System.Drawing.Size(121, 20);
            this.comBoxDatabase.TabIndex = 18;
            this.comBoxDatabase.DropDown += new System.EventHandler(this.comBoxDatabase_DropDown);
            this.comBoxDatabase.TextUpdate += new System.EventHandler(this.comBoxDatabase_TextUpdate);
            this.comBoxDatabase.DropDownClosed += new System.EventHandler(this.comBoxDatabase_DropDownClosed);
            // 
            // comBoxHost
            // 
            this.comBoxHost.FormattingEnabled = true;
            this.comBoxHost.Location = new System.Drawing.Point(369, 16);
            this.comBoxHost.Name = "comBoxHost";
            this.comBoxHost.Size = new System.Drawing.Size(121, 20);
            this.comBoxHost.TabIndex = 17;
            this.comBoxHost.DropDown += new System.EventHandler(this.comBoxHost_DropDown);
            this.comBoxHost.TextUpdate += new System.EventHandler(this.comBoxHost_TextUpdate);
            this.comBoxHost.DropDownClosed += new System.EventHandler(this.comBoxHost_DropDownClosed);
            // 
            // chkboxPort
            // 
            this.chkboxPort.AutoSize = true;
            this.chkboxPort.Location = new System.Drawing.Point(183, 49);
            this.chkboxPort.Name = "chkboxPort";
            this.chkboxPort.Size = new System.Drawing.Size(60, 16);
            this.chkboxPort.TabIndex = 16;
            this.chkboxPort.Text = "Port：";
            this.chkboxPort.UseVisualStyleBackColor = true;
            // 
            // txtboxPort
            // 
            this.txtboxPort.Location = new System.Drawing.Point(249, 46);
            this.txtboxPort.Name = "txtboxPort";
            this.txtboxPort.Size = new System.Drawing.Size(62, 21);
            this.txtboxPort.TabIndex = 6;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(205, 17);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 14;
            this.btnDisconnect.Text = "断开";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(124, 17);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 13;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // radiobtnMYSQL
            // 
            this.radiobtnMYSQL.AutoSize = true;
            this.radiobtnMYSQL.Location = new System.Drawing.Point(65, 20);
            this.radiobtnMYSQL.Name = "radiobtnMYSQL";
            this.radiobtnMYSQL.Size = new System.Drawing.Size(53, 16);
            this.radiobtnMYSQL.TabIndex = 2;
            this.radiobtnMYSQL.TabStop = true;
            this.radiobtnMYSQL.Text = "mysql";
            this.radiobtnMYSQL.UseVisualStyleBackColor = true;
            // 
            // radiobtnMSSQL
            // 
            this.radiobtnMSSQL.AutoSize = true;
            this.radiobtnMSSQL.Location = new System.Drawing.Point(6, 20);
            this.radiobtnMSSQL.Name = "radiobtnMSSQL";
            this.radiobtnMSSQL.Size = new System.Drawing.Size(53, 16);
            this.radiobtnMSSQL.TabIndex = 1;
            this.radiobtnMSSQL.TabStop = true;
            this.radiobtnMSSQL.Text = "mssql";
            this.radiobtnMSSQL.UseVisualStyleBackColor = true;
            this.radiobtnMSSQL.CheckedChanged += new System.EventHandler(this.radiobtnMSSQL_CheckedChanged);
            // 
            // txtboxPassword
            // 
            this.txtboxPassword.Location = new System.Drawing.Point(757, 46);
            this.txtboxPassword.Name = "txtboxPassword";
            this.txtboxPassword.Size = new System.Drawing.Size(100, 21);
            this.txtboxPassword.TabIndex = 12;
            // 
            // txtboxUsername
            // 
            this.txtboxUsername.Location = new System.Drawing.Point(595, 46);
            this.txtboxUsername.Name = "txtboxUsername";
            this.txtboxUsername.Size = new System.Drawing.Size(85, 21);
            this.txtboxUsername.TabIndex = 10;
            // 
            // txtboxDatabase
            // 
            this.txtboxDatabase.Location = new System.Drawing.Point(388, 46);
            this.txtboxDatabase.Name = "txtboxDatabase";
            this.txtboxDatabase.Size = new System.Drawing.Size(130, 21);
            this.txtboxDatabase.TabIndex = 8;
            // 
            // txtboxHost
            // 
            this.txtboxHost.Location = new System.Drawing.Point(54, 46);
            this.txtboxHost.Name = "txtboxHost";
            this.txtboxHost.Size = new System.Drawing.Size(123, 21);
            this.txtboxHost.TabIndex = 4;
            // 
            // labPassword
            // 
            this.labPassword.AutoSize = true;
            this.labPassword.Location = new System.Drawing.Point(686, 50);
            this.labPassword.Name = "labPassword";
            this.labPassword.Size = new System.Drawing.Size(65, 12);
            this.labPassword.TabIndex = 11;
            this.labPassword.Text = "Password：";
            // 
            // labUsername
            // 
            this.labUsername.AutoSize = true;
            this.labUsername.Location = new System.Drawing.Point(524, 50);
            this.labUsername.Name = "labUsername";
            this.labUsername.Size = new System.Drawing.Size(65, 12);
            this.labUsername.TabIndex = 9;
            this.labUsername.Text = "Username：";
            // 
            // labDatabase
            // 
            this.labDatabase.AutoSize = true;
            this.labDatabase.Location = new System.Drawing.Point(317, 50);
            this.labDatabase.Name = "labDatabase";
            this.labDatabase.Size = new System.Drawing.Size(65, 12);
            this.labDatabase.TabIndex = 7;
            this.labDatabase.Text = "Database：";
            // 
            // labConnectStatus
            // 
            this.labConnectStatus.AutoSize = true;
            this.labConnectStatus.Location = new System.Drawing.Point(286, 22);
            this.labConnectStatus.Name = "labConnectStatus";
            this.labConnectStatus.Size = new System.Drawing.Size(77, 12);
            this.labConnectStatus.TabIndex = 15;
            this.labConnectStatus.Text = "状态：已断开";
            // 
            // labHost
            // 
            this.labHost.AutoSize = true;
            this.labHost.Location = new System.Drawing.Point(7, 50);
            this.labHost.Name = "labHost";
            this.labHost.Size = new System.Drawing.Size(41, 12);
            this.labHost.TabIndex = 3;
            this.labHost.Text = "Host：";
            // 
            // richtxtboxInsertSQL
            // 
            this.richtxtboxInsertSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richtxtboxInsertSQL.Location = new System.Drawing.Point(12, 113);
            this.richtxtboxInsertSQL.Name = "richtxtboxInsertSQL";
            this.richtxtboxInsertSQL.Size = new System.Drawing.Size(732, 137);
            this.richtxtboxInsertSQL.TabIndex = 1;
            this.richtxtboxInsertSQL.Text = "";
            // 
            // labInsertSQL
            // 
            this.labInsertSQL.AutoSize = true;
            this.labInsertSQL.Location = new System.Drawing.Point(10, 98);
            this.labInsertSQL.Name = "labInsertSQL";
            this.labInsertSQL.Size = new System.Drawing.Size(77, 12);
            this.labInsertSQL.TabIndex = 2;
            this.labInsertSQL.Text = "insert语句：";
            // 
            // richtxtboxResult
            // 
            this.richtxtboxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richtxtboxResult.Location = new System.Drawing.Point(12, 268);
            this.richtxtboxResult.Name = "richtxtboxResult";
            this.richtxtboxResult.Size = new System.Drawing.Size(732, 170);
            this.richtxtboxResult.TabIndex = 1;
            this.richtxtboxResult.Text = "";
            // 
            // labNumberOfExecutions
            // 
            this.labNumberOfExecutions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labNumberOfExecutions.AutoSize = true;
            this.labNumberOfExecutions.Location = new System.Drawing.Point(750, 113);
            this.labNumberOfExecutions.Name = "labNumberOfExecutions";
            this.labNumberOfExecutions.Size = new System.Drawing.Size(65, 12);
            this.labNumberOfExecutions.TabIndex = 3;
            this.labNumberOfExecutions.Text = "执行次数：";
            // 
            // txtboxNumberOfExecutions
            // 
            this.txtboxNumberOfExecutions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxNumberOfExecutions.Location = new System.Drawing.Point(750, 128);
            this.txtboxNumberOfExecutions.Name = "txtboxNumberOfExecutions";
            this.txtboxNumberOfExecutions.Size = new System.Drawing.Size(100, 21);
            this.txtboxNumberOfExecutions.TabIndex = 4;
            // 
            // btnStartInserting
            // 
            this.btnStartInserting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartInserting.Location = new System.Drawing.Point(750, 155);
            this.btnStartInserting.Name = "btnStartInserting";
            this.btnStartInserting.Size = new System.Drawing.Size(75, 23);
            this.btnStartInserting.TabIndex = 5;
            this.btnStartInserting.Text = "开始插入";
            this.btnStartInserting.UseVisualStyleBackColor = true;
            this.btnStartInserting.Click += new System.EventHandler(this.btnStartInserting_Click);
            // 
            // labResult
            // 
            this.labResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labResult.AutoSize = true;
            this.labResult.Location = new System.Drawing.Point(12, 253);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(65, 12);
            this.labResult.TabIndex = 6;
            this.labResult.Text = "执行情况：";
            // 
            // groupbox_QuickInsert
            // 
            this.groupbox_QuickInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupbox_QuickInsert.Controls.Add(this.btn_QuickInsert_Instruction);
            this.groupbox_QuickInsert.Controls.Add(this.btn_QuickInsert_Insert);
            this.groupbox_QuickInsert.Controls.Add(this.btn_QuickInsert_Settings);
            this.groupbox_QuickInsert.Controls.Add(this.cmbox_QuickInsert_List);
            this.groupbox_QuickInsert.Location = new System.Drawing.Point(750, 184);
            this.groupbox_QuickInsert.Name = "groupbox_QuickInsert";
            this.groupbox_QuickInsert.Size = new System.Drawing.Size(156, 78);
            this.groupbox_QuickInsert.TabIndex = 11;
            this.groupbox_QuickInsert.TabStop = false;
            this.groupbox_QuickInsert.Text = "快捷插入";
            // 
            // btn_QuickInsert_Insert
            // 
            this.btn_QuickInsert_Insert.Location = new System.Drawing.Point(110, 18);
            this.btn_QuickInsert_Insert.Name = "btn_QuickInsert_Insert";
            this.btn_QuickInsert_Insert.Size = new System.Drawing.Size(40, 23);
            this.btn_QuickInsert_Insert.TabIndex = 2;
            this.btn_QuickInsert_Insert.Text = "插入";
            this.btn_QuickInsert_Insert.UseVisualStyleBackColor = true;
            this.btn_QuickInsert_Insert.Click += new System.EventHandler(this.btn_QuickInsert_Insert_Click);
            // 
            // btn_QuickInsert_Settings
            // 
            this.btn_QuickInsert_Settings.Location = new System.Drawing.Point(6, 47);
            this.btn_QuickInsert_Settings.Name = "btn_QuickInsert_Settings";
            this.btn_QuickInsert_Settings.Size = new System.Drawing.Size(98, 23);
            this.btn_QuickInsert_Settings.TabIndex = 1;
            this.btn_QuickInsert_Settings.Text = "快捷插入配置";
            this.btn_QuickInsert_Settings.UseVisualStyleBackColor = true;
            this.btn_QuickInsert_Settings.Click += new System.EventHandler(this.btn_QuickInsert_Settings_Click);
            // 
            // cmbox_QuickInsert_List
            // 
            this.cmbox_QuickInsert_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbox_QuickInsert_List.FormattingEnabled = true;
            this.cmbox_QuickInsert_List.Location = new System.Drawing.Point(6, 20);
            this.cmbox_QuickInsert_List.Name = "cmbox_QuickInsert_List";
            this.cmbox_QuickInsert_List.Size = new System.Drawing.Size(98, 20);
            this.cmbox_QuickInsert_List.TabIndex = 0;
            // 
            // groupbox_CommonlyUsedSQL
            // 
            this.groupbox_CommonlyUsedSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupbox_CommonlyUsedSQL.Controls.Add(this.btn_CommonlyUsedSQL_Settings);
            this.groupbox_CommonlyUsedSQL.Controls.Add(this.btn_CommonlyUsedSQL_New);
            this.groupbox_CommonlyUsedSQL.Controls.Add(this.btn_CommonlyUsedSQL_Insert);
            this.groupbox_CommonlyUsedSQL.Controls.Add(this.cmbox_CommonlyUsedSQL_List);
            this.groupbox_CommonlyUsedSQL.Location = new System.Drawing.Point(750, 268);
            this.groupbox_CommonlyUsedSQL.Name = "groupbox_CommonlyUsedSQL";
            this.groupbox_CommonlyUsedSQL.Size = new System.Drawing.Size(156, 75);
            this.groupbox_CommonlyUsedSQL.TabIndex = 12;
            this.groupbox_CommonlyUsedSQL.TabStop = false;
            this.groupbox_CommonlyUsedSQL.Text = "常用SQL";
            // 
            // btn_CommonlyUsedSQL_Settings
            // 
            this.btn_CommonlyUsedSQL_Settings.Location = new System.Drawing.Point(110, 46);
            this.btn_CommonlyUsedSQL_Settings.Name = "btn_CommonlyUsedSQL_Settings";
            this.btn_CommonlyUsedSQL_Settings.Size = new System.Drawing.Size(40, 23);
            this.btn_CommonlyUsedSQL_Settings.TabIndex = 3;
            this.btn_CommonlyUsedSQL_Settings.Text = "配置";
            this.btn_CommonlyUsedSQL_Settings.UseVisualStyleBackColor = true;
            this.btn_CommonlyUsedSQL_Settings.Click += new System.EventHandler(this.btn_CommonlyUsedSQL_Settings_Click);
            // 
            // btn_CommonlyUsedSQL_New
            // 
            this.btn_CommonlyUsedSQL_New.Location = new System.Drawing.Point(58, 46);
            this.btn_CommonlyUsedSQL_New.Name = "btn_CommonlyUsedSQL_New";
            this.btn_CommonlyUsedSQL_New.Size = new System.Drawing.Size(40, 23);
            this.btn_CommonlyUsedSQL_New.TabIndex = 2;
            this.btn_CommonlyUsedSQL_New.Text = "新增";
            this.btn_CommonlyUsedSQL_New.UseVisualStyleBackColor = true;
            this.btn_CommonlyUsedSQL_New.Click += new System.EventHandler(this.btn_CommonlyUsedSQL_New_Click);
            // 
            // btn_CommonlyUsedSQL_Insert
            // 
            this.btn_CommonlyUsedSQL_Insert.Location = new System.Drawing.Point(6, 46);
            this.btn_CommonlyUsedSQL_Insert.Name = "btn_CommonlyUsedSQL_Insert";
            this.btn_CommonlyUsedSQL_Insert.Size = new System.Drawing.Size(40, 23);
            this.btn_CommonlyUsedSQL_Insert.TabIndex = 1;
            this.btn_CommonlyUsedSQL_Insert.Text = "插入";
            this.btn_CommonlyUsedSQL_Insert.UseVisualStyleBackColor = true;
            this.btn_CommonlyUsedSQL_Insert.Click += new System.EventHandler(this.btn_CommonlyUsedSQL_Insert_Click);
            // 
            // cmbox_CommonlyUsedSQL_List
            // 
            this.cmbox_CommonlyUsedSQL_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbox_CommonlyUsedSQL_List.FormattingEnabled = true;
            this.cmbox_CommonlyUsedSQL_List.Location = new System.Drawing.Point(6, 20);
            this.cmbox_CommonlyUsedSQL_List.Name = "cmbox_CommonlyUsedSQL_List";
            this.cmbox_CommonlyUsedSQL_List.Size = new System.Drawing.Size(144, 20);
            this.cmbox_CommonlyUsedSQL_List.TabIndex = 0;
            // 
            // btn_QuickInsert_Instruction
            // 
            this.btn_QuickInsert_Instruction.Location = new System.Drawing.Point(110, 47);
            this.btn_QuickInsert_Instruction.Name = "btn_QuickInsert_Instruction";
            this.btn_QuickInsert_Instruction.Size = new System.Drawing.Size(40, 23);
            this.btn_QuickInsert_Instruction.TabIndex = 3;
            this.btn_QuickInsert_Instruction.Text = "说明";
            this.btn_QuickInsert_Instruction.UseVisualStyleBackColor = true;
            this.btn_QuickInsert_Instruction.Click += new System.EventHandler(this.btn_QuickInsert_Instruction_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 450);
            this.Controls.Add(this.groupbox_CommonlyUsedSQL);
            this.Controls.Add(this.groupbox_QuickInsert);
            this.Controls.Add(this.labResult);
            this.Controls.Add(this.btnStartInserting);
            this.Controls.Add(this.txtboxNumberOfExecutions);
            this.Controls.Add(this.labNumberOfExecutions);
            this.Controls.Add(this.labInsertSQL);
            this.Controls.Add(this.richtxtboxResult);
            this.Controls.Add(this.richtxtboxInsertSQL);
            this.Controls.Add(this.groupbox_DataBase);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量插数据小工具";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupbox_DataBase.ResumeLayout(false);
            this.groupbox_DataBase.PerformLayout();
            this.groupbox_QuickInsert.ResumeLayout(false);
            this.groupbox_CommonlyUsedSQL.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupbox_DataBase;
        private System.Windows.Forms.Label labHost;
        private System.Windows.Forms.TextBox txtboxPassword;
        private System.Windows.Forms.TextBox txtboxUsername;
        private System.Windows.Forms.TextBox txtboxDatabase;
        private System.Windows.Forms.TextBox txtboxHost;
        private System.Windows.Forms.Label labPassword;
        private System.Windows.Forms.Label labUsername;
        private System.Windows.Forms.Label labDatabase;
        private System.Windows.Forms.RadioButton radiobtnMYSQL;
        private System.Windows.Forms.RadioButton radiobtnMSSQL;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label labConnectStatus;
        private System.Windows.Forms.TextBox txtboxPort;
        private System.Windows.Forms.RichTextBox richtxtboxInsertSQL;
        private System.Windows.Forms.Label labInsertSQL;
        private System.Windows.Forms.RichTextBox richtxtboxResult;
        private System.Windows.Forms.Label labNumberOfExecutions;
        private System.Windows.Forms.TextBox txtboxNumberOfExecutions;
        private System.Windows.Forms.Button btnStartInserting;
        private System.Windows.Forms.Label labResult;
        private System.Windows.Forms.CheckBox chkboxPort;
        private System.Windows.Forms.GroupBox groupbox_QuickInsert;
        private System.Windows.Forms.Button btn_QuickInsert_Insert;
        private System.Windows.Forms.Button btn_QuickInsert_Settings;
        private System.Windows.Forms.ComboBox cmbox_QuickInsert_List;
        private System.Windows.Forms.GroupBox groupbox_CommonlyUsedSQL;
        private System.Windows.Forms.ComboBox cmbox_CommonlyUsedSQL_List;
        private System.Windows.Forms.Button btn_CommonlyUsedSQL_New;
        private System.Windows.Forms.Button btn_CommonlyUsedSQL_Insert;
        private System.Windows.Forms.Button btn_CommonlyUsedSQL_Settings;
        private System.Windows.Forms.ComboBox comBoxHost;
        private System.Windows.Forms.ComboBox comBoxDatabase;
        private System.Windows.Forms.Button btn_QuickInsert_Instruction;
    }
}

