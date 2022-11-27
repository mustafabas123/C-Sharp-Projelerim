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
    public partial class Frm_Hasta_kayit : Form
    {
        public Frm_Hasta_kayit()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl=new SqlBaglanti();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_hastalar (HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet) values(@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTC.Text);
            komut.Parameters.AddWithValue("@p4", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", txtSifre.Text);
            komut.Parameters.AddWithValue("@p6", cmbCinsiyet.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            txtAd.Clear();
            txtSoyad.Clear();
            mskTC.Clear();
            mskTelefon.Clear();
            txtSifre.Clear();
            

            MessageBox.Show("Kaydiniz gerceklesmistir sifreniz:" + txtSifre.Text,"Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

            

        }
    }
}
