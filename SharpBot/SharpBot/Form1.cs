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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
    }
}
