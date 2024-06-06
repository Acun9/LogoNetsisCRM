using SinerjiCRM.Scripts;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
                dataGridView1.Columns["ID"].Visible = false; // ID sütununu gizle
                dataGridView1.Columns["SIRA_NO"].ReadOnly = true; // SIRA_NO sütununu yalnızca okunabilir yap

            }
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow newRow = dataGridView1.Rows[e.RowIndex];
                var id = newRow.Cells["ID"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(id))
                {
                    InsertRecord(newRow);
                }
                else
                {
                    UpdateRecord(newRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına ekleme/güncelleme hatası: " + ex.Message);
            }
        }

        private void SetSiraNo(string teklifNo)
        {
            if (!string.IsNullOrEmpty(teklifNo))
            {
                var rowsWithSameTeklifNo = dataGridView1.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells["TEKLIF_NO"].Value?.ToString() == teklifNo)
                    .OrderBy(r => r.Index)
                    .ToList();

                int newSiraNo = 1;
                foreach (var r in rowsWithSameTeklifNo)
                {
                    r.Cells["SIRA_NO"].Value = newSiraNo++;
                }
            }
        }

        private void InsertRecord(DataGridViewRow row)
        {
            using (SqlConnection connection = new SQLBaglantisi().baglanti())
            {
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    string query = "INSERT INTO dbo.TEKLIFTRA (TEKLIF_NO, STOK_KODU, STOK_ADI, TESLIM_TARIHI, MIKTAR, MIKTAR_OLCU_BIRIMI, DOVIZ_KURU, TL_FIYATI, KDV_ORANI, TUTAR, SIRA_NO, PROJE_KODU, EK_ALAN_1, EK_ALAN_2) VALUES (@TeklifNo, @StokKodu, @StokAdi, @TeslimTarihi, @Miktar, @MiktarOlcuBirimi, @DovizKuru, @TlFiyati, @KdvOrani, @Tutar, @SiraNo, @ProjeKodu, @EkAlan1, @EkAlan2); SELECT SCOPE_IDENTITY();";
                    using (SqlCommand command = new SqlCommand(query, connection, transaction))
                    {
                        AddParameters(command, row);
                        var newId = command.ExecuteScalar(); // Yeni ID'yi al
                        row.Cells["ID"].Value = newId; // Yeni ID'yi DataGridView'e ata
                    }
                    transaction.Commit();
                    SetSiraNo(row.Cells["TEKLIF_NO"].Value?.ToString());
                }
            }
        }

        private void UpdateRecord(DataGridViewRow row)
        {
            using (SqlConnection connection = new SQLBaglantisi().baglanti())
            {
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    string query = "UPDATE dbo.TEKLIFTRA SET TEKLIF_NO = @TeklifNo, STOK_KODU = @StokKodu, STOK_ADI = @StokAdi, TESLIM_TARIHI = @TeslimTarihi, MIKTAR = @Miktar, MIKTAR_OLCU_BIRIMI = @MiktarOlcuBirimi, DOVIZ_KURU = @DovizKuru, TL_FIYATI = @TlFiyati, KDV_ORANI = @KdvOrani, TUTAR = @Tutar, SIRA_NO = @SiraNo, PROJE_KODU = @ProjeKodu, EK_ALAN_1 = @EkAlan1, EK_ALAN_2 = @EkAlan2 WHERE ID = @ID";
                    using (SqlCommand command = new SqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@ID", row.Cells["ID"].Value);
                        AddParameters(command, row);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    SetSiraNo(row.Cells["TEKLIF_NO"].Value?.ToString());
                }
            }
        }

        private void AddParameters(SqlCommand command, DataGridViewRow row)
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
                var id = e.Row.Cells["ID"].Value?.ToString();
                var teklifNo = e.Row.Cells["TEKLIF_NO"].Value?.ToString();

                if (id != null)
                {
                    try
                    {
                        using (SqlConnection connection = new SQLBaglantisi().baglanti())
                        {
                            using (SqlTransaction transaction = connection.BeginTransaction())
                            {
                                string query = "DELETE FROM dbo.TEKLIFTRA WHERE ID = @ID";
                                using (SqlCommand command = new SqlCommand(query, connection, transaction))
                                {
                                    command.Parameters.AddWithValue("@ID", id);
                                    command.ExecuteNonQuery();
                                    transaction.Commit();
                                }
                            }
                        }

                        // SIRA_NO değerlerini güncelle
                        SetSiraNo(teklifNo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanından silme hatası: " + ex.Message);
                        e.Cancel = true;
                    }
                }
                else
                {
                    MessageBox.Show("Silinecek satırın ID değeri alınamadı.");
                    e.Cancel = true;
                }
            }
        }
    }
}
