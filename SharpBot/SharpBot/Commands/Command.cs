using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpBot.Commands
{
    public abstract class Command
    {
        public abstract string name { get; }
        public abstract string shortcut { get; }
        public abstract void Use(Player p, string message);
        public abstract void Help(Player p);

        public static List<Command>all = new List<Command>();
        public static void Init()
        {
            all.Add(new CmdHelp());
        }
        public static Command Find(string name)
        {
            foreach (Command cmd in Command.all)
            {
                if (cmd.name.ToLower().Contains(name.ToLower()))
                {
                    return cmd;
                }
            }
            return null;
        }
    }
}
