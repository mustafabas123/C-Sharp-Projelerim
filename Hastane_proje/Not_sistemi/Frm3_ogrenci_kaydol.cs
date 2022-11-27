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
    
    public partial class Frm3_ogrenci_kaydol : Form
    {
        SqlBglanti3 bgl=new SqlBglanti3();
        public Frm3_ogrenci_kaydol()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("insert into Tbl_ogrenci (OgrenciAd,OgrenciSoyad,OgrenciNumara,OgrenciSifre) values(@p1,@p2,@p3,@p4)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBoxAd.Text);
            komut.Parameters.AddWithValue("@p2", txtBoxSoyad.Text);
            komut.Parameters.AddWithValue("@p3",mskNumara.Text);
            komut.Parameters.AddWithValue("@p4", mskSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğrenci eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            txtBoxAd.Clear();
            txtBoxSoyad.Clear();
            mskNumara.Clear();
            mskSifre.Clear();
        }
    }
}
