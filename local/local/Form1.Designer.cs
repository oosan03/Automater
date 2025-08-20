namespace local
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainPanel = new Panel();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = SystemColors.WindowFrame;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.MaximumSize = new Size(750, 406);
            mainPanel.MinimumSize = new Size(750, 406);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(750, 406);
            mainPanel.TabIndex = 0;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(750, 406);
            Controls.Add(mainPanel);
            MaximumSize = new Size(766, 445);
            MinimumSize = new Size(766, 445);
            Name = "mainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Automater";
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
    }
}
