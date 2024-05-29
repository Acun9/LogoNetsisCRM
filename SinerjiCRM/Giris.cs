using System.Data;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace SinerjiCRM
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string? kullaniciAdi = txtKullaniciAdi.Text; // Kullanıcı adı textbox'ından alınabilir
            string? girilenSifre = txtSifre.Text;

            // Şifreyi veritabanından al
            string? dogruSifre = "";
            using (SqlConnection connection = new SQLBaglantisi().baglanti())
            {
                string query = "SELECT SIFRE FROM KULLANICI WHERE KULLANICI_ADI = @kullaniciAdi";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        dogruSifre = reader["SIFRE"].ToString();
                    }
                }
            }

            // Şifre doğrulaması yap
            if (!string.IsNullOrEmpty(dogruSifre) && girilenSifre == dogruSifre)
            {
                // Giriş başarılı, ana uygulama formunu aç
                SinerjiCRM sinerjiCRMForm = new SinerjiCRM();
                sinerjiCRMForm.Show();
                txtKullaniciAdi.Clear();
                txtSifre.Clear();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
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

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            // KayitOl formunu aç
            KayitOl kayitOlForm = new KayitOl();
            kayitOlForm.Show();
            this.Hide();
        }

        private void btnGiris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGiris_Click(sender, e); // Enter tuşuna basıldığında giriş işlemini gerçekleştir
            }
        }        
    }
}
