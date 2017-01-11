using System.Windows.Forms;

namespace LeerlingenProgramma
{
    public partial class InlogPagina : Form
    {
        Database DB = new Database();
        LeerlingenBestand Leerlingenkant = new LeerlingenBestand();
        public InlogPagina()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, System.EventArgs e)
        {
            if (DB.LoginControle(tbUsername.Text, tbPassword.Text))
            {
                Hide();
                switch (CheckRole(tbUsername.Text))
                {
                    default:
                        MessageBox.Show("fail");
                        break;
                    case 1:
                        Leerlingenkant.ShowDialog();
                        break;

                    case 2:
                        MessageBox.Show("Leraar");
                        break;
                }
                Show();
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }

        public int CheckRole(string Username)
        {
            var Result = DB.ReadRolID(Username);
            return Result.RolID;
        }
    }
    public class AlgemeneGegevens
    {
        public string User { get; set; }
        public string Klas { get; set; }
        public int RolID { get; set; }
    }
}