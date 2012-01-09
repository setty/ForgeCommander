using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SharpBot.Commands
{
    class CmdWalk : Command
    {
        
        public override string name { get { return "walk"; } }
        public override string shortcut { get { return "w"; } }
        public override bool opperm { get { return false; } }
        public override void Use(Player p, string message)
        {
            if (!SharpControl.teleporting)
            {

                if (message == null || message == "") { Help(p); return; }

                if (message == "stop")
                {
                    if (!SharpControl.walkbool)
                    {
                        p.SendMessage(SharpControl.p.UserName + " isn't walking! You can't stop it."); return;
                    }
                    SharpControl.walkbool = false;
                }
                else
                {
                    if (SharpControl.walkbool) { p.SendMessage(SharpControl.p.UserName + " is already walking. Stop with !walk stop."); return; }
                    int speedvar;
                    try { speedvar = Convert.ToInt32(message); }
                    catch { Help(p); return; }
                    if (speedvar < 1 || speedvar > 5) { p.SendMessage("Speed must be in between 1 and 5"); return; }
                    SharpControl.walkbool = true;
                    switch (speedvar)
                    {
                        case 1:
                            Thread walkinf500 = new Thread(new ThreadStart(() => CmdMove.WalkInf(500)));
                            walkinf500.IsBackground = true;
                            walkinf500.Start();
                            break;
                        case 2:
                            Thread walkinf400 = new Thread(new ThreadStart(() => CmdMove.WalkInf(400)));
                            walkinf400.IsBackground = true;
                            walkinf400.Start();
                            break;
                        case 3:
                            Thread walkinf300 = new Thread(new ThreadStart(() => CmdMove.WalkInf(300)));
                            walkinf300.IsBackground = true;
                            walkinf300.Start();
                            break;
                        case 4:
                            Thread walkinf200 = new Thread(new ThreadStart(() => CmdMove.WalkInf(200)));
                            walkinf200.IsBackground = true;
                            walkinf200.Start();
                            break;
                        case 5:
                            Thread walkinf100 = new Thread(new ThreadStart(() => CmdMove.WalkInf(100)));
                            walkinf100.IsBackground = true;
                            walkinf100.Start();
                            break;
                    }
                }
            }
            else
            {
                p.SendMessage("Can't move while teleporting!");
            }
        }
        
        public override void Help(Player p)
        {
            p.SendMessage("!walk <speed> - Walks forward till stopped.");
            p.SendMessage("!walk stop - Stops walking");
        }
        
    }
}
