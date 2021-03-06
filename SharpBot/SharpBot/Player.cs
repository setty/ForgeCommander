﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SharpBot
{
    public class Player
    {
        public static List<Player> all = new List<Player>();
        public string Playername;
        public bool IsOp;
        public Player(string name)
        {
            Playername = name;
            IsOp = GetOp(name);
            all.Add(this);
        }
        public static bool GetOp(string name)
        {
            if (!Directory.Exists("bot")) { Directory.CreateDirectory("bot"); }
            if (!File.Exists("bot/op.txt")) { File.CreateText("bot/op.txt").Close(); return false; }
            foreach (string line in File.ReadAllLines("bot/op.txt"))
            {
                if (line.ToLower().Trim() == name.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        public static bool SetOp(string name)
        {
            if (!Directory.Exists("bot")) { Directory.CreateDirectory("bot"); }
            if (!File.Exists("bot/op.txt")) { File.CreateText("bot/op.txt").Close(); }
            foreach (string l in File.ReadAllLines("bot/op.txt"))
            {
                if (l.ToLower() == name.ToLower()) { return false; }
            }
            File.AppendAllText("bot/op.txt", name.ToLower() + Environment.NewLine);
            foreach (Player who in Player.all)
            {
                if (who.Playername == name) { who.IsOp = true; }
            }
            return true;
        }
        public static bool RemoveOp(string name)
        {
            List<string> lines = new List<string>();
            if (!Directory.Exists("bot")) { Directory.CreateDirectory("bot"); }
            if (!File.Exists("bot/op.txt")) { File.CreateText("bot/op.txt").Close(); }
            if (File.ReadAllText("bot/op.txt").Contains(name.ToLower()))
            {
                foreach (string line in File.ReadAllLines("bot/op.txt"))
                {
                    if (line.ToLower().Trim() != name.ToLower()) { lines.Add(line); }
                }
            }
            File.WriteAllLines("bot/op.txt", lines.ToArray());
            return false;
        }
        public void SendMessage(string message)
        {
            if (message.Length > 119)
            {
                string remaining = "asdfg";
                while (remaining.Length > 0)
                {
                    remaining = message.Remove(0, 119);
                    SharpControl.Client.SendChat(message.Remove(120, remaining.Length));
                }
            }
            else
            {
                SharpControl.Client.SendChat("/tell " + Playername + " " + message);
            }
        }
        public void GlobalMessage(string message)
        {
            if (message.StartsWith("/")) { message = "." + message; }
            SharpControl.Client.SendChat(message);
        }
        public static string[] oplist()
        {
            if (!Directory.Exists("bot")) { Directory.CreateDirectory("bot"); }
            if (!File.Exists("bot/op.txt")) { File.CreateText("bot/op.txt").Close(); string[] ops = { "No ops yet!" }; return ops; }
            return File.ReadAllLines("bot/op.txt");
        }
        public static Player Find(string name)
        {
            foreach (Player p in Player.all)
            {
                if (p.Playername == name)
                {
                    return p;
                }
            }
            Player who = new Player(name);
            return who;
        }
    }
}
