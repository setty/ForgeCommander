using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpBot.Commands
{
    class CmdControl : Command
    {
        public override string name { get { return "control"; } }
        public override string shortcut { get { return "c"; } }
        public override bool opperm { get { return true; } }
        public override void Use(Player p, string message)
        {
            if (message.ToLower() == SharpControl.p.UserName.ToLower())
            {
                foreach (Player controller in User_Control.controllers)
                {
                    if (controller == p) { User_Control.controllers.Remove(p); p.SendMessage("You stopped controlling me"); return; }
                }
                User_Control.controllers.Add(p);
                p.SendMessage("You started controlling me!");
            }
        }
        public override void Help(Player p)
        {
            p.SendMessage("!c <botname> - start / stop controlling me");
        }
    }
}
