namespace EP
{
    partial class ContactForm
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
            this.SendMsgBtn = new System.Windows.Forms.Button();
            this.RemovingBtn = new System.Windows.Forms.Button();
            this.FstNameInfoBox = new System.Windows.Forms.MaskedTextBox();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.ProfilePict = new System.Windows.Forms.PictureBox();
            this.LastNameInfoBox = new System.Windows.Forms.MaskedTextBox();
            this.LoginInfoBox = new System.Windows.Forms.MaskedTextBox();
            this.ProgLangInfoBox = new System.Windows.Forms.MaskedTextBox();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.FstName = new System.Windows.Forms.Label();
            this.LastName = new System.Windows.Forms.Label();
            this.ProgLang = new System.Windows.Forms.Label();
            this.NickName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePict)).BeginInit();
            this.SuspendLayout();
            // 
            // SendMsgBtn
            // 
            this.SendMsgBtn.Location = new System.Drawing.Point(12, 153);
            this.SendMsgBtn.Name = "SendMsgBtn";
            this.SendMsgBtn.Size = new System.Drawing.Size(97, 33);
            this.SendMsgBtn.TabIndex = 2;
            this.SendMsgBtn.Text = "Send";
            this.SendMsgBtn.UseVisualStyleBackColor = true;
            this.SendMsgBtn.Click += new System.EventHandler(this.SendMsgBtn_Click);
            // 
            // RemovingBtn
            // 
            this.RemovingBtn.Location = new System.Drawing.Point(130, 153);
            this.RemovingBtn.Name = "RemovingBtn";
            this.RemovingBtn.Size = new System.Drawing.Size(115, 33);
            this.RemovingBtn.TabIndex = 3;
            this.RemovingBtn.Text = "Remove from friends";
            this.RemovingBtn.UseVisualStyleBackColor = true;
            this.RemovingBtn.Click += new System.EventHandler(this.RemovingBtn_Click);
            // 
            // FstNameInfoBox
            // 
            this.FstNameInfoBox.Location = new System.Drawing.Point(289, 63);
            this.FstNameInfoBox.Name = "FstNameInfoBox";
            this.FstNameInfoBox.ReadOnly = true;
            this.FstNameInfoBox.Size = new System.Drawing.Size(73, 20);
            this.FstNameInfoBox.TabIndex = 5;
            // 
            // MessageBox
            // 
            this.MessageBox.Location = new System.Drawing.Point(14, 192);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(350, 43);
            this.MessageBox.TabIndex = 1;
            // 
            // ProfilePict
            // 
            this.ProfilePict.Image = global::EP.Properties.Resources.dazzle_dota_2_wallpaper_5_1024x1024;
            this.ProfilePict.Location = new System.Drawing.Point(12, 12);
            this.ProfilePict.Name = "ProfilePict";
            this.ProfilePict.Size = new System.Drawing.Size(133, 122);
            this.ProfilePict.TabIndex = 0;
            this.ProfilePict.TabStop = false;
            // 
            // LastNameInfoBox
            // 
            this.LastNameInfoBox.Location = new System.Drawing.Point(289, 92);
            this.LastNameInfoBox.Name = "LastNameInfoBox";
            this.LastNameInfoBox.ReadOnly = true;
            this.LastNameInfoBox.Size = new System.Drawing.Size(73, 20);
            this.LastNameInfoBox.TabIndex = 6;
            // 
            // LoginInfoBox
            // 
            this.LoginInfoBox.Location = new System.Drawing.Point(289, 35);
            this.LoginInfoBox.Name = "LoginInfoBox";
            this.LoginInfoBox.ReadOnly = true;
            this.LoginInfoBox.Size = new System.Drawing.Size(73, 20);
            this.LoginInfoBox.TabIndex = 7;
            // 
            // ProgLangInfoBox
            // 
            this.ProgLangInfoBox.Location = new System.Drawing.Point(289, 119);
            this.ProgLangInfoBox.Name = "ProgLangInfoBox";
            this.ProgLangInfoBox.ReadOnly = true;
            this.ProgLangInfoBox.Size = new System.Drawing.Size(73, 20);
            this.ProgLangInfoBox.TabIndex = 8;
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InfoLabel.Location = new System.Drawing.Point(171, 9);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(144, 20);
            this.InfoLabel.TabIndex = 9;
            this.InfoLabel.Text = "Main Information";
            // 
            // FstName
            // 
            this.FstName.AutoSize = true;
            this.FstName.Location = new System.Drawing.Point(162, 66);
            this.FstName.Name = "FstName";
            this.FstName.Size = new System.Drawing.Size(60, 13);
            this.FstName.TabIndex = 10;
            this.FstName.Text = "First Name:";
            // 
            // LastName
            // 
            this.LastName.AutoSize = true;
            this.LastName.Location = new System.Drawing.Point(161, 95);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(61, 13);
            this.LastName.TabIndex = 11;
            this.LastName.Text = "Last Name:";
            // 
            // ProgLang
            // 
            this.ProgLang.AutoSize = true;
            this.ProgLang.Location = new System.Drawing.Point(161, 122);
            this.ProgLang.Name = "ProgLang";
            this.ProgLang.Size = new System.Drawing.Size(122, 13);
            this.ProgLang.TabIndex = 12;
            this.ProgLang.Text = "Programming Language:";
            // 
            // NickName
            // 
            this.NickName.AutoSize = true;
            this.NickName.Location = new System.Drawing.Point(161, 38);
            this.NickName.Name = "NickName";
            this.NickName.Size = new System.Drawing.Size(36, 13);
            this.NickName.TabIndex = 13;
            this.NickName.Text = "Login:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 258);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(350, 43);
            this.textBox1.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(267, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 33);
            this.button1.TabIndex = 15;
            this.button1.Text = "History";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 313);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.NickName);
            this.Controls.Add(this.ProgLang);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.FstName);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.ProgLangInfoBox);
            this.Controls.Add(this.LoginInfoBox);
            this.Controls.Add(this.LastNameInfoBox);
            this.Controls.Add(this.FstNameInfoBox);
            this.Controls.Add(this.RemovingBtn);
            this.Controls.Add(this.SendMsgBtn);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.ProfilePict);
            this.Name = "ContactForm";
            this.Text = "ContactForm";
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePict)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ProfilePict;
        private System.Windows.Forms.Button SendMsgBtn;
        private System.Windows.Forms.Button RemovingBtn;
        private System.Windows.Forms.MaskedTextBox FstNameInfoBox;
        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.MaskedTextBox LastNameInfoBox;
        private System.Windows.Forms.MaskedTextBox LoginInfoBox;
        private System.Windows.Forms.MaskedTextBox ProgLangInfoBox;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Label FstName;
        private System.Windows.Forms.Label LastName;
        private System.Windows.Forms.Label ProgLang;
        private System.Windows.Forms.Label NickName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}