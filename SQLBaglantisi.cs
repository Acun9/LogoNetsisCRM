using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace C_Forms
{
    internal class SQLBaglantisi
    {
        public SqlConnection baglanti()
        {
            //SqlConnection baglan = new SqlConnection(@"Data Source=DIJITALOFIS1\NETSIS;Initial Catalog=KullaniciGirisi;Integrated Security=True");
            SqlConnection baglan = new SqlConnection("Server=DIJITALOFIS1\\NETSIS;Database=NETSISTEST1;User Id=sa;Password=SA123pass_;");
            baglan.Open();
            return baglan;
        }
    }
}

