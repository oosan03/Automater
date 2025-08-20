namespace local
{
    partial class AddDialog
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
            lblData = new Label();
            txtLotNumber = new TextBox();
            btnCancel = new Button();
            btnSave = new Button();
            lblInvalidLot = new Label();
            SuspendLayout();
            // 
            // lblData
            // 
            lblData.AutoSize = true;
            lblData.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblData.Location = new Point(41, 49);
            lblData.Name = "lblData";
            lblData.Size = new Size(69, 15);
            lblData.TabIndex = 0;
            lblData.Text = "Placeholder";
            // 
            // txtLotNumber
            // 
            txtLotNumber.Location = new Point(148, 46);
            txtLotNumber.Name = "txtLotNumber";
            txtLotNumber.Size = new Size(159, 23);
            txtLotNumber.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ControlDarkDark;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.ButtonFace;
            btnCancel.Location = new Point(274, 131);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = SystemColors.ButtonFace;
            btnSave.Location = new Point(193, 131);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // lblInvalidLot
            // 
            lblInvalidLot.AutoSize = true;
            lblInvalidLot.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInvalidLot.ForeColor = Color.Maroon;
            lblInvalidLot.Location = new Point(27, 135);
            lblInvalidLot.Name = "lblInvalidLot";
            lblInvalidLot.Size = new Size(0, 15);
            lblInvalidLot.TabIndex = 4;
            // 
            // AddDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(361, 166);
            Controls.Add(lblInvalidLot);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(txtLotNumber);
            Controls.Add(lblData);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "AddDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblData;
        private TextBox txtLotNumber;
        private Button btnCancel;
        private Button btnSave;
        private Label lblInvalidLot;
    }
}