using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpBot.Commands
{
    class CmdSay : Command
    {
        public override string name { get { return "Say"; } }
        public override string shortcut { get { return ""; } }
        public override bool opperm { get { return true; } }
        public override void Use(Player p, string message)
        {
            if (message == "" || message == null)
            {
                Help(p); return;
            }
            SharpControl.Client.SendChat(message);
        }
        public override void Help(Player p)
        {
            p.SendMessage("!say <message> - Sends chatmessage");
        }
    }
}
