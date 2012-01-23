using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibMinecraft.Client;
using LibMinecraft.Model;
using LibMinecraft.Server;
using SharpBot.Misc;

namespace SharpBot
{
    public static class SharpControl
    {
        public static string servername = "";
        public static string appversion = "v0.1 Alpha";
        public static bool teleporting = false;
        public static bool walkbool = false;
        public static MultiplayerClient Client = new MultiplayerClient();
        public static MinecraftServer Server = new MinecraftServer();
        public static User p = new User();
        private static MultiplayerClient Connect(string username, string password, string server)
        {
            p.UserName = username;
            p.Password = password;
            MultiplayerClient mpc = new MultiplayerClient();
            MinecraftServer mcs = new MinecraftServer();
            mcs.Hostname = server;
            mpc.Connect(mcs);
            mpc.LogIn(p);
            Server = mcs;
            return mpc;
        }
        public static void Login(string username, string password, string server)
        {
            Client = Connect(username, password, server);
            Client.Player.Location.Y -= 0.5;
            Client.Player.Rotation.Y = 0;
            Recenter_Location();
        }
        /// <summary>
        /// Execute commands from SharpBot
        /// </summary>
        /// <param name="line">you must enter a / yourself!</param>
        public static void ExecuteCommand(string line)
        {
            Client.SendChat(line);
        }
        public static int GetWalkway()
        {
            int rot = (int)SharpControl.Client.Player.Rotation.X;
            //360(0) - 315 - 360
            //270 - 225 - 315
            //180 - 135 - 225
            //90 - 45 - 135
            //0 - 0 - 45
            if ((rot > 315 && rot <= 360) || (rot > 0 && rot <= 45))
            {
                SharpControl.Client.Player.Rotation.X = 0;
                return 0;
            }
            if (rot > 45 && rot <= 135) { SharpControl.Client.Player.Rotation.X = 90; return 1; }
            if (rot > 135 && rot <= 225) { SharpControl.Client.Player.Rotation.X = 180; return 2; }
            if (rot > 225 && rot < 315) { SharpControl.Client.Player.Rotation.X = 270; return 3; }
            else { SharpControl.Client.Player.Rotation.X = 0; return 0; }
        }

        public static void Recenter_Location()
        {
            //automatic head rotation fix:
            GetWalkway();
            //Fix center block ._.
            // X
            double xfix = SharpControl.Client.Player.Location.X - (int)SharpControl.Client.Player.Location.X - 0.5;
            SharpControl.Client.Player.Location.X -= xfix;
            // Z
            double zfix = SharpControl.Client.Player.Location.Z - (int)SharpControl.Client.Player.Location.Z - 0.5;
            SharpControl.Client.Player.Location.Z -= zfix + 1;
            // +1 = for some strange reason?

            // Y = if you are half-step above/below a block, it'll fix it to central block too
            double yfix = SharpControl.Client.Player.Location.Y - (int)SharpControl.Client.Player.Location.Y - 0.5;
            SharpControl.Client.Player.Location.Y -= yfix + 0.5;
        }
    }
}
