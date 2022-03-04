using NAudio.CoreAudioApi;
using System;
using System.Runtime.InteropServices;

namespace SystemPushToTalk.AudioApi
{
    [ComImport, Guid("870af99c-171d-4f9e-af0d-e63df40c2bc9")]
    internal class _PolicyConfigClient
    {
    }

    public class PolicyConfigClient
    {
        private readonly IPolicyConfig _PolicyConfig;
        private readonly IPolicyConfigVista _PolicyConfigVista;
        private readonly IPolicyConfig10 _PolicyConfig10;

        public PolicyConfigClient()
        {
            _PolicyConfig = new _PolicyConfigClient() as IPolicyConfig;
            if (_PolicyConfig != null)
                return;

            _PolicyConfigVista = new _PolicyConfigClient() as IPolicyConfigVista;
            if (_PolicyConfigVista != null)
                return;

            _PolicyConfig10 = new _PolicyConfigClient() as IPolicyConfig10;
        }

        public void SetDefaultEndpoint(string deviceId, Role role)
        {
            if (_PolicyConfig != null)
            {
                Marshal.ThrowExceptionForHR(_PolicyConfig.SetDefaultEndpoint(deviceId, role));
                return;
            }
            if (_PolicyConfigVista != null)
            {
                Marshal.ThrowExceptionForHR(_PolicyConfigVista.SetDefaultEndpoint(deviceId, role));
                return;
            }
            if (_PolicyConfig10 != null)
            {
                Marshal.ThrowExceptionForHR(_PolicyConfig10.SetDefaultEndpoint(deviceId, role));
            }
        }
    }
}