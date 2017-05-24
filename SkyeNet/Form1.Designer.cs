namespace SkyeNetDemo
{
    partial class Form1
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
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnFindDevices = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAllDevices = new System.Windows.Forms.CheckBox();
            this.cmbDevices = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumDevices = new System.Windows.Forms.Label();
            this.btnCloseAll = new System.Windows.Forms.Button();
            this.grpReaders = new System.Windows.Forms.GroupBox();
            this.cmbReaders = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNumReaders = new System.Windows.Forms.Label();
            this.btnFindReaders = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.grpTags = new System.Windows.Forms.GroupBox();
            this.cmbTags = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNumTags = new System.Windows.Forms.Label();
            this.btnGetTags = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpReaders.SuspendLayout();
            this.grpTags.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(13, 194);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(643, 204);
            this.txtLog.TabIndex = 0;
            // 
            // btnFindDevices
            // 
            this.btnFindDevices.Location = new System.Drawing.Point(6, 23);
            this.btnFindDevices.Name = "btnFindDevices";
            this.btnFindDevices.Size = new System.Drawing.Size(137, 23);
            this.btnFindDevices.TabIndex = 1;
            this.btnFindDevices.Text = "Find Skyetek Devices...";
            this.btnFindDevices.UseVisualStyleBackColor = true;
            this.btnFindDevices.Click += new System.EventHandler(this.btnFindDevices_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of Devices Attached:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAllDevices);
            this.groupBox1.Controls.Add(this.cmbDevices);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblNumDevices);
            this.groupBox1.Controls.Add(this.btnFindDevices);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 137);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hardware Devices";
            // 
            // chkAllDevices
            // 
            this.chkAllDevices.AutoSize = true;
            this.chkAllDevices.Enabled = false;
            this.chkAllDevices.Location = new System.Drawing.Point(119, 96);
            this.chkAllDevices.Name = "chkAllDevices";
            this.chkAllDevices.Size = new System.Drawing.Size(79, 17);
            this.chkAllDevices.TabIndex = 6;
            this.chkAllDevices.Text = "All Devices";
            this.chkAllDevices.UseVisualStyleBackColor = true;
            this.chkAllDevices.CheckedChanged += new System.EventHandler(this.chkAllDevices_CheckedChanged);
            // 
            // cmbDevices
            // 
            this.cmbDevices.Enabled = false;
            this.cmbDevices.FormattingEnabled = true;
            this.cmbDevices.Location = new System.Drawing.Point(9, 103);
            this.cmbDevices.Name = "cmbDevices";
            this.cmbDevices.Size = new System.Drawing.Size(104, 21);
            this.cmbDevices.TabIndex = 5;
            this.cmbDevices.SelectedIndexChanged += new System.EventHandler(this.cmbDevices_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Active Device";
            // 
            // lblNumDevices
            // 
            this.lblNumDevices.AutoSize = true;
            this.lblNumDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumDevices.Location = new System.Drawing.Point(159, 55);
            this.lblNumDevices.Name = "lblNumDevices";
            this.lblNumDevices.Size = new System.Drawing.Size(14, 13);
            this.lblNumDevices.TabIndex = 3;
            this.lblNumDevices.Text = "0";
            // 
            // btnCloseAll
            // 
            this.btnCloseAll.Location = new System.Drawing.Point(12, 165);
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.Size = new System.Drawing.Size(119, 23);
            this.btnCloseAll.TabIndex = 4;
            this.btnCloseAll.Text = "Close SkyeNet...";
            this.btnCloseAll.UseVisualStyleBackColor = true;
            this.btnCloseAll.Click += new System.EventHandler(this.btnCloseAll_Click);
            // 
            // grpReaders
            // 
            this.grpReaders.Controls.Add(this.cmbReaders);
            this.grpReaders.Controls.Add(this.label4);
            this.grpReaders.Controls.Add(this.lblNumReaders);
            this.grpReaders.Controls.Add(this.btnFindReaders);
            this.grpReaders.Controls.Add(this.label3);
            this.grpReaders.Enabled = false;
            this.grpReaders.Location = new System.Drawing.Point(230, 12);
            this.grpReaders.Name = "grpReaders";
            this.grpReaders.Size = new System.Drawing.Size(200, 137);
            this.grpReaders.TabIndex = 5;
            this.grpReaders.TabStop = false;
            this.grpReaders.Text = "RFID Readers";
            // 
            // cmbReaders
            // 
            this.cmbReaders.Enabled = false;
            this.cmbReaders.FormattingEnabled = true;
            this.cmbReaders.Location = new System.Drawing.Point(9, 103);
            this.cmbReaders.Name = "cmbReaders";
            this.cmbReaders.Size = new System.Drawing.Size(173, 21);
            this.cmbReaders.TabIndex = 7;
            this.cmbReaders.SelectedIndexChanged += new System.EventHandler(this.cmbReaders_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Select Active Reader";
            // 
            // lblNumReaders
            // 
            this.lblNumReaders.AutoSize = true;
            this.lblNumReaders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumReaders.Location = new System.Drawing.Point(159, 55);
            this.lblNumReaders.Name = "lblNumReaders";
            this.lblNumReaders.Size = new System.Drawing.Size(14, 13);
            this.lblNumReaders.TabIndex = 3;
            this.lblNumReaders.Text = "0";
            // 
            // btnFindReaders
            // 
            this.btnFindReaders.Location = new System.Drawing.Point(6, 19);
            this.btnFindReaders.Name = "btnFindReaders";
            this.btnFindReaders.Size = new System.Drawing.Size(137, 23);
            this.btnFindReaders.TabIndex = 1;
            this.btnFindReaders.Text = "Find RFID Readers...";
            this.btnFindReaders.UseVisualStyleBackColor = true;
            this.btnFindReaders.Click += new System.EventHandler(this.btnFindReaders_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number of Readers Attached:";
            // 
            // grpTags
            // 
            this.grpTags.Controls.Add(this.cmbTags);
            this.grpTags.Controls.Add(this.label5);
            this.grpTags.Controls.Add(this.lblNumTags);
            this.grpTags.Controls.Add(this.btnGetTags);
            this.grpTags.Controls.Add(this.label7);
            this.grpTags.Location = new System.Drawing.Point(450, 12);
            this.grpTags.Name = "grpTags";
            this.grpTags.Size = new System.Drawing.Size(200, 137);
            this.grpTags.TabIndex = 6;
            this.grpTags.TabStop = false;
            this.grpTags.Text = "RFID Tags";
            // 
            // cmbTags
            // 
            this.cmbTags.Enabled = false;
            this.cmbTags.FormattingEnabled = true;
            this.cmbTags.Location = new System.Drawing.Point(15, 100);
            this.cmbTags.Name = "cmbTags";
            this.cmbTags.Size = new System.Drawing.Size(173, 21);
            this.cmbTags.TabIndex = 12;
            this.cmbTags.SelectedIndexChanged += new System.EventHandler(this.cmbTags_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Select Tag Reader";
            // 
            // lblNumTags
            // 
            this.lblNumTags.AutoSize = true;
            this.lblNumTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumTags.Location = new System.Drawing.Point(165, 52);
            this.lblNumTags.Name = "lblNumTags";
            this.lblNumTags.Size = new System.Drawing.Size(14, 13);
            this.lblNumTags.TabIndex = 10;
            this.lblNumTags.Text = "0";
            // 
            // btnGetTags
            // 
            this.btnGetTags.Location = new System.Drawing.Point(12, 16);
            this.btnGetTags.Name = "btnGetTags";
            this.btnGetTags.Size = new System.Drawing.Size(137, 23);
            this.btnGetTags.TabIndex = 8;
            this.btnGetTags.Text = "Get Tags...";
            this.btnGetTags.UseVisualStyleBackColor = true;
            this.btnGetTags.Click += new System.EventHandler(this.btnGetTags_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Number of Tags Discovered:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 410);
            this.Controls.Add(this.grpTags);
            this.Controls.Add(this.grpReaders);
            this.Controls.Add(this.btnCloseAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtLog);
            this.Name = "Form1";
            this.Text = "SkyeNet Demo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpReaders.ResumeLayout(false);
            this.grpReaders.PerformLayout();
            this.grpTags.ResumeLayout(false);
            this.grpTags.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnFindDevices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNumDevices;
        private System.Windows.Forms.Button btnCloseAll;
        private System.Windows.Forms.GroupBox grpReaders;
        private System.Windows.Forms.Label lblNumReaders;
        private System.Windows.Forms.Button btnFindReaders;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAllDevices;
        private System.Windows.Forms.ComboBox cmbDevices;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbReaders;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpTags;
        private System.Windows.Forms.ComboBox cmbTags;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNumTags;
        private System.Windows.Forms.Button btnGetTags;
        private System.Windows.Forms.Label label7;
    }
}

