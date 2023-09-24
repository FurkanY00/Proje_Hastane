using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Proje_Hastane
{
    internal class sqlbaglantısı
    {
        public SqlConnection baglantı()
        {
            
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-KPC6PV7\\SQLEXPRESS;Initial Catalog=hastaneproje;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
      
    }
}
