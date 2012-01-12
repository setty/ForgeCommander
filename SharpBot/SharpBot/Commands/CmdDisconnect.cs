using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SharpBot.Commands
{
    class CmdDisconnect : Command
    {
        public override string name { get { return "Disconnect"; } }
        public override string shortcut { get { return "dc"; } }
        public override bool opperm { get { return true; } }
        public override void Use(Player p, string message)
        {
            SharpControl.Client.SendChat("I'm disconnecting. Cya all!");
            Thread dc = new Thread(new ThreadStart(DisconnectTurning));
            dc.Start();
        }
        public override void Help(Player p)
        {
            p.SendMessage("!disconnect - Disconnects the bot");
        }
        public static void DisconnectTurning()
        {
            double speed = 0;
            try
            {
                while (speed < 250)
                {
                    speed++;
                    int countmedown = 3;
                    while (countmedown > 0)
                    {
                        SharpControl.Client.Player.Rotation.X += speed;
                        countmedown--;
                    }
                }
                try
                {
                    SharpControl.Client.Disconnect();
                }
                catch
                {
                    SharpControl.Client.ForceDisconnect();
                }
            }
            catch
            {
                try
                {
                    SharpControl.Client.Disconnect();
                }
                catch
                {
                    SharpControl.Client.ForceDisconnect();
                }
            }
        }
    }
}
