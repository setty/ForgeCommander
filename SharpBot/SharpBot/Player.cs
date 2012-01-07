using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SharpBot
{
    public class Player
    {
        public string Playername;
        public bool IsOp;
        public Player(string name)
        {
            Playername = name;
            IsOp = GetOp(name);
        }
        public bool GetOp(string name)
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
        public bool SetOp(string name)
        {
            if (!Directory.Exists("bot")) { Directory.CreateDirectory("bot"); }
            if (!File.Exists("bot/op.txt")) { File.CreateText("bot/op.txt").Close(); }
            if (!File.ReadAllText("bot/op.txt").Contains(name.ToLower()))
            {
                File.AppendAllText("bot/op.txt", name + "\r\n");
                return true;
            }
            return false;
        }
        public bool RemoveOp(string name)
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
            if (message.Length > 90)
            {
                string remaining = message.Remove(0, 90);
                while (remaining.Length > 0)
                {
                    SharpControl.Client.SendChat("/tell " + Playername + " " + message.Remove(91, (remaining.Length - 90)));
                    remaining = remaining.Remove(0, 90);
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
            return File.ReadAllLines("bot/ops.txt");
        }
    }
}
