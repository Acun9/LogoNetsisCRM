using System.Data.SqlClient;



namespace C_Forms
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

//namespace C_Forms
//{
//    internal class SQLBaglantisi
//    {
//        public SqlConnection baglanti()
//        {
//            //SqlConnection baglan = new SqlConnection(@"Data Source=DIJITALOFIS1\NETSIS;Initial Catalog=KullaniciGirisi;Integrated Security=True");
//            SqlConnection baglan = new SqlConnection("Server=SRV1;Database=SINERJICRM;User Id=sa;Password=SA123pass_;");
//            baglan.Open();
//            return baglan;
//        }

//        private Kernel kernel;
//        private Sirket sirket;

//        public SQLBaglantisi()
//        {
//            InitializeNetOpenX();
//        }

//        private void InitializeNetOpenX()
//        {
//            kernel = new Kernel();
//            sirket = kernel.yeniSirket(TVTTipi.vtMSSQL, "SINERJISMART", "TEMELSET", "", "netsis", "5091", 0);
//        }

//        public Kernel GetKernel()
//        {
//            return kernel;
//        }

//        public Sirket GetSirket()
//        {
//            return sirket;
//        }

//        public void CleanupNetOpenX()
//        {
//            Marshal.ReleaseComObject(sirket);
//            kernel.FreeNetsisLibrary();
//            Marshal.ReleaseComObject(kernel);
//        }
//    }
//}

