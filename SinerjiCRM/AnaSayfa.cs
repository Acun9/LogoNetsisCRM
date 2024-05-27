using System.Data;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace Sinerji
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string? kullaniciAdi = txtKullaniciAdi.Text; // Kullanıcı adı textbox'ından alınabilir
            string? girilenSifre = txtSifre.Text;
            
            // E-posta adresini ve şifreyi veritabanından al
            string? kullaniciMail = "";
            string? dogruSifre = "";
            using (SqlConnection connection = new SQLBaglantisi().baglanti())
            {
                string query = "SELECT KULLANICI_MAIL, SIFRE FROM KULLANICI WHERE KULLANICI_ADISOYADI = @kullaniciAdi";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi); 
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {                        
                        kullaniciMail = reader["KULLANICI_MAIL"].ToString();
                        dogruSifre = reader["SIFRE"].ToString() ;                        
                    }
                }
            }

            // Şifre doğrulaması yap
            if (!string.IsNullOrEmpty(dogruSifre) && girilenSifre == dogruSifre)
            {
                // Kullanıcıya doğrulama kodu gönder
                if (!string.IsNullOrEmpty(kullaniciMail))
                {
                    string dogrulamaKodu = GenerateRandomCode(); // Rastgele doğrulama kodu oluştur
                    SendVerificationCode(kullaniciMail, dogrulamaKodu); // Doğrulama kodunu e-posta ile gönder

                    txtKullaniciAdi.Clear();
                    txtSifre.Clear();
                    cbSifre.Checked = false;

                    // Doğrulama kodu formunu aç
                    DogrulamaKodu dogrulamaFormu = new DogrulamaKodu(dogrulamaKodu, kullaniciAdi);
                    dogrulamaFormu.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı bulunamadı veya e-posta adresi kayıtlı değil.");
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
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

                smtpServer.Send(mail);
                MessageBox.Show("Doğrulama kodu e-posta adresinize gönderildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doğrulama kodu gönderilirken bir hata oluştu: " + ex.Message);
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSifre_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbSifre.CheckState == CheckState.Checked)
            {
                txtSifre.UseSystemPasswordChar = false;
            }
            else
            {
                txtSifre.UseSystemPasswordChar = true;
            }
        }
    }
}
