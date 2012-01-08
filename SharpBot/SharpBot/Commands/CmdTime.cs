using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpBot.Commands
{
    class CmdTime : Command
    {
        public override string name { get { return "time"; } }
        public override string shortcut { get { return ""; } }
        public override bool opperm { get { return true; } }
        public override void Use(Player p, string message)
        {
            if (message == "day") { SharpControl.ExecuteCommand("/time set 0"); }
            if (message == "night") { SharpControl.ExecuteCommand("/time set 14000"); }
            else { Help(p); return; }
        }
        public override void Help(Player p)
        {
            p.SendMessage("!time <day/night> - sets time");
        }
    }
}
