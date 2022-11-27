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
    public partial class Frm2_ogrenci_islemleri : Form
    {
        SqlBaglanti2 bgl=new SqlBaglanti2();
        public Frm2_ogrenci_islemleri()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        void bilgileri_getir()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_ogrenci ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void temizle()
        {
            txtBoxAd.Clear();
            txtBoxSoyad.Clear();
            mskBoxTc.Clear();
            txtBoxSifre.Clear();
            txtBoxSube.Clear();
            txtBoxSinif.Clear();
            txtBoxAd.Focus();
        }
        private void Frm2_ogrenci_islemleri_Load(object sender, EventArgs e)
        {
            bilgileri_getir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_ogrenci (OgrenciAd,OgrenciSoyad,OgrenciTc,OgrenciSifre,OgrenciSube,OgrenciSinif) values(@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBoxAd.Text);
            komut.Parameters.AddWithValue("@p2", txtBoxSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskBoxTc.Text);
            komut.Parameters.AddWithValue("@p4", txtBoxSifre.Text);
            komut.Parameters.AddWithValue("@p5", txtBoxSube.Text);
            komut.Parameters.AddWithValue("@p6", txtBoxSinif.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgi Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            bilgileri_getir();
            temizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_ogrenci set OgrenciAd=@a1,OgrenciSoyad=@a2,OgrenciTc=@a3,OgrenciSifre=@a4,OgrenciSube=@a5,OgrenciSinif=@a6 where OgregciId=@a7", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", txtBoxAd.Text);
            komut.Parameters.AddWithValue("@a2", txtBoxSoyad.Text);
            komut.Parameters.AddWithValue("@a3", mskBoxTc.Text);
            komut.Parameters.AddWithValue("@a4", txtBoxSifre.Text);
            komut.Parameters.AddWithValue("@a5", txtBoxSube.Text);
            komut.Parameters.AddWithValue("@a6", txtBoxSinif.Text);
            komut.Parameters.AddWithValue("@a7", txtBoxId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgiler güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            bilgileri_getir();
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtBoxId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtBoxAd.Text= dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtBoxSoyad.Text= dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            mskBoxTc.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtBoxSifre.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtBoxSinif.Text= dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            txtBoxSube.Text= dataGridView1.Rows[secilen].Cells[8].Value.ToString();
        }
    }
}
