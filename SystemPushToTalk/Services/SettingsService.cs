using Microsoft.Win32;
using Newtonsoft.Json;
using System.Windows.Forms;
using SystemPushToTalk.Models;

namespace SystemPushToTalk.Services
{
    public class SettingsService
    {
        private const string REG_APP_NAME = "SystemPushToTalk";
        private const string REG_APP_VERSION = "v1";
        private const string REG_APP_KEYBIND_KEY = "KeyBinding";
        private const string REG_APP_DEBOUNCE = "Debounce";

        public SettingsService()
        {
        }

        public PushToTalkSettings LoadSettings()
        {
            var settings = new PushToTalkSettings();

            //read from registry
            var key = Registry.CurrentUser.OpenSubKey("Software", true)?.CreateSubKey(REG_APP_NAME, true)?.CreateSubKey(REG_APP_VERSION, true);
            var val = key.GetValue(REG_APP_KEYBIND_KEY)?.ToString();
            settings.Debounce = (int?)key.GetValue(REG_APP_DEBOUNCE) ?? 0;

            if (!string.IsNullOrEmpty(val))
            {
                try
                {
                    //there is a much better way to do this with a custom JsonConverter that tests the serialized data for properties/values to presume the type
                    //but EventArgs is in the System namespace which makes the solution no cleaner than the lines below
                    var mouseBinding = JsonConvert.DeserializeObject<MouseEventArgs>(val);
                    if (mouseBinding.Button != MouseButtons.None)
                    {
                        settings.KeyBinding = mouseBinding;
                    }

                    var keyBinding = JsonConvert.DeserializeObject<KeyEventArgs>(val);
                    if (keyBinding.KeyCode != Keys.None)
                    {
                        settings.KeyBinding = keyBinding;
                    }
                }
                catch { }
            }

            return settings;
        }

        public void SaveSettings(PushToTalkSettings settings)
        {
            //save to registry
            var key = Registry.CurrentUser.OpenSubKey("Software", true)?.CreateSubKey(REG_APP_NAME, true)?.CreateSubKey(REG_APP_VERSION, true);
            var serializedKeyBinding = JsonConvert.SerializeObject(settings.KeyBinding);
            key.SetValue(REG_APP_KEYBIND_KEY, serializedKeyBinding);
            key.SetValue(REG_APP_DEBOUNCE, settings.Debounce);
        }
    }
}