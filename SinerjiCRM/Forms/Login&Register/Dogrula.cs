using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SinerjiCRM.Scripts;

namespace SinerjiCRM
{
    public partial class Dogrula : Form
    {
        private string? dogrulamaKodu;
        private string kullaniciAdi;
        private string sifre;
        private string mail;
        private DateTime kodOlusturmaZamani;        

        public Dogrula(string kod, string kullaniciAdi, string sifre, string mail, DateTime kodOlusturmaZamani)
        {
            InitializeComponent();
            dogrulamaKodu = kod;
            this.kullaniciAdi = kullaniciAdi;
            this.sifre = sifre;
            this.mail = mail;
            this.kodOlusturmaZamani = kodOlusturmaZamani;            
        }

        private void btnDogrula_Click(object sender, EventArgs e)
        {
            string girilenKod = txtDogrulamaKodu.Text;
            TimeSpan fark = DateTime.Now - kodOlusturmaZamani;

            if (fark.TotalMinutes > 2) // Kodun süresini 10 dakika olarak belirleyebilirsiniz.
            {
                MessageBox.Show("Doğrulama kodunun süresi doldu. Lütfen yeniden giriş yapın.");
                // Giriş formuna geri dön veya başka bir işlem yap.
                this.Close();
                return;
            }

            if (girilenKod == dogrulamaKodu)
            {
                MessageBox.Show("Doğrulama başarılı!");                                
                KayitOlVeritabaninaKaydet(kullaniciAdi, sifre, mail); // Kullanıcıyı veritabanına kaydet                
                SinerjiCRM sinerjiCRMForm = new SinerjiCRM();
                sinerjiCRMForm.Show();
                Application.OpenForms?["Giris"]?.Hide(); // Giris formunu gizle
                this.Close(); // Mevcut formu kapat
                
            }
            else
            {
                MessageBox.Show("Girilen doğrulama kodu yanlış. Lütfen tekrar deneyin.");
            }
        }

        // Kullanıcıyı veritabanına kaydet
        private void KayitOlVeritabaninaKaydet(string kullaniciAdi, string sifre, string mail)
        {
            using (SqlConnection connection = new SQLBaglantisi().baglanti())
            {
                string query = "INSERT INTO KULLANICI (KULLANICI_ADI, SIFRE, EMAIL) VALUES (@kullaniciAdi, @sifre, @mail)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    command.Parameters.AddWithValue("@sifre", sifre);
                    command.Parameters.AddWithValue("@mail", mail);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
