
namespace SystemPushToTalk.Controls
{
    partial class AudioDeviceControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDefault = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceName.Location = new System.Drawing.Point(49, 6);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(210, 23);
            this.lblDeviceName.TabIndex = 0;
            this.lblDeviceName.Text = "Device Friendly Name";
            this.lblDeviceName.Click += new System.EventHandler(this.AudioDeviceControl_Click);
            this.lblDeviceName.MouseEnter += new System.EventHandler(this.AudioDeviceControl_MouseEnter);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(50, 26);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "lblName";
            this.lblName.Click += new System.EventHandler(this.AudioDeviceControl_Click);
            this.lblName.MouseEnter += new System.EventHandler(this.AudioDeviceControl_MouseEnter);
            // 
            // lblDefault
            // 
            this.lblDefault.AutoSize = true;
            this.lblDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefault.ForeColor = System.Drawing.Color.Green;
            this.lblDefault.Location = new System.Drawing.Point(83, 42);
            this.lblDefault.Name = "lblDefault";
            this.lblDefault.Size = new System.Drawing.Size(83, 20);
            this.lblDefault.TabIndex = 2;
            this.lblDefault.Text = "DEFAULT";
            this.lblDefault.Click += new System.EventHandler(this.AudioDeviceControl_Click);
            this.lblDefault.MouseEnter += new System.EventHandler(this.AudioDeviceControl_MouseEnter);
            // 
            // picIcon
            // 
            this.picIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picIcon.Location = new System.Drawing.Point(7, 11);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(40, 40);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picIcon.TabIndex = 3;
            this.picIcon.TabStop = false;
            this.picIcon.Click += new System.EventHandler(this.AudioDeviceControl_Click);
            this.picIcon.MouseEnter += new System.EventHandler(this.AudioDeviceControl_MouseEnter);
            // 
            // AudioDeviceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblDefault);
            this.Controls.Add(this.lblDeviceName);
            this.Name = "AudioDeviceControl";
            this.Size = new System.Drawing.Size(273, 66);
            this.Click += new System.EventHandler(this.AudioDeviceControl_Click);
            this.MouseEnter += new System.EventHandler(this.AudioDeviceControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.AudioDeviceControl_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDefault;
        private System.Windows.Forms.PictureBox picIcon;
    }
}
