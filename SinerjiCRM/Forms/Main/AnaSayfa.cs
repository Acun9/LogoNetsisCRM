using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinerjiCRM
{
    public partial class AnaSayfa : Form
    {

        public AnaSayfa()
        {
            InitializeComponent();

        }

        private void SinerjiCRM_FormClosed(object sender, FormClosedEventArgs e)
        {
            // SinerjiCRM formu kapatıldığında Giris formunu yeniden göster            
            Application.OpenForms?["Giris"]?.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKisi_Click(object sender, EventArgs e)
        {
            PlasiyerKayit plasiyerKayitForm = new PlasiyerKayit();
            plasiyerKayitForm.Show();
            this.Hide();
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            MusteriKayit musteriKayitForm = new MusteriKayit();
            musteriKayitForm.Show();
            this.Hide();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            CariKayit cariKayitForm = new CariKayit();
            cariKayitForm.Show();
            this.Hide();
        }
    }
}
