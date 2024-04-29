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
using System.IO;

namespace C_Forms
{
    public partial class PlasiyerKayit : Form
    {
        public PlasiyerKayit()
        {
            InitializeComponent();

            LoadPlasiyerler();

            LoadIller();

            LoadUlkeler();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string plasiyerKodu = txtPlasiyerKodu.Text;
            string plasiyerAdıSoyadı = txtAdSoyad.Text;
            string plasiyerCinsiyeti = "";
            string plasiyerMeslegi = txtMeslek.Text;
            string plasiyerGorevi = txtGorev.Text;
            string plasiyerDepartmani = txtDepartman.Text;
            string plasiyerYoneticisi = txtYonetici.Text;
            string plasiyerMail = txtMail.Text;
            string plasiyerTel = txtTelefon.Text;
            string plasiyerAdres = txtAdres.Text;
            string plasiyerResim = txtResimYolu.Text;
            string plasiyerCv = txtCvYolu.Text;
            string plasiyerIl = "";
            string plasiyerIlce = "";
            string plasiyerUlke = "";


            if (rbErkek.Checked)
            {
                plasiyerCinsiyeti = rbErkek.Text;
            }
            else if (rbKadin.Checked)
            {
                plasiyerCinsiyeti = rbKadin.Text;
            }

            if (cmbIller.SelectedItem != null)
            {
                plasiyerIl = cmbIller.SelectedItem.ToString();
            }

            if (cmbIlceler.SelectedItem != null)
            {
                plasiyerIlce = cmbIlceler.SelectedItem.ToString();
            }

            if (cmbUlkeler.SelectedItem != null)
            {
                plasiyerUlke = cmbUlkeler.SelectedItem.ToString();
            }


            using (SqlConnection connection = new SQLBaglantisi().baglanti()) // Veritabanı bağlantısı
            {
                string queryCheckExisting = "SELECT COUNT(*) FROM dbo.PLASIYER WHERE PLASIYER_KODU = @plasiyerKodu";
                using (SqlCommand commandCheckExisting = new SqlCommand(queryCheckExisting, connection))
                {
                    commandCheckExisting.Parameters.AddWithValue("@plasiyerKodu", plasiyerKodu);
                    int existingCount = (int)commandCheckExisting.ExecuteScalar();

                    if (existingCount > 0)
                    {
                        // Primery key zaten varsa güncelleme yap
                        string queryUpdate = @"UPDATE dbo.PLASIYER SET 
                                               PLASIYER_ADISOYADI = @plasiyerAdSoyad,
                                               CINSIYETI = @plasiyerCinsiyeti,
                                               MESLEGI = @plasiyerMeslegi,
                                               GOREVI = @plasiyerGorevi,
                                               DEPARTMANI = @plasiyerDepartmani,
                                               BAGLI_YONETICI = @plasiyerYoneticisi,
                                               E_MAIL = @plasiyerMail,
                                               TELEFONU = @plasiyerTel,
                                               ADRESI = @plasiyerAdres,
                                               Il = @plasiyerIl,
                                               Ilce = @plasiyerIlce,
                                               Ulke = @plasiyerUlke,
                                               RESIM = @plasiyerResim,
                                               CV = @plasiyerCv 
                                               WHERE PLASIYER_KODU = @plasiyerKodu";

                        using (SqlCommand commandUpdate = new SqlCommand(queryUpdate, connection))
                        {
                            commandUpdate.Parameters.AddWithValue("@plasiyerKodu", plasiyerKodu);
                            commandUpdate.Parameters.AddWithValue("@plasiyerAdSoyad", plasiyerAdıSoyadı);
                            commandUpdate.Parameters.AddWithValue("@plasiyerCinsiyeti", plasiyerCinsiyeti);
                            commandUpdate.Parameters.AddWithValue("@plasiyerMeslegi", plasiyerMeslegi);
                            commandUpdate.Parameters.AddWithValue("@plasiyerGorevi", plasiyerGorevi);
                            commandUpdate.Parameters.AddWithValue("@plasiyerDepartmani", plasiyerDepartmani);
                            commandUpdate.Parameters.AddWithValue("@plasiyerYoneticisi", plasiyerYoneticisi);
                            commandUpdate.Parameters.AddWithValue("@plasiyerMail", plasiyerMail);
                            commandUpdate.Parameters.AddWithValue("@plasiyerTel", plasiyerTel);
                            commandUpdate.Parameters.AddWithValue("@plasiyerAdres", plasiyerAdres);
                            commandUpdate.Parameters.AddWithValue("@plasiyerIl", plasiyerIl);
                            commandUpdate.Parameters.AddWithValue("@plasiyerIlce", plasiyerIlce);
                            commandUpdate.Parameters.AddWithValue("@plasiyerUlke", plasiyerUlke);
                            commandUpdate.Parameters.AddWithValue("@plasiyerResim", plasiyerResim);
                            commandUpdate.Parameters.AddWithValue("@plasiyerCv", plasiyerCv);

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
                        // Yeni bir kayıt ekle
                        string queryInsert = @"INSERT INTO dbo.PLASIYER (PLASIYER_KODU, PLASIYER_ADISOYADI, CINSIYETI, MESLEGI, GOREVI, DEPARTMANI, BAGLI_YONETICI, E_MAIL, TELEFONU, ADRESI, IL, ILCE, ULKE, RESIM, CV) 
                               VALUES (@plasiyerKodu, @plasiyerAdSoyad, @plasiyerCinsiyeti, @plasiyerMeslegi, @plasiyerGorevi, @plasiyerDepartmani, @plasiyerYoneticisi, @plasiyerMail, @plasiyerTel, @plasiyerAdres, @plasiyerIl, @plasiyerIlce, @plasiyerUlke, @plasiyerResim, @plasiyerCv)";

                        using (SqlCommand commandInsert = new SqlCommand(queryInsert, connection))
                        {
                            commandInsert.Parameters.AddWithValue("@plasiyerKodu", plasiyerKodu);
                            commandInsert.Parameters.AddWithValue("@plasiyerAdSoyad", plasiyerAdıSoyadı);
                            commandInsert.Parameters.AddWithValue("@plasiyerCinsiyeti", plasiyerCinsiyeti);
                            commandInsert.Parameters.AddWithValue("@plasiyerMeslegi", plasiyerMeslegi);
                            commandInsert.Parameters.AddWithValue("@plasiyerGorevi", plasiyerGorevi);
                            commandInsert.Parameters.AddWithValue("@plasiyerDepartmani", plasiyerDepartmani);
                            commandInsert.Parameters.AddWithValue("@plasiyerYoneticisi", plasiyerYoneticisi);
                            commandInsert.Parameters.AddWithValue("@plasiyerMail", plasiyerMail);
                            commandInsert.Parameters.AddWithValue("@plasiyerTel", plasiyerTel);
                            commandInsert.Parameters.AddWithValue("@plasiyerAdres", plasiyerAdres);
                            commandInsert.Parameters.AddWithValue("@plasiyerIl", plasiyerIl);
                            commandInsert.Parameters.AddWithValue("@plasiyerIlce", plasiyerIlce);
                            commandInsert.Parameters.AddWithValue("@plasiyerUlke", plasiyerUlke);
                            commandInsert.Parameters.AddWithValue("@plasiyerResim", plasiyerResim);
                            commandInsert.Parameters.AddWithValue("@plasiyerCv", plasiyerCv);

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

                if (dataGridView1.Rows[secilen].Cells[2].Value?.ToString() == "Erkek")
                {
                    rbErkek.Checked = true;
                }
                else if (dataGridView1.Rows[secilen].Cells[2].Value?.ToString() == "Kadın")
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
                string sehirAdi = cmbIller.SelectedItem.ToString(); // Seçilen ilin adını al
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

        private void PlasiyerKayit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["AdminPanel"].Show();
        }
    }
}
