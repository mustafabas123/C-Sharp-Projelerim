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
    public partial class Frm_hasta_detay : Form
    {
        Thread th;
        SqlBaglanti bgl=new SqlBaglanti();
        public string tc;
        public Frm_hasta_detay()
        {
            InitializeComponent();
        }

        private void Frm_hasta_detay_Load(object sender, EventArgs e)
        {
            lblTC.Text = Frm_Hasta_giris.tc.ToString();


            //Ad soyad cekme
            SqlCommand komut = new SqlCommand("select HastaAd,HastaSoyad from Tbl_hastalar where HastaTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text=dr[0]+" "+dr[1];
            }
            bgl.baglanti().Close();

            //randevu gecmisi
            
            DataTable dt=new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_randevular where HastaTC=" + lblTC.Text, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Branslar ekrana yazdirma
            SqlCommand komut2=new SqlCommand("select BransAd from Tbl_brans",bgl.baglanti());
            SqlDataReader dr2=komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("select DoktorAd,DoktorSoyad from Tbl_doktorlar where DoktorBrans=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1",cmbBrans.Text);
            SqlDataReader dr3=komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbDoktor.Items.Add(dr3[0]+" "+dr3[1]);
            }
            bgl.baglanti().Close();
        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_randevular where RandevuBrans='" + cmbBrans.Text + "'" + "and RandevuDoktor='" + cmbDoktor.Text + "'and RandevuDurum=0", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        private void OpenNewForm()
        {
            Application.Run(new Frm_Bilgi_Duzenle());
        }

        private void lnkBilgileriDüzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            th = new Thread(OpenNewForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtBoxId.Text=dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void Btn_randevu_al_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("update Tbl_randevular set RandevuDurum=1,HastaTC=@p2,HastaSikayet=@p3 where RandevuId=@p4",bgl.baglanti());
            komut.Parameters.AddWithValue("@p2", lblTC.Text);
            komut.Parameters.AddWithValue("@p3",richSikayet.Text);
            komut.Parameters.AddWithValue("@p4",txtBoxId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("randevu güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
