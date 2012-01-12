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
    public partial class SaveServer : Form
    {
        public SaveServer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.didsavename = false;
            if (textBox1.Text == "" || textBox1.Text == null) { MessageBox.Show("Please enter a server name!"); return; }
            bool alreadyin = false;
            foreach (string stringvar in Form1.servers)
            {
                if (stringvar.Contains(textBox1.Text))
                {
                    alreadyin = true;
                }
            }
            if (alreadyin) { MessageBox.Show("This name is already taken!"); return; }
            Program.saveservername = textBox1.Text;
            Program.didsavename = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
