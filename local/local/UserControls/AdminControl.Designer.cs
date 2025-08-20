namespace local.UserControls
{
    partial class AdminControl
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
            boxUsers = new ListBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnRemove = new Button();
            btnLogin = new Button();
            lblManageUsers = new Label();
            SuspendLayout();
            // 
            // boxUsers
            // 
            boxUsers.BackColor = SystemColors.ActiveBorder;
            boxUsers.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            boxUsers.FormattingEnabled = true;
            boxUsers.ItemHeight = 17;
            boxUsers.Location = new Point(36, 60);
            boxUsers.Name = "boxUsers";
            boxUsers.Size = new Size(557, 242);
            boxUsers.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.SteelBlue;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = SystemColors.ButtonHighlight;
            btnAdd.Location = new Point(599, 60);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(107, 38);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add User";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.SeaGreen;
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.ForeColor = SystemColors.ButtonHighlight;
            btnEdit.Location = new Point(599, 117);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(107, 37);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit User";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.Brown;
            btnRemove.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemove.ForeColor = SystemColors.ButtonHighlight;
            btnRemove.Location = new Point(599, 266);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(107, 36);
            btnRemove.TabIndex = 3;
            btnRemove.Text = "Remove User";
            btnRemove.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.ActiveBorder;
            btnLogin.FlatStyle = FlatStyle.System;
            btnLogin.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.InactiveBorder;
            btnLogin.Location = new Point(654, 367);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(84, 27);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Sign Out";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblManageUsers
            // 
            lblManageUsers.AutoSize = true;
            lblManageUsers.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblManageUsers.ForeColor = SystemColors.ButtonFace;
            lblManageUsers.Location = new Point(200, 20);
            lblManageUsers.Name = "lblManageUsers";
            lblManageUsers.Size = new Size(243, 37);
            lblManageUsers.TabIndex = 5;
            lblManageUsers.Text = "Manage Users 🤔";
            // 
            // AdminControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            Controls.Add(lblManageUsers);
            Controls.Add(btnLogin);
            Controls.Add(btnRemove);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(boxUsers);
            Name = "AdminControl";
            Size = new Size(750, 397);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox boxUsers;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnRemove;
        private Button btnLogin;
        private Label lblManageUsers;
    }
}
