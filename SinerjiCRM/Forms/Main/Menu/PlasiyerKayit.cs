using System.Data;
using System.Data.SqlClient;
using SinerjiCRM.Scripts;


namespace SinerjiCRM
{
    public partial class PlasiyerKayit : Form
    {

        public PlasiyerKayit()
        {
            InitializeComponent();

        }

        private void PlasiyerKayit_Load(object sender, EventArgs e)
        {
            LoadPlasiyerler();

            LoadIller();

            LoadUlkeler();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string plasiyerKodu = txtPlasiyerKodu.Text;
            string plasiyerAdıSoyadı = txtAdSoyad.Text;
            string plasiyerCinsiyeti = GetSelectedCinsiyet();
            string plasiyerMeslegi = txtMeslek.Text;
            string plasiyerGorevi = txtGorev.Text;
            string plasiyerDepartmani = txtDepartman.Text;
            string plasiyerYoneticisi = txtYonetici.Text;
            string plasiyerMail = txtMail.Text;
            string plasiyerTel = txtTelefon.Text;
            string plasiyerAdres = txtAdres.Text;
            string plasiyerResim = txtResimYolu.Text;
            string plasiyerCv = txtCvYolu.Text;
            string plasiyerIl = cmbIller.SelectedItem?.ToString() ?? string.Empty;
            string plasiyerIlce = cmbIlceler.SelectedItem?.ToString() ?? string.Empty;
            string plasiyerUlke = cmbUlkeler.SelectedItem?.ToString() ?? string.Empty;

            string GetSelectedCinsiyet()
            {
                if (rbErkek.Checked)
                {
                    return "ERKEK";
                }
                else if (rbKadin.Checked)
                {
                    return "KADIN";
                }
                else
                {
                    return string.Empty; // Hiçbir şey seçilmediyse
                }
            }

            using (SqlConnection connection = new Scripts.SQLBaglantisi().baglanti())
            {
                string mergeQuery = @"
            MERGE INTO dbo.PLASIYER AS Target
            USING (VALUES (@plasiyerKodu, @plasiyerAdSoyad, @plasiyerCinsiyeti, @plasiyerMeslegi, @plasiyerGorevi, @plasiyerDepartmani, @plasiyerYoneticisi, @plasiyerMail, @plasiyerTel, @plasiyerAdres, @plasiyerIl, @plasiyerIlce, @plasiyerUlke, @plasiyerResim, @plasiyerCv)) 
            AS Source (PLASIYER_KODU, PLASIYER_ADISOYADI, CINSIYETI, MESLEGI, GOREVI, DEPARTMANI, BAGLI_YONETICI, E_MAIL, TELEFONU, ADRESI, IL, ILCE, ULKE, RESIM, CV)
            ON Target.PLASIYER_KODU = Source.PLASIYER_KODU
            WHEN MATCHED THEN
                UPDATE SET 
                    PLASIYER_ADISOYADI = Source.PLASIYER_ADISOYADI,
                    CINSIYETI = Source.CINSIYETI,
                    MESLEGI = Source.MESLEGI,
                    GOREVI = Source.GOREVI,
                    DEPARTMANI = Source.DEPARTMANI,
                    BAGLI_YONETICI = Source.BAGLI_YONETICI,
                    E_MAIL = Source.E_MAIL,
                    TELEFONU = Source.TELEFONU,
                    ADRESI = Source.ADRESI,
                    IL = Source.IL,
                    ILCE = Source.ILCE,
                    ULKE = Source.ULKE,
                    RESIM = Source.RESIM,
                    CV = Source.CV
            WHEN NOT MATCHED THEN
                INSERT (PLASIYER_KODU, PLASIYER_ADISOYADI, CINSIYETI, MESLEGI, GOREVI, DEPARTMANI, BAGLI_YONETICI, E_MAIL, TELEFONU, ADRESI, IL, ILCE, ULKE, RESIM, CV)
                VALUES (Source.PLASIYER_KODU, Source.PLASIYER_ADISOYADI, Source.CINSIYETI, Source.MESLEGI, Source.GOREVI, Source.DEPARTMANI, Source.BAGLI_YONETICI, Source.E_MAIL, Source.TELEFONU, Source.ADRESI, Source.IL, Source.ILCE, Source.ULKE, Source.RESIM, Source.CV);";

                using (SqlCommand mergeCommand = new SqlCommand(mergeQuery, connection))
                {
                    mergeCommand.Parameters.AddWithValue("@plasiyerKodu", plasiyerKodu);
                    mergeCommand.Parameters.AddWithValue("@plasiyerAdSoyad", plasiyerAdıSoyadı);
                    mergeCommand.Parameters.AddWithValue("@plasiyerCinsiyeti", plasiyerCinsiyeti);
                    mergeCommand.Parameters.AddWithValue("@plasiyerMeslegi", plasiyerMeslegi);
                    mergeCommand.Parameters.AddWithValue("@plasiyerGorevi", plasiyerGorevi);
                    mergeCommand.Parameters.AddWithValue("@plasiyerDepartmani", plasiyerDepartmani);
                    mergeCommand.Parameters.AddWithValue("@plasiyerYoneticisi", plasiyerYoneticisi);
                    mergeCommand.Parameters.AddWithValue("@plasiyerMail", plasiyerMail);
                    mergeCommand.Parameters.AddWithValue("@plasiyerTel", plasiyerTel);
                    mergeCommand.Parameters.AddWithValue("@plasiyerAdres", plasiyerAdres);
                    mergeCommand.Parameters.AddWithValue("@plasiyerIl", plasiyerIl);
                    mergeCommand.Parameters.AddWithValue("@plasiyerIlce", plasiyerIlce);
                    mergeCommand.Parameters.AddWithValue("@plasiyerUlke", plasiyerUlke);
                    mergeCommand.Parameters.AddWithValue("@plasiyerResim", plasiyerResim);
                    mergeCommand.Parameters.AddWithValue("@plasiyerCv", plasiyerCv);

                    int rowsAffected = mergeCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Veriler başarıyla kaydedildi veya güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("Veriler kaydedilirken veya güncellenirken bir hata oluştu.");
                    }
                }
            }
            LoadPlasiyerler();
        }


        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 || dataGridView1.SelectedCells.Count > 0)
            {
                // Seçili satır varsa veya seçili hücre varsa silme işlemini gerçekleştir
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    if (selectedRow.Cells["PLASIYER_KODU"] != null && selectedRow.Cells["PLASIYER_KODU"].Value != null)
                    {
                        string plasiyerKodu = selectedRow.Cells["PLASIYER_KODU"].Value.ToString();
                        plasiyerSil(plasiyerKodu);

                        // Silme işlemi tamamlandıktan sonra DataGridView'i yenile
                        LoadPlasiyerler();
                    }
                    else
                    {
                        MessageBox.Show("Seçili satırın PLASIYER_KODU değeri null olduğu için silme işlemi gerçekleştirilemiyor.");
                    }
                }
                else if (dataGridView1.SelectedCells.Count > 0)
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
                    if (selectedRow.Cells["PLASIYER_KODU"] != null && selectedRow.Cells["PLASIYER_KODU"].Value != null)
                    {
                        string plasiyerKodu = selectedRow.Cells["PLASIYER_KODU"].Value.ToString();
                        plasiyerSil(plasiyerKodu);

                        // Silme işlemi tamamlandıktan sonra DataGridView'i yenile
                        LoadPlasiyerler();
                    }
                    else
                    {
                        MessageBox.Show("Seçili hücrenin bulunduğu satırın PLASIYER_KODU değeri null olduğu için silme işlemi gerçekleştirilemiyor.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz bir satır veya hücre seçin.");
            }
        }


        private void plasiyerSil(string plasiyerKodu)
        {
            using (SqlConnection connection = new SQLBaglantisi().baglanti()) // Veritabanı bağlantısı
            {
                string queryDelete = "DELETE FROM dbo.PLASIYER WHERE PLASIYER_KODU = @plasiyerKodu";

                using (SqlCommand commandDelete = new SqlCommand(queryDelete, connection))
                {
                    commandDelete.Parameters.AddWithValue("@plasiyerKodu", plasiyerKodu);

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

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PlasiyerKayit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms?["SinerjiCRM"]?.Show();
        }

        private void LoadPlasiyerler()
        {
            using (SqlConnection connection = new SQLBaglantisi().baglanti())
            {
                string query = "SELECT * FROM dbo.PLASIYER";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable plasiyerlerTable = new DataTable();
                    adapter.Fill(plasiyerlerTable);

                    // DataGridView'e plasiyerler tablosunu bağla
                    dataGridView1.DataSource = plasiyerlerTable;
                }
            }
        }

        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pcrResim.ImageLocation = openFileDialog1.FileName;
            txtResimYolu.Text = openFileDialog1.FileName;

        }
        private void btnCvEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog pdfAc = new OpenFileDialog();
            pdfAc.Title = "Pdf Aç";
            pdfAc.Filter = "PDF Dosyaları (*.Pdf) | *.Pdf";
            if (pdfAc.ShowDialog() == DialogResult.OK)
            {
                txtCvYolu.Text = pdfAc.FileName;
                axAcropdf1.LoadFile(pdfAc.FileName);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int secilen = e.RowIndex;

                txtPlasiyerKodu.Text = dataGridView1.Rows[secilen].Cells[0].Value?.ToString();
                txtAdSoyad.Text = dataGridView1.Rows[secilen].Cells[1].Value?.ToString();
                txtMeslek.Text = dataGridView1.Rows[secilen].Cells[3].Value?.ToString();
                txtGorev.Text = dataGridView1.Rows[secilen].Cells[4].Value?.ToString();
                txtDepartman.Text = dataGridView1.Rows[secilen].Cells[5].Value?.ToString();
                txtYonetici.Text = dataGridView1.Rows[secilen].Cells[6].Value?.ToString();
                txtMail.Text = dataGridView1.Rows[secilen].Cells[7].Value?.ToString();
                txtTelefon.Text = dataGridView1.Rows[secilen].Cells[8].Value?.ToString();
                txtAdres.Text = dataGridView1.Rows[secilen].Cells[9].Value?.ToString();

                txtResimYolu.Text = dataGridView1.Rows[secilen].Cells[13].Value?.ToString();
                txtCvYolu.Text = dataGridView1.Rows[secilen].Cells[14].Value?.ToString();
                pcrResim.ImageLocation = dataGridView1.Rows[secilen].Cells[13].Value?.ToString();
                axAcropdf1.LoadFile(dataGridView1.Rows[secilen].Cells[14].Value?.ToString());

                string il = dataGridView1.Rows[secilen].Cells[10].Value?.ToString();
                string ilce = dataGridView1.Rows[secilen].Cells[11].Value?.ToString();
                string ulke = dataGridView1.Rows[secilen].Cells[12].Value?.ToString();

                // Combobox'ları temizle
                cmbIller.Items.Clear();
                cmbIlceler.Items.Clear();
                cmbUlkeler.Items.Clear();

                // Eğer il, ilçe veya ülke null değilse, combobox'lara yeni verileri set et
                if (il != null)
                {
                    LoadIller();
                    cmbIller.SelectedItem = il;
                                       
                }

                if (ilce != null)
                {
                    void LoadIlceler(int sehirId)
                    {
                        cmbIlceler.Items.Clear();

                        using (SqlConnection connection = new SQLBaglantisi().baglanti())
                        {
                            string query = "SELECT id, ilceadi FROM ilceler WHERE sehirid = @sehirid";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@sehirid", sehirId);
                                SqlDataReader reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    // İlçeleri ComboBox'a ekle
                                    cmbIlceler.Items.Add((string)reader["ilceadi"]);
                                }
                            }
                        }
                    }
                    cmbIlceler.SelectedItem = ilce;
                }

                if (ulke != null)
                {
                    LoadUlkeler();
                    cmbUlkeler.SelectedItem = ulke;
                }

                if (dataGridView1.Rows[secilen].Cells[2].Value?.ToString() == "ERKEK")
                {
                    rbErkek.Checked = true;
                }
                else if (dataGridView1.Rows[secilen].Cells[2].Value?.ToString() == "KADIN")
                {
                    rbKadin.Checked = true;
                }
                else
                {
                    rbErkek.Checked = false;
                    rbKadin.Checked = false;
                }
            }
        }

        // İl ve ilçeleri veritabanından yükle
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
                        // İlleri ComboBox'a ekle
                        cmbIller.Items.Add((string)reader["sehiradi"]);
                    }
                }
            }
        }

        private void LoadIlceler(int sehirId)
        {
            cmbIlceler.Items.Clear();

            using (SqlConnection connection = new SQLBaglantisi().baglanti())
            {
                string query = "SELECT id, ilceadi FROM ilceler WHERE sehirid = @sehirid";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sehirid", sehirId);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // İlçeleri ComboBox'a ekle
                        cmbIlceler.Items.Add((string)reader["ilceadi"]);
                    }
                }
            }
        }
        private void LoadUlkeler()
        {
            cmbUlkeler.Items.Add("TÜRKİYE");
            cmbUlkeler.Items.Add("Diğer");

        }

        private void cmbIller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIller.SelectedItem != null)
            {
                string sehirAdi = cmbIller.SelectedItem?.ToString() ?? string.Empty; // Seçilen ilin adını al
                int sehirId;

                // Seçilen ilin id'sini bul
                using (SqlConnection connection = new SQLBaglantisi().baglanti())
                {
                    string query = "SELECT id FROM iller WHERE sehiradi = @sehiradi";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@sehiradi", sehirAdi);
                        object result = command.ExecuteScalar();
                        sehirId = result != null ? (int)result : -1; // Varsayılan bir değer kullanabilirsiniz

                        //sehirId = (int)command.ExecuteScalar();
                    }
                }
                if (sehirId != -1)
                {
                    LoadIlceler(sehirId); // Ilceleri yukle
                }
                else
                {
                    //cmbIller.Items.Clear();
                    cmbIlceler.Items.Clear();
                    LoadIller();
                    LoadUlkeler();
                }
                //LoadIlceler(sehirId); // Ilceleri yukle
            }
        }    
    }
}
