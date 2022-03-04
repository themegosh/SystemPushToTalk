using NAudio.CoreAudioApi;

namespace SystemPushToTalk.Models
{
    public class AudioDeviceArgs
    {
        public string DeviceId { get; set; }
        public Role Role { get; set; }
        public DataFlow DataFlow { get; set; }
    }
}