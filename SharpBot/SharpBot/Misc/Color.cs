/*
 * you can get color like so: p.SendMessage(Color.id_0 + " message");
 * or you can get it like this: p.SendMessage(Color.Get('0') + " message");
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpBot.Misc
{
    public class Color
    {
        public const string id_0 = "§0";
        public const string id_1 = "§1";
        public const string id_2 = "§2";
        public const string id_3 = "§3";
        public const string id_4 = "§4";
        public const string id_5 = "§5";
        public const string id_6 = "§6";
        public const string id_7 = "§7";
        public const string id_8 = "§8";
        public const string id_9 = "§9";
        public const string id_a = "§a";
        public const string id_b = "§b";
        public const string id_c = "§c";
        public const string id_d = "§d";
        public const string id_e = "§e";
        public const string id_f = "§f";
        public static string Get(char colorkey)
        {
            switch (colorkey)
            {
                case '0':
                    return "§0";
                case '1':
                    return "§1";
                case '2':
                    return "§2";
                case '3':
                    return "§3";
                case '4':
                    return "§4";
                case '5':
                    return "§5";
                case '6':
                    return "§6";
                case '7':
                    return "§7";
                case '8':
                    return "§8";
                case '9':
                    return "§9";
                case 'a':
                    return "§a";
                case 'b':
                    return "§b";
                case 'c':
                    return "§c";
                case 'd':
                    return "§d";
                case 'e':
                    return "§e";
                case 'f':
                    return "§f";
                default:
                    return "§f";
            }
        }
    }
}
