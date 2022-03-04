using NAudio.CoreAudioApi;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SystemPushToTalk.AudioApi;

namespace SystemPushToTalk.Controls
{
    public partial class AudioDeviceControl : UserControl
    {
        private readonly MMDevice _device;

        public AudioDeviceControl(MMDevice device, bool isDefault)
        {
            _device = device;

            InitializeComponent();

            lblDeviceName.Text = device.DeviceFriendlyName;
            lblName.Text = device.FriendlyName;//device.State.ToString();
            lblDefault.Visible = isDefault;
            picIcon.Image = Extract(device.IconPath, true).ToBitmap();
        }

        //retrieve an icon from a file handle
        public static Icon Extract(string file, bool largeIcon)
        {
            var elements = file.Split(',').ToList();
            var number = int.Parse(elements[1]);
            ExtractIconEx(elements[0], number, out IntPtr large, out IntPtr small, 1);
            try
            {
                return Icon.FromHandle(largeIcon ? large : small);
            }
            catch
            {
                return null;
            }
        }

        void SetDefault()
        {
            var client = new PolicyConfigClient();
            // Using PolicyConfigClient, set the given device as the default communication device (for its type)
            client.SetDefaultEndpoint(_device.ID, Role.Communications);
            // Using PolicyConfigClient, set the given device as the default device (for its type)
            client.SetDefaultEndpoint(_device.ID, Role.Multimedia);
        }

        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion, out IntPtr piSmallVersion, int amountIcons);

        private void AudioDeviceControl_Click(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void AudioDeviceControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.ActiveCaption;
        }

        private void AudioDeviceControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
        }
    }
}
