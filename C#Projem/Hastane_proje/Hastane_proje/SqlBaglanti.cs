using System.Data.SqlClient;

namespace Hastane_proje
{
    internal class SqlBaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-GLTFK1B;Initial Catalog=Hastane;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
