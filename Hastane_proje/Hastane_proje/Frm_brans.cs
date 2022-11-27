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
    public partial class Frm_brans : Form
    {
        SqlBaglanti bgl=new SqlBaglanti();
        void bilgileri_getir()
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Tbl_brans", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            bgl.baglanti().Close();

        }
        public Frm_brans()
        {
            InitializeComponent();
        }



        private void Frm_brans_Load(object sender, EventArgs e)
        {
            bilgileri_getir();

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_brans (BransAd) values(@p2)", bgl.baglanti());
            
            komut.Parameters.AddWithValue("@p2", txtBoxAd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            bilgileri_getir();
            MessageBox.Show("Brans eklendi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Tbl_brans where BransId=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBoxId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            bilgileri_getir();
            MessageBox.Show("Brans silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtBoxId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtBoxAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_brans set BransAd=@a2 where BransId=@a1", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1",txtBoxId.Text);
            komut.Parameters.AddWithValue("@a2",txtBoxAd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            bilgileri_getir();
            MessageBox.Show("Branslar güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
