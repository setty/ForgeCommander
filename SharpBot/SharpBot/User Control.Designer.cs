namespace SharpBot
{
    partial class User_Control
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ChatBox1 = new System.Windows.Forms.ListBox();
            this.btnW = new System.Windows.Forms.Button();
            this.btnS = new System.Windows.Forms.Button();
            this.btnA = new System.Windows.Forms.Button();
            this.btnD = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butDisconnect = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 245);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chat";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(315, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(303, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // ChatBox1
            // 
            this.ChatBox1.FormattingEnabled = true;
            this.ChatBox1.Location = new System.Drawing.Point(12, 12);
            this.ChatBox1.Name = "ChatBox1";
            this.ChatBox1.Size = new System.Drawing.Size(385, 225);
            this.ChatBox1.TabIndex = 2;
            this.ChatBox1.SelectedIndexChanged += new System.EventHandler(this.ChatBox1_SelectedIndexChanged);
            // 
            // btnW
            // 
            this.btnW.Location = new System.Drawing.Point(447, 12);
            this.btnW.Name = "btnW";
            this.btnW.Size = new System.Drawing.Size(37, 35);
            this.btnW.TabIndex = 2;
            this.btnW.Text = "W";
            this.btnW.UseVisualStyleBackColor = true;
            this.btnW.Click += new System.EventHandler(this.btnW_Click);
            // 
            // btnS
            // 
            this.btnS.Location = new System.Drawing.Point(447, 53);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(37, 35);
            this.btnS.TabIndex = 4;
            this.btnS.Text = "S";
            this.btnS.UseVisualStyleBackColor = true;
            this.btnS.Click += new System.EventHandler(this.btnS_Click);
            // 
            // btnA
            // 
            this.btnA.Location = new System.Drawing.Point(404, 53);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(37, 35);
            this.btnA.TabIndex = 5;
            this.btnA.Text = "A";
            this.btnA.UseVisualStyleBackColor = true;
            this.btnA.Click += new System.EventHandler(this.btnA_Click);
            // 
            // btnD
            // 
            this.btnD.Location = new System.Drawing.Point(490, 53);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(37, 35);
            this.btnD.TabIndex = 6;
            this.btnD.Text = "D";
            this.btnD.UseVisualStyleBackColor = true;
            this.btnD.Click += new System.EventHandler(this.btnD_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(404, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 35);
            this.button2.TabIndex = 7;
            this.button2.Text = "UP";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(469, 94);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(59, 35);
            this.button3.TabIndex = 8;
            this.button3.Text = "DOWN";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(404, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(37, 35);
            this.button4.TabIndex = 9;
            this.button4.Text = "<--";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(490, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(37, 35);
            this.button5.TabIndex = 10;
            this.button5.Text = "-->";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(12, 304);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Clear on send";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(469, 135);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(59, 35);
            this.button7.TabIndex = 12;
            this.button7.Text = "1/2 DOWN";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(404, 135);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(59, 35);
            this.button8.TabIndex = 11;
            this.button8.Text = "1/2\r\nUP";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(6, 58);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(112, 25);
            this.button9.TabIndex = 13;
            this.button9.Text = "Place block below";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(6, 32);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(112, 20);
            this.txtID.TabIndex = 14;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtID);
            this.groupBox3.Controls.Add(this.button9);
            this.groupBox3.Location = new System.Drawing.Point(404, 177);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(124, 89);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Set block";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Block ID";
            // 
            // butDisconnect
            // 
            this.butDisconnect.Location = new System.Drawing.Point(404, 272);
            this.butDisconnect.Name = "butDisconnect";
            this.butDisconnect.Size = new System.Drawing.Size(124, 24);
            this.butDisconnect.TabIndex = 16;
            this.butDisconnect.Text = "Disconnect";
            this.butDisconnect.UseVisualStyleBackColor = true;
            this.butDisconnect.Click += new System.EventHandler(this.butDisconnect_Click);
            // 
            // User_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 325);
            this.Controls.Add(this.butDisconnect);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.btnS);
            this.Controls.Add(this.btnW);
            this.Controls.Add(this.ChatBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "User_Control";
            this.Text = "Control panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.User_Control_FormClosing);
            this.Load += new System.EventHandler(this.User_Control_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox ChatBox1;
        private System.Windows.Forms.Button btnW;
        private System.Windows.Forms.Button btnS;
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.Button btnD;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butDisconnect;
    }
}