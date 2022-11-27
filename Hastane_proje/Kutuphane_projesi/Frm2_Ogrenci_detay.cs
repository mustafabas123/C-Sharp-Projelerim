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
    public partial class Frm2_Ogrenci_detay : Form
    {
        SqlBaglanti2 bgl=new SqlBaglanti2();
        public Frm2_Ogrenci_detay()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Frm2_Ogrenci_detay_Load(object sender, EventArgs e)
        {
            // Ogrenci bilgilerini çekme
            lblTc.Text = Frm2_Ogrenci_girisi.tc.ToString();
            SqlCommand komut = new SqlCommand("select * from Tbl_Ogrenci where OgrenciTc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",lblTc.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                LblAd.Text=dr[1].ToString();
                lblSoyad.Text=dr[2].ToString();
                lblSinif.Text=dr[9].ToString();
                lblSube.Text=dr[8].ToString();
                lblTurkce.Text=dr[5].ToString();
                lblMat.Text=dr[6].ToString();
                lblSosyal.Text=dr[7].ToString();
            }
            bgl.baglanti().Close();
            // Ogrenci ortalamasını çekme
            /*
            SqlCommand komut2 = new SqlCommand("select (OgrenciNot1+OgrenciNot2+OgrenciNot3)/3 from Tbl_Ogrenci where OgrenciTc=@a1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@a1", lblTc.Text);
            SqlDataReader dr2=komut2.ExecuteReader();
            if (dr2.Read())
            {
                lblOrtalama.Text=dr2[0].ToString();
            }
            */
            //Ders programı
            
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select OgretmenAdSoyad as 'Öğretmenler',OgretmenBrans as 'Branşlar' from Tbl_DersProgrami where Sinif='" + lblSinif.Text + "'"+"and Sube='"+lblSube.Text+"'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
            
            
        }
    }
}
