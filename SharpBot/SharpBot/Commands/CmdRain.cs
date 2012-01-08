using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpBot.Commands
{
    class CmdRain : Command
    {
        public override string name { get { return "rain"; } }
        public override string shortcut { get { return ""; } }
        public override bool opperm { get { return true; } }
        public override void Use(Player p, string message)
        {
            if (message.Length > 0)
            {
                Help(p); return;
            }
            SharpControl.ExecuteCommand("/toggledownfall");
        }
        public override void Help(Player p)
        {
            p.SendMessage("/rain - toggles rain and snow");
        }
    }
}
