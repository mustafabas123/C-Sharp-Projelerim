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

namespace Not_sistemi
{
    public partial class Frm3_sifre_alma : Form
    {
        SqlBglanti3 bgl=new SqlBglanti3();
        public Frm3_sifre_alma()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("select * from Tbl_ogretmen where OgretmenAd=@p1 and OgretmenSoyad=@p2 and OgretmenTc=@p3 and OgretmenKullaniciAdi=@p4",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBoxAd.Text);
            komut.Parameters.AddWithValue("@p2", txtBoxSoyad.Text);
            komut.Parameters.AddWithValue("@p3",MskTc.Text);
            komut.Parameters.AddWithValue("@p4", txtBoxKullaniciAdi.Text);
            SqlDataReader dr=komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Şifreniz:"+ "5555","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Yanliş bilgi girdiniz","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            bgl.baglanti().Close();
        }
    }
}
