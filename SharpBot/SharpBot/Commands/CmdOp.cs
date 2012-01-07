using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpBot.Commands
{
    class CmdOp : Command
    {
        public override string name { get { return "op"; } }
        public override string shortcut { get { return ""; } }
        public override void Use(Player p, string message)
        {
            string[] args = message.Split(' ');
            if (args.Length < 1) { Help(p); return; }
            if (args[0] == "list")
            {
                string saystring = "";
                foreach (string w in Player.oplist()) { saystring += w + ", "; }
                p.SendMessage(saystring);
            }
        }
        public override void Help(Player p)
        {
            p.SendMessage("!op add <username> - ops a user");
            p.SendMessage("!op del <username> - de-ops a user");
            p.SendMessage("!op list - shows all operators");
        }
    }
}