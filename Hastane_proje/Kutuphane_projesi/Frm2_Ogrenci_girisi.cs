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
    public partial class Frm2_Ogrenci_girisi : Form
    {
        SqlBaglanti2 bgl=new SqlBaglanti2();
        Thread th;
        public static string tc = " ";
        public Frm2_Ogrenci_girisi()
        {
            InitializeComponent();
        }
        private void OpenNewForm()
        {
            Application.Run(new Frm2_Ogrenci_detay());
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            tc = MskBocTC.Text;
            SqlCommand komut=new SqlCommand("select * from Tbl_ogrenci where OgrenciTc=@p1 and OgrenciSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskBocTC.Text);
            komut.Parameters.AddWithValue("@p2", txtBoxSifre.Text);
            SqlDataReader dr=komut.ExecuteReader();
            if (dr.Read())
            {
                th = new Thread(OpenNewForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                this.Close();

            }
            else
            {
                MessageBox.Show("Kullanici adi veya sifreyi yanliş girdiniz", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.baglanti().Close();


        }
    }
}
