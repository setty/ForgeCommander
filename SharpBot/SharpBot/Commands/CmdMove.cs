using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SharpBot.Commands
{
    class CmdMove : Command
    {
        public override string name { get { return "move"; } }
        public override string shortcut { get { return "m"; } }
        public override bool opperm { get { return true; } }
        public override void Use(Player p, string message)
        {
            string[] vars = message.ToLower().Split(' ');
            if (vars.Length < 1) { Help(p); return; }
            if (vars[0] == "<" || vars[0] == "left") { SharpControl.Client.Player.Rotation.X -= 90; return; }
            if (vars[0] == ">" || vars[0] == "right") { SharpControl.Client.Player.Rotation.X += 90; return; }
            if (vars.Length < 2) { Help(p); return; }
            try { Convert.ToDouble(vars[1]); }
            catch { Help(p); return; }
            if (vars[0] == "w" || vars[0] == "forward")
            {
                Thread walk = new Thread(new ThreadStart(() => Walk(true, vars[1])));
                walk.Start();
                return;
            }
            if (vars[0] == "s" || vars[0] == "back")
            {
                Thread walk = new Thread(new ThreadStart(() => Walk(false, vars[1])));
                walk.Start();
                return;
            }
            if (vars[0] == "up")
            {
                Thread walk = new Thread(new ThreadStart(() => Ymove(true, vars[1])));
                walk.Start();
                return;
            }
            if (vars[0] == "down")
            {
                Thread walk = new Thread(new ThreadStart(() => Ymove(false, vars[1])));
                walk.Start();
                return;
            }
            Help(p);
        }
        public override void Help(Player p)
        {
            p.SendMessage("!move < - rotate left");
            p.SendMessage("!move > - rotate right");
            p.SendMessage("!move w <ammount> - move forward");
            p.SendMessage("!move d <ammount> - move backwards");
            p.SendMessage("!move up <ammount> - move up");
            p.SendMessage("!move down <ammount> - move down");
        }
        public static void Walk(bool forward, string times)
        {
            double time = Convert.ToDouble(times);
            if (forward)
            {
                while (time > 0)
                {
                    int walkto = SharpControl.GetWalkway();
                    if (walkto == 0) { Misc.Map.ZPLUS(); SharpControl.Client.Player.Location.Z += 1; }
                    if (walkto == 1) { Misc.Map.XMIN(); SharpControl.Client.Player.Location.X -= 1; }
                    if (walkto == 2) { Misc.Map.ZMIN(); SharpControl.Client.Player.Location.Z -= 1; }
                    if (walkto == 3) { Misc.Map.XPLUS(); SharpControl.Client.Player.Location.X += 1; }
                    Thread.Sleep(250);
                    time--;
                }
            }
            else
            {
                while (time > 0)
                {
                    int walkto = SharpControl.GetWalkway();
                    if (walkto == 2) { Misc.Map.ZPLUS(); SharpControl.Client.Player.Location.Z += 1; }
                    if (walkto == 3) { Misc.Map.XMIN(); SharpControl.Client.Player.Location.X -= 1; }
                    if (walkto == 0) { Misc.Map.ZMIN(); SharpControl.Client.Player.Location.Z -= 1; }
                    if (walkto == 1) { Misc.Map.XPLUS(); SharpControl.Client.Player.Location.X += 1; }
                    Thread.Sleep(250);
                    time--;
                }
            }
        }
        public static void Ymove(bool up, string times)
        {
            double time = Convert.ToDouble(times);
            if (up)
            {
                while (time > 0)
                {
                    time--;
                    SharpControl.Client.Player.Location.Y++;
                    Thread.Sleep(250);
                }
            }
            else
            {
                while (time > 0)
                {
                    time--;
                    SharpControl.Client.Player.Location.Y--;
                    Thread.Sleep(250);
                }
            }
        }
    }
}
