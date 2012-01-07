using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibMinecraft.Client;
using LibMinecraft.Model;
using LibMinecraft.Server;

namespace SharpBot
{
    public static class SharpControl
    {
        public static MultiplayerClient Client = new MultiplayerClient();
        public static MinecraftServer Server = new MinecraftServer();
        public static User p = new User();
        public static MultiplayerClient Connect(string username, string password, string server)
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
            Client.SendPlayerPositionAndLook();
        }
    }
}
