using System.Data.SqlClient;

namespace Sinerji
{
    internal class SQLBaglantisi
    {
        public SqlConnection baglanti()
        {
            //SqlConnection baglan = new SqlConnection(@"Data Source=DIJITALOFIS1\NETSIS;Initial Catalog=KullaniciGirisi;Integrated Security=True");
            SqlConnection baglan = new SqlConnection("Server=SRV1;Database=SINERJICRM;User Id=sa;Password=SA123pass_;");
            baglan.Open();
            return baglan;
        }
    }
}

