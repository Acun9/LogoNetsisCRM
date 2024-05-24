using C_Forms;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;


namespace SinerjiPanel
{
    public partial class CariKayit : Form
    {
        private static HttpClient client;
        private string token;

        public CariKayit()
        {
            InitializeComponent();            
        }

        private void CariKayit_Load(object sender, EventArgs e)
        {
            LoadComboboxData();            
        }

        private async Task InitializeNetOpenX()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://srv1/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Authentication
            var authResponse = await client.PostAsJsonAsync("api/authenticate", new { username = "netsis", password = "5091" });
            if (authResponse.IsSuccessStatusCode)
            {
                var authResultString = await authResponse.Content.ReadAsStringAsync();
                var authResult = JsonConvert.DeserializeObject<Dictionary<string, string>>(authResultString);
                token = authResult["token"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            else
            {
                MessageBox.Show("Kimlik doğrulama başarısız!");
            }
        }

        private async void btnAktar_Click(object sender, EventArgs e)
        {
            await InitializeNetOpenX();
            try
            {
                using (SqlConnection sourceConnection = new SqlConnection("Server=SRV1;Database=SINERJICRM;User Id=sa;Password=SA123pass_;"))
                {
                    sourceConnection.Open();
                    SqlCommand selectCommand = new SqlCommand("SELECT * FROM CARI_KAYIT", sourceConnection);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            await ProcessRecord(reader);
                        }
                    }
                }

                await DeleteRemovedRecords();
                MessageBox.Show("Veri aktarımı başarıyla tamamlandı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri aktarımı sırasında hata oluştu: {ex.Message}");
            }
        }

        private async Task ProcessRecord(SqlDataReader reader)
        {
            var cariData = new
            {
                CARI_KOD = reader["CARI_KOD"].ToString(),
                CARI_ISIM = reader["CARI_ISIM"].ToString(),
                ADRES = reader["ADRES"].ToString(),
                ULKE = reader["ULKE"].ToString(),
                IL = reader["IL"].ToString(),
                ILCE = reader["ILCE"].ToString(),
                POSTA_KODU = reader["POSTA_KODU"].ToString(),
                TEL = reader["TEL"].ToString(),
                FAKS = reader["FAKS"].ToString(),
                MAIL = reader["MAIL"].ToString(),
                WEB = reader["WEB"].ToString(),
                VERGI_DAIRE = reader["VERGI_DAIRE"].ToString(),
                VERGI_NO = reader["VERGI_NO"].ToString(),
                GRUP_KODU = reader["GRUP_KODU"].ToString(),
                RAPOR_KODU_1 = reader["RAPOR_KODU_1"].ToString(),
                RAPOR_KODU_2 = reader["RAPOR_KODU_2"].ToString(),
                SUBE_KODU = 0,
                ISLETME_KODU = 1
            };

            var response = await client.PostAsJsonAsync("api/cari", cariData);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show($"Cari kaydı eklenirken hata oluştu: {response.ReasonPhrase}");
            }
        }

        private async Task DeleteRemovedRecords()
        {
            var response = await client.DeleteAsync("api/cari/sync");
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show($"Silme işlemi sırasında hata oluştu: {response.ReasonPhrase}");
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            // Kullanıcı girişlerini al
            string cariKod = txtCariKod.Text;
            string cariIsım = txtCariIsim.Text;
            string adres = txtAdres.Text;
            string ulke = cmbUlke.SelectedItem?.ToString() ?? string.Empty;
            string il = cmbIl.SelectedItem?.ToString() ?? string.Empty;
            string ilce = cmbIlce.SelectedItem?.ToString() ?? string.Empty;
            string postaKodu = cmbPostaKodu.SelectedItem?.ToString() ?? string.Empty;
            string tel = txtTelefon.Text;
            string faks = txtFaks.Text;
            string mail = txtMail.Text;
            string web = txtWeb.Text;
            string vergiDaire = cmbVergiDairesi.SelectedItem?.ToString() ?? string.Empty;
            string vergiNo = txtVergiNo.Text;
            string grupKodu = cmbGrupKodu.SelectedItem?.ToString() ?? string.Empty;
            string raporKodu1 = cmbRaporKodu1.SelectedItem?.ToString() ?? string.Empty;
            string raporKodu2 = cmbRaporKodu2.SelectedItem?.ToString() ?? string.Empty;

            using (SqlConnection connection = new SQLBaglantisi().baglanti())
            {
                // CARI_KOD zaten var mı kontrolü
                string queryCheck = "SELECT COUNT(*) FROM dbo.CARI_KAYIT WHERE CARI_KOD = @CARI_KOD";
                using (SqlCommand commandCheck = new SqlCommand(queryCheck, connection))
                {
                    commandCheck.Parameters.AddWithValue("@CARI_KOD", cariKod);
                    int count = (int)commandCheck.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Bu Cari Kod zaten mevcut. Güncelleme yapmak istiyorsanız 'Güncelle' butonunu kullanın. ");
                        return;
                    }
                }

                // Yeni kayıt ekleme
                string queryInsert = @"INSERT INTO dbo.CARI_KAYIT 
                               (CARI_KOD, CARI_ISIM, ADRES, ULKE, IL, ILCE, POSTA_KODU, TEL, FAKS, MAIL, WEB, VERGI_DAIRE, VERGI_NO, GRUP_KODU, RAPOR_KODU_1, RAPOR_KODU_2) 
                               VALUES (@CARI_KOD, @CARI_ISIM, @ADRES, @ULKE, @IL, @ILCE, @POSTA_KODU, @TEL, @FAKS, @MAIL, @WEB, @VERGI_DAIRE, @VERGI_NO, @GRUP_KODU, @RAPOR_KODU_1, @RAPOR_KODU_2)";

                using (SqlCommand commandInsert = new SqlCommand(queryInsert, connection))
                {
                    // Parametreleri ekle
                    commandInsert.Parameters.AddWithValue("@CARI_KOD", cariKod);
                    commandInsert.Parameters.AddWithValue("@CARI_ISIM", cariIsım);
                    commandInsert.Parameters.AddWithValue("@ADRES", adres);
                    commandInsert.Parameters.AddWithValue("@ULKE", ulke);
                    commandInsert.Parameters.AddWithValue("@IL", il);
                    commandInsert.Parameters.AddWithValue("@ILCE", ilce);
                    commandInsert.Parameters.AddWithValue("@POSTA_KODU", postaKodu);
                    commandInsert.Parameters.AddWithValue("@TEL", tel);
                    commandInsert.Parameters.AddWithValue("@FAKS", faks);
                    commandInsert.Parameters.AddWithValue("@MAIL", mail);
                    commandInsert.Parameters.AddWithValue("@WEB", web);
                    commandInsert.Parameters.AddWithValue("@VERGI_DAIRE", vergiDaire);
                    commandInsert.Parameters.AddWithValue("@VERGI_NO", vergiNo);
                    commandInsert.Parameters.AddWithValue("@GRUP_KODU", grupKodu);
                    commandInsert.Parameters.AddWithValue("@RAPOR_KODU_1", raporKodu1);
                    commandInsert.Parameters.AddWithValue("@RAPOR_KODU_2", raporKodu2);

                    int rowsAffected = commandInsert.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Veriler başarıyla kaydedildi.");
                    }
                    else
                    {
                        MessageBox.Show("Veriler kaydedilirken bir hata oluştu.");
                    }
                }
            }
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string cariKod = txtCariKod.Text;
            string cariIsım = txtCariIsim.Text;
            string adres = txtAdres.Text;
            string ulke = cmbUlke.SelectedItem?.ToString() ?? string.Empty;
            string il = cmbIl.SelectedItem?.ToString() ?? string.Empty;
            string ilce = cmbIlce.SelectedItem?.ToString() ?? string.Empty;
            string postaKodu = cmbPostaKodu.SelectedItem?.ToString() ?? string.Empty;
            string tel = txtTelefon.Text;
            string faks = txtFaks.Text;
            string mail = txtMail.Text;
            string web = txtWeb.Text;
            string vergiDaire = cmbVergiDairesi.SelectedItem?.ToString() ?? string.Empty;
            string vergiNo = txtVergiNo.Text;
            string grupKodu = cmbGrupKodu.SelectedItem?.ToString() ?? string.Empty;
            string raporKodu1 = cmbRaporKodu1.SelectedItem?.ToString() ?? string.Empty;
            string raporKodu2 = cmbRaporKodu2.SelectedItem?.ToString() ?? string.Empty;

            using (SqlConnection connection = new SQLBaglantisi().baglanti())
            {
                string queryUpdate = @"UPDATE dbo.CARI_KAYIT SET 
                               CARI_ISIM = @CARI_ISIM,
                               ADRES = @ADRES,
                               ULKE = @ULKE,
                               IL = @IL,
                               ILCE = @ILCE,
                               POSTA_KODU = @POSTA_KODU,
                               TEL = @TEL,
                               FAKS = @FAKS,
                               MAIL = @MAIL,
                               WEB = @WEB,
                               VERGI_DAIRE = @VERGI_DAIRE,
                               VERGI_NO = @VERGI_NO,
                               GRUP_KODU = @GRUP_KODU,
                               RAPOR_KODU_1 = @RAPOR_KODU_1,
                               RAPOR_KODU_2 = @RAPOR_KODU_2
                               WHERE CARI_KOD = @CARI_KOD";

                using (SqlCommand commandUpdate = new SqlCommand(queryUpdate, connection))
                {
                    commandUpdate.Parameters.AddWithValue("@CARI_KOD", cariKod);
                    commandUpdate.Parameters.AddWithValue("@CARI_ISIM", cariIsım);
                    commandUpdate.Parameters.AddWithValue("@ADRES", adres);
                    commandUpdate.Parameters.AddWithValue("@ULKE", ulke);
                    commandUpdate.Parameters.AddWithValue("@IL", il);
                    commandUpdate.Parameters.AddWithValue("@ILCE", ilce);
                    commandUpdate.Parameters.AddWithValue("@POSTA_KODU", postaKodu);
                    commandUpdate.Parameters.AddWithValue("@TEL", tel);
                    commandUpdate.Parameters.AddWithValue("@FAKS", faks);
                    commandUpdate.Parameters.AddWithValue("@MAIL", mail);
                    commandUpdate.Parameters.AddWithValue("@WEB", web);
                    commandUpdate.Parameters.AddWithValue("@VERGI_DAIRE", vergiDaire);
                    commandUpdate.Parameters.AddWithValue("@VERGI_NO", vergiNo);
                    commandUpdate.Parameters.AddWithValue("@GRUP_KODU", grupKodu);
                    commandUpdate.Parameters.AddWithValue("@RAPOR_KODU_1", raporKodu1);
                    commandUpdate.Parameters.AddWithValue("@RAPOR_KODU_2", raporKodu2);

                    int rowsAffected = commandUpdate.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Veriler güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("Veriler güncellenirken bir hata oluştu.");
                    }
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SQLBaglantisi().baglanti())
            {
                string queryDelete = "DELETE FROM dbo.CARI_KAYIT WHERE CARI_KOD = @CARI_KOD";

                using (SqlCommand commandDelete = new SqlCommand(queryDelete, connection))
                {
                    commandDelete.Parameters.AddWithValue("@CARI_KOD", txtCariKod.Text);

                    int rowsAffected = commandDelete.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Veri başarıyla silindi.");
                    }
                    else
                    {
                        MessageBox.Show("Veri silinirken bir hata oluştu.");
                    }
                }
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadComboboxData()
        {
            LoadUlkeler();
            LoadIller();
            LoadGrupKodlari();
            LoadRaporKodlari();
            LoadPostaKodlari();
        }

        private void LoadUlkeler()
        {
            cmbUlke.Items.Add("TR");
            cmbUlke.Items.Add("EN");
        }

        private void LoadIller()
        {
            using (SqlConnection connection = new SQLBaglantisi().baglanti())
            {
                string query = "SELECT id, sehiradi FROM iller";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbIl.Items.Add(reader["sehiradi"].ToString());
                    }
                }
            }
        }

        private void LoadIlceler(int sehirId)
        {
            cmbIlce.Items.Clear();

            using (SqlConnection connection = new SQLBaglantisi().baglanti())
            {
                string query = "SELECT id, ilceadi FROM ilceler WHERE sehirid = @sehirid";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sehirid", sehirId);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbIlce.Items.Add(reader["ilceadi"].ToString());
                    }
                }
            }
        }

        private void LoadGrupKodlari()
        {
            // Grup kodlarını yükleyecek kod
            cmbGrupKodu.Items.Add("grpkod");
        }

        private void LoadRaporKodlari()
        {
            // Rapor kodlarını yükleyecek kod
            cmbRaporKodu1.Items.Add("rprkod1");
            cmbRaporKodu2.Items.Add("rprkod2");
        }

        private void LoadPostaKodlari()
        {
            cmbPostaKodu.Items.Add("pstkod");
        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIl.SelectedItem != null)
            {
                string sehirAdi = cmbIl.SelectedItem.ToString();
                int sehirId;

                using (SqlConnection connection = new SQLBaglantisi().baglanti())
                {
                    string query = "SELECT id FROM iller WHERE sehiradi = @sehiradi";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@sehiradi", sehirAdi);
                        object result = command.ExecuteScalar();
                        sehirId = result != null ? (int)result : -1;
                    }
                }

                if (sehirId != -1)
                {
                    LoadIlceler(sehirId);
                }
                else
                {
                    cmbIlce.Items.Clear();
                }
            }
        }
    }
}
