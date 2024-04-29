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
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-J2B6H4Q\SQLEXPRESS;Initial Catalog=KullaniciGirisi;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }

    /*

    using (SqlConnection connection = new SQLBaglantisi().baglanti())
            {
                string query = "SELECT KULLANICI_MAIL, SIFRE FROM KULLANICI WHERE KULLANICI_ADISOYADI = @kullaniciAdi";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@kullaniciAdi", txtKullaniciAdi.Text); // Kullanıcı adı textbox'ından alınabilir
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {                        
                        kullaniciMail = reader["KULLANICI_MAIL"].ToString();
                        dogruSifre = reader["SIFRE"].ToString() ;
                    }
                }
            }

    */

}

