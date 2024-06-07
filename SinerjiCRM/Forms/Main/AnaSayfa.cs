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
            Application.OpenForms?["AnaSayfa"]?.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKisi_Click(object sender, EventArgs e)
        {
            KisiKayit plasiyerKayitForm = new KisiKayit();
            plasiyerKayitForm.Show();
            this.Hide();
        }

        private void btnSatisTeklif_Click(object sender, EventArgs e)
        {
            SatisTeklif satisTeklifForm = new SatisTeklif();
            satisTeklifForm.Show();
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
