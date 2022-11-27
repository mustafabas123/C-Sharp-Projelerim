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
    public partial class Frm3_ogrenci_giris : Form
    {
        public static string Numara = " ";
        Thread th;
        SqlBglanti3 bgl=new SqlBglanti3();
        public Frm3_ogrenci_giris()
        {
            InitializeComponent();
        }
        private void OpenNewForm()
        {
            Application.Run(new Frm3_ogrenci_detay());
        }
        private void OpenNewForm2()
        {
            Application.Run(new Frm3_ogrenci_kaydol());
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Numara=mskBoxNumara.Text;
            SqlCommand komut=new SqlCommand("select * from Tbl_ogrenci where OgrenciNumara=@p1 and OgrenciSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskBoxNumara.Text);
            komut.Parameters.AddWithValue("@p2",txtBoxSifre.Text);
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
                MessageBox.Show("Kullanici adi veya şifreyi yanliş girdiniz","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            bgl.baglanti().Close();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        {
            th = new Thread(OpenNewForm2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }
    }
}
