using System.Data.SqlClient;
using NetOpenX.Rest.Client.BLL;
using NetOpenX.Rest.Client.Model.NetOpenX;
using NetOpenX.Rest.Client.Model;
using NetOpenX.Rest.Client;
using System.Data;
using SinerjiCRM.Scripts;
using System.Windows.Forms;
using NetOpenX.Rest.Client.Model.Enums;
using System.Data.Common;

namespace SinerjiCRM
{
    public partial class SatisTeklif : Form
    {
        public SatisTeklif()
        {
            InitializeComponent();
        }

        private void SatinAlmaTalep_Load(object sender, EventArgs e)
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
            var teklifMasData = GetTeklifMasData();

            using (SqlConnection connection = new SQLBaglantisi().baglanti())
            {
                // TEKLIF_NO zaten var mı kontrolü
                string queryCheck = "SELECT COUNT(*) FROM dbo.TEKLIFMAS WHERE TEKLIF_NO = @TEKLIF_NO";
                using (SqlCommand commandCheck = new SqlCommand(queryCheck, connection))
                {
                    commandCheck.Parameters.AddWithValue("@TEKLIF_NO", teklifMasData.No);
                    int count = (int)commandCheck.ExecuteScalar();

                    if (count > 0)
                    {
                        // Kayıt varsa güncelleme yap
                        string queryUpdate = @"UPDATE dbo.TEKLIFMAS SET                        
                       CARI_KOD = @CARI_KOD,
                       TARIH = @TARIH,
                       DOVIZ_BAZ_TARIHI = @DOVIZ_BAZ_TARIHI,
                       YURT_ICI_DISI = @YURT_ICI_DISI,
                       TEKLIF_DURUMU = @TEKLIF_DURUMU,
                       FIRMA_TEMSILCISI = @FIRMA_TEMSILCISI,
                       SATIS_MUHENDISI = @SATIS_MUHENDISI,
                       ITHALAT_IHRACAT_TIPI = @ITHALAT_IHRACAT_TIPI,
                       NOT_1 = @NOT_1,
                       NOT_2 = @NOT_2,
                       NOT_3 = @NOT_3,
                       NOT_4 = @NOT_4,
                       ISTENEN_OZELLIKLER = @ISTENEN_OZELLIKLER,
                       NAKLIYE_SARTI = @NAKLIYE_SARTI,
                       ACIKLAMA = @ACIKLAMA,
                       ODEME_SARTI = @ODEME_SARTI,
                       GECERLILIK = @GECERLILIK,
                       PAKETLEME = @PAKETLEME,
                       HAZIRLAYAN = @HAZIRLAYAN,
                       BRUT_TOPLAM = @BRUT_TOPLAM,
                       KDV_TOPLAMI = @KDV_TOPLAMI,
                       GENEL_TOPLAM = @GENEL_TOPLAM,
                       VADE_TARIHI = @VADE_TARIHI,
                       VADE_GUNU = @VADE_GUNU,
                       WHERE TEKLIF_NO = @TEKLIF_NO";

                        using (SqlCommand commandUpdate = new SqlCommand(queryUpdate, connection))
                        {
                            // Parametreleri ekle
                            AddParametersToCommandMas(commandUpdate, teklifMasData);

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
                        string queryInsert = @"INSERT INTO dbo.TEKLIFMAS 
                       (TEKLIF_NO, CARI_KOD, TARIH, DOVIZ_BAZ_TARIHI, YURT_ICI_DISI, TEKLIF_DURUMU, FIRMA_TEMSILCISI, SATIS_MUHENDISI, ITHALAT_IHRACAT_TIPI, NOT_1, NOT_2, NOT_3, NOT_4, ISTENEN_OZELLIKLER, NAKLIYE_SARTI, ACIKLAMA, ODEME_SARTLARI, GECERLILIK, PAKETLEME, HAZIRLAYAN, BRUT_TOPLAM, KDV_ORANI, KDV_TOPLAMI, GENEL_TOPLAM, VADE_TARIHI, VADE_GUNU) 
                       VALUES (@TEKLIF_NO, @CARI_KOD, @TARIH, @DOVIZ_BAZ_TARIHI, @YURT_ICI_DISI, @TEKLIF_DURUMU, @FIRMA_TEMSILCISI, @SATIS_MUHENDISI, @ITHALAT_IHRACAT_TIPI, @NOT_1, @NOT_2, @NOT_3, @NOT_4, @ISTENEN_OZELLIKLER, @NAKLIYE_SARTI, @ACIKLAMA, @ODEME_SARTLARI, @GECERLILIK, @PAKETLEME, @HAZIRLAYAN, @BRUT_TOPLAM, @KDV_ORANI, @KDV_TOPLAMI, @GENEL_TOPLAM, @VADE_TARIHI, @VADE_GUNU)";

                        using (SqlCommand commandInsert = new SqlCommand(queryInsert, connection))
                        {
                            // Parametreleri ekle
                            AddParametersToCommandMas(commandInsert, teklifMasData);

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
                string queryDelete = "DELETE FROM dbo.TEKLIFMAS WHERE TEKLIF_NO = @TEKLIF_NO";

                using (SqlCommand commandDelete = new SqlCommand(queryDelete, connection))
                {
                    commandDelete.Parameters.AddWithValue("@TEKLIF_NO", txtNo.Text);

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
        private void SatinAlmaTalep_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms?["SinerjiCRM"]?.Show();
        }

        //Kullanıcı girişlerini kontrol et
        private bool ValidateInputs()
        {
            return true;
        }

        //Comboboxları doldur
        private void LoadComboboxData()
        {

        }

        // Kullanıcı girişlerini al (Mas)
        private Data GetTeklifMasData()
        {
            return new Data
            {
                Kod = txtKod.Text,
                No = txtNo.Text,
                Tarih = txtTarih.Text,
                DovizBazTarihi = txtDovizBazTarihi.Text,
                YurtIciDisi = GetSelectedYurtIciDisi(),
                TeklifDurumu = txtTeklifDurumu.Text,
                FirmaTemsilcisi = txtFirmaTemsilcisi.Text,
                SatisMuhendisi = txtSatisMuhendisi.Text,
                IthalatIhracatTipi = cmbIthalatIhracat.SelectedItem?.ToString() ?? string.Empty,
                Not1 = txtNot1.Text,
                Not2 = txtNot2.Text,
                Not3 = txtNot3.Text,
                Not4 = txtNot4.Text,
                IstenenOzellikler = txtIstenenOzellikler.Text,
                NakliyeSarti = txtNakliyeSarti.Text,
                Aciklama = txtAciklama.Text,
                OdemeSartlari = txtOdemeSartlari.Text,
                Gecerlilik = txtGecerlilik.Text,
                Paketleme = txtPaketleme.Text,
                Hazirlayan = txtHazirlayan.Text,
                BrutToplam = txtBrutToplam.Text,
                KdvOrani = txtKdvOrani.Text,
                KdvToplami = txtKdvToplami.Text,
                GenelToplam = txtGenelToplam.Text,
                VadeTarihi = txtVadeTarihi.Text,
                VadeGunu = txtVadeGunu.Text,
            };

            string GetSelectedYurtIciDisi()
            {
                if (rbYurtIci.Checked)
                {
                    return "YURT ICI";
                }
                else if (rbYurtDisi.Checked)
                {
                    return "YURT DİSİ";
                }
                else
                {
                    return string.Empty; // Hiçbir şey seçilmediyse
                }
            }
        }

        // Parametreleri ekle (Mas)
        private void AddParametersToCommandMas(SqlCommand command, Data teklifMasData)
        {
            command.Parameters.AddWithValue("@CARI_KOD", teklifMasData.Kod);
            command.Parameters.AddWithValue("@TEKLIF_NO", teklifMasData.No);
            command.Parameters.AddWithValue("@TARIH", teklifMasData.Tarih);
            command.Parameters.AddWithValue("@DOVIZ_BAZ_TARIHI", teklifMasData.DovizBazTarihi);
            command.Parameters.AddWithValue("@YURT_ICI_DISI", teklifMasData.YurtIciDisi);
            command.Parameters.AddWithValue("@TEKLIF_DURUMU", teklifMasData.TeklifDurumu);
            command.Parameters.AddWithValue("@FIRMA_TEMSILCISI", teklifMasData.FirmaTemsilcisi);
            command.Parameters.AddWithValue("@SATIS_MUHENDISI", teklifMasData.SatisMuhendisi);
            command.Parameters.AddWithValue("@ITHALAT_IHRACAT_TIPI", teklifMasData.IthalatIhracatTipi);
            command.Parameters.AddWithValue("@NOT_1", teklifMasData.Not1);
            command.Parameters.AddWithValue("@NOT_2", teklifMasData.Not2);
            command.Parameters.AddWithValue("@NOT_3", teklifMasData.Not3);
            command.Parameters.AddWithValue("@NOT_4", teklifMasData.Not4);
            command.Parameters.AddWithValue("@ISTENEN_OZELLIKLER", teklifMasData.IstenenOzellikler);
            command.Parameters.AddWithValue("@NAKLIYE_SARTI", teklifMasData.NakliyeSarti);
            command.Parameters.AddWithValue("@ACIKLAMA", teklifMasData.Aciklama);
            command.Parameters.AddWithValue("@ODEME_SARTLARI", teklifMasData.OdemeSartlari);
            command.Parameters.AddWithValue("@GECERLILIK", teklifMasData.Gecerlilik);
            command.Parameters.AddWithValue("@PAKETLEME", teklifMasData.Paketleme);
            command.Parameters.AddWithValue("@HAZIRLAYAN", teklifMasData.Hazirlayan);
            command.Parameters.AddWithValue("@BRUT_TOPLAM", teklifMasData.BrutToplam);
            command.Parameters.AddWithValue("@KDV_ORANI", teklifMasData.KdvOrani);
            command.Parameters.AddWithValue("@KDV_TOPLAMI", teklifMasData.KdvToplami);
            command.Parameters.AddWithValue("@GENEL_TOPLAM", teklifMasData.GenelToplam);
            command.Parameters.AddWithValue("@VADE_TARIHI", teklifMasData.VadeTarihi);
            command.Parameters.AddWithValue("@VADE_GUNU", teklifMasData.VadeGunu);
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

                // SINERJICRM veritabanındaki dbo.TEKLIFMAS tablosundaki verileri al
                using (SqlConnection crmConnection = new SqlConnection("Server=SRV1; Database=SINERJICRM; User Id=sa; Password=SA123pass_"))
                {
                    crmConnection.Open();
                    string selectQuery = "SELECT * FROM dbo.TEKLIFMAS";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, crmConnection);
                    SqlDataReader reader = selectCommand.ExecuteReader();

                    // SINERJISMART veritabanına bağlan ve verileri aktar
                    using (SqlConnection smartConnection = new SqlConnection("Server=SRV1; Database=SINERJISMART; User Id=sa; Password=SA123pass_"))
                    {
                        smartConnection.Open();
                        while (reader.Read())
                        {
                            string insertQuery = @"INSERT INTO dbo.TBLTEKLIFMAS 
                            (TEKLIF_NO, CARI_KOD, TARIH, DOVIZ_BAZ_TARIHI, YURT_ICI_DISI, TEKLIF_DURUMU, FIRMA_TEMSILCISI, SATIS_MUHENDISI, ITHALAT_IHRACAT_TIPI, NOT_1, NOT_2, NOT_3, NOT_4, ISTENEN_OZELLIKLER, NAKLIYE_SARTI, ACIKLAMA, ODEME_SARTLARI, GECERLILIK, PAKETLEME, HAZIRLAYAN, BRUT_TOPLAM, KDV_ORANI, KDV_TOPLAMI, GENEL_TOPLAM, VADE_TARIHI, VADE_GUNU) 
                            VALUES (@TEKLIF_NO, @CARI_KOD, @TARIH, @DOVIZ_BAZ_TARIHI, @YURT_ICI_DISI, @TEKLIF_DURUMU, @FIRMA_TEMSILCISI, @SATIS_MUHENDISI, @ITHALAT_IHRACAT_TIPI, @NOT_1, @NOT_2, @NOT_3, @NOT_4, @ISTENEN_OZELLIKLER, @NAKLIYE_SARTI, @ACIKLAMA, @ODEME_SARTLARI, @GECERLILIK, @PAKETLEME, @HAZIRLAYAN, @BRUT_TOPLAM, @KDV_ORANI, @KDV_TOPLAMI, @GENEL_TOPLAM, @VADE_TARIHI, @VADE_GUNU)";

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, smartConnection))
                            {
                                insertCommand.Parameters.AddWithValue("@FATIRS_NO", reader["TEKLIF_NO"]);
                                insertCommand.Parameters.AddWithValue("@CARI_KODU", reader["CARI_KOD"]);
                                insertCommand.Parameters.AddWithValue("@TARIH", reader["TARIH"]);
                                //insertCommand.Parameters.AddWithValue("@DOVIZ_BAZ_TARIHI", reader["DOVIZ_BAZ_TARIHI"]);
                                //insertCommand.Parameters.AddWithValue("@YURT_ICI_DISI", reader["YURT_ICI_DISI"]);
                                //insertCommand.Parameters.AddWithValue("@TEKLIF_DURUMU", reader["TEKLIF_DURUMU"]);
                                //insertCommand.Parameters.AddWithValue("@FIRMA_TEMSILCISI", reader["FIRMA_TEMSILCISI"]);
                                //insertCommand.Parameters.AddWithValue("@SATIS_MUHENDISI", reader["SATIS_MUHENDISI"]);
                                //insertCommand.Parameters.AddWithValue("@ITHALAT_IHRACAT_TIPI", reader["ITHALAT_IHRACAT_TIPI"]);
                                insertCommand.Parameters.AddWithValue("@NOT_1", reader["NOT_1"]);
                                insertCommand.Parameters.AddWithValue("@NOT_2", reader["NOT_2"]);
                                insertCommand.Parameters.AddWithValue("@NOT_3", reader["NOT_3"]);
                                insertCommand.Parameters.AddWithValue("@NOT_4", reader["NOT_4"]);
                                insertCommand.Parameters.AddWithValue("@ISTENEN_OZELLIKLER", reader["ISTENEN_OZELLIKLER"]);
                                insertCommand.Parameters.AddWithValue("@NAKLIYE_SARTI", reader["NAKLIYE_SARTI"]);
                                insertCommand.Parameters.AddWithValue("@ACIKLAMA", reader["ACIKLAMA"]);
                                insertCommand.Parameters.AddWithValue("@ODEME_SARTLARI", reader["ODEME_SARTLARI"]);
                                insertCommand.Parameters.AddWithValue("@GECERLILIK", reader["GECERLILIK"]);
                                insertCommand.Parameters.AddWithValue("@PAKETLEME", reader["PAKETLEME"]);
                                insertCommand.Parameters.AddWithValue("@HAZIRLAYAN", reader["HAZIRLAYAN"]);
                                insertCommand.Parameters.AddWithValue("@BRUT_TOPLAM", reader["BRUT_TOPLAM"]);
                                insertCommand.Parameters.AddWithValue("@KDV_ORANI", reader["KDV_ORANI"]);
                                insertCommand.Parameters.AddWithValue("@KDV_TOPLAMI", reader["KDV_TOPLAMI"]);
                                insertCommand.Parameters.AddWithValue("@GENEL_TOPLAM", reader["GENEL_TOPLAM"]);
                                insertCommand.Parameters.AddWithValue("@VADE_TARIHI", reader["VADE_TARIHI"]);
                                insertCommand.Parameters.AddWithValue("@VADE_GUNU", reader["VADE_GUNU"]);

                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    MessageBox.Show("Veriler başarıyla aktarıldı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri aktarımı sırasında hata oluştu: {ex.Message}");
            }
            
        }
    }
}
