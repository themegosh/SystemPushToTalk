using NAudio.CoreAudioApi;
using System;
using System.Linq;
using System.Windows.Forms;
using SystemPushToTalk.Controls;
using SystemPushToTalk.Services;

namespace SystemPushToTalk.Forms
{
    public partial class NotificationForm : Form
    {
        private readonly DebounceDispatcher _debounceDispatcher = new DebounceDispatcher();
        private readonly AudioDeviceNotificationClient _notificationClient = new AudioDeviceNotificationClient();

        public NotificationForm()
        {
            InitializeComponent();
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            this.Activate();
            this.Focus();
            BindEvents();
            LoadDevices();
        }

        private void NotificationForm_Deactivate(object sender, EventArgs e)
        {
            UnbindEvents();
            this.Close();
        }

        private void BindEvents()
        {
            using (var deviceEnumerator = new MMDeviceEnumerator())
            {
                deviceEnumerator.RegisterEndpointNotificationCallback(_notificationClient);
                _notificationClient.DefaultDeviceChanged += NotificationClient_DeviceChanged;
                _notificationClient.DeviceAdded += NotificationClient_DeviceAdded;
                _notificationClient.DeviceRemoved += NotificationClient_DeviceRemoved;
                //_notificationClient.PropertyValueChanged += NotificationClient_PropertyValueChanged;
            }
        }

        private void UnbindEvents()
        {
            _notificationClient.DefaultDeviceChanged -= NotificationClient_DeviceChanged;
            _notificationClient.DeviceAdded -= NotificationClient_DeviceAdded;
            _notificationClient.DeviceRemoved -= NotificationClient_DeviceRemoved;
            //_notificationClient.PropertyValueChanged -= NotificationClient_PropertyValueChanged;
        }

        private void LoadDevices()
        {
            pnlInputDevices.Controls.Clear();
            pnlOuputDevices.Controls.Clear();

            using (var deviceEnumerator = new MMDeviceEnumerator())
            {
                var captureDevices = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
                var defaultCaputreDevice = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia);
                var renderDevices = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
                var defaultRenderDevice = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

                pnlInputDevices.Controls.AddRange(captureDevices.Select(device => new AudioDeviceControl(device, device.ID == defaultCaputreDevice.ID)).ToArray());
                pnlOuputDevices.Controls.AddRange(renderDevices.Select(device => new AudioDeviceControl(device, device.ID == defaultRenderDevice.ID)).ToArray());
            }
        }

        private void HandleDeviceEvent()
        {
            //call back to the main thread to refresh the device list
            Invoke((MethodInvoker)delegate
            {
                //throttle this event (many of them are spammed)
                _debounceDispatcher.Debounce(100, (p) =>
                {
                    LoadDevices();
                });
            });
        }

        private void NotificationClient_DeviceRemoved(string deviceId)
        {
            HandleDeviceEvent();
        }

        private void NotificationClient_DeviceAdded(string deviceId)
        {
            HandleDeviceEvent();
        }

        private void NotificationClient_DeviceChanged(DataFlow dataFlow, Role deviceRole, string defaultDeviceId)
        {
            HandleDeviceEvent();
        }

        //private void NotificationClient_PropertyValueChanged(string deviceId, PropertyKey propertyKey)
        //{
        //    HandleDeviceEvent();
        //}
    }
}