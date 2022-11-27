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
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl=new SqlBaglanti();

        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskTC.Text = Frm_giris_doktor.DoktorTC.ToString();
            SqlCommand komut1=new SqlCommand("select * from Tbl_doktorlar where DoktorTC=@p1",bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1",mskTC.Text);
            SqlDataReader dr1=komut1.ExecuteReader();
            while (dr1.Read())
            {
                txtAd.Text = dr1[1].ToString();
                txtSoyad.Text = dr1[2].ToString();
                cmbBrans.Text = dr1[3].ToString();
                txtSifre.Text=dr1[5].ToString();
            }
            bgl.baglanti().Close();
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update Tbl_doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 where DoktorTC=@p5", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtAd.Text);
            komut2.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut2.Parameters.AddWithValue("@p3",cmbBrans.Text);
            komut2.Parameters.AddWithValue("@p4", txtSifre.Text);
            komut2.Parameters.AddWithValue("@p5", mskTC.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktorun bilgileri güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
    }
}
