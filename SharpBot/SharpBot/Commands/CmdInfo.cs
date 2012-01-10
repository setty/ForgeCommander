using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpBot.Commands
{
    class CmdInfo : Command
    {
        public override string name { get { return "info"; } }
        public override string shortcut { get { return ""; } }
        public override bool opperm { get { return false; } }
        public override void Use(Player p, string message)
        {
            p.SendMessage("ForgeCommander " + SharpControl.appversion + ", by Forgeware Inc.");
            p.SendMessage("Coded by BeMacized, Wouto1997 and  SirCmpwn.");
            p.SendMessage("www.forgewareint.com");
        }
        public override void Help(Player p)
        {
            p.SendMessage("!info - Shows ForgeCommander information");
        }
    }
}
