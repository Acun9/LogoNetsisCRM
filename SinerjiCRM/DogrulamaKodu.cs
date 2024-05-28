
namespace SinerjiCRM
{
    public partial class DogrulamaKodu : Form
    {
        private string? dogrulamaKodu;
        private string kullaniciAdi;

        public DogrulamaKodu(string kod, string kullaniciAdi)
        {
            InitializeComponent();
            dogrulamaKodu = kod;
            this.kullaniciAdi = kullaniciAdi;
        }

        private void btnDogrula_Click(object sender, EventArgs e)
        {
            string girilenKod = txtDogrulamaKodu.Text;
            if (girilenKod == dogrulamaKodu)
            {
                MessageBox.Show("Doğrulama başarılı!");                

                //Eğer admin giriyorsa admin panelini plasiyer giriyorsa müşteri kayıt panelini aç
                if (kullaniciAdi == "admin")
                {
                    AdminPanel adminPanelForm = new AdminPanel(kullaniciAdi);
                    adminPanelForm.Show();
                }
                else
                {
                    MusteriKayit musteriKayitForm = new MusteriKayit(kullaniciAdi);
                    musteriKayitForm.Show();
                }

                this.Close(); // Mevcut formu kapat
                Application.OpenForms?["AnaSayfa"]?.Hide(); // AnaSayfa formunu gizle
            }
            else
            {
                MessageBox.Show("Girilen doğrulama kodu yanlış. Lütfen tekrar deneyin.");
            }
        }
    }
}