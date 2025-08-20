using local.Models;
using local.Models.Utilities;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace local.UserControls
{
    public partial class UserControl : System.Windows.Forms.UserControl
    {
        private mainForm _mainForm;
        private LoginControl _loginControl;
        private User _user;
        private string _lotNumber;

        List<string> calNumbers = new List<string> { "018425" };
        List<string> qcNumbers = new List<string> { "018495" };
        public UserControl(mainForm mainForm, LoginControl loginControl, User user)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _loginControl = loginControl;
            _user = user;
            initializeLotnumbers(null, null);
            downloadProgress.Visible = false;
        }
        private void displayLotnumbers(List<string> calNumbers, List<string> qcNumbers)
        {
            comboCal.Items.Clear();
            boxQC.Items.Clear();
            boxFailure.Items.Clear();
            boxStatus.Items.Clear();

            string[] failureModes = { "Lot Pass", "Precision", "QC Accuracy", "Cal Accuracy", "P-Value", "PC/EC", };
            string[] pass = { "Pass", "Fail" };

            comboCal.Items.AddRange(calNumbers.ToArray());
            boxQC.Items.AddRange(qcNumbers.ToArray());
            boxFailure.Items.AddRange(failureModes);
            boxStatus.Items.AddRange(pass);

            comboCal.SelectedIndex = 0;
            boxQC.SelectedIndex = 0;

        }
        private void initializeLotnumbers(string calNumber, string qcNumber)
        {
            if (calNumber != null)
            {
                calNumbers.Insert(0, calNumber);
            }
            if (qcNumber != null)
            {
                qcNumbers.Insert(0, qcNumber);
            }

            displayLotnumbers(calNumbers, qcNumbers);
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            _mainForm.LoadPage(new LoginControl(_mainForm));
        }
        private async void btnDownload_Click(object sender, EventArgs e)
        {
            lblDownloadStatus.Text = String.Empty;

            bool validLotNumber = false;
            bool createdFolder = false;

            DownloadFiles df = new DownloadFiles(_user);
            string lotNumber = df.lotNumberValidation(txtLotNumber.Text, ref validLotNumber);

            // If lot number was invalid, show error message and exit
            if (validLotNumber == false)
            {
                lblDownloadStatus.Text = "Error: invalid lot number.";
                return;
            }

            // Continue if valid lot number
            // Ensure user has GA credentials loaded; show error messae if false and exit
            _lotNumber = lotNumber;
            if (!_user.GrandavenueExists)
            {
                lblDownloadStatus.Text = "Error: user does not have Grand Avenue credentials";
                return;
            }
            try
            {
                // Continue if credentials loaded
                btnDownload.Enabled = false;

                downloadProgress.Visible = true;
                downloadProgress.Style = ProgressBarStyle.Marquee;


                // Create folder and assign download path
                string lotFolder = createLotFolder(lotNumber, ref createdFolder);
                if (!createdFolder) { MessageBox.Show("Could not create folder in Network Drive, continuing download locally"); }
                df.download_path = lotFolder;

                lblDownloadStatus.Text = $"Downloading {lotNumber} documents...";
                lblDownloadStatus.ForeColor = Color.MediumBlue;

                bool success = await df.RunDownloadAsync(lotNumber);
                if (success)
                {
                    lblDownloadStatus.Text = "Download success";
                    lblDownloadStatus.ForeColor = Color.Green;
                    df.RenameFolders(lotFolder, lotNumber);
                    txtTooltrackLN.Text = lotNumber;
                }
                else
                {
                    lblDownloadStatus.Text = "Download failed";
                    lblDownloadStatus.ForeColor = Color.Maroon;
                }

                downloadProgress.Visible = false;

                btnDownload.Enabled = true;
            }
            catch (Exception ex)
            {
                lblDownloadStatus.Text = ex.Message;
                lblDownloadStatus.ForeColor = Color.Maroon;
                downloadProgress.Visible = false;
                btnDownload.Enabled = true;
            }

        }
        private string createLotFolder(string lotNumber, ref bool createdFolder)
        {

            //for testing; remove
            bool isTest = false;

            if (checkTest.Checked)
            {
                isTest = true;
            }

            if (isTest)
            {
                string path = "C:\\Users\\OSan.MBIO\\OneDrive - MBio Diagnostics\\Desktop\\Data\\Test";
                Directory.CreateDirectory(path);
                return path;
            }


            string product_code = lotNumber.Substring(0, 2).ToUpper();
            string folder_path = "T:\\1 - QUALITY\\Quality Records\\Inspection Records\\QC Data";
            createdFolder = true;
            try
            {
                string today = DateTime.Today.ToString("yyyyMMdd");
                string year = DateTime.Now.Year.ToString();

                if (product_code == "HT")
                {
                    bool autoT4 = false;
                    DialogResult result = MessageBox.Show(this,
                        "Is this a T4 Auto lot?",
                        "Confirmation",

                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                        );
                    if (result == DialogResult.Yes) { autoT4 = true; }
                    else { autoT4 = false; }

                    if (autoT4 == true)
                    {
                        folder_path += "\\WI-7000-013 HT - T4 Cartridge QC\\Auto\\" + today;
                    }
                    else
                    {
                        folder_path += "\\WI-7000-013 HT - T4 Cartridge QC\\Semi-auto\\" + today;
                    }

                }
                else if (product_code == "HC")
                {
                    folder_path += "\\WI-7000-010 HC - Cortisol Cartridge QC\\" + today;
                }
                else if (product_code == "HP")
                {
                    folder_path += "\\WI-7000-011 HP - Progesterone Cartridge QC\\" + today;
                }
                else if (product_code == "HS")
                {
                    folder_path += "\\WI-7000-012 HS - cTSH Cartridge QC\\" + today;
                }
                else if (product_code == "HR")
                {
                    folder_path += "\\WI-7000-026 cCRP Cartridge Lot QC and Calibration Procedure\\" + today;
                }
                else if (product_code == "HN")
                {
                    folder_path += $"\\WI-7000-0XX Nu. Q Cartridge QC\\{year}\\{today}";
                }
                else
                {
                    folder_path = "C:\\Downloads\\ " + lotNumber;

                }

                folder_path += "_" + lotNumber;
                Directory.CreateDirectory(folder_path);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred: {ex}");
            }

            return folder_path;
        }
        private async void btnUpdateToolTrack_Click(object sender, EventArgs e)
        {

            lblToolTrackStatus.Text = String.Empty;
            lblToolTrackStatus.ForeColor = Color.Maroon;

            string? lotNumber = lotNumberValidation(txtTooltrackLN.Text);
            string? calibrator = sampleLotValidation(comboCal.SelectedItem?.ToString());
            string? qc = sampleLotValidation(boxQC.SelectedItem?.ToString());
            string? pass = boxStatus.SelectedItem?.ToString();
            string? failure = boxFailure.SelectedItem?.ToString();

            if (lotNumber == "false")
            {
                lblToolTrackStatus.Text = "Error: Lot number invalid";
                return;
            }

            if (checkTL.Checked)
            {
                if (lotNumber == "" | calibrator == null | qc == null | pass == null | failure == null) { lblToolTrackStatus.Text = "Error: missing fields."; return; }

                btnUpdateToolTrack.Enabled = false;

                UpdateTooltrack tl = new UpdateTooltrack(_user);
                try
                {
                    lblToolTrackStatus.ForeColor = Color.MediumBlue;
                    lblToolTrackStatus.Text = "Completing ToolTrack route...";
                    bool updatedTooltrack = await tl.UpdateToolTrackStatus(lotNumber, calibrator, qc, pass, failure);
                    if (updatedTooltrack)
                    {
                        lblToolTrackStatus.ForeColor = Color.Green;
                        lblToolTrackStatus.Text = "Successfully completed ToolTrack route";
                    }

                }
                catch (TimeoutException ex)
                {
                    lblToolTrackStatus.Text = ex.Message;
                    btnUpdateToolTrack.Enabled = true;
                    return;
                }
            }

            if (checkNS.Checked)
            {
                UpdateNetsuite ns = new UpdateNetsuite(_user);
                try
                {
                    lblToolTrackStatus.ForeColor = Color.MediumBlue;
                    lblToolTrackStatus.Text = "Updating NetSuite status...";
                    bool updatedNS = await ns.UpdateNetsuiteStatus(lotNumber);
                    if (updatedNS)
                    {
                        lblToolTrackStatus.ForeColor = Color.White;
                        lblToolTrackStatus.Text = "My job here is done, complete the rest. 😏 🗝";
                    }
                }
                catch (Exception ex)
                {
                    lblToolTrackStatus.Text = ex.Message;
                    btnUpdateToolTrack.Enabled = true;
                    return;
                }
            }

            if (!checkTL.Checked & !checkNS.Checked)
            {
                lblToolTrackStatus.Text = "No operation selected.";
            }

            btnUpdateToolTrack.Enabled = true;
        }
        public string lotNumberValidation(string lotNumber)
        {
            string pattern = @"^(HT|HR|HS|HC|HN|HP)-\d{5}$";
            string validatedLotNumber = lotNumber.Trim().Replace(" ", "").ToUpper();

            bool isMatch = Regex.IsMatch(validatedLotNumber, pattern);

            if (!isMatch)
            {
                return "false";
            }
            else
            {
                return validatedLotNumber;
            }

        }
        public string sampleLotValidation(string lotNumber)
        {
            if (lotNumber == null) { return "false"; }

            string pattern = @"^\d{5}";
            string validatedLotNumber = lotNumber.Trim().Replace(" ", "");

            bool isMatch = Regex.IsMatch(validatedLotNumber, pattern);

            if (!isMatch)
            {
                return "false";
            }
            else
            {
                return validatedLotNumber;
            }

        }
        private void btnAddCal_Click(object sender, EventArgs e)
        {
            AddDialog ad = new AddDialog(this, "AddCal");
            var result = ad.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                string calibratorLN = ad.lotNumber;
                // Run code to populate calibrator combo box
                initializeLotnumbers(calibratorLN, null);
            }
        }
        private void btnAddQC_Click(object sender, EventArgs e)
        {
            AddDialog ad = new AddDialog(this, "AddQC");
            var result = ad.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                string qcLN = ad.lotNumber;
                // Run code to populate qc lot number combo box
                initializeLotnumbers(null, qcLN);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (tabUsers.SelectedTab == pageDownload)
                {
                    btnDownload.PerformClick();
                }
                else if (tabUsers.SelectedTab == pageTooltrack)
                {
                    btnUpdateToolTrack.PerformClick();
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private CancellationTokenSource? _cts;
        private async void btnRun_Click(object sender, EventArgs e)
        {
            _cts = new CancellationTokenSource();
            btnRun.Enabled = false;

            var sourceRoot = txtSourcePath.Text;   // e.g., a TextBox on your form
            var destRoot = txtDestPath.Text;

            var log = new Progress<string>(msg =>
            {
                lstLog.Items.Add(ShrinkLogMessage.ShortenAnyPaths(msg, keepSegments: 3));
            });



            try
            {
                await LightdeckFileUtils.RunAsync(sourceRoot, destRoot, log, _cts.Token);
            }
            catch (OperationCanceledException)
            {
                lstLog.Items.Add("Canceled.");
            }
            finally
            {
                btnRun.Enabled = true;
                _cts = null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
        }
    }
}
