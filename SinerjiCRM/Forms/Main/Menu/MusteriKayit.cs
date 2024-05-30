
namespace SinerjiCRM
{
    public partial class MusteriKayit : Form
    {
        string? kullaniciAdi;
        public MusteriKayit()
        {
            InitializeComponent();
            
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MusteriKayit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms?["SinerjiCRM"]?.Show();
        }
    }
}
