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

namespace Hastane_proje
{
    public partial class Frm_Bilgi_Duzenle : Form
    {
        SqlBaglanti bgl=new SqlBaglanti();
        public Frm_Bilgi_Duzenle()
        {
            InitializeComponent();
        }

        private void Frm_Bilgi_Duzenle_Load(object sender, EventArgs e)
        {
            mskTC.Text = Frm_Hasta_giris.tc.ToString();
            SqlCommand komut=new SqlCommand("select * from Tbl_hastalar where HastaTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",mskTC.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                mskTelefon.Text=dr[4].ToString();
                txtSifre.Text=dr[5].ToString();
                cmbCinsiyet.Text=dr[6].ToString();

            }
            bgl.baglanti().Close();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update Tbl_hastalar set HastaAd=@p1,HastaSoyad=@p2,HastaTelefon=@p4,HastaSifre=@p5,HastaCinsiyet=@p6 where HastaTC=@p3", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1",txtAd.Text);
            komut2.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut2.Parameters.AddWithValue("@p3", mskTC.Text);
            komut2.Parameters.AddWithValue("@p4", mskTelefon.Text);
            komut2.Parameters.AddWithValue("@p5", txtSifre.Text);
            komut2.Parameters.AddWithValue("@p6", cmbCinsiyet.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgiler güncellendi ","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);



        }
    }
}
