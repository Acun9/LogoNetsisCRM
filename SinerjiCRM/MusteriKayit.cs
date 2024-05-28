
namespace SinerjiCRM
{
    public partial class MusteriKayit : Form
    {
        string? kullaniciAdi;
        public MusteriKayit(string kullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MusteriKayit_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (kullaniciAdi == "admin")
            {
                Application.OpenForms?["AdminPanel"]?.Show();
            }
            else
            {
                Application.OpenForms?["AnaSayfa"]?.Show();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
