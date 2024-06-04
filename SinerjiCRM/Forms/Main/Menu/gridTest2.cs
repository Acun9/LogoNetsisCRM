using SinerjiCRM.Scripts;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SinerjiCRM.Forms.Main.Menu
{
    public partial class gridTest2 : Form
    {
        private SqlDataAdapter adapter;
        private DataTable dataTable;

        public gridTest2()
        {
            InitializeComponent();
        }

        private void gridTest2_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            using (SqlConnection connection = new SQLBaglantisi().baglanti())
            {
                adapter = new SqlDataAdapter("SELECT * FROM dbo.TEKLIFTRA", connection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                // RowVersion kolonunu ekleyin
                dataTable.Columns["TEKLIF_NO"].Unique = true;
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["TEKLIF_NO"] };

                // Update, Insert ve Delete komutlarını manuel olarak ayarlayın
                SetUpdateCommand(adapter);
                SetInsertCommand(adapter);
                SetDeleteCommand(adapter);

                dataGridView1.DataSource = dataTable;
            }
        }

        private void SetUpdateCommand(SqlDataAdapter adapter)
        {
            SqlCommand updateCommand = new SqlCommand(
                "UPDATE dbo.TEKLIFTRA SET STOK_KODU = @STOK_KODU, STOK_ADI = @STOK_ADI, TESLIM_TARIHI = @TESLIM_TARIHI, MIKTAR = @MIKTAR, " +
                "MIKTAR_OLCU_BIRIMI = @MIKTAR_OLCU_BIRIMI, DOVIZ_KURU = @DOVIZ_KURU, TL_FIYATI = @TL_FIYATI, KDV_ORANI = @KDV_ORANI, TUTAR = @TUTAR, " +
                "SIRA_NO = @SIRA_NO, PROJE_KODU = @PROJE_KODU, EK_ALAN_1 = @EK_ALAN_1, EK_ALAN_2 = @EK_ALAN_2 WHERE TEKLIF_NO = @TEKLIF_NO", adapter.SelectCommand.Connection);
            updateCommand.Parameters.Add("@TEKLIF_NO", SqlDbType.VarChar, 50, "TEKLIF_NO");
            updateCommand.Parameters.Add("@STOK_KODU", SqlDbType.VarChar, 50, "STOK_KODU");
            updateCommand.Parameters.Add("@STOK_ADI", SqlDbType.VarChar, 100, "STOK_ADI");
            updateCommand.Parameters.Add("@TESLIM_TARIHI", SqlDbType.DateTime, 0, "TESLIM_TARIHI");
            updateCommand.Parameters.Add("@MIKTAR", SqlDbType.Decimal, 0, "MIKTAR");
            updateCommand.Parameters.Add("@MIKTAR_OLCU_BIRIMI", SqlDbType.VarChar, 50, "MIKTAR_OLCU_BIRIMI");
            updateCommand.Parameters.Add("@DOVIZ_KURU", SqlDbType.Decimal, 0, "DOVIZ_KURU");
            updateCommand.Parameters.Add("@TL_FIYATI", SqlDbType.Decimal, 0, "TL_FIYATI");
            updateCommand.Parameters.Add("@KDV_ORANI", SqlDbType.Decimal, 0, "KDV_ORANI");
            updateCommand.Parameters.Add("@TUTAR", SqlDbType.Decimal, 0, "TUTAR");
            updateCommand.Parameters.Add("@SIRA_NO", SqlDbType.Int, 0, "SIRA_NO");
            updateCommand.Parameters.Add("@PROJE_KODU", SqlDbType.VarChar, 50, "PROJE_KODU");
            updateCommand.Parameters.Add("@EK_ALAN_1", SqlDbType.VarChar, 50, "EK_ALAN_1");
            updateCommand.Parameters.Add("@EK_ALAN_2", SqlDbType.VarChar, 50, "EK_ALAN_2");

            adapter.UpdateCommand = updateCommand;
        }

        private void SetInsertCommand(SqlDataAdapter adapter)
        {
            SqlCommand insertCommand = new SqlCommand(
                "INSERT INTO dbo.TEKLIFTRA (TEKLIF_NO, STOK_KODU, STOK_ADI, TESLIM_TARIHI, MIKTAR, MIKTAR_OLCU_BIRIMI, DOVIZ_KURU, TL_FIYATI, KDV_ORANI, TUTAR, " +
                "SIRA_NO, PROJE_KODU, EK_ALAN_1, EK_ALAN_2) VALUES (@TEKLIF_NO, @STOK_KODU, @STOK_ADI, @TESLIM_TARIHI, @MIKTAR, @MIKTAR_OLCU_BIRIMI, " +
                "@DOVIZ_KURU, @TL_FIYATI, @KDV_ORANI, @TUTAR, @SIRA_NO, @PROJE_KODU, @EK_ALAN_1, @EK_ALAN_2)", adapter.SelectCommand.Connection);
            insertCommand.Parameters.Add("@TEKLIF_NO", SqlDbType.VarChar, 50, "TEKLIF_NO");
            insertCommand.Parameters.Add("@STOK_KODU", SqlDbType.VarChar, 50, "STOK_KODU");
            insertCommand.Parameters.Add("@STOK_ADI", SqlDbType.VarChar, 100, "STOK_ADI");
            insertCommand.Parameters.Add("@TESLIM_TARIHI", SqlDbType.DateTime, 0, "TESLIM_TARIHI");
            insertCommand.Parameters.Add("@MIKTAR", SqlDbType.Decimal, 0, "MIKTAR");
            insertCommand.Parameters.Add("@MIKTAR_OLCU_BIRIMI", SqlDbType.VarChar, 50, "MIKTAR_OLCU_BIRIMI");
            insertCommand.Parameters.Add("@DOVIZ_KURU", SqlDbType.Decimal, 0, "DOVIZ_KURU");
            insertCommand.Parameters.Add("@TL_FIYATI", SqlDbType.Decimal, 0, "TL_FIYATI");
            insertCommand.Parameters.Add("@KDV_ORANI", SqlDbType.Decimal, 0, "KDV_ORANI");
            insertCommand.Parameters.Add("@TUTAR", SqlDbType.Decimal, 0, "TUTAR");
            insertCommand.Parameters.Add("@SIRA_NO", SqlDbType.Int, 0, "SIRA_NO");
            insertCommand.Parameters.Add("@PROJE_KODU", SqlDbType.VarChar, 50, "PROJE_KODU");
            insertCommand.Parameters.Add("@EK_ALAN_1", SqlDbType.VarChar, 50, "EK_ALAN_1");
            insertCommand.Parameters.Add("@EK_ALAN_2", SqlDbType.VarChar, 50, "EK_ALAN_2");

            adapter.InsertCommand = insertCommand;
        }

        private void SetDeleteCommand(SqlDataAdapter adapter)
        {
            SqlCommand deleteCommand = new SqlCommand("DELETE FROM dbo.TEKLIFTRA WHERE TEKLIF_NO = @TEKLIF_NO", adapter.SelectCommand.Connection);
            deleteCommand.Parameters.Add("@TEKLIF_NO", SqlDbType.VarChar, 50, "TEKLIF_NO");

            adapter.DeleteCommand = deleteCommand;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.EndEdit();
                using (SqlConnection connection = new SQLBaglantisi().baglanti())
                {
                    adapter.SelectCommand.Connection = connection;
                    SetUpdateCommand(adapter);

                    // Değişiklikleri kabul edin ve güncelleyin
                    dataTable.AcceptChanges();
                    int affectedRows = adapter.Update(dataTable);

                    if (affectedRows == 0)
                    {
                        MessageBox.Show("Güncelleme işlemi başarısız oldu, çünkü beklenen satır bulunamadı.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı güncelleme hatası: " + ex.Message);
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
                try
                {
                    dataGridView1.EndEdit();
                    using (SqlConnection connection = new SQLBaglantisi().baglanti())
                    {
                        adapter.SelectCommand.Connection = connection;
                        SetDeleteCommand(adapter);

                        // Değişiklikleri kabul edin ve güncelleyin
                        dataTable.AcceptChanges();
                        int affectedRows = adapter.Update(dataTable);

                        if (affectedRows == 0)
                        {
                            MessageBox.Show("Silme işlemi başarısız oldu, çünkü beklenen satır bulunamadı.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanından silme hatası: " + ex.Message);
                    e.Cancel = true; // Hata durumunda silme işlemini iptal et
                }
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                dataGridView1.EndEdit();
                using (SqlConnection connection = new SQLBaglantisi().baglanti())
                {
                    adapter.SelectCommand.Connection = connection;
                    SetInsertCommand(adapter);

                    // Değişiklikleri kabul edin ve güncelleyin
                    dataTable.AcceptChanges();
                    int affectedRows = adapter.Update(dataTable);

                    if (affectedRows == 0)
                    {
                        MessageBox.Show("Ekleme işlemi başarısız oldu.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına ekleme hatası: " + ex.Message);
            }
        }
    }
}
