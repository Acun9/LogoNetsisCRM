using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Forms
{
    public partial class MusteriKayit : Form
    {
        string? kullaniciAdi;
        public MusteriKayit(string kullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MusteriKayit_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (kullaniciAdi == "admin")
            {
                Application.OpenForms?["AdminPanel"]?.Show();
            }
            else
            {
                Application.OpenForms?["AnaSayfa"]?.Show();
            }    
            
        }
    }
}
