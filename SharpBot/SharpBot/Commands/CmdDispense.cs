using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpBot.Commands
{
    class CmdDispense : Command
    {
        public override string name { get { return "dispense"; } }
        public override string shortcut { get { return "i"; } }
        public override bool opperm { get { return true; } }
        public override void Use(Player p, string message)
        {
            SharpControl.ExecuteCommand("/give " + SharpControl.p.UserName + " " + message);
        }
        public override void Help(Player p)
        {
            p.SendMessage("/i <itemid> <ammount> - throws item out of the bots mouth");
            p.SendMessage("gives nothing on invalid ID");
        }
    }
}
