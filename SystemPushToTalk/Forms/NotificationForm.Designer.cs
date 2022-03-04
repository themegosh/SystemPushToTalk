
namespace SystemPushToTalk.Forms
{
    partial class NotificationForm
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
            this.pnlInputDevices = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlOuputDevices = new System.Windows.Forms.TableLayoutPanel();
            this.lblRecordingDevices = new System.Windows.Forms.Label();
            this.lblPlaybackDevices = new System.Windows.Forms.Label();
            this.pnlInputDevices.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInputDevices
            // 
            this.pnlInputDevices.AutoSize = true;
            this.pnlInputDevices.ColumnCount = 1;
            this.pnlInputDevices.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlInputDevices.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.pnlInputDevices.Location = new System.Drawing.Point(308, 36);
            this.pnlInputDevices.Name = "pnlInputDevices";
            this.pnlInputDevices.RowCount = 1;
            this.pnlInputDevices.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlInputDevices.Size = new System.Drawing.Size(290, 194);
            this.pnlInputDevices.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pnlOuputDevices
            // 
            this.pnlOuputDevices.AutoSize = true;
            this.pnlOuputDevices.ColumnCount = 1;
            this.pnlOuputDevices.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlOuputDevices.Location = new System.Drawing.Point(12, 36);
            this.pnlOuputDevices.Name = "pnlOuputDevices";
            this.pnlOuputDevices.RowCount = 1;
            this.pnlOuputDevices.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlOuputDevices.Size = new System.Drawing.Size(290, 194);
            this.pnlOuputDevices.TabIndex = 1;
            // 
            // lblRecordingDevices
            // 
            this.lblRecordingDevices.AutoSize = true;
            this.lblRecordingDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordingDevices.Location = new System.Drawing.Point(311, 9);
            this.lblRecordingDevices.Name = "lblRecordingDevices";
            this.lblRecordingDevices.Size = new System.Drawing.Size(170, 24);
            this.lblRecordingDevices.TabIndex = 2;
            this.lblRecordingDevices.Text = "Recording Devices";
            // 
            // lblPlaybackDevices
            // 
            this.lblPlaybackDevices.AutoSize = true;
            this.lblPlaybackDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaybackDevices.Location = new System.Drawing.Point(12, 9);
            this.lblPlaybackDevices.Name = "lblPlaybackDevices";
            this.lblPlaybackDevices.Size = new System.Drawing.Size(157, 24);
            this.lblPlaybackDevices.TabIndex = 3;
            this.lblPlaybackDevices.Text = "Playback Devices";
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(620, 242);
            this.Controls.Add(this.lblPlaybackDevices);
            this.Controls.Add(this.lblRecordingDevices);
            this.Controls.Add(this.pnlOuputDevices);
            this.Controls.Add(this.pnlInputDevices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotificationForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Click to change Default Device";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.NotificationForm_Deactivate);
            this.Load += new System.EventHandler(this.NotificationForm_Load);
            this.pnlInputDevices.ResumeLayout(false);
            this.pnlInputDevices.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlInputDevices;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel pnlOuputDevices;
        private System.Windows.Forms.Label lblRecordingDevices;
        private System.Windows.Forms.Label lblPlaybackDevices;
    }
}