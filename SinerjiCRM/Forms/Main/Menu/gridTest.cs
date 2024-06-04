using SinerjiCRM.Scripts;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SinerjiCRM.Forms.Main.Menu
{
    public partial class gridTest : Form
    {
        public gridTest()
        {
            InitializeComponent();
        }

        private void gridTest_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            using (SqlConnection connection = new SQLBaglantisi().baglanti())
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.TEKLIFTRA", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Yeni eklenen veya güncellenen satırı alın
                DataGridViewRow newRow = dataGridView1.Rows[e.RowIndex];

                // TEKLIF_NO (Primary Key) değerini alın
                var teklifNo = newRow.Cells["TEKLIF_NO"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(teklifNo))
                {
                    MessageBox.Show("Teklif No boş olamaz. Lütfen Teklif No girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Diğer sütun değerlerini alın
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
                    string query = "IF EXISTS (SELECT 1 FROM dbo.TEKLIFTRA WHERE TEKLIF_NO = @TeklifNo) " +
                                   "BEGIN " +
                                   "UPDATE dbo.TEKLIFTRA SET STOK_KODU = @StokKodu, STOK_ADI = @StokAdi, TESLIM_TARIHI = @TeslimTarihi, MIKTAR = @Miktar, MIKTAR_OLCU_BIRIMI = @MiktarOlcuBirimi, DOVIZ_KURU = @DovizKuru, TL_FIYATI = @TlFiyati, KDV_ORANI = @KdvOrani, TUTAR = @Tutar, SIRA_NO = @SiraNo, PROJE_KODU = @ProjeKodu, EK_ALAN_1 = @EkAlan1, EK_ALAN_2 = @EkAlan2 " +
                                   "WHERE TEKLIF_NO = @TeklifNo " +
                                   "END " +
                                   "ELSE " +
                                   "BEGIN " +
                                   "INSERT INTO dbo.TEKLIFTRA (TEKLIF_NO, STOK_KODU, STOK_ADI, TESLIM_TARIHI, MIKTAR, MIKTAR_OLCU_BIRIMI, DOVIZ_KURU, TL_FIYATI, KDV_ORANI, TUTAR, SIRA_NO, PROJE_KODU, EK_ALAN_1, EK_ALAN_2) " +
                                   "VALUES (@TeklifNo, @StokKodu, @StokAdi, @TeslimTarihi, @Miktar, @MiktarOlcuBirimi, @DovizKuru, @TlFiyati, @KdvOrani, @Tutar, @SiraNo, @ProjeKodu, @EkAlan1, @EkAlan2) " +
                                   "END";
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
                MessageBox.Show("Veritabanına ekleme/güncelleme hatası: " + ex.Message);
            }
        }

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
                            string query = "DELETE FROM dbo.TEKLIFTRA WHERE TEKLIF_NO = @TeklifNo";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@TeklifNo", teklifNo);
                                command.ExecuteNonQuery();
                            }
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
    }
}
