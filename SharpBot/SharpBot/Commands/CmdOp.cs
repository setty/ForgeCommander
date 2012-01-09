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
        public override bool opperm { get { return true; } }
        public override void Use(Player p, string message)
        {
            string[] args = message.Split(' ');
            if (args.Length < 1) { Help(p); return; }
            if (args[0] == "list")
            {
                string saystring = "";
                foreach (string w in Player.oplist()) { saystring += w + ", "; }
                saystring.Remove(saystring.Length - 2);
                saystring += ".";
                p.SendMessage(saystring);
                return;
            }
            if (args.Length < 2) { Help(p); return; }
            if (args[0] == "del")
            {
                if (Player.RemoveOp(args[1]))
                {
                    p.GlobalMessage(p.Playername + " removed OP for " + args[1]);
                    return;
                }
                else
                {
                    p.SendMessage("User not found!");
                    return;
                }
            }
            if (args[0] == "add")
            {
                if (Player.SetOp(args[1]))
                {
                    p.GlobalMessage(p.Playername + " Opped " + args[1]);
                    return;
                }
                else
                {
                    p.SendMessage("User is already OP!");
                    return;
                }
            }
            Help(p);
        }
        public override void Help(Player p)
        {
            p.SendMessage("!op add <username> - ops a user");
            p.SendMessage("!op del <username> - de-ops a user");
            p.SendMessage("!op list - shows all operators");
        }
    }
}