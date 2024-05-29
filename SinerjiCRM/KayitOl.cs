using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace SinerjiCRM
{
    public partial class KayitOl : Form
    {
        public KayitOl()
        {
            InitializeComponent();
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string mail = txtMail.Text;
            string? sifre = txtSifre.Text;
            string? sifreTekrar = txtSifreTekrar.Text;

            if (sifre != sifreTekrar)
            {
                txtSifre.Clear();
                txtSifreTekrar.Clear();
                MessageBox.Show("Şifreler uyuşmamaktadır. Lütfen şifrenizi kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // E-posta adresinin daha önce kayıtlı olup olmadığını kontrol et
            if (IsEmailRegistered(mail))
            {
                MessageBox.Show("Bu e-posta adresi zaten kayıtlı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kullanıcıya doğrulama kodu gönder
            if (!string.IsNullOrEmpty(mail))
            {
                string dogrulamaKodu = GenerateRandomCode(); // Rastgele doğrulama kodu oluştur
                SendVerificationCode(mail, dogrulamaKodu); // Doğrulama kodunu e-posta ile gönder

                DateTime kodOlusturmaZamani = DateTime.Now;

                // Doğrulama kodu formunu aç
                Dogrula dogrulamaFormu = new Dogrula(dogrulamaKodu, kullaniciAdi, sifre, mail, kodOlusturmaZamani);
                dogrulamaFormu.Show();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir e-posta adresi girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {            
            this.Close();
        }
        private void KayitOl_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms?["Giris"]?.Show();
        }

        private void cbSifre_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbSifre.CheckState == CheckState.Checked)
            {
                txtSifre.UseSystemPasswordChar = false;
                txtSifreTekrar.UseSystemPasswordChar = false;
            }
            else
            {
                txtSifre.UseSystemPasswordChar = true;
                txtSifreTekrar.UseSystemPasswordChar = true;
            }
        }

        // Rastgele doğrulama kodu oluştur
        private string GenerateRandomCode()
        {
            Random rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

        // Doğrulama kodunu e-posta ile gönder
        private void SendVerificationCode(string email, string verificationCode)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("sinerjiacun@gmail.com"); // Gönderici e-posta adresi
                mail.To.Add(email); // Alıcı e-posta adresi
                mail.Subject = "Doğrulama Kodu";
                mail.Body = "Giriş için doğrulama kodunuz: " + verificationCode;

                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential("sinerjiacun@gmail.com", "olzl nuty kgic pawx"); // Gönderici e-posta adresi ve şifre
                smtpServer.EnableSsl = true;

                MessageBox.Show("Doğrulama kodu e-posta adresinize gönderildi.");
                smtpServer.Send(mail);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Doğrulama kodu gönderilirken bir hata oluştu: " + ex.Message);
            }
        }

        // E-posta adresinin daha önce kayıtlı olup olmadığını kontrol et
        private bool IsEmailRegistered(string email)
        {
            bool isRegistered = false;

            using (SqlConnection connection = new SQLBaglantisi().baglanti())
            {
                string query = "SELECT COUNT(*) FROM KULLANICI WHERE EMAIL = @mail";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@mail", email);
                    int count = (int)command.ExecuteScalar();
                    isRegistered = count > 0;
                }
            }

            return isRegistered;
        }
    }
}
