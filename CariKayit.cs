using C_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinerjiPanel
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

        private void btnAktar_Click(object sender, EventArgs e)
        {
            string sourceConnectionString = "Server=DIJITALOFIS1\\NETSIS;Database=NETSISTEST1;User Id=sa;Password=SA123pass_;";
            string destinationConnectionString = "Server=DIJITALOFIS1\\NETSIS;Database=SINERJI2024TEST;User Id=sa;Password=SA123pass_;";

            using (SqlConnection sourceConnection = new SqlConnection(sourceConnectionString))
            {
                sourceConnection.Open();
                string selectQuery = "SELECT * FROM CARI_KAYIT";
                SqlCommand selectCommand = new SqlCommand(selectQuery, sourceConnection);

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    using (SqlConnection destinationConnection = new SqlConnection(destinationConnectionString))
                    {
                        destinationConnection.Open();

                        while (reader.Read())
                        {
                            string mergeQuery = @"
                        MERGE INTO [SINERJI2024TEST].[dbo].[TBLCASABIT] AS Target
                        USING (SELECT @CARI_KOD AS CARI_KOD,
                                      @CARI_ISIM AS CARI_ISIM,
                                      @CARI_ADRES AS CARI_ADRES,
                                      @ULKE_KODU AS ULKE_KODU,
                                      @CARI_IL AS CARI_IL,
                                      @CARI_ILCE AS CARI_ILCE,
                                      @POSTAKODU AS POSTAKODU,
                                      @CARI_TEL AS CARI_TEL,
                                      @FAX AS FAX,
                                      @EMAIL AS EMAIL,
                                      @WEB AS WEB,
                                      @VERGI_DAIRESI AS VERGI_DAIRESI,
                                      @VERGI_NUMARASI AS VERGI_NUMARASI,
                                      @GRUP_KODU AS GRUP_KODU,
                                      @RAPOR_KODU1 AS RAPOR_KODU1,
                                      @RAPOR_KODU2 AS RAPOR_KODU2,
                                      @SUBE_KODU AS SUBE_KODU,
                                      @ISLETME_KODU AS ISLETME_KODU) AS Source
                        ON Target.CARI_KOD = Source.CARI_KOD
                        WHEN MATCHED THEN
                            UPDATE SET CARI_ISIM = Source.CARI_ISIM,
                                       CARI_ADRES = Source.CARI_ADRES,
                                       ULKE_KODU = Source.ULKE_KODU,
                                       CARI_IL = Source.CARI_IL,
                                       CARI_ILCE = Source.CARI_ILCE,
                                       POSTAKODU = Source.POSTAKODU,
                                       CARI_TEL = Source.CARI_TEL,
                                       FAX = Source.FAX,
                                       EMAIL = Source.EMAIL,
                                       WEB = Source.WEB,
                                       VERGI_DAIRESI = Source.VERGI_DAIRESI,
                                       VERGI_NUMARASI = Source.VERGI_NUMARASI,
                                       GRUP_KODU = Source.GRUP_KODU,
                                       RAPOR_KODU1 = Source.RAPOR_KODU1,
                                       RAPOR_KODU2 = Source.RAPOR_KODU2,
                                       SUBE_KODU = Source.SUBE_KODU,
                                       ISLETME_KODU = Source.ISLETME_KODU
                        WHEN NOT MATCHED THEN
                            INSERT (CARI_KOD, CARI_ISIM, CARI_ADRES, ULKE_KODU, CARI_IL, CARI_ILCE, POSTAKODU, CARI_TEL, FAX, EMAIL, WEB, VERGI_DAIRESI, VERGI_NUMARASI, GRUP_KODU, RAPOR_KODU1, RAPOR_KODU2, SUBE_KODU, ISLETME_KODU)
                            VALUES (Source.CARI_KOD, Source.CARI_ISIM, Source.CARI_ADRES, Source.ULKE_KODU, Source.CARI_IL, Source.CARI_ILCE, Source.POSTAKODU, Source.CARI_TEL, Source.FAX, Source.EMAIL, Source.WEB, Source.VERGI_DAIRESI, Source.VERGI_NUMARASI, Source.GRUP_KODU, Source.RAPOR_KODU1, Source.RAPOR_KODU2, Source.SUBE_KODU, Source.ISLETME_KODU);";

                            SqlCommand mergeCommand = new SqlCommand(mergeQuery, destinationConnection);

                            mergeCommand.Parameters.AddWithValue("@CARI_KOD", reader["CARI_KOD"]);
                            mergeCommand.Parameters.AddWithValue("@CARI_ISIM", reader["CARI_ISIM"]);
                            mergeCommand.Parameters.AddWithValue("@CARI_ADRES", reader["ADRES"]);
                            mergeCommand.Parameters.AddWithValue("@ULKE_KODU", reader["ULKE"]);
                            mergeCommand.Parameters.AddWithValue("@CARI_IL", reader["IL"]);
                            mergeCommand.Parameters.AddWithValue("@CARI_ILCE", reader["ILCE"]);
                            mergeCommand.Parameters.AddWithValue("@POSTAKODU", reader["POSTA_KODU"]);
                            mergeCommand.Parameters.AddWithValue("@CARI_TEL", reader["TEL"]);
                            mergeCommand.Parameters.AddWithValue("@FAX", reader["FAKS"]);
                            mergeCommand.Parameters.AddWithValue("@EMAIL", reader["MAIL"]);
                            mergeCommand.Parameters.AddWithValue("@WEB", reader["WEB"]);
                            mergeCommand.Parameters.AddWithValue("@VERGI_DAIRESI", reader["VERGI_DAIRE"]);
                            mergeCommand.Parameters.AddWithValue("@VERGI_NUMARASI", reader["VERGI_NO"]);
                            mergeCommand.Parameters.AddWithValue("@GRUP_KODU", reader["GRUP_KODU"]);
                            mergeCommand.Parameters.AddWithValue("@RAPOR_KODU1", reader["RAPOR_KODU_1"]);
                            mergeCommand.Parameters.AddWithValue("@RAPOR_KODU2", reader["RAPOR_KODU_2"]);
                            mergeCommand.Parameters.AddWithValue("@SUBE_KODU", "0"); // Varsayılan değer.
                            mergeCommand.Parameters.AddWithValue("@ISLETME_KODU", "1"); // Varsayılan değer.

                            mergeCommand.ExecuteNonQuery();
                        }

                        // Kaynak tablodan silinmiş olan kayıtları hedef tablodan sil
                        string deleteQuery = @"
                    DELETE FROM [SINERJI2024TEST].[dbo].[TBLCASABIT]
                    WHERE CARI_KOD NOT IN (SELECT CARI_KOD FROM [NETSISTEST1].[dbo].[CARI_KAYIT])";

                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, destinationConnection);
                        deleteCommand.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Veri aktarımı başarıyla tamamlandı.");
        }
    }
}
