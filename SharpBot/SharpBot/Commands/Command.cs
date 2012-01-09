        #region start
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
        public abstract bool opperm { get; }
        public abstract void Use(Player p, string message);
        public abstract void Help(Player p);

        public static List<Command>all = new List<Command>();
        public static void Init()
#endregion
        #region Commands (alphabetical order!)
        {
            all.Add(new CmdDispense());
            all.Add(new CmdHelp());
            all.Add(new CmdMove());
            all.Add(new CmdOp());
            all.Add(new CmdRain());
            all.Add(new CmdTime());
        }
        #endregion
        #region endpart
        public static Command Find(string name)
        {
            foreach (Command cmd in Command.all)
            {
                if (cmd.name.ToLower().Contains(name.ToLower()) || cmd.shortcut.ToLower().Contains(name.ToLower()))
                {
                    return cmd;
                }
            }
            return null;
        }
        public bool Execute(Player who, string message)
        {
            if (who.Playername == SharpControl.p.UserName) { who.IsOp = true; }
            if (opperm)
            {
                if (who.IsOp)
                {
                    Use(who, message);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            Use(who, message);
            return true;
        }
    }
}
        #endregion