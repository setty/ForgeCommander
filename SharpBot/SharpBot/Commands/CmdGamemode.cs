using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpBot.Commands
{
    class CmdGamemode : Command
    {
        public override string name { get { return "gamemode"; } }
        public override string shortcut { get { return "gm"; } }
        public override bool opperm { get { return false; } }
        public override void Use(Player p, string message)
        {
            if (message == "1") { SharpControl.ExecuteCommand("/gamemode " + p.Playername + " 1"); return; }
            if (message == "0") { SharpControl.ExecuteCommand("/gamemode " + p.Playername + " 0"); }
            if (message == null || message == "") { Help(p); return; }
        }
        public override void Help(Player p)
        {
            p.SendMessage("!gamemode <mode> - Changes your gamemode (use 0 or 1)");
        }
    }
}
