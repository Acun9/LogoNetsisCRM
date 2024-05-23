using C_Forms;
using NetOpenX50;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinerjiPanel
{
    public partial class CariKayit : Form
    {
        private Kernel kernel;
        private Sirket sourceSirket;
        private Sirket destinationSirket;

        public CariKayit()
        {
            InitializeComponent();
        }

        private void CariKayit_Load(object sender, EventArgs e)
        {
            LoadComboboxData();            
        }

        private void InitializeNetOpenX()
        {
            kernel = new Kernel();
            sourceSirket = kernel.yeniSirket(TVTTipi.vtMSSQL, "SINERJICRM", "sa", "SA123pass_", "netsis", "5091", 0);
            destinationSirket = kernel.yeniSirket(TVTTipi.vtMSSQL, "SINERJISMART", "TemelSet", "", "netsis", "5091", 0);
        }

        private void btnAktar_Click(object sender, EventArgs e)
        {
            InitializeNetOpenX();
            try
            {
                string selectQuery = "SELECT * FROM CARI_KAYIT";
                using (SqlConnection sourceConnection = new SqlConnection("Server=SRV1;Database=SINERJICRM;User Id=sa;Password=SA123pass_;"))
                {
                    sourceConnection.Open();
                    SqlCommand selectCommand = new SqlCommand(selectQuery, sourceConnection);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProcessRecord(reader);
                        }
                    }
                }

                DeleteRemovedRecords();
                MessageBox.Show("Veri aktarımı başarıyla tamamlandı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri aktarımı sırasında hata oluştu: {ex.Message}");
            }
            finally
            {
                CleanupNetOpenX();
            }
        }

        private void ProcessRecord(SqlDataReader reader)
        {
            // NetOpenX kullanarak veri ekleme/güncelleme mantığı
            Cari cari = kernel.yeniCari(destinationSirket);
            CariTemelBilgi cariTmlBlg = cari.TemelBilgi();
            CariEkBilgi cariEkBlg = cari.EkBilgi();




            // Veritabanı alanlarını Cari nesnesine ayarla
            cariTmlBlg.CARI_KOD = reader["CARI_KOD"].ToString();
            cariTmlBlg.CARI_ISIM = reader["CARI_ISIM"].ToString();
            cariTmlBlg.CARI_ADRES = reader["ADRES"].ToString();
            cariTmlBlg.ULKE_KODU = reader["ULKE"].ToString();
            cariTmlBlg.CARI_IL = reader["IL"].ToString();
            cariTmlBlg.CARI_ILCE = reader["ILCE"].ToString();
            cariTmlBlg.POSTAKODU = reader["POSTA_KODU"].ToString();
            cariTmlBlg.CARI_TEL = reader["TEL"].ToString();
            cariTmlBlg.FAX = reader["FAKS"].ToString();
            cariTmlBlg.EMAIL = reader["MAIL"].ToString();
            cariTmlBlg.WEB = reader["WEB"].ToString();
            cariTmlBlg.VERGI_DAIRESI = reader["VERGI_DAIRE"].ToString();
            cariTmlBlg.VERGI_NUMARASI = reader["VERGI_NO"].ToString();
            cariTmlBlg.Grup_Kodu = reader["GRUP_KODU"].ToString();
            cariTmlBlg.RAPOR_KODU1 = reader["RAPOR_KODU_1"].ToString();
            cariTmlBlg.Rapor_Kodu2 = reader["RAPOR_KODU_2"].ToString();
            cariTmlBlg.Sube_Kodu = 0; // Varsayılan değer
            cariTmlBlg.ISLETME_KODU = 1; // Varsayılan değer

            // Veritabanına kaydet
            cari.kayitYeni();
        }

        private void DeleteRemovedRecords()
        {
            // NetOpenX kullanarak kayıtları silme mantığı
            using (SqlConnection destinationConnection = new SqlConnection("Server=SRV1;Database=SINERJISMART;User Id=netsis;Password=5091;"))
            {
                destinationConnection.Open();
                string deleteQuery = @"
                DELETE FROM TBLCASABIT
                WHERE CARI_KOD NOT IN (SELECT CARI_KOD FROM [SINERJICRM].[dbo].[CARI_KAYIT])";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, destinationConnection);
                deleteCommand.ExecuteNonQuery();
            }
        }

        private void CleanupNetOpenX()
        {
            Marshal.ReleaseComObject(destinationSirket);
            Marshal.ReleaseComObject(sourceSirket);
            kernel.FreeNetsisLibrary();
            Marshal.ReleaseComObject(kernel);
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
    }
}