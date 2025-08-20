using local.Models;
using Microsoft.VisualBasic.ApplicationServices;

namespace local
{
    public partial class EditUserForm : Form
    {

        private local.Models.User _user;
        private bool existingUser = false;

        public EditUserForm()
        {
            InitializeComponent();

            txtAutomaterPass.UseSystemPasswordChar = true;
            txtToolTrackPass.UseSystemPasswordChar = true;
            txtGrandAvenuePass.UseSystemPasswordChar = true;
            txtNetSuitePass.UseSystemPasswordChar = true;

        }
        public EditUserForm(local.Models.User user): this()
        {
            existingUser = true;
            _user = user;

            txtAutomaterUser.Text = _user.GetAppUsername();
            txtAutomaterPass.Text = _user.GetAppPassword();

            txtToolTrackUser.Text = _user.GetTooltrackUsername();
            txtToolTrackPass.Text = _user.GetTooltrackPassword();

            txtGrandAvenueUser.Text = _user.GetGrandavenueUsername();
            txtGrandAvenuePass.Text = _user.GetGrandavenuePassword();

            txtNetSuiteUser.Text = _user.GetNetsuiteUsername();
            txtNetSuitePass.Text = _user.GetNetsuitePassword();
            // All app usernames not editable
            txtAutomaterUser.Enabled = false;
            if (_user.GetAppUsername() == "admin")
            {
                txtToolTrackPass.Enabled = false;
                txtToolTrackUser.Enabled = false;
                txtGrandAvenuePass.Enabled = false;
                txtGrandAvenueUser.Enabled = false;
                txtNetSuitePass.Enabled = false;
                txtNetSuiteUser.Enabled = false;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            return;
        }

        private void lblShowAutomater_Click(object sender, EventArgs e)
        {
            if (txtAutomaterPass.UseSystemPasswordChar == false)
            {
                txtAutomaterPass.UseSystemPasswordChar = true;
            }
            else
            {
                txtAutomaterPass.UseSystemPasswordChar = false;
            }
        }

        private void lblShowTL_Click(object sender, EventArgs e)
        {
            if (txtToolTrackPass.UseSystemPasswordChar == false)
            {
                txtToolTrackPass.UseSystemPasswordChar = true;
            }
            else
            {
                txtToolTrackPass.UseSystemPasswordChar = false;
            }
        }

        private void lblShowGA_Click(object sender, EventArgs e)
        {
            if (txtGrandAvenuePass.UseSystemPasswordChar == false)
            {
                txtGrandAvenuePass.UseSystemPasswordChar = true;
            }
            else
            {
                txtGrandAvenuePass.UseSystemPasswordChar = false;
            }
        }

        private void lblShowNS_Click(object sender, EventArgs e)
        {
            if (txtNetSuitePass.UseSystemPasswordChar == false)
            {
                txtNetSuitePass.UseSystemPasswordChar = true;
            }
            else
            {
                txtNetSuitePass.UseSystemPasswordChar = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (existingUser)
            {
                if (_user.GetAppUsername() == "admin")
                {
                    // Update admin password
                    FileUtility.CreateUser(_user.GetAppUsername(), txtAutomaterPass.Text.Trim(), true);
                    Close();
                    return;
                }

                if (txtAutomaterUser.Text == "" | txtAutomaterPass.Text == "" | txtToolTrackUser.Text == "" | txtToolTrackPass.Text == "" | txtGrandAvenueUser.Text == "" | txtGrandAvenuePass.Text == "" | txtNetSuiteUser.Text == "" | txtNetSuitePass.Text == "")
                {
                    MessageBox.Show("Error: one or more fields empty");
                    return;
                }

                // Update app password
                FileUtility.CreateUser(_user.GetAppUsername(), txtAutomaterPass.Text.Trim(), true);

                // Update ToolTrack username and password
                FileUtility.SetToolTrack(txtToolTrackUser.Text.Trim(), txtToolTrackPass.Text.Trim());

                // Update Grand Avenue username and password
                FileUtility.SetGrandAvenue(txtGrandAvenueUser.Text.Trim(), txtGrandAvenuePass.Text.Trim());

                // Update NetSuite username and password
                FileUtility.SetNetsuite(txtNetSuiteUser.Text.Trim(), txtNetSuitePass.Text.Trim());

                Close();
                return;
            }

            else
            {
                // Check if username folder exists already


                // 
            }
        }
    }
}
