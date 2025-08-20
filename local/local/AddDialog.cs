using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace local
{
    public partial class AddDialog : Form
    {
        private UserControl _userControl;
        public string lotNumber;
        public AddDialog(UserControl userControl, string context)
        {
            InitializeComponent();
            _userControl = userControl;
            if (context == "AddCal")
            {
                Text = "Add New Calbrator Lot Number";
                lblData.Text = "Enter New Cal LN:";
            }
            else
            {
                Text = "Add New QC Lot Number";
                lblData.Text = "Enter New QC LN:";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            lotNumber = txtLotNumber.Text.Trim();
            if (!Regex.IsMatch(lotNumber, @"^\d{6}$"))
            {
                lblInvalidLot.Text = "Error: invalid lot number.";
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnSave.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
