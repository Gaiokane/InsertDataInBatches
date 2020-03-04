﻿namespace InsertDataInBatches
{
    partial class Form1
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
            this.labHost = new System.Windows.Forms.Label();
            this.txtboxHost = new System.Windows.Forms.TextBox();
            this.labDatabase = new System.Windows.Forms.Label();
            this.txtboxDatabase = new System.Windows.Forms.TextBox();
            this.labUsername = new System.Windows.Forms.Label();
            this.txtboxUsername = new System.Windows.Forms.TextBox();
            this.labPassword = new System.Windows.Forms.Label();
            this.txtboxPassword = new System.Windows.Forms.TextBox();
            this.radiobtnMSSQL = new System.Windows.Forms.RadioButton();
            this.radiobtnMYSQL = new System.Windows.Forms.RadioButton();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.labConnectStatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
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
            this.groupBox1.Size = new System.Drawing.Size(708, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库";
            // 
            // labHost
            // 
            this.labHost.AutoSize = true;
            this.labHost.Location = new System.Drawing.Point(7, 49);
            this.labHost.Name = "labHost";
            this.labHost.Size = new System.Drawing.Size(41, 12);
            this.labHost.TabIndex = 3;
            this.labHost.Text = "Host：";
            // 
            // txtboxHost
            // 
            this.txtboxHost.Location = new System.Drawing.Point(54, 46);
            this.txtboxHost.Name = "txtboxHost";
            this.txtboxHost.Size = new System.Drawing.Size(100, 21);
            this.txtboxHost.TabIndex = 4;
            // 
            // labDatabase
            // 
            this.labDatabase.AutoSize = true;
            this.labDatabase.Location = new System.Drawing.Point(160, 49);
            this.labDatabase.Name = "labDatabase";
            this.labDatabase.Size = new System.Drawing.Size(65, 12);
            this.labDatabase.TabIndex = 5;
            this.labDatabase.Text = "Database：";
            // 
            // txtboxDatabase
            // 
            this.txtboxDatabase.Location = new System.Drawing.Point(231, 46);
            this.txtboxDatabase.Name = "txtboxDatabase";
            this.txtboxDatabase.Size = new System.Drawing.Size(100, 21);
            this.txtboxDatabase.TabIndex = 6;
            // 
            // labUsername
            // 
            this.labUsername.AutoSize = true;
            this.labUsername.Location = new System.Drawing.Point(337, 49);
            this.labUsername.Name = "labUsername";
            this.labUsername.Size = new System.Drawing.Size(65, 12);
            this.labUsername.TabIndex = 7;
            this.labUsername.Text = "Username：";
            // 
            // txtboxUsername
            // 
            this.txtboxUsername.Location = new System.Drawing.Point(408, 46);
            this.txtboxUsername.Name = "txtboxUsername";
            this.txtboxUsername.Size = new System.Drawing.Size(100, 21);
            this.txtboxUsername.TabIndex = 8;
            // 
            // labPassword
            // 
            this.labPassword.AutoSize = true;
            this.labPassword.Location = new System.Drawing.Point(514, 49);
            this.labPassword.Name = "labPassword";
            this.labPassword.Size = new System.Drawing.Size(65, 12);
            this.labPassword.TabIndex = 9;
            this.labPassword.Text = "Password：";
            // 
            // txtboxPassword
            // 
            this.txtboxPassword.Location = new System.Drawing.Point(585, 46);
            this.txtboxPassword.Name = "txtboxPassword";
            this.txtboxPassword.Size = new System.Drawing.Size(100, 21);
            this.txtboxPassword.TabIndex = 10;
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
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(124, 17);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 11;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(205, 17);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 12;
            this.btnDisconnect.Text = "断开";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // labConnectStatus
            // 
            this.labConnectStatus.AutoSize = true;
            this.labConnectStatus.Location = new System.Drawing.Point(286, 22);
            this.labConnectStatus.Name = "labConnectStatus";
            this.labConnectStatus.Size = new System.Drawing.Size(41, 12);
            this.labConnectStatus.TabIndex = 13;
            this.labConnectStatus.Text = "状态：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

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
    }
}

