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
    public partial class AdminControl : System.Windows.Forms.UserControl
    {

        private mainForm _mainForm;
        private LoginControl _loginControl;
        public AdminControl(mainForm MainForm, LoginControl loginControl)
        {
            InitializeComponent();
            _mainForm = MainForm;
            _loginControl = loginControl;

            string[] users = FileUtility.GetAllUsers();
            boxUsers.Items.Clear();
            boxUsers.Items.AddRange(users);

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _mainForm.LoadPage(_loginControl);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string? username = boxUsers.SelectedItem?.ToString();
            if (username == null)
            {
                MessageBox.Show("Error: no user selected.");
                return;
            }

            // Find and set user folder
            FileUtility.SetCurrentUser(username);
            string? userFolder = FileUtility.FindUser();

            User user = new User();
            EditUserForm editUserForm = new EditUserForm(user);
            editUserForm.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditUserForm editUserForm = new EditUserForm();
            editUserForm.ShowDialog();

        }
    }
}
