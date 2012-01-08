using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using SharpBot.Commands;
using LibMinecraft.Client;
using LibMinecraft.Model;
using LibMinecraft.Server;
using System.Diagnostics;

namespace SharpBot
{
    public partial class User_Control : Form
    {
        public bool connected = true;
        public short lasthealth = 0;
        public bool closed = false;
        public User_Control()
        {
            InitializeComponent();
        }
        private void User_Control_Load(object sender, EventArgs e)
        {
            Command.Init();
            SharpControl.Client.OnChat += new EventHandler<ChatEventArgs>(Client_OnChat);
            SharpControl.Client.OnDisconnect += new EventHandler(Client_OnDisconnect);
        }

        void Client_OnDisconnect(object sender, EventArgs e)
        {
            connected = false;
            CloseForm(""); //NEEDA FIX THIZ SHIZZL 
        }
        
        public void CloseForm(string message)
        {
            if (!closed)
            {
                closed = true;
                if (message == null || message == "")
                {
                    message = "You have been disconnected.";
                }
                MessageBox.Show(message);
                Application.Restart();
            }
        }
        void Client_OnChat(object sender, ChatEventArgs e)
        {
            if (e.RawText.Contains("§"))
            {
                string result = ""; foreach (string s in e.RawText.Split('§')) { if (!string.IsNullOrEmpty(s)) { result += s.Substring(1); } } e.RawText = result;
            }
            if (e.RawText.Contains(">") && e.RawText.Contains("<"))
            {
                if (e.RawText.Split('>')[1].Trim().StartsWith("!")) 
                {
                    /*try
                    {
                        string username = e.RawText.Split('<')[1].Split('>')[0];
                        string command = "";
                        if (e.RawText.Split('>')[1].Trim().Contains(" "))
                        {
                            string cemd = e.RawText.Split('>')[1];
                            if (command.StartsWith("!")) { command = cemd.Remove(0, 1); }
                        }
                        else { command = e.RawText.Split('>')[1].Trim().Remove(0, 1); }
                        string args = e.RawText.Remove(0, username.Length + 4 + command.Length);
                        Player who = Player.Find(username);
                        Command cmd = Command.Find(command);
                        if (cmd == null) { who.SendMessage("Command '" + command + "' not found!"); }
                        else 
                        {
                            if (!cmd.Execute(who, args))
                            {
                                who.SendMessage("You are not allowed to use that command!");
                            }
                        }
                    
                    }
                    catch(Exception err)
                    {
                        // laat mensen opsturen als er errors zijn
                        MessageBox.Show(err.ToString());
                    }
                     */
                }
            }
            Addline(e.RawText.ToString());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Sendmsg(textBox1.Text);
        }
        delegate void AddChatAsyncDelegate(string Chat);
        void Addline(string Chat)
        {
            if (!ChatBox1.InvokeRequired)
            {
                ChatBox1.Items.Add(Chat);
                ChatBox1.SelectedIndex = ChatBox1.Items.Count - 1;
                ChatBox1.SelectedIndex = -1;
            }
            else
            {
                AddChatAsyncDelegate d = new AddChatAsyncDelegate(Addline);
                ChatBox1.Invoke(d, Chat);
            }
        }
        private void Sendmsg(string text)
        {
            SharpControl.Client.SendChat(text);
            if (checkBox1.Checked)
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { Sendmsg(textBox1.Text); }
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            int walkto = GetWalkway();
            if (walkto == 0) { SharpControl.Client.Player.Location.Z += 1;  }
            if (walkto == 1) { SharpControl.Client.Player.Location.X -= 1;  }
            if (walkto == 2) { SharpControl.Client.Player.Location.Z -= 1;  }
            if (walkto == 3) { SharpControl.Client.Player.Location.X += 1;  }

        }

        private void btnA_Click(object sender, EventArgs e)
        {
            int walkto = GetWalkway();
            if (walkto == 1) { SharpControl.Client.Player.Location.Z += 1;  }
            if (walkto == 2) { SharpControl.Client.Player.Location.X -= 1;  }
            if (walkto == 3) { SharpControl.Client.Player.Location.Z -= 1;  }
            if (walkto == 0) { SharpControl.Client.Player.Location.X += 1;  }

        }

        private void btnS_Click(object sender, EventArgs e)
        {
            int walkto = GetWalkway();
            if (walkto == 2) { SharpControl.Client.Player.Location.Z += 1;  }
            if (walkto == 3) { SharpControl.Client.Player.Location.X -= 1;  }
            if (walkto == 0) { SharpControl.Client.Player.Location.Z -= 1;  }
            if (walkto == 1) { SharpControl.Client.Player.Location.X += 1;  }

        }

        private void btnD_Click(object sender, EventArgs e)
        {
            int walkto = GetWalkway();
            if (walkto == 3) { SharpControl.Client.Player.Location.Z += 1;  }
            if (walkto == 0) { SharpControl.Client.Player.Location.X -= 1;  }
            if (walkto == 1) { SharpControl.Client.Player.Location.Z -= 1;  }
            if (walkto == 2) { SharpControl.Client.Player.Location.X += 1;  }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>0=z, 1=-x, 2=-z, 3=x</returns>
        public int GetWalkway()
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

        private void button2_Click(object sender, EventArgs e)
        {
            SharpControl.Client.Player.Location.Y++;
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SharpControl.Client.Player.Location.Y--;
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SharpControl.Client.Player.Rotation.X -= 90;
            if (SharpControl.Client.Player.Rotation.X > 360) { SharpControl.Client.Player.Rotation.X -= 360; }
            if (SharpControl.Client.Player.Rotation.X < 0) { SharpControl.Client.Player.Rotation.X += 360; }
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SharpControl.Client.Player.Rotation.X += 90;
            if (SharpControl.Client.Player.Rotation.X > 360) { SharpControl.Client.Player.Rotation.X -= 360; }
            if (SharpControl.Client.Player.Rotation.X < 0) { SharpControl.Client.Player.Rotation.X += 360; }
            

        }

        private void button8_Click(object sender, EventArgs e)
        {
            SharpControl.Client.Player.Location.Y += 0.5;
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SharpControl.Client.Player.Location.Y -= 0.5;
            

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            string[] nr = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string remaining = txtID.Text;
            foreach (string n in nr)
            {
                remaining.Replace(n, "");
            }
            if (remaining.Length > 0)
            {
                Console.Beep();
                foreach (string s in remaining.Split())
                {
                    txtID.Text.Replace(s, "");
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LibMinecraft.Model.Vector3 location = new LibMinecraft.Model.Vector3(SharpControl.Client.Player.Location.X, SharpControl.Client.Player.Location.Y, SharpControl.Client.Player.Location.Z);
            location.Y -= 2;
            LibMinecraft.Model.Blocks.Block b = SharpControl.Client.World.GetBlock(location);
            if (b.BlockID == 0)
            {
                //Sendmsg("I placed a block at " + location.X.ToString() + " x " + location.Y.ToString() + " x " + location.Z.ToString());
                //SharpControl.Client.World.SetBlock(location, (new LibMinecraft.Model.Blocks.Wood()));
            }
        }

        void Changeselected(short i)
        {
            SharpControl.Client.Player.SelectedSlot += 1;
            if (SharpControl.Client.Player.SelectedSlot > 9) { SharpControl.Client.Player.SelectedSlot = 0; }
            if (SharpControl.Client.Player.SelectedSlot < 0) { SharpControl.Client.Player.SelectedSlot = 9; }
            
        }

        private void butDisconnect_Click(object sender, EventArgs e)
        {
            if (connected)
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

        private void User_Control_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connected)
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

        private void ChatBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChatBox1.SelectedIndex = -1;
        }

        public static Thread tp;
        private void button10_Click_1(object sender, EventArgs e)
        {
            button10.Enabled = false;
            button12.Enabled = true;
            tp = new Thread(new ThreadStart(() => TP(new Vector3(Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text)), this)));
            tp.IsBackground = true;
            tp.Start();

        }
        private static void TP(Vector3 vec, User_Control uc)
        {
            try
            {
                while (SharpControl.Client.Player.Location.Y < 125)
                {
                    SharpControl.Client.Player.Location.Y += 1;

                    Thread.Sleep(100);
                }
                bool didaction = true;
                int actions = 0;
                while (didaction)
                {
                    actions = 0;
                    didaction = false;
                    if ((int)vec.X < (int)SharpControl.Client.Player.Location.X) { SharpControl.Client.Player.Location.X--; didaction = true; actions++; }
                    if ((int)vec.X > (int)SharpControl.Client.Player.Location.X) { SharpControl.Client.Player.Location.X++; didaction = true; actions++; }
                    if ((int)vec.Z < (int)SharpControl.Client.Player.Location.Z) { SharpControl.Client.Player.Location.Z--; didaction = true; actions++; }
                    if ((int)vec.Z > (int)SharpControl.Client.Player.Location.Z) { SharpControl.Client.Player.Location.Z++; didaction = true; actions++; }
                    Thread.Sleep(100 * actions);
                }
                int godown = (int)(SharpControl.Client.Player.Location.Y - vec.Y);
                while (godown > 0)
                {
                    SharpControl.Client.Player.Location.Y--;

                    Thread.Sleep(100);
                    godown -= 1;
                }
            }
            catch { tp.Abort(); }
            uc.button12.Enabled = false;
            uc.button10.Enabled = true;
            uc.Recenter_Location();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button12.Enabled = false;
            button10.Enabled = true;
            tp.Abort();
        }

        private void User_Control_KeyDown(object sender, KeyEventArgs e)
        {
            Recenter_Location();
            if (e.KeyCode == Keys.Down)
            {

                int walkto = GetWalkway();
                if (walkto == 2) { SharpControl.Client.Player.Location.Z += 0.5; }
                if (walkto == 3) { SharpControl.Client.Player.Location.X -= 0.5; }
                if (walkto == 0) { SharpControl.Client.Player.Location.Z -= 0.5; }
                if (walkto == 1) { SharpControl.Client.Player.Location.X += 0.5; }
            }
            if (e.KeyCode == Keys.Left)
            {
                SharpControl.Client.Player.Rotation.X -= 90;
                if (SharpControl.Client.Player.Rotation.X > 360) { SharpControl.Client.Player.Rotation.X -= 360; }
                if (SharpControl.Client.Player.Rotation.X < 0) { SharpControl.Client.Player.Rotation.X += 360; }
            }
            if (e.KeyCode == Keys.Up)
            {
                int walkto = GetWalkway();
            if (walkto == 0) { SharpControl.Client.Player.Location.Z += 0.5;  }
            if (walkto == 1) { SharpControl.Client.Player.Location.X -= 0.5;  }
            if (walkto == 2) { SharpControl.Client.Player.Location.Z -= 0.5;  }
            if (walkto == 3) { SharpControl.Client.Player.Location.X += 0.5;  }
            }
            if (e.KeyCode == Keys.Right)
            {
                SharpControl.Client.Player.Rotation.X += 90;
                if (SharpControl.Client.Player.Rotation.X > 360) { SharpControl.Client.Player.Rotation.X -= 360; }
                if (SharpControl.Client.Player.Rotation.X < 0) { SharpControl.Client.Player.Rotation.X += 360; }
            }
            
        }
        // Recenter location button, sets user position back to x.5 and y.5 (in center of block) and sets head rotation to 0, 90, 180, 270
        private void button6_Click(object sender, EventArgs e)
        {
            Recenter_Location();
        }
        public void Recenter_Location()
        {
            //automatic head rotation fix:
            GetWalkway();
            //Fix center block ._.
            // X
            double xfix = SharpControl.Client.Player.Location.X - (int)SharpControl.Client.Player.Location.X - 0.5;
            SharpControl.Client.Player.Location.X -= xfix;
            // Z
            double zfix = SharpControl.Client.Player.Location.Z - (int)SharpControl.Client.Player.Location.Z - 0.5;
            SharpControl.Client.Player.Location.Z -= zfix;

            // Y = if you are half-step above/below a block, it'll fix it to central block too
            double yfix = SharpControl.Client.Player.Location.Y - (int)SharpControl.Client.Player.Location.Y - 0.5;
            SharpControl.Client.Player.Location.Y -= yfix;
        }
    }
}
