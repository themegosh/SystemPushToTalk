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
            lblName.Text = device.FriendlyName;
            lblDefault.Visible = isDefault;
            try
            {
                picIcon.Image = Extract(device.IconPath, true)?.ToBitmap();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.ToString());
                picIcon.Image = null;
            }
        }

        // Retrieve an icon from a file handle
        public static Icon Extract(string file, bool largeIcon)
        {
            var elements = file.Split(',');
            if (elements.Length < 2 || !int.TryParse(elements[1], out int number))
            {
                throw new ArgumentException("Invalid icon path format.");
            }
            if (ExtractIconEx(elements[0], number, out IntPtr large, out IntPtr small, 1) < 1)
            {
                throw new InvalidOperationException("No icons extracted.");
            }

            try
            {
                IntPtr iconHandle = largeIcon ? large : small;
                if (iconHandle == IntPtr.Zero)
                {
                    throw new InvalidOperationException("Extracted icon handle is null.");
                }
                return Icon.FromHandle(iconHandle);
            }
            finally
            {
                // Clean up the unused handle
                if (largeIcon && small != IntPtr.Zero)
                    DestroyIcon(small);
                else if (!largeIcon && large != IntPtr.Zero)
                    DestroyIcon(large);
            }
        }

        void SetDefault()
        {
            var client = new PolicyConfigClient();
            client.SetDefaultEndpoint(_device.ID, Role.Communications);
            client.SetDefaultEndpoint(_device.ID, Role.Multimedia);
        }

        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion, out IntPtr piSmallVersion, int amountIcons);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool DestroyIcon(IntPtr hIcon);

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
