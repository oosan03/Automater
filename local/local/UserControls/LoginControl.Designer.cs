namespace local.UserControls
{
    partial class LoginControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
            txtPin = new TextBox();
            btnLogin = new Button();
            boxLogin = new GroupBox();
            lblStatusLogin = new Label();
            lblLogin = new Label();
            logoPicture = new PictureBox();
            boxLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPicture).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(104, 90);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(70, 17);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(143, 123);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(31, 17);
            label2.TabIndex = 1;
            label2.Text = "PIN:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(182, 89);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(181, 23);
            txtUsername.TabIndex = 2;
            // 
            // txtPin
            // 
            txtPin.Location = new Point(182, 122);
            txtPin.Name = "txtPin";
            txtPin.Size = new Size(181, 23);
            txtPin.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.BackColor = SystemColors.HotTrack;
            btnLogin.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.ButtonFace;
            btnLogin.Location = new Point(435, 234);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(103, 33);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            
            // 
            // boxLogin
            // 
            boxLogin.BackColor = SystemColors.ActiveBorder;
            boxLogin.Controls.Add(lblStatusLogin);
            boxLogin.Controls.Add(txtUsername);
            boxLogin.Controls.Add(btnLogin);
            boxLogin.Controls.Add(label1);
            boxLogin.Controls.Add(label2);
            boxLogin.Controls.Add(txtPin);
            boxLogin.FlatStyle = FlatStyle.Popup;
            boxLogin.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            boxLogin.Location = new Point(100, 76);
            boxLogin.Name = "boxLogin";
            boxLogin.Size = new Size(544, 273);
            boxLogin.TabIndex = 5;
            boxLogin.TabStop = false;
            // 
            // lblStatusLogin
            // 
            lblStatusLogin.AutoSize = true;
            lblStatusLogin.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatusLogin.ForeColor = Color.DarkRed;
            lblStatusLogin.Location = new Point(16, 241);
            lblStatusLogin.Name = "lblStatusLogin";
            lblStatusLogin.Size = new Size(0, 17);
            lblStatusLogin.TabIndex = 5;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogin.ForeColor = SystemColors.Control;
            lblLogin.Location = new Point(282, 20);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(164, 37);
            lblLogin.TabIndex = 6;
            lblLogin.Text = "Automater ";
            // 
            // logoPicture
            // 
            logoPicture.Location = new Point(437, 20);
            logoPicture.Name = "logoPicture";
            logoPicture.Size = new Size(42, 37);
            logoPicture.TabIndex = 7;
            logoPicture.TabStop = false;
            // 
            // LoginControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.WindowFrame;
            Controls.Add(logoPicture);
            Controls.Add(lblLogin);
            Controls.Add(boxLogin);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 3, 5, 3);
            Name = "LoginControl";
            Size = new Size(750, 400);
            boxLogin.ResumeLayout(false);
            boxLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.GroupBox boxLogin;
        private System.Windows.Forms.Label lblStatusLogin;
        private Label lblLogin;
        private PictureBox logoPicture;
    }
}
