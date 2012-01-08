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

namespace SharpBot
{
    public partial class User_Control : Form
    {
        public short lasthealth = 0;
        public User_Control()
        {
            InitializeComponent();
        }
        private void User_Control_Load(object sender, EventArgs e)
        {
            SharpControl.Client.OnChat += new EventHandler<ChatEventArgs>(Client_OnChat);
        }
        void Client_OnChat(object sender, ChatEventArgs e)
        {
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
            if (walkto == 0) { SharpControl.Client.Player.Location.Z += 1; SharpControl.Client.SendPlayerPositionAndLook(); }
            if (walkto == 1) { SharpControl.Client.Player.Location.X -= 1; SharpControl.Client.SendPlayerPositionAndLook(); }
            if (walkto == 2) { SharpControl.Client.Player.Location.Z -= 1; SharpControl.Client.SendPlayerPositionAndLook(); }
            if (walkto == 3) { SharpControl.Client.Player.Location.X += 1; SharpControl.Client.SendPlayerPositionAndLook(); }

        }

        private void btnA_Click(object sender, EventArgs e)
        {
            int walkto = GetWalkway();
            if (walkto == 1) { SharpControl.Client.Player.Location.Z += 1; SharpControl.Client.SendPlayerPositionAndLook(); }
            if (walkto == 2) { SharpControl.Client.Player.Location.X -= 1; SharpControl.Client.SendPlayerPositionAndLook(); }
            if (walkto == 3) { SharpControl.Client.Player.Location.Z -= 1; SharpControl.Client.SendPlayerPositionAndLook(); }
            if (walkto == 0) { SharpControl.Client.Player.Location.X += 1; SharpControl.Client.SendPlayerPositionAndLook(); }

        }

        private void btnS_Click(object sender, EventArgs e)
        {
            int walkto = GetWalkway();
            if (walkto == 2) { SharpControl.Client.Player.Location.Z += 1; SharpControl.Client.SendPlayerPositionAndLook(); }
            if (walkto == 3) { SharpControl.Client.Player.Location.X -= 1; SharpControl.Client.SendPlayerPositionAndLook(); }
            if (walkto == 0) { SharpControl.Client.Player.Location.Z -= 1; SharpControl.Client.SendPlayerPositionAndLook(); }
            if (walkto == 1) { SharpControl.Client.Player.Location.X += 1; SharpControl.Client.SendPlayerPositionAndLook(); }

        }

        private void btnD_Click(object sender, EventArgs e)
        {
            int walkto = GetWalkway();
            if (walkto == 3) { SharpControl.Client.Player.Location.Z += 1; SharpControl.Client.SendPlayerPositionAndLook(); }
            if (walkto == 0) { SharpControl.Client.Player.Location.X -= 1; SharpControl.Client.SendPlayerPositionAndLook(); }
            if (walkto == 1) { SharpControl.Client.Player.Location.Z -= 1; SharpControl.Client.SendPlayerPositionAndLook(); }
            if (walkto == 2) { SharpControl.Client.Player.Location.X += 1; SharpControl.Client.SendPlayerPositionAndLook(); }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>0=z, 1=-x, 2=-z, 3=x</returns>
        public int GetWalkway()
        {
            int rot = (int)SharpControl.Client.Player.Rotation.Z;
            //360(0) - 315 - 360
            //270 - 225 - 315
            //180 - 135 - 225
            //90 - 45 - 135
            //0 - 0 - 45
            if ((rot > 315 && rot <= 360) || (rot > 0 && rot <= 45))
            {
                return 0;
            }
            if (rot > 45 && rot <= 135) { return 1; }
            if (rot > 135 && rot <= 225) { return 2; }
            if (rot > 225 && rot < 315) { return 3; }
            else { return 0; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SharpControl.Client.Player.Location.Y++;
            SharpControl.Client.SendPlayerPositionAndLook();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SharpControl.Client.Player.Location.Y--;
            SharpControl.Client.SendPlayerPositionAndLook();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SharpControl.Client.Player.Rotation.Z -= 90;
            if (SharpControl.Client.Player.Rotation.Z > 360) { SharpControl.Client.Player.Rotation.Z -= 360; }
            if (SharpControl.Client.Player.Rotation.Z < 0) { SharpControl.Client.Player.Rotation.Z += 360; }
            SharpControl.Client.SendPlayerPositionAndLook();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SharpControl.Client.Player.Rotation.Z += 90;
            if (SharpControl.Client.Player.Rotation.Z > 360) { SharpControl.Client.Player.Rotation.Z -= 360; }
            if (SharpControl.Client.Player.Rotation.Z < 0) { SharpControl.Client.Player.Rotation.Z += 360; }
            SharpControl.Client.SendPlayerPositionAndLook();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SendCmd(textBox2.Text);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { SendCmd(textBox2.Text); }
        }
        public void SendCmd(string text)
        {
            SharpControl.Client.SendChat("/" + text);
            if (checkBox1.Checked)
            {
                textBox2.Text = "";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SharpControl.Client.Player.Location.Y += 0.5;
            SharpControl.Client.SendPlayerPositionAndLook();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SharpControl.Client.Player.Location.Y -= 0.5;
            SharpControl.Client.SendPlayerPositionAndLook();

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
                Sendmsg("I placed a block at " + location.X.ToString() + " x " + location.Y.ToString() + " x " + location.Z.ToString());
                SharpControl.Client.World.SetBlock(location, (new LibMinecraft.Model.Blocks.Wood()));
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SharpControl.Client.Respawn();
            SendCmd("me respawned!");
        }
        void Changeselected(short i)
        {
            SharpControl.Client.Player.SelectedSlot += 1;
            if (SharpControl.Client.Player.SelectedSlot > 9) { SharpControl.Client.Player.SelectedSlot = 0; }
            if (SharpControl.Client.Player.SelectedSlot < 0) { SharpControl.Client.Player.SelectedSlot = 9; }
            SharpControl.Client.SendPlayerPositionAndLook();
        }

        private void butDisconnect_Click(object sender, EventArgs e)
        {
            SharpControl.Client.ForceDisconnect();
            Close();
                                  
        }

        private void User_Control_FormClosing(object sender, FormClosingEventArgs e)
        {
            SharpControl.Client.ForceDisconnect();
        }
    }
}
