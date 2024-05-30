using System.Data.SqlClient;
using NetOpenX.Rest.Client.BLL;
using NetOpenX.Rest.Client.Model.NetOpenX;
using NetOpenX.Rest.Client.Model;
using NetOpenX.Rest.Client;
using System.Data;
using SinerjiCRM.Scripts;

namespace SinerjiCRM
{
    public partial class CariKayit : Form
    {

        public CariKayit()
        {
            InitializeComponent();
        }

        private void CariKayit_Load(object sender, EventArgs e)
        {
            LoadComboboxData();
        }

        private void btnEkleGuncelle_Click(object sender, EventArgs e)
        {
            // Girişlerin kontrolü
            if (!ValidateInputs())
            {
                return;
            }

            // Girişleri al
            var cariData = GetCariData();

            using (SqlConnection connection = new SQLBaglantisi().baglanti())
            {
                // CARI_KOD zaten var mı kontrolü
                string queryCheck = "SELECT COUNT(*) FROM dbo.CARI_KAYIT WHERE CARI_KOD = @CARI_KOD";
                using (SqlCommand commandCheck = new SqlCommand(queryCheck, connection))
                {
                    commandCheck.Parameters.AddWithValue("@CARI_KOD", cariData.Kod);
                    int count = (int)commandCheck.ExecuteScalar();

                    if (count > 0)
                    {
                        // Kayıt varsa güncelleme yap
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
                       VERGI_TC_NO = @VERGI_TC_NO,
                       GRUP_KODU = @GRUP_KODU,
                       RAPOR_KODU_1 = @RAPOR_KODU_1,
                       RAPOR_KODU_2 = @RAPOR_KODU_2,
                       RAPOR_KODU_3 = @RAPOR_KODU_3
                       WHERE CARI_KOD = @CARI_KOD";

                        using (SqlCommand commandUpdate = new SqlCommand(queryUpdate, connection))
                        {
                            // Parametreleri ekle
                            AddParametersToCommand(commandUpdate, cariData);

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
                    else
                    {
                        // Kayıt yoksa yeni kayıt ekle
                        string queryInsert = @"INSERT INTO dbo.CARI_KAYIT 
                       (CARI_KOD, CARI_ISIM, ADRES, ULKE, IL, ILCE, POSTA_KODU, TEL, FAKS, MAIL, WEB, VERGI_DAIRE, VERGI_TC_NO, GRUP_KODU, RAPOR_KODU_1, RAPOR_KODU_2, RAPOR_KODU_3) 
                       VALUES (@CARI_KOD, @CARI_ISIM, @ADRES, @ULKE, @IL, @ILCE, @POSTA_KODU, @TEL, @FAKS, @MAIL, @WEB, @VERGI_DAIRE, @VERGI_TC_NO, @GRUP_KODU, @RAPOR_KODU_1, @RAPOR_KODU_2, @RAPOR_KODU_3)";

                        using (SqlCommand commandInsert = new SqlCommand(queryInsert, connection))
                        {
                            // Parametreleri ekle
                            AddParametersToCommand(commandInsert, cariData);

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
        private void CariKayit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms?["SinerjiCRM"]?.Show();
        }

        // Stringdeki boşluğa kadar olan kısmı al
        private string GetStringUntilSpace(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty; // Eğer input boş veya null ise boş string döner
            }

            int spaceIndex = input.IndexOf(' ');
            if (spaceIndex == -1)
            {
                return input; // Eğer boşluk karakteri yoksa tüm string döner
            }

            return input.Substring(0, spaceIndex); // Boşluk karakterine kadar olan kısmı döner
        }

        //Kullanıcı girişlerini kontrol et
        private bool ValidateInputs()
        {
            //Cari Kod kontrolü
            if (string.IsNullOrWhiteSpace(txtCariKod.Text))
            {
                MessageBox.Show("Lütfen Cari Kod girin.");
                return false;
            }

            // Vergi/T.C. numarası kontrolü           
            if (rbVergi.Checked)
            {
                if (txtVergiTCNo.Text.Length != 10 || !long.TryParse(txtVergiTCNo.Text, out _))
                {
                    MessageBox.Show("Lütfen rakamlardan oluşan 10 haneli geçerli bir Vergi No giriniz.");
                    return false;
                }
            }
            else if (rbTC.Checked)
            {
                if (txtVergiTCNo.Text.Length != 11 || !long.TryParse(txtVergiTCNo.Text, out _))
                {
                    MessageBox.Show("Lütfen rakamlardan oluşan 11 haneli geçerli bir T.C. No giriniz.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Lütfen Vergi / T.C. No belirtiniz.");
                return false;
            }

            return true;
        }

        // Kullanıcı girişlerini al
        private Data GetCariData()
        {
            return new Data
            {
                Kod = txtCariKod.Text,
                Isim = txtCariIsim.Text,
                Adres = txtAdres.Text,
                Ulke = cmbUlke.SelectedItem?.ToString() ?? string.Empty,
                Il = cmbIl.SelectedItem?.ToString() ?? string.Empty,
                Ilce = cmbIlce.SelectedItem?.ToString() ?? string.Empty,
                PostaKodu = cmbPostaKodu.SelectedItem?.ToString() ?? string.Empty,
                Tel = txtTelefon.Text,
                Faks = txtFaks.Text,
                Mail = txtMail.Text,
                Web = txtWeb.Text,
                VergiDaire = cmbVergiDairesi.SelectedItem?.ToString() ?? string.Empty,
                VergiTCNo = txtVergiTCNo.Text,
                GrupKodu = cmbGrupKodu.SelectedItem?.ToString() ?? string.Empty,
                RaporKodu1 = cmbRaporKodu1.SelectedItem?.ToString() ?? string.Empty,
                RaporKodu2 = cmbRaporKodu2.SelectedItem?.ToString() ?? string.Empty,
                RaporKodu3 = cmbRaporKodu3?.SelectedItem?.ToString() ?? string.Empty
            };
        }

        // Parametreleri ekle
        private void AddParametersToCommand(SqlCommand command, Data satinAlmaTalepData)
        {
            command.Parameters.AddWithValue("@CARI_KOD", satinAlmaTalepData.Kod);
            command.Parameters.AddWithValue("@CARI_ISIM", satinAlmaTalepData.Isim);
            command.Parameters.AddWithValue("@ADRES", satinAlmaTalepData.Adres);
            command.Parameters.AddWithValue("@ULKE", satinAlmaTalepData.Ulke);
            command.Parameters.AddWithValue("@IL", satinAlmaTalepData.Il);
            command.Parameters.AddWithValue("@ILCE", satinAlmaTalepData.Ilce);
            command.Parameters.AddWithValue("@POSTA_KODU", satinAlmaTalepData.PostaKodu);
            command.Parameters.AddWithValue("@TEL", satinAlmaTalepData.Tel);
            command.Parameters.AddWithValue("@FAKS", satinAlmaTalepData.Faks);
            command.Parameters.AddWithValue("@MAIL", satinAlmaTalepData.Mail);
            command.Parameters.AddWithValue("@WEB", satinAlmaTalepData.Web);
            command.Parameters.AddWithValue("@VERGI_DAIRE", satinAlmaTalepData.VergiDaire);
            command.Parameters.AddWithValue("@VERGI_TC_NO", satinAlmaTalepData.VergiTCNo);
            command.Parameters.AddWithValue("@GRUP_KODU", GetStringUntilSpace(satinAlmaTalepData.GrupKodu));
            command.Parameters.AddWithValue("@RAPOR_KODU_1", GetStringUntilSpace(satinAlmaTalepData.RaporKodu1));
            command.Parameters.AddWithValue("@RAPOR_KODU_2", GetStringUntilSpace(satinAlmaTalepData.RaporKodu2));
            command.Parameters.AddWithValue("@RAPOR_KODU_3", GetStringUntilSpace(satinAlmaTalepData.RaporKodu3));
        }

        private void LoadComboboxData()
        {
            LoadUlkeler();
            LoadIller();
            LoadGrupKodlari();
            LoadRaporKodu1();
            LoadRaporKodu2();
            LoadRaporKodu3();
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

        /* ====================================================================== [ NetOpenX REST API ] ====================================================================== */

        private void btnAktar_Click(object sender, EventArgs e)
        {
            try
            {
                // NetOpenX-REST için OAuth2 ile kimlik doğrulama
                oAuth2 _oAuth2 = new oAuth2("http://srv1:7070");
                _oAuth2.Login(new JLogin()
                {
                    BranchCode = 0,
                    NetsisUser = "netsis",
                    NetsisPassword = "5091",
                    DbType = JNVTTipi.vtMSSQL,
                    DbName = "SINERJISMART",
                    DbPassword = "",
                    DbUser = "TEMELSET"
                });

                // Kaynak veritabanından verileri çekme
                string selectQuery = "SELECT * FROM CARI_KAYIT";
                List<ARPsPrimInfo> cariler = new List<ARPsPrimInfo>();

                using (SqlConnection sourceConnection = new SqlConnection("Server=SRV1;Database=SINERJICRM;User Id=sa;Password=SA123pass_;"))
                {
                    sourceConnection.Open();
                    SqlCommand selectCommand = new SqlCommand(selectQuery, sourceConnection);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ARPsPrimInfo cariTmlBlg = new ARPsPrimInfo
                            {
                                CARI_KOD = reader["CARI_KOD"].ToString(),
                                CARI_ISIM = reader["CARI_ISIM"].ToString(),
                                CARI_ADRES = reader["ADRES"].ToString(),
                                ULKE_KODU = reader["ULKE"].ToString(),
                                CARI_IL = reader["IL"].ToString(),
                                CARI_ILCE = reader["ILCE"].ToString(),
                                POSTAKODU = reader["POSTA_KODU"].ToString(),
                                CARI_TEL = reader["TEL"].ToString(),
                                FAX = reader["FAKS"].ToString(),
                                EMAIL = reader["MAIL"].ToString(),
                                WEB = reader["WEB"].ToString(),
                                VERGI_DAIRESI = reader["VERGI_DAIRE"].ToString(),
                                VERGI_NUMARASI = reader["VERGI_TC_NO"].ToString(),
                                Grup_Kodu = reader["GRUP_KODU"].ToString(),
                                RAPOR_KODU1 = reader["RAPOR_KODU_1"].ToString(),
                                Rapor_Kodu2 = reader["RAPOR_KODU_2"].ToString(),

                                //Zorunlular
                                Sube_Kodu = 0, // Varsayılan değer
                                ISLETME_KODU = 1, // Varsayılan değer
                                CARI_TIP = "A"

                            };
                            cariler.Add(cariTmlBlg);
                        }
                    }
                }

                // Hedef veritabanına verileri aktarma
                var _ARPsManager = new ARPsManager(_oAuth2);
                foreach (var cari in cariler)
                {
                    var existingRecordResult = _ARPsManager.GetInternalById(cari.CARI_KOD);
                    if (existingRecordResult.IsSuccessful && existingRecordResult.Data != null)
                    {
                        // Kayıt mevcutsa güncelle
                        var result = _ARPsManager.PutInternal(cari.CARI_KOD, new ARPs()
                        {
                            CariTemelBilgi = cari
                        });

                        if (!result.IsSuccessful)
                        {
                            throw new Exception($"Cari kodu {cari.CARI_KOD} olan kaydın güncellenmesi başarısız: {result.ErrorDesc}");
                        }
                    }
                    else
                    {
                        // Kayıt mevcut değilse yeni kayıt oluştur
                        var result = _ARPsManager.PostInternal(new ARPs()
                        {
                            CariTemelBilgi = cari
                        });

                        if (!result.IsSuccessful)
                        {
                            throw new Exception($"Cari kodu {cari.CARI_KOD} olan kaydın oluşturulması başarısız: {result.ErrorDesc}");
                        }
                    }
                }

                // Hedef veritabanından fazladan kayıtları silme
                var existingRecordsResult = _ARPsManager.GetInternal();
                if (existingRecordsResult.IsSuccessful)
                {
                    var existingRecords = existingRecordsResult.Data;
                    var sourceCariKodlar = new HashSet<string>(cariler.Select(c => c.CARI_KOD));

                    foreach (var record in existingRecords)
                    {
                        if (!sourceCariKodlar.Contains(record.CariTemelBilgi.CARI_KOD))
                        {
                            var deleteResult = _ARPsManager.DeleteInternalById(record.CariTemelBilgi.CARI_KOD);
                            if (!deleteResult.IsSuccessful)
                            {
                                throw new Exception($"Cari kodu {record.CariTemelBilgi.CARI_KOD} olan kaydın silinmesi başarısız: {deleteResult.ErrorDesc}");
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception($"Mevcut kayıtların alınması başarısız: {existingRecordsResult.ErrorDesc}");
                }

                MessageBox.Show("Veri aktarımı başarıyla tamamlandı.");
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Veri aktarımı sırasında hata oluştu: {ex.Message}");
            }
        }

        private void LoadGrupKodlari()
        {
            try
            {
                // NetOpenX-REST için OAuth2 ile kimlik doğrulama
                oAuth2 _oAuth2 = new oAuth2("http://srv1:7070");
                _oAuth2.Login(new JLogin()
                {
                    BranchCode = 0,
                    NetsisUser = "netsis",
                    NetsisPassword = "5091",
                    DbType = JNVTTipi.vtMSSQL,
                    DbName = "SINERJISMART",
                    DbPassword = "",
                    DbUser = "TEMELSET"
                });

                // Verileri çekmek için gerekli API isteği
                //string selectQuery = "SELECT GRUP_KOD, GRUP_ISIM FROM TBLCAGRUP";
                string selectQuery = "SELECT GRUP_KOD, GRUP_ISIM, dbo.TRK(GRUP_KOD) AS TRK_GRUP_KOD, dbo.TRK(GRUP_ISIM) AS TRK_GRUP_ISIM FROM TBLCAGRUP";

                using (SqlConnection sourceConnection = new SqlConnection("Server=SRV1;Database=SINERJISMART;User Id=sa;Password=SA123pass_;"))
                {
                    sourceConnection.Open();
                    SqlCommand selectCommand = new SqlCommand(selectQuery, sourceConnection);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //string grupKod = reader["GRUP_KOD"].ToString();
                            //string grupIsim = reader["GRUP_ISIM"].ToString();

                            string grupKod = reader["TRK_GRUP_KOD"].ToString();
                            string grupIsim = reader["TRK_GRUP_ISIM"].ToString();

                            string combinedText = $"{grupKod} ({grupIsim})";
                            cmbGrupKodu.Items.Add(combinedText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri çekme sırasında hata oluştu: {ex.Message}");
            }
        }

        private void LoadRaporKodu1()
        {
            try
            {
                // NetOpenX-REST için OAuth2 ile kimlik doğrulama
                oAuth2 _oAuth2 = new oAuth2("http://srv1:7070");
                _oAuth2.Login(new JLogin()
                {
                    BranchCode = 0,
                    NetsisUser = "netsis",
                    NetsisPassword = "5091",
                    DbType = JNVTTipi.vtMSSQL,
                    DbName = "SINERJISMART",
                    DbPassword = "",
                    DbUser = "TEMELSET"
                });

                // Verileri çekmek için gerekli API isteği                
                string selectQuery = "SELECT GRUP_KOD, GRUP_ISIM, dbo.TRK(GRUP_KOD) AS TRK_GRUP_KOD, dbo.TRK(GRUP_ISIM) AS TRK_GRUP_ISIM FROM TBLCARIKOD1";

                using (SqlConnection sourceConnection = new SqlConnection("Server=SRV1;Database=SINERJISMART;User Id=sa;Password=SA123pass_;"))
                {
                    sourceConnection.Open();
                    SqlCommand selectCommand = new SqlCommand(selectQuery, sourceConnection);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string grupKod = reader["TRK_GRUP_KOD"].ToString();
                            string grupIsim = reader["TRK_GRUP_ISIM"].ToString();

                            string combinedText = $"{grupKod} ({grupIsim})";
                            cmbRaporKodu1.Items.Add(combinedText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri çekme sırasında hata oluştu: {ex.Message}");
            }
        }

        private void LoadRaporKodu2()
        {
            try
            {
                // NetOpenX-REST için OAuth2 ile kimlik doğrulama
                oAuth2 _oAuth2 = new oAuth2("http://srv1:7070");
                _oAuth2.Login(new JLogin()
                {
                    BranchCode = 0,
                    NetsisUser = "netsis",
                    NetsisPassword = "5091",
                    DbType = JNVTTipi.vtMSSQL,
                    DbName = "SINERJISMART",
                    DbPassword = "",
                    DbUser = "TEMELSET"
                });

                // Verileri çekmek için gerekli API isteği                
                string selectQuery = "SELECT GRUP_KOD, GRUP_ISIM, dbo.TRK(GRUP_KOD) AS TRK_GRUP_KOD, dbo.TRK(GRUP_ISIM) AS TRK_GRUP_ISIM FROM TBLCARIKOD2";

                using (SqlConnection sourceConnection = new SqlConnection("Server=SRV1;Database=SINERJISMART;User Id=sa;Password=SA123pass_;"))
                {
                    sourceConnection.Open();
                    SqlCommand selectCommand = new SqlCommand(selectQuery, sourceConnection);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string grupKod = reader["TRK_GRUP_KOD"].ToString();
                            string grupIsim = reader["TRK_GRUP_ISIM"].ToString();

                            string combinedText = $"{grupKod} ({grupIsim})";
                            cmbRaporKodu2.Items.Add(combinedText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri çekme sırasında hata oluştu: {ex.Message}");
            }
        }

        private void LoadRaporKodu3()
        {
            try
            {
                // NetOpenX-REST için OAuth2 ile kimlik doğrulama
                oAuth2 _oAuth2 = new oAuth2("http://srv1:7070");
                _oAuth2.Login(new JLogin()
                {
                    BranchCode = 0,
                    NetsisUser = "netsis",
                    NetsisPassword = "5091",
                    DbType = JNVTTipi.vtMSSQL,
                    DbName = "SINERJISMART",
                    DbPassword = "",
                    DbUser = "TEMELSET"
                });

                // Verileri çekmek için gerekli API isteği                
                string selectQuery = "SELECT GRUP_KOD, GRUP_ISIM, dbo.TRK(GRUP_KOD) AS TRK_GRUP_KOD, dbo.TRK(GRUP_ISIM) AS TRK_GRUP_ISIM FROM TBLCARIKOD3";

                using (SqlConnection sourceConnection = new SqlConnection("Server=SRV1;Database=SINERJISMART;User Id=sa;Password=SA123pass_;"))
                {
                    sourceConnection.Open();
                    SqlCommand selectCommand = new SqlCommand(selectQuery, sourceConnection);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string grupKod = reader["TRK_GRUP_KOD"].ToString();
                            string grupIsim = reader["TRK_GRUP_ISIM"].ToString();

                            string combinedText = $"{grupKod} ({grupIsim})";
                            cmbRaporKodu3.Items.Add(combinedText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri çekme sırasında hata oluştu: {ex.Message}");
            }
        }        
    }
}
