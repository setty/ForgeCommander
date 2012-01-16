using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LibMinecraft.Server;
using LibMinecraft.Client;
using LibMinecraft.Model;
namespace SharpBot
{
    public partial class Form1 : Form
    {
        public static List<string> servers = new List<string>();
        public static List<string> users = new List<string>();

        public Form1()
        {

            InitializeComponent();
            if (!Directory.Exists("bot")) { Directory.CreateDirectory("bot"); }
            if (!File.Exists("bot/servers_dat.dll")) { File.Create("bot/servers_dat.dll").Close(); }
            if (!File.Exists("bot/users_dat.dll")) { File.Create("bot/users_dat.dll").Close(); }
            if (!File.Exists("bot/op.txt")) { File.Create("bot/op.txt").Close(); }
            if (!File.Exists("bot/settings_dat.dll")) { File.Create("bot/settings_dat.dll").Close(); }
            foreach (string line in File.ReadAllLines("bot/servers_dat.dll"))
            {
                servers.Add(line);
            }
            ServerBox.Items.Clear();
            foreach (string line in File.ReadAllLines("bot/users_dat.dll"))
            {
                users.Add(line);
            }
            UserBox.Items.Clear();

            foreach (string line in servers)
            {

                ServerBox.Items.Add(line.Split('|')[0]);
            }
            foreach (string line in users)
            {

                UserBox.Items.Add(line.Split('|')[0]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != "" && txtServer.Text != "")
            {
                string port;
                string sendserver;
                if (txtPort.Text == "")
                {
                    port = "25565";
                }
                else
                {
                    port = txtPort.Text;
                }
                sendserver = txtServer.Text + ":" + port;

                SharpControl.Login(txtUser.Text, txtPass.Text, sendserver);
                SharpControl.servername = txtServer.Text;
                Hide();
                (new User_Control()).ShowDialog();
                Close();


            }
            else
            {
                if (txtUser.Text == "")
                {
                    MessageBox.Show("Make sure to enter an username!");
                }
                if (txtServer.Text == "")
                {
                    MessageBox.Show("Make sure to enter a hostname!");
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtServer.Text == null || txtServer.Text == "") { MessageBox.Show("Make sure to enter a hostname before you save!"); return; }
            string portsave;
            if (txtPort.Text == null || txtPort.Text == "")
            {
                portsave = "25565";
            }
            else
            {
                portsave = txtPort.Text;
            }
            Hide();
            (new SaveServer()).ShowDialog();
            Show();
            if (Program.didsavename)
            {
                string savevar = Program.saveservername + "|" + txtServer.Text + "|" + portsave;
                servers.Add(savevar);
                ServerBox.Items.Clear();
                foreach (string line in servers)
                {

                    ServerBox.Items.Add(line.Split('|')[0]);
                }
                File.WriteAllLines("bot/servers_dat.dll", servers.ToArray());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ServerBox.SelectedIndex == -1) { return; }
            string name = ServerBox.Items[ServerBox.SelectedIndex].ToString();
            foreach (string stringvar in servers.ToArray())
            {
                if (stringvar.Contains(name))
                {
                    servers.Remove(stringvar);
                }
            }
            ServerBox.Items.Clear();
            foreach (string line in servers)
            {

                ServerBox.Items.Add(line.Split('|')[0]);
            }
            File.WriteAllLines("bot/servers_dat.dll", servers.ToArray());

        }

        private void ServerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ServerBox.SelectedIndex == -1) { return; }
            string name = ServerBox.Items[ServerBox.SelectedIndex].ToString();
            foreach (string stringvar in servers.ToArray())
            {
                if (stringvar.Contains(name))
                {
                    txtServer.Text = stringvar.Split('|')[1];
                    txtPort.Text = stringvar.Split('|')[2];
                }
            }

        }

        private void UserBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserBox.SelectedIndex == -1) { return; }
            string name = UserBox.Items[UserBox.SelectedIndex].ToString();
            foreach (string stringvar in users.ToArray())
            {
                if (stringvar.Contains(name))
                {
                    txtUser.Text = stringvar.Split('|')[0];
                    txtPass.Text = stringvar.Split('|')[1];
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == null || txtUser.Text == "") { MessageBox.Show("Make sure to enter an username before you save!"); return; }
            string savevar = txtUser.Text + "|" + txtPass.Text;
            users.Add(savevar);
            UserBox.Items.Clear();
            foreach (string line in users)
            {

                UserBox.Items.Add(line.Split('|')[0]);
            }
            File.WriteAllLines("bot/users_dat.dll", users.ToArray());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (UserBox.SelectedIndex == -1) { return; }
            string name = UserBox.Items[UserBox.SelectedIndex].ToString();
            foreach (string stringvar in users.ToArray())
            {
                if (stringvar.Contains(name))
                {
                    users.Remove(stringvar);
                }
            }
            UserBox.Items.Clear();
            foreach (string line in users)
            {

                UserBox.Items.Add(line.Split('|')[0]);
            }
            File.WriteAllLines("bot/users_dat.dll", servers.ToArray());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!Program.settingsopened)
            {
                SettingsForm settings = new SettingsForm();
                settings.Show();
                Program.settingsopened = true;
            }
        }
    }
}

