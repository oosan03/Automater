namespace local
{
    partial class EditUserForm
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
            boxAppFields = new GroupBox();
            lblShowAutomater = new Label();
            txtAutomaterPass = new TextBox();
            txtAutomaterUser = new TextBox();
            lblAutomaterPass = new Label();
            lblAutomaterUser = new Label();
            boxGrandAvenueFields = new GroupBox();
            lblShowGA = new Label();
            txtGrandAvenueUser = new TextBox();
            txtGrandAvenuePass = new TextBox();
            lblGrandAvenuePass = new Label();
            lblGrandAvenueUser = new Label();
            boxNetSuiteFields = new GroupBox();
            lblShowNS = new Label();
            txtNetSuiteUser = new TextBox();
            txtNetSuitePass = new TextBox();
            lblNetSuitePass = new Label();
            lblNetSuiteUser = new Label();
            boxToolTrackFields = new GroupBox();
            lblShowTL = new Label();
            txtToolTrackUser = new TextBox();
            txtToolTrackPass = new TextBox();
            lblToolTrackPass = new Label();
            lblToolTrackUser = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            boxAppFields.SuspendLayout();
            boxGrandAvenueFields.SuspendLayout();
            boxNetSuiteFields.SuspendLayout();
            boxToolTrackFields.SuspendLayout();
            SuspendLayout();
            // 
            // boxAppFields
            // 
            boxAppFields.BackColor = SystemColors.ControlLight;
            boxAppFields.Controls.Add(lblShowAutomater);
            boxAppFields.Controls.Add(txtAutomaterPass);
            boxAppFields.Controls.Add(txtAutomaterUser);
            boxAppFields.Controls.Add(lblAutomaterPass);
            boxAppFields.Controls.Add(lblAutomaterUser);
            boxAppFields.Location = new Point(17, 12);
            boxAppFields.Name = "boxAppFields";
            boxAppFields.Size = new Size(316, 115);
            boxAppFields.TabIndex = 0;
            boxAppFields.TabStop = false;
            boxAppFields.Text = "Automater Credentials";
            // 
            // lblShowAutomater
            // 
            lblShowAutomater.AutoSize = true;
            lblShowAutomater.BackColor = SystemColors.Window;
            lblShowAutomater.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblShowAutomater.ForeColor = SystemColors.MenuText;
            lblShowAutomater.Location = new Point(256, 73);
            lblShowAutomater.Name = "lblShowAutomater";
            lblShowAutomater.Size = new Size(30, 20);
            lblShowAutomater.TabIndex = 4;
            lblShowAutomater.Text = "👁";
            lblShowAutomater.Click += lblShowAutomater_Click;
            // 
            // txtAutomaterPass
            // 
            txtAutomaterPass.Location = new Point(90, 72);
            txtAutomaterPass.Name = "txtAutomaterPass";
            txtAutomaterPass.Size = new Size(198, 23);
            txtAutomaterPass.TabIndex = 3;
            // 
            // txtAutomaterUser
            // 
            txtAutomaterUser.Location = new Point(90, 43);
            txtAutomaterUser.Name = "txtAutomaterUser";
            txtAutomaterUser.Size = new Size(198, 23);
            txtAutomaterUser.TabIndex = 2;
            // 
            // lblAutomaterPass
            // 
            lblAutomaterPass.AutoSize = true;
            lblAutomaterPass.Location = new Point(24, 75);
            lblAutomaterPass.Name = "lblAutomaterPass";
            lblAutomaterPass.Size = new Size(60, 15);
            lblAutomaterPass.TabIndex = 1;
            lblAutomaterPass.Text = "Password:";
            // 
            // lblAutomaterUser
            // 
            lblAutomaterUser.AutoSize = true;
            lblAutomaterUser.Location = new Point(21, 46);
            lblAutomaterUser.Name = "lblAutomaterUser";
            lblAutomaterUser.Size = new Size(63, 15);
            lblAutomaterUser.TabIndex = 0;
            lblAutomaterUser.Text = "Username:";
            // 
            // boxGrandAvenueFields
            // 
            boxGrandAvenueFields.BackColor = SystemColors.ControlLight;
            boxGrandAvenueFields.Controls.Add(lblShowGA);
            boxGrandAvenueFields.Controls.Add(txtGrandAvenueUser);
            boxGrandAvenueFields.Controls.Add(txtGrandAvenuePass);
            boxGrandAvenueFields.Controls.Add(lblGrandAvenuePass);
            boxGrandAvenueFields.Controls.Add(lblGrandAvenueUser);
            boxGrandAvenueFields.Location = new Point(17, 145);
            boxGrandAvenueFields.Name = "boxGrandAvenueFields";
            boxGrandAvenueFields.Size = new Size(316, 115);
            boxGrandAvenueFields.TabIndex = 1;
            boxGrandAvenueFields.TabStop = false;
            boxGrandAvenueFields.Text = "Grand Avenue Credentials";
            // 
            // lblShowGA
            // 
            lblShowGA.AutoSize = true;
            lblShowGA.BackColor = SystemColors.Window;
            lblShowGA.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblShowGA.ForeColor = SystemColors.MenuText;
            lblShowGA.Location = new Point(257, 66);
            lblShowGA.Name = "lblShowGA";
            lblShowGA.Size = new Size(30, 20);
            lblShowGA.TabIndex = 7;
            lblShowGA.Text = "👁";
            lblShowGA.Click += lblShowGA_Click;
            // 
            // txtGrandAvenueUser
            // 
            txtGrandAvenueUser.Location = new Point(90, 36);
            txtGrandAvenueUser.Name = "txtGrandAvenueUser";
            txtGrandAvenueUser.Size = new Size(198, 23);
            txtGrandAvenueUser.TabIndex = 6;
            // 
            // txtGrandAvenuePass
            // 
            txtGrandAvenuePass.Location = new Point(90, 65);
            txtGrandAvenuePass.Name = "txtGrandAvenuePass";
            txtGrandAvenuePass.Size = new Size(198, 23);
            txtGrandAvenuePass.TabIndex = 7;
            // 
            // lblGrandAvenuePass
            // 
            lblGrandAvenuePass.AutoSize = true;
            lblGrandAvenuePass.Location = new Point(24, 68);
            lblGrandAvenuePass.Name = "lblGrandAvenuePass";
            lblGrandAvenuePass.Size = new Size(60, 15);
            lblGrandAvenuePass.TabIndex = 4;
            lblGrandAvenuePass.Text = "Password:";
            // 
            // lblGrandAvenueUser
            // 
            lblGrandAvenueUser.AutoSize = true;
            lblGrandAvenueUser.Location = new Point(21, 39);
            lblGrandAvenueUser.Name = "lblGrandAvenueUser";
            lblGrandAvenueUser.Size = new Size(63, 15);
            lblGrandAvenueUser.TabIndex = 3;
            lblGrandAvenueUser.Text = "Username:";
            // 
            // boxNetSuiteFields
            // 
            boxNetSuiteFields.BackColor = SystemColors.ControlLight;
            boxNetSuiteFields.Controls.Add(lblShowNS);
            boxNetSuiteFields.Controls.Add(txtNetSuiteUser);
            boxNetSuiteFields.Controls.Add(txtNetSuitePass);
            boxNetSuiteFields.Controls.Add(lblNetSuitePass);
            boxNetSuiteFields.Controls.Add(lblNetSuiteUser);
            boxNetSuiteFields.Location = new Point(350, 145);
            boxNetSuiteFields.Name = "boxNetSuiteFields";
            boxNetSuiteFields.Size = new Size(316, 115);
            boxNetSuiteFields.TabIndex = 1;
            boxNetSuiteFields.TabStop = false;
            boxNetSuiteFields.Text = "NetSuite Credentials";
            // 
            // lblShowNS
            // 
            lblShowNS.AutoSize = true;
            lblShowNS.BackColor = SystemColors.Window;
            lblShowNS.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblShowNS.ForeColor = SystemColors.MenuText;
            lblShowNS.Location = new Point(257, 67);
            lblShowNS.Name = "lblShowNS";
            lblShowNS.Size = new Size(30, 20);
            lblShowNS.TabIndex = 5;
            lblShowNS.Text = "👁";
            lblShowNS.Click += lblShowNS_Click;
            // 
            // txtNetSuiteUser
            // 
            txtNetSuiteUser.Location = new Point(90, 36);
            txtNetSuiteUser.Name = "txtNetSuiteUser";
            txtNetSuiteUser.Size = new Size(198, 23);
            txtNetSuiteUser.TabIndex = 8;
            // 
            // txtNetSuitePass
            // 
            txtNetSuitePass.Location = new Point(90, 65);
            txtNetSuitePass.Name = "txtNetSuitePass";
            txtNetSuitePass.Size = new Size(198, 23);
            txtNetSuitePass.TabIndex = 9;
            // 
            // lblNetSuitePass
            // 
            lblNetSuitePass.AutoSize = true;
            lblNetSuitePass.Location = new Point(24, 68);
            lblNetSuitePass.Name = "lblNetSuitePass";
            lblNetSuitePass.Size = new Size(60, 15);
            lblNetSuitePass.TabIndex = 3;
            lblNetSuitePass.Text = "Password:";
            // 
            // lblNetSuiteUser
            // 
            lblNetSuiteUser.AutoSize = true;
            lblNetSuiteUser.Location = new Point(24, 39);
            lblNetSuiteUser.Name = "lblNetSuiteUser";
            lblNetSuiteUser.Size = new Size(63, 15);
            lblNetSuiteUser.TabIndex = 2;
            lblNetSuiteUser.Text = "Username:";
            // 
            // boxToolTrackFields
            // 
            boxToolTrackFields.BackColor = SystemColors.ControlLight;
            boxToolTrackFields.Controls.Add(lblShowTL);
            boxToolTrackFields.Controls.Add(txtToolTrackUser);
            boxToolTrackFields.Controls.Add(txtToolTrackPass);
            boxToolTrackFields.Controls.Add(lblToolTrackPass);
            boxToolTrackFields.Controls.Add(lblToolTrackUser);
            boxToolTrackFields.Location = new Point(350, 12);
            boxToolTrackFields.Name = "boxToolTrackFields";
            boxToolTrackFields.Size = new Size(316, 115);
            boxToolTrackFields.TabIndex = 1;
            boxToolTrackFields.TabStop = false;
            boxToolTrackFields.Text = "ToolTrack Credentials";
            // 
            // lblShowTL
            // 
            lblShowTL.AutoSize = true;
            lblShowTL.BackColor = SystemColors.Window;
            lblShowTL.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblShowTL.ForeColor = SystemColors.MenuText;
            lblShowTL.Location = new Point(257, 71);
            lblShowTL.Name = "lblShowTL";
            lblShowTL.Size = new Size(30, 20);
            lblShowTL.TabIndex = 6;
            lblShowTL.Text = "👁";
            lblShowTL.Click += lblShowTL_Click;
            // 
            // txtToolTrackUser
            // 
            txtToolTrackUser.Location = new Point(90, 41);
            txtToolTrackUser.Name = "txtToolTrackUser";
            txtToolTrackUser.Size = new Size(198, 23);
            txtToolTrackUser.TabIndex = 4;
            // 
            // txtToolTrackPass
            // 
            txtToolTrackPass.Location = new Point(90, 70);
            txtToolTrackPass.Name = "txtToolTrackPass";
            txtToolTrackPass.Size = new Size(198, 23);
            txtToolTrackPass.TabIndex = 5;
            // 
            // lblToolTrackPass
            // 
            lblToolTrackPass.AutoSize = true;
            lblToolTrackPass.Location = new Point(27, 73);
            lblToolTrackPass.Name = "lblToolTrackPass";
            lblToolTrackPass.Size = new Size(60, 15);
            lblToolTrackPass.TabIndex = 2;
            lblToolTrackPass.Text = "Password:";
            // 
            // lblToolTrackUser
            // 
            lblToolTrackUser.AutoSize = true;
            lblToolTrackUser.Location = new Point(21, 44);
            lblToolTrackUser.Name = "lblToolTrackUser";
            lblToolTrackUser.Size = new Size(63, 15);
            lblToolTrackUser.TabIndex = 1;
            lblToolTrackUser.Text = "Username:";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ControlDarkDark;
            btnCancel.ForeColor = SystemColors.ButtonFace;
            btnCancel.Location = new Point(586, 280);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 30);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.ForeColor = SystemColors.ButtonFace;
            btnSave.Location = new Point(495, 280);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(85, 30);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // EditUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(683, 322);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(boxNetSuiteFields);
            Controls.Add(boxToolTrackFields);
            Controls.Add(boxGrandAvenueFields);
            Controls.Add(boxAppFields);
            Name = "EditUserForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit User Credentials";
            boxAppFields.ResumeLayout(false);
            boxAppFields.PerformLayout();
            boxGrandAvenueFields.ResumeLayout(false);
            boxGrandAvenueFields.PerformLayout();
            boxNetSuiteFields.ResumeLayout(false);
            boxNetSuiteFields.PerformLayout();
            boxToolTrackFields.ResumeLayout(false);
            boxToolTrackFields.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox boxAppFields;
        private GroupBox boxGrandAvenueFields;
        private GroupBox boxNetSuiteFields;
        private GroupBox boxToolTrackFields;
        private Button btnCancel;
        private Button btnSave;
        private Label lblAutomaterUser;
        private Label lblGrandAvenueUser;
        private Label lblNetSuiteUser;
        private Label lblToolTrackUser;
        private TextBox txtAutomaterPass;
        private TextBox txtAutomaterUser;
        private Label lblAutomaterPass;
        private TextBox txtGrandAvenueUser;
        private TextBox txtGrandAvenuePass;
        private Label lblGrandAvenuePass;
        private TextBox txtNetSuiteUser;
        private TextBox txtNetSuitePass;
        private Label lblNetSuitePass;
        private TextBox txtToolTrackUser;
        private TextBox txtToolTrackPass;
        private Label lblToolTrackPass;
        private Label lblShowAutomater;
        private Label lblShowTL;
        private Label lblShowNS;
        private Label lblShowGA;
    }
}