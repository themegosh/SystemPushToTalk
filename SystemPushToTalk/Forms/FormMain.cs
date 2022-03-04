using NAudio.CoreAudioApi;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using SystemPushToTalk.Models;
using SystemPushToTalk.Services;

namespace SystemPushToTalk.Forms
{
    public partial class FormMain : Form
    {
        private readonly SettingsService _settingsService = new SettingsService();
        private readonly DebounceDispatcher _debounceDispatcher = new DebounceDispatcher();
        private readonly AudioDeviceNotificationClient _notificationClient = new AudioDeviceNotificationClient();
        private MMDevice CurrentRecordingDevice { get; set; }
        private PushToTalkSettings Settings { get; set; }

        //default to mouse 4
        public bool KeyHeld { get; set; }

        public FormMain()
        {
            InitializeComponent();

            Settings = _settingsService.LoadSettings();

            SetBindings();

            lblDebounce.Text = "Push to Talk Release Delay: " + trkDebounce.Value;

            RefreshDefaultRecordingDevice();

            //when opening the program, mute the mic
            SetMute(true);

            using (var deviceEnumerator = new MMDeviceEnumerator())
            {
                deviceEnumerator.RegisterEndpointNotificationCallback(_notificationClient);
                _notificationClient.DefaultDeviceChanged += NotificationClient_DeviceChanged;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //when opening the program, mute the mic
            SetMute(true);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearBindings();

            _notificationClient.DefaultDeviceChanged -= NotificationClient_DeviceChanged;

            //when closing the program, unmute
            SetMute(false);
        }

        private void btnSetBinding_Click(object sender, EventArgs e)
        {
            ClearBindings();

            using (var configForm = new FormSetKeyBinding(Settings.KeyBinding))
            {
                if (configForm.ShowDialog() == DialogResult.OK)
                {
                    Settings.KeyBinding = configForm.NewKeyBinding;
                    _settingsService.SaveSettings(Settings);
                }
            }

            SetBindings();
        }

        private void trayIcon_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Normal)
            {
                //bring to front
                WindowState = FormWindowState.Minimized;
                Show();
                WindowState = FormWindowState.Normal;
            }

            var notificationForm = new NotificationForm();
            notificationForm.Left = Math.Min(Cursor.Position.X, Screen.PrimaryScreen.WorkingArea.Right - notificationForm.Width); // for multiple monitors and different placements of task bar
            notificationForm.Top = Screen.PrimaryScreen.WorkingArea.Bottom - notificationForm.Height;
            notificationForm.Show();
            notificationForm.Focus();
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            OpenRecordingDevices();
        }

        private void trkDebounce_ValueChanged(object sender, EventArgs e)
        {
            //some logic to prevent steps of 1,2,3 and only allow multiples of the SmallChange's value

            var smallChange = trkDebounce.SmallChange;
            var trackValue = trkDebounce.Value;
            if (trackValue % smallChange != 0)
            {
                trackValue = (trackValue / smallChange) * smallChange;

                trkDebounce.Value = trackValue;
            }

            lblDebounce.Text = "Push to Talk Release Delay: " + trackValue;
            Settings.Debounce = trackValue;

            _debounceDispatcher.Debounce(50, (p) =>
            {
                _settingsService.SaveSettings(Settings);
            });
        }

        private void btnShowDevices_Click(object sender, EventArgs e)
        {
            OpenRecordingDevices();
        }

        private void ClearBindings()
        {
            HookManager.MouseUp -= HandleMouseUp;
            HookManager.MouseDown -= HandleMouseDown;
            HookManager.KeyUp -= HandleKeyUp;
            HookManager.KeyDown -= HandleKeyDown;
        }

        private void SetBindings()
        {
            ClearBindings();

            switch (Settings.KeyBinding)
            {
                case MouseEventArgs m:
                    HookManager.MouseUp += HandleMouseUp;
                    HookManager.MouseDown += HandleMouseDown;
                    lblKeyBinding.Text = $"Mouse: {m.Button}";
                    break;

                case KeyEventArgs k:
                    HookManager.KeyUp += HandleKeyUp;
                    HookManager.KeyDown += HandleKeyDown;
                    lblKeyBinding.Text = $"Key: {k.KeyCode}";
                    break;
            }
        }

        private void NotificationClient_DeviceChanged(DataFlow dataFlow, Role deviceRole, string defaultDeviceId)
        {
            Console.WriteLine($"NotificationClient_DeviceChanged dataFlow {dataFlow} deviceRole {deviceRole} defaultDeviceId {defaultDeviceId}");
            //call back to the main thread to refresh the device list
            Invoke((MethodInvoker)delegate
            {
                //throttle this event (many of them are spammed)
                _debounceDispatcher.Debounce(100, (p) =>
                {
                    RefreshDefaultRecordingDevice();
                });
            });
        }

        private void HandleMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == ((MouseEventArgs)Settings.KeyBinding).Button)
            {
                KeyHeld = false;
                _debounceDispatcher.Debounce(trkDebounce.Value, (p) =>
                {
                    if (!KeyHeld)
                    {
                        SetMute(true);
                    }
                });
            }
        }

        private void HandleMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == ((MouseEventArgs)Settings.KeyBinding).Button)
            {
                KeyHeld = true;
                SetMute(false);
            }
        }

        private void HandleKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == ((KeyEventArgs)Settings.KeyBinding).KeyCode)
            {
                KeyHeld = false;
                _debounceDispatcher.Debounce(trkDebounce.Value, (p) =>
                {
                    if (!KeyHeld)
                    {
                        SetMute(true);
                    }
                });
            }
        }

        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == ((KeyEventArgs)Settings.KeyBinding).KeyCode)
            {
                KeyHeld = true;
                SetMute(false);
            }
        }

        private void RefreshDefaultRecordingDevice()
        {
            using (var deviceEnumerator = new MMDeviceEnumerator())
            {
                //find the default recording device
                CurrentRecordingDevice = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Console);

                lblDeviceName.Text = CurrentRecordingDevice?.FriendlyName ?? "No Device Available.";

                SetMute(!KeyHeld);
            }
        }

        public void SetMute(bool muted)
        {
            try
            {
                if (CurrentRecordingDevice == null)
                    return;

                //set the current device's muted state
                CurrentRecordingDevice.AudioEndpointVolume.Mute = muted;

                if (muted)
                {
                    lblMuteStatus.Text = "Muted";
                    lblMuteStatus.ForeColor = Color.Red;
                    trayIcon.Icon = Properties.Resources.micred;
                    Icon = Properties.Resources.micred;
                }
                else
                {
                    lblMuteStatus.Text = "Unmuted";
                    lblMuteStatus.ForeColor = Color.Green;
                    trayIcon.Icon = Properties.Resources.micgreen;
                    Icon = Properties.Resources.micgreen;
                }
            }
            catch (Exception ex)
            {
                //When something happend that prevent us to iterate through the devices
                MessageBox.Show("Failed to set volume: " + ex.Message);
                RefreshDefaultRecordingDevice();
            }
        }

        private void OpenRecordingDevices()
        {
            //open the Playback Devices window
            //rundll32.exe shell32.dll,Control_RunDLL mmsys.cpl,,0
            var startInfo = new ProcessStartInfo
            {
                Verb = "RunAs",
                FileName = "rundll32.exe",
                Arguments = @"shell32.dll,Control_RunDLL mmsys.cpl,,1 "
            };
            Process.Start(startInfo);
            //process.WaitForExit();
        }
    }
}