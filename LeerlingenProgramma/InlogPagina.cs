using System.Windows.Forms;

namespace LeerlingenProgramma
{
    public partial class InlogPagina : Form
    {
        Database DB = new Database();
        Keuzemenu KeuzeMenu = new Keuzemenu();
        public InlogPagina()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, System.EventArgs e)
        {
            if (DB.LoginControle(tbUsername.Text, tbPassword.Text))
            {
                KeuzeMenu.ShowDialog();
            }
        }
    }
    public class AlgemeneGegevens
    {
        public string User { get; set; }
        public string Klas { get; set; }
    }
}