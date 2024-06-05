using SinerjiCRM.Scripts;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SinerjiCRM.Forms.Main.Menu
{
    public partial class gridTest : Form
    {
        private string _previousValue;

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

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _previousValue = dataGridView1[e.ColumnIndex, e.RowIndex].Value?.ToString();
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow newRow = dataGridView1.Rows[e.RowIndex];
                var teklifNo = newRow.Cells["TEKLIF_NO"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(teklifNo))
                {
                    MessageBox.Show("Teklif No boş olamaz. Lütfen Teklif No girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    newRow.Cells["TEKLIF_NO"].Value = _previousValue; // Eski değeri geri yükle
                    return;
                }

                using (SqlConnection connection = new SQLBaglantisi().baglanti())
                {
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        if (RecordExists(teklifNo, connection, transaction))
                        {
                            UpdateRecord(newRow, connection, transaction);
                        }
                        else
                        {
                            InsertRecord(newRow, connection, transaction);
                        }

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına ekleme/güncelleme hatası: " + ex.Message);
            }
        }

        private bool RecordExists(string teklifNo, SqlConnection connection, SqlTransaction transaction)
        {
            string checkQuery = "SELECT COUNT(*) FROM dbo.TEKLIFTRA WHERE TEKLIF_NO = @TeklifNo";
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection, transaction))
            {
                checkCommand.Parameters.AddWithValue("@TeklifNo", teklifNo);
                return (int)checkCommand.ExecuteScalar() > 0;
            }
        }

        private void UpdateRecord(DataGridViewRow row, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "UPDATE dbo.TEKLIFTRA SET STOK_KODU = @StokKodu, STOK_ADI = @StokAdi, TESLIM_TARIHI = @TeslimTarihi, MIKTAR = @Miktar, MIKTAR_OLCU_BIRIMI = @MiktarOlcuBirimi, DOVIZ_KURU = @DovizKuru, TL_FIYATI = @TlFiyati, KDV_ORANI = @KdvOrani, TUTAR = @Tutar, SIRA_NO = @SiraNo, PROJE_KODU = @ProjeKodu, EK_ALAN_1 = @EkAlan1, EK_ALAN_2 = @EkAlan2 WHERE TEKLIF_NO = @TeklifNo";
            ExecuteNonQuery(query, row, connection, transaction);
        }

        private void InsertRecord(DataGridViewRow row, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "INSERT INTO dbo.TEKLIFTRA (TEKLIF_NO, STOK_KODU, STOK_ADI, TESLIM_TARIHI, MIKTAR, MIKTAR_OLCU_BIRIMI, DOVIZ_KURU, TL_FIYATI, KDV_ORANI, TUTAR, SIRA_NO, PROJE_KODU, EK_ALAN_1, EK_ALAN_2) VALUES (@TeklifNo, @StokKodu, @StokAdi, @TeslimTarihi, @Miktar, @MiktarOlcuBirimi, @DovizKuru, @TlFiyati, @KdvOrani, @Tutar, @SiraNo, @ProjeKodu, @EkAlan1, @EkAlan2)";
            ExecuteNonQuery(query, row, connection, transaction);
        }

        private void ExecuteNonQuery(string query, DataGridViewRow row, SqlConnection connection, SqlTransaction transaction)
        {
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@TeklifNo", row.Cells["TEKLIF_NO"].Value?.ToString());
                command.Parameters.AddWithValue("@StokKodu", row.Cells["STOK_KODU"].Value?.ToString());
                command.Parameters.AddWithValue("@StokAdi", row.Cells["STOK_ADI"].Value?.ToString());
                command.Parameters.AddWithValue("@TeslimTarihi", row.Cells["TESLIM_TARIHI"].Value?.ToString());
                command.Parameters.AddWithValue("@Miktar", row.Cells["MIKTAR"].Value?.ToString());
                command.Parameters.AddWithValue("@MiktarOlcuBirimi", row.Cells["MIKTAR_OLCU_BIRIMI"].Value?.ToString());
                command.Parameters.AddWithValue("@DovizKuru", row.Cells["DOVIZ_KURU"].Value?.ToString());
                command.Parameters.AddWithValue("@TlFiyati", row.Cells["TL_FIYATI"].Value?.ToString());
                command.Parameters.AddWithValue("@KdvOrani", row.Cells["KDV_ORANI"].Value?.ToString());
                command.Parameters.AddWithValue("@Tutar", row.Cells["TUTAR"].Value?.ToString());
                command.Parameters.AddWithValue("@SiraNo", row.Cells["SIRA_NO"].Value?.ToString());
                command.Parameters.AddWithValue("@ProjeKodu", row.Cells["PROJE_KODU"].Value?.ToString());
                command.Parameters.AddWithValue("@EkAlan1", row.Cells["EK_ALAN_1"].Value?.ToString());
                command.Parameters.AddWithValue("@EkAlan2", row.Cells["EK_ALAN_2"].Value?.ToString());

                command.ExecuteNonQuery();
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
                var teklifNo = e.Row.Cells["TEKLIF_NO"].Value?.ToString();

                if (teklifNo != null)
                {
                    try
                    {
                        using (SqlConnection connection = new SQLBaglantisi().baglanti())
                        {
                            using (SqlTransaction transaction = connection.BeginTransaction())
                            {
                                string query = "DELETE FROM dbo.TEKLIFTRA WHERE TEKLIF_NO = @TeklifNo";
                                using (SqlCommand command = new SqlCommand(query, connection, transaction))
                                {
                                    command.Parameters.AddWithValue("@TeklifNo", teklifNo);
                                    command.ExecuteNonQuery();
                                    transaction.Commit();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanından silme hatası: " + ex.Message);
                        e.Cancel = true;
                    }
                }
                else
                {
                    MessageBox.Show("Silinecek satırın TEKLIF_NO değeri alınamadı.");
                    e.Cancel = true;
                }
            }
        }
    }
}
