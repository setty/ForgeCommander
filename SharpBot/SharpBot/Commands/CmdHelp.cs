using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpBot.Commands
{
    class CmdHelp : Command
    {
        public override string name { get { return "help"; } }
        public override string shortcut { get { return "?"; } }
        public override bool opperm { get { return false; } }
        public override void Use(Player p, string message)
        {
            if (message.Length == 0)
            {
                Help(p); return;
            }
            else
            {
                Command cmd = Command.Find(message);
                if (cmd != null)
                {
                    cmd.Help(p); return;
                }
                else
                {
                    p.SendMessage("Command '" + message + "' not found!");
                }
            }
        }
        public override void Help(Player p)
        {
            p.SendMessage("!help <command> - Shows command help");
        }
    }
}
