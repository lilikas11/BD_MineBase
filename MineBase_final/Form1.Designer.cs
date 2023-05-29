namespace MineBase_final
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.loginPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.login = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBoxPersonagem = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SoundButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.ErrorPopUpPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.TryAgainButton = new System.Windows.Forms.Button();
            this.CredentialsNotPanel = new System.Windows.Forms.Panel();
            this.TryAgain2Button = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.loginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.ErrorPopUpPanel.SuspendLayout();
            this.CredentialsNotPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginPanel
            // 
            this.loginPanel.Controls.Add(this.CredentialsNotPanel);
            this.loginPanel.Controls.Add(this.ErrorPopUpPanel);
            this.loginPanel.Controls.Add(this.pictureBox1);
            this.loginPanel.Controls.Add(this.login);
            this.loginPanel.Controls.Add(this.PasswordTextBox);
            this.loginPanel.Controls.Add(this.EmailTextBox);
            this.loginPanel.Controls.Add(this.label2);
            this.loginPanel.Controls.Add(this.label1);
            this.loginPanel.Location = new System.Drawing.Point(40, 12);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(723, 426);
            this.loginPanel.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(295, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(298, 263);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(117, 43);
            this.login.TabIndex = 4;
            this.login.Text = "Login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(257, 209);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(316, 26);
            this.PasswordTextBox.TabIndex = 3;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(257, 160);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(316, 26);
            this.EmailTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-mail:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboBoxPersonagem);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(75, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(602, 411);
            this.panel3.TabIndex = 2;
            this.panel3.Visible = false;
            // 
            // comboBoxPersonagem
            // 
            this.comboBoxPersonagem.FormattingEnabled = true;
            this.comboBoxPersonagem.Location = new System.Drawing.Point(52, 114);
            this.comboBoxPersonagem.Name = "comboBoxPersonagem";
            this.comboBoxPersonagem.Size = new System.Drawing.Size(312, 28);
            this.comboBoxPersonagem.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(368, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 45);
            this.button2.TabIndex = 1;
            this.button2.Text = "Selecionar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(323, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Seleciona uma Personagem:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SoundButton);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.comboBox4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.comboBox3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.listBox2);
            this.panel2.Location = new System.Drawing.Point(76, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(671, 411);
            this.panel2.TabIndex = 1;
            this.panel2.Visible = false;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // SoundButton
            // 
            this.SoundButton.Location = new System.Drawing.Point(608, 13);
            this.SoundButton.Name = "SoundButton";
            this.SoundButton.Size = new System.Drawing.Size(56, 47);
            this.SoundButton.TabIndex = 8;
            this.SoundButton.Text = "Som";
            this.SoundButton.UseVisualStyleBackColor = true;
            this.SoundButton.Click += new System.EventHandler(this.SoundButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(19, 142);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(291, 264);
            this.listBox1.TabIndex = 6;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(431, 94);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(134, 28);
            this.comboBox4.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(359, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Mundo:";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(103, 92);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(134, 28);
            this.comboBox3.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Inventário:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(101, 28);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(136, 28);
            this.comboBox2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Bioma:";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(364, 142);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(300, 264);
            this.listBox2.TabIndex = 7;
            // 
            // ErrorPopUpPanel
            // 
            this.ErrorPopUpPanel.Controls.Add(this.TryAgainButton);
            this.ErrorPopUpPanel.Controls.Add(this.label7);
            this.ErrorPopUpPanel.Location = new System.Drawing.Point(82, 26);
            this.ErrorPopUpPanel.Name = "ErrorPopUpPanel";
            this.ErrorPopUpPanel.Size = new System.Drawing.Size(518, 321);
            this.ErrorPopUpPanel.TabIndex = 6;
            this.ErrorPopUpPanel.Visible = false;
            this.ErrorPopUpPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(164, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(181, 32);
            this.label7.TabIndex = 0;
            this.label7.Text = "Fill all Fields!";
            // 
            // TryAgainButton
            // 
            this.TryAgainButton.Location = new System.Drawing.Point(361, 250);
            this.TryAgainButton.Name = "TryAgainButton";
            this.TryAgainButton.Size = new System.Drawing.Size(125, 46);
            this.TryAgainButton.TabIndex = 1;
            this.TryAgainButton.Text = "Try Again";
            this.TryAgainButton.UseVisualStyleBackColor = true;
            this.TryAgainButton.Click += new System.EventHandler(this.TryAgainButton_Click);
            // 
            // CredentialsNotPanel
            // 
            this.CredentialsNotPanel.Controls.Add(this.TryAgain2Button);
            this.CredentialsNotPanel.Controls.Add(this.label8);
            this.CredentialsNotPanel.Location = new System.Drawing.Point(38, 14);
            this.CredentialsNotPanel.Name = "CredentialsNotPanel";
            this.CredentialsNotPanel.Size = new System.Drawing.Size(638, 374);
            this.CredentialsNotPanel.TabIndex = 7;
            this.CredentialsNotPanel.Visible = false;
            // 
            // TryAgain2Button
            // 
            this.TryAgain2Button.Location = new System.Drawing.Point(260, 246);
            this.TryAgain2Button.Name = "TryAgain2Button";
            this.TryAgain2Button.Size = new System.Drawing.Size(125, 46);
            this.TryAgain2Button.TabIndex = 1;
            this.TryAgain2Button.Text = "Try Again";
            this.TryAgain2Button.UseVisualStyleBackColor = true;
            this.TryAgain2Button.Click += new System.EventHandler(this.TryAgain2Button_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(142, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(362, 32);
            this.label8.TabIndex = 0;
            this.label8.Text = "Credentials Not Authorized!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 300);
            this.Controls.Add(this.loginPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ErrorPopUpPanel.ResumeLayout(false);
            this.ErrorPopUpPanel.PerformLayout();
            this.CredentialsNotPanel.ResumeLayout(false);
            this.CredentialsNotPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPersonagem;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button SoundButton;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel ErrorPopUpPanel;
        private System.Windows.Forms.Button TryAgainButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel CredentialsNotPanel;
        private System.Windows.Forms.Button TryAgain2Button;
        private System.Windows.Forms.Label label8;
    }
}

