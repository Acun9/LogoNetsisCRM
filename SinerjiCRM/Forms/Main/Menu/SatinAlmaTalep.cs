using System.Data.SqlClient;
using NetOpenX.Rest.Client.BLL;
using NetOpenX.Rest.Client.Model.NetOpenX;
using NetOpenX.Rest.Client.Model;
using NetOpenX.Rest.Client;
using System.Data;
using SinerjiCRM.Scripts;
using System.Windows.Forms;
using NetOpenX.Rest.Client.Model.Enums;

namespace SinerjiCRM
{
    public partial class SatinAlmaTalep : Form
    {

        public SatinAlmaTalep()
        {
            InitializeComponent();
        }

        private void SatinAlmaTalep_Load(object sender, EventArgs e)
        {
            LoadComboboxData();
            LoadDataGridView();
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
                                LoadDataGridView();
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
                                LoadDataGridView();
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
                        LoadDataGridView();
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
                    return "YURTICI";
                }
                else if (rbYurtDisi.Checked)
                {
                    return "YURTDİSİ";
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

        
        //private void AddParametersToCommandTra(SqlCommand command, Data teklifTraData)
        //{
        //    command.Parameters.AddWithValue("@TEKLIF_NO", teklifTraData.No ?? string.Empty);
        //    command.Parameters.AddWithValue("@STOK_KODU", teklifTraData.Kod ?? string.Empty);
        //    command.Parameters.AddWithValue("@STOK_ADI", teklifTraData.Isim ?? string.Empty);
        //    command.Parameters.AddWithValue("@TESLIM_TARIHI", teklifTraData.Tarih ?? (object)DBNull.Value);
        //    command.Parameters.AddWithValue("@MIKTAR", teklifTraData.Miktar ?? string.Empty);
        //    command.Parameters.AddWithValue("@MIKTAR_OLCU_BIRIMI", teklifTraData.MiktarOlcuBirimi ?? string.Empty);
        //    command.Parameters.AddWithValue("@DOVIZ_KURU", teklifTraData.DovizKuru ?? (object)DBNull.Value);
        //    command.Parameters.AddWithValue("@TL_FIYATI", teklifTraData.Fiyat ?? (object)DBNull.Value);
        //    command.Parameters.AddWithValue("@KDV_ORANI", teklifTraData.KdvOrani ?? (object)DBNull.Value);
        //    command.Parameters.AddWithValue("@TUTAR", teklifTraData.Tutar ?? (object)DBNull.Value);
        //    command.Parameters.AddWithValue("@SIRA_NO", teklifTraData.No2 ?? string.Empty);
        //    command.Parameters.AddWithValue("@PROJE_KODU", teklifTraData.Kod2 ?? string.Empty);
        //    command.Parameters.AddWithValue("@EK_ALAN_1", teklifTraData.Ek1 ?? string.Empty);
        //    command.Parameters.AddWithValue("@EK_ALAN_2", teklifTraData.Ek2 ?? string.Empty);
        //}

        private void LoadComboboxData()
        {

        }

        private void LoadDataGridView()
        {
            using (SqlConnection connection = new SQLBaglantisi().baglanti())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.TEKLIFTRA", connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Düzenlenen hücrenin satır ve sütun bilgilerini al
                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;

                // Düzenlenen hücrenin yeni değerini al
                var newValue = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value;

                // TEKLIF_NO (Primary Key) değerini al
                var teklifNo = dataGridView1.Rows[rowIndex].Cells["TEKLIF_NO"].Value;

                if (teklifNo == null || string.IsNullOrWhiteSpace(teklifNo.ToString()))
                {
                    MessageBox.Show("Teklif No boş olamaz.");
                    return;
                }

                // Güncellenen sütun adını al
                var columnName = dataGridView1.Columns[columnIndex].Name;

                // SQL bağlantısı ve komutu
                using (SqlConnection connection = new SQLBaglantisi().baglanti())
                {
                    string query = $"UPDATE dbo.TEKLIFTRA SET {columnName} = @NewValue WHERE TEKLIF_NO = @TeklifNo";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NewValue", newValue ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TeklifNo", teklifNo);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı güncelleme hatası: " + ex.Message);
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                // Yeni eklenen satırı alın
                DataGridViewRow newRow = dataGridView1.Rows[e.Row.Index - 1];

                // Sütun değerlerini alın
                var teklifNo = newRow.Cells["TEKLIF_NO"].Value?.ToString();
                var stokKodu = newRow.Cells["STOK_KODU"].Value?.ToString();
                var stokAdi = newRow.Cells["STOK_ADI"].Value?.ToString();
                var teslimTarihi = newRow.Cells["TESLIM_TARIHI"].Value?.ToString();
                var miktar = newRow.Cells["MIKTAR"].Value?.ToString();
                var miktarOlcuBirimi = newRow.Cells["MIKTAR_OLCU_BIRIMI"].Value?.ToString();
                var dovizKuru = newRow.Cells["DOVIZ_KURU"].Value?.ToString();
                var tlFiyati = newRow.Cells["TL_FIYATI"].Value?.ToString();
                var kdvOrani = newRow.Cells["KDV_ORANI"].Value?.ToString();
                var tutar = newRow.Cells["TUTAR"].Value?.ToString();
                var siraNo = newRow.Cells["SIRA_NO"].Value?.ToString();
                var projeKodu = newRow.Cells["PROJE_KODU"].Value?.ToString();
                var ekAlan1 = newRow.Cells["EK_ALAN_1"].Value?.ToString();
                var ekAlan2 = newRow.Cells["EK_ALAN_2"].Value?.ToString();

                // SQL bağlantısı ve komutu
                using (SqlConnection connection = new SQLBaglantisi().baglanti())
                {
                    string query = "INSERT INTO dbo.TEKLIFTRA (TEKLIF_NO, STOK_KODU, STOK_ADI, TESLIM_TARIHI, MIKTAR, MIKTAR_OLCU_BIRIMI, DOVIZ_KURU, TL_FIYATI, KDV_ORANI, TUTAR, SIRA_NO, PROJE_KODU, EK_ALAN_1, EK_ALAN_2) " +
                                   "VALUES (@TeklifNo, @StokKodu, @StokAdi, @TeslimTarihi, @Miktar, @MiktarOlcuBirimi, @DovizKuru, @TlFiyati, @KdvOrani, @Tutar, @SiraNo, @ProjeKodu, @EkAlan1, @EkAlan2)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TeklifNo", teklifNo);
                        command.Parameters.AddWithValue("@StokKodu", stokKodu);
                        command.Parameters.AddWithValue("@StokAdi", stokAdi);
                        command.Parameters.AddWithValue("@TeslimTarihi", teslimTarihi);
                        command.Parameters.AddWithValue("@Miktar", miktar);
                        command.Parameters.AddWithValue("@MiktarOlcuBirimi", miktarOlcuBirimi);
                        command.Parameters.AddWithValue("@DovizKuru", dovizKuru);
                        command.Parameters.AddWithValue("@TlFiyati", tlFiyati);
                        command.Parameters.AddWithValue("@KdvOrani", kdvOrani);
                        command.Parameters.AddWithValue("@Tutar", tutar);
                        command.Parameters.AddWithValue("@SiraNo", siraNo);
                        command.Parameters.AddWithValue("@ProjeKodu", projeKodu);
                        command.Parameters.AddWithValue("@EkAlan1", ekAlan1);
                        command.Parameters.AddWithValue("@EkAlan2", ekAlan2);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına ekleme hatası: " + ex.Message);
            }
        }


        //private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        // Yeni eklenen satırı al
        //        DataGridViewRow newRow = dataGridView1.Rows[e.Row.Index - 1];

        //        // TEKLIF_NO kontrolü yap
        //        if (newRow.Cells["TEKLIF_NO"].Value == null || string.IsNullOrWhiteSpace(newRow.Cells["TEKLIF_NO"].Value.ToString()))
        //        {
        //            MessageBox.Show("Teklif No boş olamaz.");
        //            dataGridView1.Rows.RemoveAt(e.Row.Index - 1); // Boş satırı kaldır
        //            return;
        //        }

        //        // Diğer sütun değerlerini bir teklifTraData nesnesine ata
        //        var teklifTraData = new Data
        //        {
        //            No = newRow.Cells["TEKLIF_NO"].Value?.ToString(),
        //            Kod = newRow.Cells["STOK_KODU"].Value?.ToString(),
        //            Isim = newRow.Cells["STOK_ADI"].Value?.ToString(),
        //            Tarih = newRow.Cells["TESLIM_TARIHI"].Value?.ToString(),
        //            Miktar = newRow.Cells["MIKTAR"].Value?.ToString(),
        //            MiktarOlcuBirimi = newRow.Cells["MIKTAR_OLCU_BIRIMI"].Value?.ToString(),
        //            DovizKuru = newRow.Cells["DOVIZ_KURU"].Value?.ToString(),
        //            Fiyat = newRow.Cells["TL_FIYATI"].Value?.ToString(),
        //            KdvOrani = newRow.Cells["KDV_ORANI"].Value?.ToString(),
        //            Tutar = newRow.Cells["TUTAR"].Value?.ToString(),
        //            No2 = newRow.Cells["SIRA_NO"].Value?.ToString(),
        //            Kod2 = newRow.Cells["PROJE_KODU"].Value?.ToString(),
        //            Ek1 = newRow.Cells["EK_ALAN_1"].Value?.ToString(),
        //            Ek2 = newRow.Cells["EK_ALAN_2"].Value?.ToString()
        //        };

        //        // SQL bağlantısı ve komutu
        //        using (SqlConnection connection = new SQLBaglantisi().baglanti())
        //        {
        //            string query = "INSERT INTO dbo.TEKLIFTRA (TEKLIF_NO, STOK_KODU, STOK_ADI, TESLIM_TARIHI, MIKTAR, MIKTAR_OLCU_BIRIMI, DOVIZ_KURU, TL_FIYATI, KDV_ORANI, TUTAR, SIRA_NO, PROJE_KODU, EK_ALAN_1, EK_ALAN_2) " +
        //                           "VALUES (@TEKLIF_NO, @STOK_KODU, @STOK_ADI, @TESLIM_TARIHI, @MIKTAR, @MIKTAR_OLCU_BIRIMI, @DOVIZ_KURU, @TL_FIYATI, @KDV_ORANI, @TUTAR, @SIRA_NO, @PROJE_KODU, @EK_ALAN_1, @EK_ALAN_2)";
        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                AddParametersToCommandTra(command, teklifTraData);
        //                command.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Veritabanına ekleme hatası: " + ex.Message);
        //    }
        //}


        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bu satırı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                // Silinecek satırın TEKLIF_NO değerini al
                var teklifNo = e.Row.Cells["TEKLIF_NO"].Value?.ToString();

                if (teklifNo != null)
                {
                    // SQL bağlantısı ve komutu
                    try
                    {
                        using (SqlConnection connection = new SQLBaglantisi().baglanti())
                        {
                            connection.Open();
                            string query = "DELETE FROM dbo.TEKLIFTRA WHERE TEKLIF_NO = @TeklifNo";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@TeklifNo", teklifNo);
                                command.ExecuteNonQuery();
                            }
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanından silme hatası: " + ex.Message);
                        e.Cancel = true; // Hata durumunda silme işlemini iptal et
                    }
                }
                else
                {
                    MessageBox.Show("Silinecek satırın TEKLIF_NO değeri alınamadı.");
                    e.Cancel = true; // TEKLIF_NO değeri alınamazsa silme işlemini iptal et
                }
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

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
                string selectQuery = "SELECT * FROM SATIN_ALMA_TALEP";

                using (SqlConnection sourceConnection = new SqlConnection("Server=SRV1;Database=SINERJICRM;User Id=sa;Password=SA123pass_;"))
                {
                    sourceConnection.Open();
                    SqlCommand selectCommand = new SqlCommand(selectQuery, sourceConnection);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                        }
                    }
                }

                // Hedef veritabanına verileri aktarma


                // Hedef veritabanından fazladan kayıtları silme
                if (true)
                {

                }
                else
                {
                    throw new Exception($"Mevcut kayıtların alınması başarısız: ");
                }

                MessageBox.Show("Veri aktarımı başarıyla tamamlandı.");
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Veri aktarımı sırasında hata oluştu: {ex.Message}");
            }
        }
    }
}
