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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.fastbtn_idIncreasing = new System.Windows.Forms.Button();
            this.fastbtn_randomNum = new System.Windows.Forms.Button();
            this.fastbtn_newid = new System.Windows.Forms.Button();
            this.fastbtn_newdatetime = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkboxPort);
            this.groupBox1.Controls.Add(this.txtboxPort);
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.radiobtnMYSQL);
            this.groupBox1.Controls.Add(this.radiobtnMSSQL);
            this.groupBox1.Controls.Add(this.txtboxPassword);
            this.groupBox1.Controls.Add(this.txtboxUsername);
            this.groupBox1.Controls.Add(this.txtboxDatabase);
            this.groupBox1.Controls.Add(this.txtboxHost);
            this.groupBox1.Controls.Add(this.labPassword);
            this.groupBox1.Controls.Add(this.labUsername);
            this.groupBox1.Controls.Add(this.labDatabase);
            this.groupBox1.Controls.Add(this.labConnectStatus);
            this.groupBox1.Controls.Add(this.labHost);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(894, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库";
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
            this.richtxtboxInsertSQL.Location = new System.Drawing.Point(12, 113);
            this.richtxtboxInsertSQL.Name = "richtxtboxInsertSQL";
            this.richtxtboxInsertSQL.Size = new System.Drawing.Size(732, 100);
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
            this.richtxtboxResult.Location = new System.Drawing.Point(12, 231);
            this.richtxtboxResult.Name = "richtxtboxResult";
            this.richtxtboxResult.Size = new System.Drawing.Size(732, 207);
            this.richtxtboxResult.TabIndex = 1;
            this.richtxtboxResult.Text = "";
            // 
            // labNumberOfExecutions
            // 
            this.labNumberOfExecutions.AutoSize = true;
            this.labNumberOfExecutions.Location = new System.Drawing.Point(750, 113);
            this.labNumberOfExecutions.Name = "labNumberOfExecutions";
            this.labNumberOfExecutions.Size = new System.Drawing.Size(65, 12);
            this.labNumberOfExecutions.TabIndex = 3;
            this.labNumberOfExecutions.Text = "执行次数：";
            // 
            // txtboxNumberOfExecutions
            // 
            this.txtboxNumberOfExecutions.Location = new System.Drawing.Point(750, 128);
            this.txtboxNumberOfExecutions.Name = "txtboxNumberOfExecutions";
            this.txtboxNumberOfExecutions.Size = new System.Drawing.Size(100, 21);
            this.txtboxNumberOfExecutions.TabIndex = 4;
            // 
            // btnStartInserting
            // 
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
            this.labResult.AutoSize = true;
            this.labResult.Location = new System.Drawing.Point(10, 216);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(65, 12);
            this.labResult.TabIndex = 6;
            this.labResult.Text = "执行情况：";
            // 
            // fastbtn_idIncreasing
            // 
            this.fastbtn_idIncreasing.Location = new System.Drawing.Point(750, 190);
            this.fastbtn_idIncreasing.Name = "fastbtn_idIncreasing";
            this.fastbtn_idIncreasing.Size = new System.Drawing.Size(75, 23);
            this.fastbtn_idIncreasing.TabIndex = 7;
            this.fastbtn_idIncreasing.Text = "id递增";
            this.fastbtn_idIncreasing.UseVisualStyleBackColor = true;
            this.fastbtn_idIncreasing.Click += new System.EventHandler(this.fastbtn_idIncreasing_Click);
            // 
            // fastbtn_randomNum
            // 
            this.fastbtn_randomNum.Location = new System.Drawing.Point(750, 219);
            this.fastbtn_randomNum.Name = "fastbtn_randomNum";
            this.fastbtn_randomNum.Size = new System.Drawing.Size(75, 23);
            this.fastbtn_randomNum.TabIndex = 8;
            this.fastbtn_randomNum.Text = "随机数";
            this.fastbtn_randomNum.UseVisualStyleBackColor = true;
            this.fastbtn_randomNum.Click += new System.EventHandler(this.fastbtn_randomNum_Click);
            // 
            // fastbtn_newid
            // 
            this.fastbtn_newid.Location = new System.Drawing.Point(750, 248);
            this.fastbtn_newid.Name = "fastbtn_newid";
            this.fastbtn_newid.Size = new System.Drawing.Size(75, 23);
            this.fastbtn_newid.TabIndex = 9;
            this.fastbtn_newid.Text = "生成newid";
            this.fastbtn_newid.UseVisualStyleBackColor = true;
            this.fastbtn_newid.Click += new System.EventHandler(this.fastbtn_newid_Click);
            // 
            // fastbtn_newdatetime
            // 
            this.fastbtn_newdatetime.Location = new System.Drawing.Point(750, 277);
            this.fastbtn_newdatetime.Name = "fastbtn_newdatetime";
            this.fastbtn_newdatetime.Size = new System.Drawing.Size(75, 23);
            this.fastbtn_newdatetime.TabIndex = 10;
            this.fastbtn_newdatetime.Text = "时间递增";
            this.fastbtn_newdatetime.UseVisualStyleBackColor = true;
            this.fastbtn_newdatetime.Click += new System.EventHandler(this.fastbtn_newdatetime_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 450);
            this.Controls.Add(this.fastbtn_newdatetime);
            this.Controls.Add(this.fastbtn_newid);
            this.Controls.Add(this.fastbtn_randomNum);
            this.Controls.Add(this.fastbtn_idIncreasing);
            this.Controls.Add(this.labResult);
            this.Controls.Add(this.btnStartInserting);
            this.Controls.Add(this.txtboxNumberOfExecutions);
            this.Controls.Add(this.labNumberOfExecutions);
            this.Controls.Add(this.labInsertSQL);
            this.Controls.Add(this.richtxtboxResult);
            this.Controls.Add(this.richtxtboxInsertSQL);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.Button fastbtn_idIncreasing;
        private System.Windows.Forms.Button fastbtn_randomNum;
        private System.Windows.Forms.Button fastbtn_newid;
        private System.Windows.Forms.Button fastbtn_newdatetime;
    }
}

