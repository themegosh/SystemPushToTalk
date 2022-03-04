using NAudio.CoreAudioApi;
using NAudio.CoreAudioApi.Interfaces;
using System;

namespace SystemPushToTalk.Services
{
    //event passthrough client for MMNotifications
    public class AudioDeviceNotificationClient : IMMNotificationClient
    {
        public delegate void DefaultDeviceHandler(DataFlow dataFlow, Role deviceRole, string defaultDeviceId);
        public delegate void DeviceAddedHandler(string deviceId);
        public delegate void DeviceRemovedHandler(string deviceId);
        public delegate void DeviceStateChangedHandler(string deviceId, DeviceState newState);
        public delegate void PropertyValueChangedHandler(string deviceId, PropertyKey propertyKey);

        private event DefaultDeviceHandler _defaultDeviceChanged;
        private event DeviceAddedHandler _deviceAdded;
        private event DeviceRemovedHandler _deviceRemoved;
        private event DeviceStateChangedHandler _deviceStateChanged;
        private event PropertyValueChangedHandler _propertyValueChanged;

        public AudioDeviceNotificationClient()
        {
            if (Environment.OSVersion.Version.Major < 6)
            {
                throw new NotSupportedException("This functionality is only supported on Windows Vista or newer.");
            }
        }

        public event DefaultDeviceHandler DefaultDeviceChanged
        {
            add
            {
                _defaultDeviceChanged += value;
            }
            remove
            {
                _defaultDeviceChanged -= value;
            }
        }

        public event DeviceAddedHandler DeviceAdded
        {
            add
            {
                _deviceAdded += value;
            }
            remove
            {
                _deviceAdded -= value;
            }
        }

        public event DeviceRemovedHandler DeviceRemoved
        {
            add
            {
                _deviceRemoved += value;
            }
            remove
            {
                _deviceRemoved -= value;
            }
        }

        public event DeviceStateChangedHandler DeviceStateChanged
        {
            add
            {
                _deviceStateChanged += value;
            }
            remove
            {
                _deviceStateChanged -= value;
            }
        }

        public event PropertyValueChangedHandler PropertyValueChanged
        {
            add
            {
                _propertyValueChanged += value;
            }
            remove
            {
                _propertyValueChanged -= value;
            }
        }

        public void OnDefaultDeviceChanged(DataFlow dataFlow, Role deviceRole, string defaultDeviceId)
            => _defaultDeviceChanged?.Invoke(dataFlow, deviceRole, defaultDeviceId);

        public void OnDeviceAdded(string deviceId)
            => _deviceAdded?.Invoke(deviceId);

        public void OnDeviceRemoved(string deviceId)
            => _deviceRemoved?.Invoke(deviceId);

        public void OnDeviceStateChanged(string deviceId, DeviceState newState)
            => _deviceStateChanged?.Invoke(deviceId, newState);

        public void OnPropertyValueChanged(string deviceId, PropertyKey propertyKey)
            => _propertyValueChanged?.Invoke(deviceId, propertyKey);
    }
}