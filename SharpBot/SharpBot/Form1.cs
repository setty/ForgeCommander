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
        
        public Form1()
        {

            InitializeComponent();
            if (!Directory.Exists("bot")) { Directory.CreateDirectory("bot"); }
            if (!File.Exists("bot/servers.txt")) { File.Create("bot/servers.txt"); }
            if (!File.Exists("bot/op.txt")) { File.Create("bot/op.txt"); }
            foreach (string line in File.ReadAllLines("bot/servers.txt"))
            {
                servers.Add(line);
            }
            ServerBox.Items.Clear();
            foreach (string line in servers)
            {
                 
                ServerBox.Items.Add(line.Split('|')[0]);
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
                MessageBox.Show("Server has been saved!");
                File.WriteAllLines("bot/servers.txt", servers.ToArray());
            }
        }
    }
}
