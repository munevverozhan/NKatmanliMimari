using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace LayerDataAccess
{
    public class Baglanti
    {
           //static tanımladığımız için nesne oluşturmadan ; bu değişkene sınıf adı ile  erişim sağlanabilir.
           public static SqlConnection conn = new SqlConnection("Data Source=DESKTOP-GBKS0E6;Initial Catalog=DBPersonel;Integrated Security=True");
    }
}
