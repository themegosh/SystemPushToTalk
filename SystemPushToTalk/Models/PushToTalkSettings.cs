using System;
using System.Windows.Forms;

namespace SystemPushToTalk.Models
{
    public class PushToTalkSettings
    {
        public EventArgs KeyBinding { get; set; } = new MouseEventArgs(MouseButtons.XButton2, 0, 0, 0, 0);
        public int Debounce { get; set; }
    }
}