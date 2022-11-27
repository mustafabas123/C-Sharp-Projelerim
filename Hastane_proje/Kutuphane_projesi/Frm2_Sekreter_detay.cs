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
    public partial class Frm2_Sekreter_detay : Form
    {
        Thread th;
        SqlBaglanti2 bgl=new SqlBaglanti2();
        public Frm2_Sekreter_detay()
        {
            InitializeComponent();
        }
        private void OpenNewForm1()
        {
            Application.Run(new Frm2_ogrenci_islemleri());
        }
        private void OpenNewForm2()
        {
            Application.Run(new Frm2_ogretmen_islemleri());
        }
 
 


        private void Frm2_Sekreter_detay_Load(object sender, EventArgs e)
        {
            // Sekreter bilgilerini getirme
            lblTc.Text =Frm2_Sekreter_girisi.SekreterTc.ToString();
            SqlCommand komut=new SqlCommand("select * from Tbl_sekreter where SekreterTc=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTc.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                lblAd.Text=dr[1].ToString();
                lblSoyad.Text=dr[2].ToString();
            }
            bgl.baglanti().Close();
            // Öğretmen bilgilerini ekrana yazdırma
            DataTable dt=new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select (OgretmenAd+' '+OgretmenSoyad) as 'Öğretmenler',OgretmenBrans as 'Branşlar'  from Tbl_ogretmen", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            // şube ve sınıf bilgilerini ekrana yazdırma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select distinct OgrenciSinif,OgrenciSube From Tbl_ogrenci", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            // sınıf bilgilerini combbox a aktarma
            SqlCommand komut2 = new SqlCommand("select distinct OgrenciSinif from Tbl_ogrenci", bgl.baglanti());
            SqlDataReader dr2=komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBoxSinif.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
            // Şube bilgilerini combbox a aktarma
            SqlCommand komut3 = new SqlCommand("select distinct OgrenciSube from Tbl_ogrenci", bgl.baglanti());
            SqlDataReader dr3=komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbBoxSube.Items.Add(dr3[0]);
            }
            bgl.baglanti().Close();
            // Öğretmenler bransini combobax a aktarma
            SqlCommand komut4 = new SqlCommand("select distinct OgretmenBrans from Tbl_ogretmen", bgl.baglanti());
            SqlDataReader dr4=komut4.ExecuteReader();
            while(dr4.Read())
            {
                cmbBoxBrans.Items.Add(dr4[0]);
            }
            bgl.baglanti().Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            th = new Thread(OpenNewForm2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            th = new Thread(OpenNewForm1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
    
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
    
        }

        private void cmbBoxSinif_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbBoxBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBoxOgremen.Items.Clear();
            SqlCommand komut=new SqlCommand("select OgretmenAd,OgretmenSoyad from Tbl_ogretmen where OgretmenBrans=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",cmbBoxBrans.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                cmbBoxOgremen.Items.Add(dr[0] + " " + dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_DersProgrami (OgretmenAdSoyad,OgretmenBrans,Sinif,Sube) values(@p1,@p2,@p3,@p4)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbBoxOgremen.Text);
            komut.Parameters.AddWithValue("@p2", cmbBoxBrans.Text);
            komut.Parameters.AddWithValue("@p3", cmbBoxSinif.Text);
            komut.Parameters.AddWithValue("@p4", cmbBoxSube.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Bilgiler kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bgl.baglanti().Close();
        }
    }
}
