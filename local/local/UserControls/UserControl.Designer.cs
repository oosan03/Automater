namespace local.UserControls
{
    partial class UserControl
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
            tabUsers = new TabControl();
            pageDownload = new TabPage();
            boxDownload = new GroupBox();
            checkTest = new CheckBox();
            downloadProgress = new ProgressBar();
            lblDownloadStatus = new Label();
            txtLotNumber = new TextBox();
            lblLotNumber = new Label();
            btnDownload = new Button();
            pageTooltrack = new TabPage();
            boxTooltrack = new GroupBox();
            panel1 = new Panel();
            checkNS = new CheckBox();
            checkTL = new CheckBox();
            lblToolTrackStatus = new Label();
            btnUpdateToolTrack = new Button();
            btnAddQC = new Button();
            btnAddCal = new Button();
            boxFailure = new ComboBox();
            lblFailType = new Label();
            boxStatus = new ComboBox();
            lblPassorFail = new Label();
            boxQC = new ComboBox();
            lblQCLN = new Label();
            comboCal = new ComboBox();
            lblCal = new Label();
            txtTooltrackLN = new TextBox();
            lblToolTrackLotNumber = new Label();
            pagePassed = new TabPage();
            lstLog = new ListBox();
            btnCancel = new Button();
            btnRun = new Button();
            txtDestPath = new TextBox();
            txtSourcePath = new TextBox();
            lblDestPath = new Label();
            lblSourcePath = new Label();
            btnLogout = new Button();
            tabUsers.SuspendLayout();
            pageDownload.SuspendLayout();
            boxDownload.SuspendLayout();
            pageTooltrack.SuspendLayout();
            boxTooltrack.SuspendLayout();
            panel1.SuspendLayout();
            pagePassed.SuspendLayout();
            SuspendLayout();
            // 
            // tabUsers
            // 
            tabUsers.Controls.Add(pageDownload);
            tabUsers.Controls.Add(pageTooltrack);
            tabUsers.Controls.Add(pagePassed);
            tabUsers.Dock = DockStyle.Bottom;
            tabUsers.ItemSize = new Size(92, 24);
            tabUsers.Location = new Point(0, 3);
            tabUsers.Name = "tabUsers";
            tabUsers.SelectedIndex = 0;
            tabUsers.Size = new Size(750, 397);
            tabUsers.TabIndex = 3;
            // 
            // pageDownload
            // 
            pageDownload.BackColor = SystemColors.WindowFrame;
            pageDownload.Controls.Add(boxDownload);
            pageDownload.Location = new Point(4, 28);
            pageDownload.Name = "pageDownload";
            pageDownload.Padding = new Padding(3);
            pageDownload.Size = new Size(742, 365);
            pageDownload.TabIndex = 0;
            pageDownload.Text = "Download Files ";
            // 
            // boxDownload
            // 
            boxDownload.BackColor = SystemColors.ActiveBorder;
            boxDownload.Controls.Add(checkTest);
            boxDownload.Controls.Add(downloadProgress);
            boxDownload.Controls.Add(lblDownloadStatus);
            boxDownload.Controls.Add(txtLotNumber);
            boxDownload.Controls.Add(lblLotNumber);
            boxDownload.Controls.Add(btnDownload);
            boxDownload.Location = new Point(97, 38);
            boxDownload.Name = "boxDownload";
            boxDownload.Size = new Size(546, 283);
            boxDownload.TabIndex = 2;
            boxDownload.TabStop = false;
            boxDownload.Text = "Download Grand Avenue Files";
            // 
            // checkTest
            // 
            checkTest.AutoSize = true;
            checkTest.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkTest.Location = new Point(337, 252);
            checkTest.Name = "checkTest";
            checkTest.RightToLeft = RightToLeft.Yes;
            checkTest.Size = new Size(64, 19);
            checkTest.TabIndex = 5;
            checkTest.Text = "Testing";
            checkTest.UseVisualStyleBackColor = true;
            // 
            // downloadProgress
            // 
            downloadProgress.Location = new Point(16, 230);
            downloadProgress.MarqueeAnimationSpeed = 1;
            downloadProgress.Name = "downloadProgress";
            downloadProgress.Size = new Size(216, 19);
            downloadProgress.Step = 100;
            downloadProgress.Style = ProgressBarStyle.Marquee;
            downloadProgress.TabIndex = 4;
            // 
            // lblDownloadStatus
            // 
            lblDownloadStatus.AutoSize = true;
            lblDownloadStatus.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDownloadStatus.ForeColor = Color.DarkRed;
            lblDownloadStatus.Location = new Point(16, 252);
            lblDownloadStatus.Name = "lblDownloadStatus";
            lblDownloadStatus.Size = new Size(0, 17);
            lblDownloadStatus.TabIndex = 3;
            // 
            // txtLotNumber
            // 
            txtLotNumber.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLotNumber.Location = new Point(151, 58);
            txtLotNumber.Name = "txtLotNumber";
            txtLotNumber.Size = new Size(150, 25);
            txtLotNumber.TabIndex = 0;
            // 
            // lblLotNumber
            // 
            lblLotNumber.AutoSize = true;
            lblLotNumber.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLotNumber.Location = new Point(41, 63);
            lblLotNumber.Name = "lblLotNumber";
            lblLotNumber.Size = new Size(104, 15);
            lblLotNumber.TabIndex = 0;
            lblLotNumber.Text = "Enter Lot Number:";
            // 
            // btnDownload
            // 
            btnDownload.BackColor = Color.SeaGreen;
            btnDownload.FlatStyle = FlatStyle.Popup;
            btnDownload.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDownload.ForeColor = Color.Transparent;
            btnDownload.Location = new Point(431, 246);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(109, 31);
            btnDownload.TabIndex = 1;
            btnDownload.Text = "Download Files";
            btnDownload.UseVisualStyleBackColor = false;
            btnDownload.Click += btnDownload_Click;
            // 
            // pageTooltrack
            // 
            pageTooltrack.BackColor = SystemColors.WindowFrame;
            pageTooltrack.Controls.Add(boxTooltrack);
            pageTooltrack.Location = new Point(4, 28);
            pageTooltrack.Name = "pageTooltrack";
            pageTooltrack.Padding = new Padding(3);
            pageTooltrack.Size = new Size(742, 365);
            pageTooltrack.TabIndex = 1;
            pageTooltrack.Text = "ToolTrack & NetSuite ";
            // 
            // boxTooltrack
            // 
            boxTooltrack.BackColor = SystemColors.ActiveBorder;
            boxTooltrack.Controls.Add(panel1);
            boxTooltrack.Controls.Add(lblToolTrackStatus);
            boxTooltrack.Controls.Add(btnUpdateToolTrack);
            boxTooltrack.Controls.Add(btnAddQC);
            boxTooltrack.Controls.Add(btnAddCal);
            boxTooltrack.Controls.Add(boxFailure);
            boxTooltrack.Controls.Add(lblFailType);
            boxTooltrack.Controls.Add(boxStatus);
            boxTooltrack.Controls.Add(lblPassorFail);
            boxTooltrack.Controls.Add(boxQC);
            boxTooltrack.Controls.Add(lblQCLN);
            boxTooltrack.Controls.Add(comboCal);
            boxTooltrack.Controls.Add(lblCal);
            boxTooltrack.Controls.Add(txtTooltrackLN);
            boxTooltrack.Controls.Add(lblToolTrackLotNumber);
            boxTooltrack.FlatStyle = FlatStyle.Popup;
            boxTooltrack.Location = new Point(72, 42);
            boxTooltrack.Name = "boxTooltrack";
            boxTooltrack.Size = new Size(599, 278);
            boxTooltrack.TabIndex = 0;
            boxTooltrack.TabStop = false;
            boxTooltrack.Text = "Process ToolTrack Route and NetSuite Status";
            // 
            // panel1
            // 
            panel1.Controls.Add(checkNS);
            panel1.Controls.Add(checkTL);
            panel1.Location = new Point(420, 153);
            panel1.Name = "panel1";
            panel1.Size = new Size(173, 64);
            panel1.TabIndex = 15;
            // 
            // checkNS
            // 
            checkNS.AutoSize = true;
            checkNS.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkNS.Location = new Point(15, 16);
            checkNS.Name = "checkNS";
            checkNS.RightToLeft = RightToLeft.Yes;
            checkNS.Size = new Size(155, 19);
            checkNS.TabIndex = 13;
            checkNS.Text = "  Update NetSuite Status";
            checkNS.UseVisualStyleBackColor = true;
            // 
            // checkTL
            // 
            checkTL.AutoSize = true;
            checkTL.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkTL.Location = new Point(16, 41);
            checkTL.Name = "checkTL";
            checkTL.RightToLeft = RightToLeft.Yes;
            checkTL.Size = new Size(154, 19);
            checkTL.TabIndex = 14;
            checkTL.Text = "Update ToolTrack Status";
            checkTL.UseVisualStyleBackColor = true;
            // 
            // lblToolTrackStatus
            // 
            lblToolTrackStatus.AutoSize = true;
            lblToolTrackStatus.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblToolTrackStatus.ForeColor = Color.DarkRed;
            lblToolTrackStatus.Location = new Point(15, 246);
            lblToolTrackStatus.Name = "lblToolTrackStatus";
            lblToolTrackStatus.Size = new Size(0, 17);
            lblToolTrackStatus.TabIndex = 12;
            // 
            // btnUpdateToolTrack
            // 
            btnUpdateToolTrack.BackColor = Color.SeaGreen;
            btnUpdateToolTrack.FlatStyle = FlatStyle.Popup;
            btnUpdateToolTrack.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdateToolTrack.ForeColor = Color.Transparent;
            btnUpdateToolTrack.Location = new Point(487, 240);
            btnUpdateToolTrack.Name = "btnUpdateToolTrack";
            btnUpdateToolTrack.Size = new Size(106, 31);
            btnUpdateToolTrack.TabIndex = 2;
            btnUpdateToolTrack.Text = "Apply Changes";
            btnUpdateToolTrack.UseVisualStyleBackColor = false;
            btnUpdateToolTrack.Click += btnUpdateToolTrack_Click;
            // 
            // btnAddQC
            // 
            btnAddQC.BackColor = Color.Gainsboro;
            btnAddQC.FlatStyle = FlatStyle.Popup;
            btnAddQC.Location = new Point(344, 119);
            btnAddQC.Name = "btnAddQC";
            btnAddQC.Size = new Size(67, 23);
            btnAddQC.TabIndex = 11;
            btnAddQC.Text = "Add QC";
            btnAddQC.UseVisualStyleBackColor = false;
            btnAddQC.Click += btnAddQC_Click;
            // 
            // btnAddCal
            // 
            btnAddCal.BackColor = Color.Gainsboro;
            btnAddCal.FlatStyle = FlatStyle.Popup;
            btnAddCal.Location = new Point(344, 91);
            btnAddCal.Name = "btnAddCal";
            btnAddCal.Size = new Size(67, 23);
            btnAddCal.TabIndex = 10;
            btnAddCal.Text = "Add Cal";
            btnAddCal.UseVisualStyleBackColor = false;
            btnAddCal.Click += btnAddCal_Click;
            // 
            // boxFailure
            // 
            boxFailure.DropDownStyle = ComboBoxStyle.DropDownList;
            boxFailure.FormattingEnabled = true;
            boxFailure.Location = new Point(193, 179);
            boxFailure.Name = "boxFailure";
            boxFailure.Size = new Size(145, 23);
            boxFailure.TabIndex = 9;
            // 
            // lblFailType
            // 
            lblFailType.AutoSize = true;
            lblFailType.Location = new Point(101, 182);
            lblFailType.Name = "lblFailType";
            lblFailType.Size = new Size(86, 15);
            lblFailType.TabIndex = 8;
            lblFailType.Text = "Failure Reason:";
            // 
            // boxStatus
            // 
            boxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            boxStatus.FormattingEnabled = true;
            boxStatus.Location = new Point(193, 150);
            boxStatus.Name = "boxStatus";
            boxStatus.Size = new Size(145, 23);
            boxStatus.TabIndex = 7;
            // 
            // lblPassorFail
            // 
            lblPassorFail.AutoSize = true;
            lblPassorFail.Location = new Point(127, 153);
            lblPassorFail.Name = "lblPassorFail";
            lblPassorFail.Size = new Size(60, 15);
            lblPassorFail.TabIndex = 6;
            lblPassorFail.Text = "Pass | Fail:";
            // 
            // boxQC
            // 
            boxQC.DropDownStyle = ComboBoxStyle.DropDownList;
            boxQC.FormattingEnabled = true;
            boxQC.Location = new Point(193, 120);
            boxQC.Name = "boxQC";
            boxQC.Size = new Size(145, 23);
            boxQC.TabIndex = 5;
            // 
            // lblQCLN
            // 
            lblQCLN.AutoSize = true;
            lblQCLN.Location = new Point(93, 123);
            lblQCLN.Name = "lblQCLN";
            lblQCLN.Size = new Size(94, 15);
            lblQCLN.TabIndex = 4;
            lblQCLN.Text = "QC Lot Number:";
            // 
            // comboCal
            // 
            comboCal.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCal.FormattingEnabled = true;
            comboCal.Location = new Point(193, 91);
            comboCal.Name = "comboCal";
            comboCal.Size = new Size(145, 23);
            comboCal.TabIndex = 3;
            // 
            // lblCal
            // 
            lblCal.AutoSize = true;
            lblCal.Location = new Point(58, 94);
            lblCal.Name = "lblCal";
            lblCal.Size = new Size(129, 15);
            lblCal.TabIndex = 2;
            lblCal.Text = "Calibrator Lot Number:";
            // 
            // txtTooltrackLN
            // 
            txtTooltrackLN.Location = new Point(193, 62);
            txtTooltrackLN.Name = "txtTooltrackLN";
            txtTooltrackLN.Size = new Size(145, 23);
            txtTooltrackLN.TabIndex = 1;
            // 
            // lblToolTrackLotNumber
            // 
            lblToolTrackLotNumber.AutoSize = true;
            lblToolTrackLotNumber.Location = new Point(61, 65);
            lblToolTrackLotNumber.Name = "lblToolTrackLotNumber";
            lblToolTrackLotNumber.Size = new Size(126, 15);
            lblToolTrackLotNumber.TabIndex = 0;
            lblToolTrackLotNumber.Text = "Cartridge Lot Number:";
            // 
            // pagePassed
            // 
            pagePassed.BackColor = SystemColors.ControlDark;
            pagePassed.Controls.Add(lstLog);
            pagePassed.Controls.Add(btnCancel);
            pagePassed.Controls.Add(btnRun);
            pagePassed.Controls.Add(txtDestPath);
            pagePassed.Controls.Add(txtSourcePath);
            pagePassed.Controls.Add(lblDestPath);
            pagePassed.Controls.Add(lblSourcePath);
            pagePassed.Location = new Point(4, 28);
            pagePassed.Name = "pagePassed";
            pagePassed.Padding = new Padding(3);
            pagePassed.Size = new Size(742, 365);
            pagePassed.TabIndex = 2;
            pagePassed.Text = "   PIP";
            // 
            // lstLog
            // 
            lstLog.BackColor = SystemColors.ScrollBar;
            lstLog.FormattingEnabled = true;
            lstLog.ItemHeight = 15;
            lstLog.Location = new Point(6, 115);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(730, 244);
            lstLog.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DimGray;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.ButtonFace;
            btnCancel.Location = new Point(657, 77);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(79, 27);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnRun
            // 
            btnRun.BackColor = Color.SeaGreen;
            btnRun.FlatStyle = FlatStyle.Popup;
            btnRun.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRun.ForeColor = SystemColors.ButtonFace;
            btnRun.Location = new Point(568, 77);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(83, 27);
            btnRun.TabIndex = 4;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = false;
            btnRun.Click += btnRun_Click;
            // 
            // txtDestPath
            // 
            txtDestPath.Location = new Point(114, 48);
            txtDestPath.Name = "txtDestPath";
            txtDestPath.Size = new Size(622, 23);
            txtDestPath.TabIndex = 3;
            // 
            // txtSourcePath
            // 
            txtSourcePath.Location = new Point(114, 19);
            txtSourcePath.Name = "txtSourcePath";
            txtSourcePath.Size = new Size(622, 23);
            txtSourcePath.TabIndex = 2;
            // 
            // lblDestPath
            // 
            lblDestPath.AutoSize = true;
            lblDestPath.BackColor = Color.Transparent;
            lblDestPath.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDestPath.ForeColor = SystemColors.ActiveCaptionText;
            lblDestPath.Location = new Point(6, 51);
            lblDestPath.Name = "lblDestPath";
            lblDestPath.Size = new Size(102, 15);
            lblDestPath.TabIndex = 1;
            lblDestPath.Text = "Destination Path:";
            // 
            // lblSourcePath
            // 
            lblSourcePath.AutoSize = true;
            lblSourcePath.BackColor = Color.Transparent;
            lblSourcePath.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSourcePath.Location = new Point(31, 22);
            lblSourcePath.Name = "lblSourcePath";
            lblSourcePath.Size = new Size(77, 15);
            lblSourcePath.TabIndex = 0;
            lblSourcePath.Text = "Source Path:";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = SystemColors.WindowFrame;
            btnLogout.FlatStyle = FlatStyle.System;
            btnLogout.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = SystemColors.ButtonHighlight;
            btnLogout.Location = new Point(661, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(85, 28);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Sign out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // UserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(btnLogout);
            Controls.Add(tabUsers);
            Name = "UserControl";
            Size = new Size(750, 400);
            tabUsers.ResumeLayout(false);
            pageDownload.ResumeLayout(false);
            boxDownload.ResumeLayout(false);
            boxDownload.PerformLayout();
            pageTooltrack.ResumeLayout(false);
            boxTooltrack.ResumeLayout(false);
            boxTooltrack.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pagePassed.ResumeLayout(false);
            pagePassed.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabUsers;
        private TabPage pageDownload;
        private TabPage pageTooltrack;
        private TabPage pagePassed;
        private Button btnLogout;
        private GroupBox boxDownload;
        private TextBox txtLotNumber;
        private Label lblLotNumber;
        private Button btnDownload;
        private Label lblDownloadStatus;
        private GroupBox boxTooltrack;
        private Label lblQCLN;
        private ComboBox comboCal;
        private Label lblCal;
        private TextBox txtTooltrackLN;
        private Label lblToolTrackLotNumber;
        private Button btnAddQC;
        private Button btnAddCal;
        private ComboBox boxFailure;
        private Label lblFailType;
        private ComboBox boxStatus;
        private Label lblPassorFail;
        private ComboBox boxQC;
        private Button btnUpdateToolTrack;
        private Label lblToolTrackStatus;
        private ProgressBar downloadProgress;
        private CheckBox checkNS;
        private CheckBox checkTL;
        private CheckBox checkTest;
        private Panel panel1;
        private Label lblSourcePath;
        private Button btnRun;
        private TextBox txtDestPath;
        private TextBox txtSourcePath;
        private Label lblDestPath;
        private Button btnCancel;
        private ListBox lstLog;
    }
}
