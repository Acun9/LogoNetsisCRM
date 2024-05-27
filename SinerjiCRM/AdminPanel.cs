using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinerji
{
    public partial class AdminPanel : Form
    {
        string kullaniciAdi;
        public AdminPanel(string kullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
        }
        private void AdminPanelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // AdminPanel formu kapatıldığında AnaSayfa formunu yeniden göster            
            Application.OpenForms?["AnaSayfa"]?.Show();
        }

        private void btnPlasiyer_Click(object sender, EventArgs e)
        {
            PlasiyerKayit plasiyerKayitForm = new PlasiyerKayit();
            plasiyerKayitForm.Show();

            this.Hide();
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            MusteriKayit musteriKayitForm = new MusteriKayit(kullaniciAdi);
            musteriKayitForm.Show();

            this.Hide();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
