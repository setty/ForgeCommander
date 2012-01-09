using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SharpBot
{
    public partial class JoyStick : Form
    {
        public JoyStick()
        {
            InitializeComponent();
        }

        private void JoyStick_Load(object sender, EventArgs e)
        {
            Width = Screen.PrimaryScreen.Bounds.Width;
            Top = 0;
            Left = 0;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SharpControl.Client.SendChat(textBox1.Text);
                textBox1.Text = "";
            }
            if (e.KeyCode == Keys.Down)
            {
                int walkto = SharpControl.GetWalkway();
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
                int walkto = SharpControl.GetWalkway();
                if (walkto == 0) { SharpControl.Client.Player.Location.Z += 0.5; }
                if (walkto == 1) { SharpControl.Client.Player.Location.X -= 0.5; }
                if (walkto == 2) { SharpControl.Client.Player.Location.Z -= 0.5; }
                if (walkto == 3) { SharpControl.Client.Player.Location.X += 0.5; }
            }
            if (e.KeyCode == Keys.Right)
            {
                SharpControl.Client.Player.Rotation.X += 90;
                if (SharpControl.Client.Player.Rotation.X > 360) { SharpControl.Client.Player.Rotation.X -= 360; }
                if (SharpControl.Client.Player.Rotation.X < 0) { SharpControl.Client.Player.Rotation.X += 360; }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SharpControl.Client.SendChat(textBox1.Text);
            textBox1.Text = "";
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int walkto = SharpControl.GetWalkway();
            if (walkto == 0) { SharpControl.Client.Player.Location.Z += 1; }
            if (walkto == 1) { SharpControl.Client.Player.Location.X -= 1; }
            if (walkto == 2) { SharpControl.Client.Player.Location.Z -= 1; }
            if (walkto == 3) { SharpControl.Client.Player.Location.X += 1; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SharpControl.Client.Player.Rotation.X -= 90;
            if (SharpControl.Client.Player.Rotation.X > 360) { SharpControl.Client.Player.Rotation.X -= 360; }
            if (SharpControl.Client.Player.Rotation.X < 0) { SharpControl.Client.Player.Rotation.X += 360; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int walkto = SharpControl.GetWalkway();
            if (walkto == 2) { SharpControl.Client.Player.Location.Z += 1; }
            if (walkto == 3) { SharpControl.Client.Player.Location.X -= 1; }
            if (walkto == 0) { SharpControl.Client.Player.Location.Z -= 1; }
            if (walkto == 1) { SharpControl.Client.Player.Location.X += 1; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SharpControl.Client.Player.Rotation.X += 90;
            if (SharpControl.Client.Player.Rotation.X > 360) { SharpControl.Client.Player.Rotation.X -= 360; }
            if (SharpControl.Client.Player.Rotation.X < 0) { SharpControl.Client.Player.Rotation.X += 360; }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SharpControl.Client.Player.Location.Y++;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SharpControl.Client.Player.Location.Y--;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void JoyStick_KeyDown(object sender, KeyEventArgs e)
        {
            User_Control uc = new User_Control();
            uc.Recenter_Location();
            if (e.KeyCode == Keys.Down)
            {
                int walkto = uc.GetWalkway();
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
                int walkto = uc.GetWalkway();
                if (walkto == 0) { SharpControl.Client.Player.Location.Z += 0.5; }
                if (walkto == 1) { SharpControl.Client.Player.Location.X -= 0.5; }
                if (walkto == 2) { SharpControl.Client.Player.Location.Z -= 0.5; }
                if (walkto == 3) { SharpControl.Client.Player.Location.X += 0.5; }
            }
            if (e.KeyCode == Keys.Right)
            {
                SharpControl.Client.Player.Rotation.X += 90;
                if (SharpControl.Client.Player.Rotation.X > 360) { SharpControl.Client.Player.Rotation.X -= 360; }
                if (SharpControl.Client.Player.Rotation.X < 0) { SharpControl.Client.Player.Rotation.X += 360; }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
