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
    public partial class Frm3_ogretmen_detay : Form
    {
        SqlBglanti3 bgl=new SqlBglanti3();
        public Frm3_ogretmen_detay()
        {
            InitializeComponent();
        }
        void Bilgileri_getir()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select OgrenciId as Id,OgrenciNumara as Numara,(OgrenciAd+' '+OgrenciSoyad) as Öğrenciler,Not1,Not2,Not3 from Tbl_ogrenci", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();

        }
        void yuksek_dusuk_not_hesaplama()
        {
            //1 . not max 
            SqlCommand komut1=new SqlCommand("select max(Not1) from Tbl_ogrenci",bgl.baglanti());
            SqlDataReader dr1=komut1.ExecuteReader();
            if (dr1.Read())
            {
                lbl1seyn.Text=dr1[0].ToString();
            }
            bgl.baglanti().Close();
            //2. not max 
            SqlCommand komut2 = new SqlCommand("select max(Not2) from Tbl_ogrenci", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            if (dr2.Read())
            {
                lbl2SEYN.Text = dr2[0].ToString();
            }
            bgl.baglanti().Close();
            //3. not max 
            SqlCommand komut3 = new SqlCommand("select max(Not3) from Tbl_ogrenci", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            if (dr3.Read())
            {
                lbl3SEYN.Text = dr3[0].ToString();
            }
            bgl.baglanti().Close();
            //1. not min
            SqlCommand komut4 = new SqlCommand("select min(Not1) from Tbl_ogrenci", bgl.baglanti());
            SqlDataReader dr4=komut4.ExecuteReader();
            if (dr4.Read())
            {
                lblSEDN.Text = dr4[0].ToString();
            }
            bgl.baglanti().Close();
            //2. not min
            SqlCommand komut5 = new SqlCommand("select min(Not2) from Tbl_ogrenci", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            if (dr5.Read())
            {
                lbl2SEDN.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();
            //3. not min
            SqlCommand komut6 = new SqlCommand("select min(Not3) from Tbl_ogrenci", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            if (dr6.Read())
            {
                lbl3SEDN.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();

        }
        

        void Ortalama_hesaplama()
        {
            int s1, s2, s3,sonuc;
            string durum;
            SqlCommand komut2=new SqlCommand("select avg(Not1),avg(Not2),avg(Not3) from Tbl_ogrenci",bgl.baglanti());
            SqlDataReader dr2=komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblNot1.Text = dr2[0].ToString();
                lblNot2.Text = dr2[1].ToString();
                lblNot3.Text=dr2[2].ToString();
            }
             s1= Convert.ToInt32(lblNot1.Text);
             s2= Convert.ToInt32(lblNot2.Text);
             s3= Convert.ToInt32(lblNot3.Text);
            sonuc = (s1 + s2 + s3) / 3;
            lblSinifOrtalmasi.Text=sonuc.ToString();
            bgl.baglanti().Close();
            

        }
        void ogrenci_sayisi()
        {
            SqlCommand komut = new SqlCommand("select count(OgrenciAd) from Tbl_ogrenci", bgl.baglanti());
            SqlDataReader dr=komut.ExecuteReader();
            if (dr.Read())
            {
                lblOgrenciSayisi.Text = dr[0].ToString();
            }
        }
 

        private void Frm3_ogretmen_detay_Load(object sender, EventArgs e)
        {
            Bilgileri_getir();
            Ortalama_hesaplama();
            ogrenci_sayisi();
            yuksek_dusuk_not_hesaplama();
    
            lblKullaniciAdi.Text = Frm3_ogretmen_giris.Kullanici_adi.ToString();
            SqlCommand komut1=new SqlCommand("select * from Tbl_ogretmen where OgretmenKullaniciAdi=@p1",bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1",lblKullaniciAdi.Text);
            SqlDataReader dr1=komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblAdSoyad.Text = dr1[1] +" "+ dr1[2];
                lblKullaniciAdi.Text = dr1[4].ToString();
                lblTc.Text = dr1[3].ToString();
            }
            bgl.baglanti().Close();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtBoxNot1.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtBoxNot2.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtBoxNot3.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            lblNumara2.Text= dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            lblAdSoyad2.Text= dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlCommand komut=new SqlCommand("update Tbl_ogrenci set Not1=@p1,Not2=@p2,Not3=@p3 where OgrenciNumara=@p4",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBoxNot1.Text);
            komut.Parameters.AddWithValue("@p2", txtBoxNot2.Text);
            komut.Parameters.AddWithValue("@p3", txtBoxNot3.Text);
            komut.Parameters.AddWithValue("@p4", lblNumara2.Text);           
            komut.ExecuteNonQuery();
            MessageBox.Show("Öğrencinin notları güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Bilgileri_getir();
            Ortalama_hesaplama();
            ogrenci_sayisi();
            yuksek_dusuk_not_hesaplama();
            bgl.baglanti().Close();
            txtBoxNot1.Clear();
            txtBoxNot2.Clear();
            txtBoxNot3.Clear();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
