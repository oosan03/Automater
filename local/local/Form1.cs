using local.UserControls;

namespace local
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            LoadPage(new LoginControl(this));
        }

        public void LoadPage(System.Windows.Forms.UserControl page)
        {
            mainPanel.Controls.Clear();
            page.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(page);

            Icon = new Icon("assets/molecule.ico");

             
        }
    }
}
