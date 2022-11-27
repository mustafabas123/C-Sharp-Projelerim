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
    public partial class Frm_doktor_paneli : Form
    {
        public Frm_doktor_paneli()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl=new SqlBaglanti();
        void bilgileri_getir()
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Tbl_Doktorlar", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            bgl.baglanti().Close();

        }
        void bilgileri_temizle()
        {
            txtBoxAd.Clear();
            txtBoxSoyad.Clear();
            txtBoxSifre.Clear();
            mskBoxTC.Clear();
            

        }

        private void Frm_doktor_paneli_Load(object sender, EventArgs e)
        {
            bilgileri_getir();
            SqlCommand komut2 = new SqlCommand("select BransAd from Tbl_brans", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBoxBrans.Items.Add(dr2[0]);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("insert into Tbl_doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values(@p1,@p2,@p3,@p4,@p5)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBoxAd.Text);
            komut.Parameters.AddWithValue("@p2", txtBoxSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbBoxBrans.Text);
            komut.Parameters.AddWithValue("@p4",mskBoxTC.Text);
            komut.Parameters.AddWithValue("@p5", txtBoxSifre.Text);
            komut.ExecuteNonQuery();
            bilgileri_getir();
            bilgileri_temizle();
            MessageBox.Show("Bilgiler eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtBoxAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtBoxSoyad.Text= dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbBoxBrans.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskBoxTC.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtBoxSifre.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("delete from Tbl_doktorlar where DoktorTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",mskBoxTC.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            bilgileri_getir();
            bilgileri_temizle();
            MessageBox.Show("Doktor bilgisi silindi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p5 where DoktorTC=@p4", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBoxAd.Text);
            komut.Parameters.AddWithValue("@p2", txtBoxSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbBoxBrans.Text);
            komut.Parameters.AddWithValue("@p4", mskBoxTC.Text);
            komut.Parameters.AddWithValue("@p5", txtBoxSifre.Text);
            komut.ExecuteNonQuery();
            bilgileri_getir();
            bilgileri_temizle();
            MessageBox.Show("Bilgiler Güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
