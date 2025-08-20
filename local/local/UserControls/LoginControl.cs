using local.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace local.UserControls
{
    public partial class LoginControl : System.Windows.Forms.UserControl
    {

        private mainForm _mainForm;
        public LoginControl(mainForm mainForm)
        {
            InitializeComponent();
            txtPin.PasswordChar = '*';
            _mainForm = mainForm;

            logoPicture.SizeMode = PictureBoxSizeMode.Zoom;
            Icon icon = new Icon("assets/molecule.ico"); // Use your correct path
            Bitmap bmp = icon.ToBitmap();
            logoPicture.Image = bmp; // pictureBox1 is a PictureBox you placed on your form

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //// Set tooltrack credentials
            //FileUtility.SetCurrentUser(txtUsername.Text.Trim().ToLower());
            //FileUtility.FindUser();
            //// ToolTrack Currently
            //FileUtility.SetToolTrack("osan", txtPin.Text);

            // Create user in login page
            //FileUtility.CreateUser(txtUsername.Text, txtPin.Text);

            // Find user folder
            FileUtility.SetCurrentUser(txtUsername.Text.Trim().ToLower());
            string? userFolder = FileUtility.FindUser();
            // If use folder doesn't exist
            if (userFolder == null | txtUsername.Text == "")
            {
                lblStatusLogin.Text = "Erorr: user not found.";
                return;
            }


            // Validate user pin
            if (FileUtility.ValidUserPin(txtPin.Text.Trim().ToLower()) == false)
            {
                lblStatusLogin.Text = "Error: invalid pin.";
                return;
            }



            // Found user folder and pin valid
            // Admin login
            if (txtUsername.Text == "admin")
            {
                _mainForm.LoadPage(new AdminControl(_mainForm, new LoginControl(_mainForm)));
                return;
            }

            // All other users
            User user = new User();
            _mainForm.LoadPage(new UserControl(_mainForm, this, user));


        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnLogin.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        // Easter egg that shows message when username label is clicked
        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do not click on the label!!!");
        }


    }
}
