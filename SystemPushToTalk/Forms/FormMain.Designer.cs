namespace SystemPushToTalk.Forms
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.lblMuteStatus = new System.Windows.Forms.Label();
            this.grpDevice = new System.Windows.Forms.GroupBox();
            this.btnShowDevices = new System.Windows.Forms.Button();
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.grpKeyBinding = new System.Windows.Forms.GroupBox();
            this.lblDebounce = new System.Windows.Forms.Label();
            this.trkDebounce = new System.Windows.Forms.TrackBar();
            this.btnSetBinding = new System.Windows.Forms.Button();
            this.lblKeyBinding = new System.Windows.Forms.Label();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.grpDevice.SuspendLayout();
            this.grpKeyBinding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkDebounce)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMuteStatus
            // 
            this.lblMuteStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMuteStatus.ForeColor = System.Drawing.Color.Red;
            this.lblMuteStatus.Location = new System.Drawing.Point(12, 7);
            this.lblMuteStatus.Name = "lblMuteStatus";
            this.lblMuteStatus.Size = new System.Drawing.Size(324, 37);
            this.lblMuteStatus.TabIndex = 0;
            this.lblMuteStatus.Text = "Muted";
            this.lblMuteStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpDevice
            // 
            this.grpDevice.Controls.Add(this.btnShowDevices);
            this.grpDevice.Controls.Add(this.lblDeviceName);
            this.grpDevice.Location = new System.Drawing.Point(12, 47);
            this.grpDevice.Name = "grpDevice";
            this.grpDevice.Size = new System.Drawing.Size(324, 72);
            this.grpDevice.TabIndex = 1;
            this.grpDevice.TabStop = false;
            this.grpDevice.Text = "Recording Device";
            // 
            // btnShowDevices
            // 
            this.btnShowDevices.Location = new System.Drawing.Point(7, 42);
            this.btnShowDevices.Name = "btnShowDevices";
            this.btnShowDevices.Size = new System.Drawing.Size(311, 23);
            this.btnShowDevices.TabIndex = 1;
            this.btnShowDevices.Text = "Show Recording Devices";
            this.btnShowDevices.UseVisualStyleBackColor = true;
            this.btnShowDevices.Click += new System.EventHandler(this.btnShowDevices_Click);
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceName.Location = new System.Drawing.Point(6, 16);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(312, 22);
            this.lblDeviceName.TabIndex = 0;
            this.lblDeviceName.Text = "Device Name";
            this.lblDeviceName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpKeyBinding
            // 
            this.grpKeyBinding.Controls.Add(this.lblDebounce);
            this.grpKeyBinding.Controls.Add(this.trkDebounce);
            this.grpKeyBinding.Controls.Add(this.btnSetBinding);
            this.grpKeyBinding.Controls.Add(this.lblKeyBinding);
            this.grpKeyBinding.Location = new System.Drawing.Point(12, 125);
            this.grpKeyBinding.Name = "grpKeyBinding";
            this.grpKeyBinding.Size = new System.Drawing.Size(324, 131);
            this.grpKeyBinding.TabIndex = 2;
            this.grpKeyBinding.TabStop = false;
            this.grpKeyBinding.Text = "Key Binding";
            // 
            // lblDebounce
            // 
            this.lblDebounce.Location = new System.Drawing.Point(11, 106);
            this.lblDebounce.Name = "lblDebounce";
            this.lblDebounce.Size = new System.Drawing.Size(307, 23);
            this.lblDebounce.TabIndex = 3;
            this.lblDebounce.Text = "Push to Talk Release Delay:";
            // 
            // trkDebounce
            // 
            this.trkDebounce.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trkDebounce.LargeChange = 200;
            this.trkDebounce.Location = new System.Drawing.Point(9, 72);
            this.trkDebounce.Maximum = 1000;
            this.trkDebounce.Name = "trkDebounce";
            this.trkDebounce.Size = new System.Drawing.Size(309, 45);
            this.trkDebounce.SmallChange = 100;
            this.trkDebounce.TabIndex = 2;
            this.trkDebounce.TickFrequency = 50;
            this.trkDebounce.Value = 300;
            this.trkDebounce.ValueChanged += new System.EventHandler(this.trkDebounce_ValueChanged);
            // 
            // btnSetBinding
            // 
            this.btnSetBinding.Location = new System.Drawing.Point(7, 42);
            this.btnSetBinding.Name = "btnSetBinding";
            this.btnSetBinding.Size = new System.Drawing.Size(311, 23);
            this.btnSetBinding.TabIndex = 1;
            this.btnSetBinding.Text = "Change Key Binding";
            this.btnSetBinding.UseVisualStyleBackColor = true;
            this.btnSetBinding.Click += new System.EventHandler(this.btnSetBinding_Click);
            // 
            // lblKeyBinding
            // 
            this.lblKeyBinding.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyBinding.Location = new System.Drawing.Point(6, 16);
            this.lblKeyBinding.Name = "lblKeyBinding";
            this.lblKeyBinding.Size = new System.Drawing.Size(312, 23);
            this.lblKeyBinding.TabIndex = 0;
            this.lblKeyBinding.Text = "Mouse: Left";
            this.lblKeyBinding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trayIcon
            // 
            this.trayIcon.Text = "System Push to Talk.";
            this.trayIcon.Visible = true;
            this.trayIcon.Click += new System.EventHandler(this.trayIcon_Click);
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(12, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Closing this program will unmute your recording device.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 284);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpKeyBinding);
            this.Controls.Add(this.grpDevice);
            this.Controls.Add(this.lblMuteStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Push To Talk";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpDevice.ResumeLayout(false);
            this.grpKeyBinding.ResumeLayout(false);
            this.grpKeyBinding.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkDebounce)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMuteStatus;
        private System.Windows.Forms.GroupBox grpDevice;
        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.GroupBox grpKeyBinding;
        private System.Windows.Forms.Button btnSetBinding;
        private System.Windows.Forms.Label lblKeyBinding;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Label lblDebounce;
        private System.Windows.Forms.TrackBar trkDebounce;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowDevices;
    }
}

