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
            this.lblNumDevices = new System.Windows.Forms.Label();
            this.btnCloseAll = new System.Windows.Forms.Button();
            this.btnGetDevice = new System.Windows.Forms.Button();
            this.grpReaders = new System.Windows.Forms.GroupBox();
            this.btnGetReader = new System.Windows.Forms.Button();
            this.lblNumReaders = new System.Windows.Forms.Label();
            this.btnFindReaders = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpReaders.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(13, 262);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(489, 136);
            this.txtLog.TabIndex = 0;
            // 
            // btnFindDevices
            // 
            this.btnFindDevices.Location = new System.Drawing.Point(6, 19);
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
            this.groupBox1.Controls.Add(this.btnGetDevice);
            this.groupBox1.Controls.Add(this.lblNumDevices);
            this.groupBox1.Controls.Add(this.btnFindDevices);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 176);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hardware Devices";
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
            this.btnCloseAll.Location = new System.Drawing.Point(13, 222);
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.Size = new System.Drawing.Size(119, 23);
            this.btnCloseAll.TabIndex = 4;
            this.btnCloseAll.Text = "Close SkyeNet...";
            this.btnCloseAll.UseVisualStyleBackColor = true;
            this.btnCloseAll.Click += new System.EventHandler(this.btnCloseAll_Click);
            // 
            // btnGetDevice
            // 
            this.btnGetDevice.Location = new System.Drawing.Point(19, 104);
            this.btnGetDevice.Name = "btnGetDevice";
            this.btnGetDevice.Size = new System.Drawing.Size(124, 23);
            this.btnGetDevice.TabIndex = 4;
            this.btnGetDevice.Text = "Get Device...";
            this.btnGetDevice.UseVisualStyleBackColor = true;
            this.btnGetDevice.Click += new System.EventHandler(this.btnGetDevice_Click);
            // 
            // grpReaders
            // 
            this.grpReaders.Controls.Add(this.btnGetReader);
            this.grpReaders.Controls.Add(this.lblNumReaders);
            this.grpReaders.Controls.Add(this.btnFindReaders);
            this.grpReaders.Controls.Add(this.label3);
            this.grpReaders.Enabled = false;
            this.grpReaders.Location = new System.Drawing.Point(230, 12);
            this.grpReaders.Name = "grpReaders";
            this.grpReaders.Size = new System.Drawing.Size(200, 176);
            this.grpReaders.TabIndex = 5;
            this.grpReaders.TabStop = false;
            this.grpReaders.Text = "RFID Readers";
            // 
            // btnGetReader
            // 
            this.btnGetReader.Location = new System.Drawing.Point(19, 104);
            this.btnGetReader.Name = "btnGetReader";
            this.btnGetReader.Size = new System.Drawing.Size(124, 23);
            this.btnGetReader.TabIndex = 4;
            this.btnGetReader.Text = "Get Reader...";
            this.btnGetReader.UseVisualStyleBackColor = true;
            this.btnGetReader.Click += new System.EventHandler(this.btnGetReader_Click);
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
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number of Devices Attached:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 410);
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
        private System.Windows.Forms.Button btnGetDevice;
        private System.Windows.Forms.GroupBox grpReaders;
        private System.Windows.Forms.Button btnGetReader;
        private System.Windows.Forms.Label lblNumReaders;
        private System.Windows.Forms.Button btnFindReaders;
        private System.Windows.Forms.Label label3;
    }
}

