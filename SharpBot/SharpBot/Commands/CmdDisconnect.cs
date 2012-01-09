using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpBot.Commands
{
    class CmdDisconnect : Command
    {
        public override string name { get { return "Disconnect"; } }
        public override string shortcut { get { return "dc"; } }
        public override bool opperm { get { return true; } }
        public override void Use(Player p, string message)
        {
            SharpControl.Client.SendChat("I'm disconnecting. Cya all!");
                try
                {
                    SharpControl.Client.Disconnect();
                }
                catch
                {
                    SharpControl.Client.ForceDisconnect();
                }
            
        }
        public override void Help(Player p)
        {
            p.SendMessage("!disconnect - Disconnects the bot");
        }
    }
}
