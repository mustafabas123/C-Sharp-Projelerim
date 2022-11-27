using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Okul_Projesi
{
    public partial class Frm2_Ogretmen_detay : Form
    {
        SqlBaglanti2 bgl=new SqlBaglanti2();
        public Frm2_Ogretmen_detay()
        {
            InitializeComponent();
        }
 

        private void Frm2_Ogretmen_detay_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select OgrenciAd,OgrenciSoyad,OgrenciTc,OgrenciNotMat from Tbl_ogrenci ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
            
            LblTc2.Text=Frm2_Ogretmen_girisi.OgretmenTc.ToString();
            SqlCommand komut=new SqlCommand("select * from Tbl_ogretmen where OgretmenTc=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", LblTc2.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                lblAd2.Text=dr[1].ToString();
                lblSoyad2.Text=dr[2].ToString();
                lblBrans2.Text=dr[5].ToString();
            }
            bgl.baglanti().Close();
            
            // combbox a sinif verilerini aktarma
            SqlCommand komut2 = new SqlCommand("select distinct Sinif from Tbl_DersProgrami where OgretmenAdSoyad=@a1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@a1", lblAd2.Text+" "+lblSoyad2.Text);
            SqlDataReader dr2=komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBoxSinif.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
            // combbox a şube verilerini aktarma

            SqlCommand komut3 = new SqlCommand("select distinct Sube from Tbl_DersProgrami where OgretmenAdSoyad=@d1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@d1", lblAd2.Text+" "+lblSoyad2.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbBoxSube.Items.Add(dr3[0]);
            }
            bgl.baglanti().Close();

        }
        




        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
     

        }

        private void button1_Click(object sender, EventArgs e)
        {

            


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
