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
    public partial class Frm2_ogretmen_islemleri : Form
    {
        SqlBaglanti2 bgl=new SqlBaglanti2();
        public Frm2_ogretmen_islemleri()
        {
            InitializeComponent();
        }
        void temizle()
        {
            txtBoxAd.Clear();
            txtBoxId.Clear();
            txtBoxSoyad.Clear();
            txtBoxBrans.Clear();
            txtBoxSifre.Clear();
            mskBoxTc.Clear();
            txtBoxAd.Focus();
        }
        void bilgileri_getir()
        {
           DataTable dt = new DataTable();
           SqlDataAdapter da=new SqlDataAdapter("select * from Tbl_ogretmen",bgl.baglanti());
           da.Fill(dt);
           dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("insert into Tbl_ogretmen (OgretmenAd,OgretmenSoyad,OgretmenTc,OgretmenSifre,OgretmenBrans) values(@p1,@p2,@p3,@p4,@p5)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBoxAd.Text);
            komut.Parameters.AddWithValue("@p2", txtBoxSoyad.Text);
            komut.Parameters.AddWithValue("@p3",mskBoxTc.Text);
            komut.Parameters.AddWithValue("@p4", txtBoxSifre.Text);
            komut.Parameters.AddWithValue("@p5", txtBoxBrans.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgi Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bilgileri_getir();
            temizle();

        }

        private void Frm2_ogretmen_islemleri_Load(object sender, EventArgs e)
        {
            bilgileri_getir();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtBoxId.Text= dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtBoxAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtBoxSoyad.Text= dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            mskBoxTc.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtBoxSifre.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtBoxBrans.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_ogretmen set OgretmenAd=@p1,OgretmenSoyad=@p2,OgretmenTc=@p3,OgretmenSifre=@p4,OgretmenBrans=@p5 where OgretmenId=@p6", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBoxAd.Text);
            komut.Parameters.AddWithValue("@p2", txtBoxSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskBoxTc.Text);
            komut.Parameters.AddWithValue("@p4", txtBoxSifre.Text);
            komut.Parameters.AddWithValue("@p5", txtBoxBrans.Text);
            komut.Parameters.AddWithValue("@p6", txtBoxId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgile Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bilgileri_getir();
            temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Tbl_ogretmen where OgretmenId=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBoxId.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Bilgiler silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            bilgileri_getir();
            temizle();

        }
    }
}
