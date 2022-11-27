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
    public partial class Frm3_ogretmen_giris : Form
    {
        public static string Kullanici_adi=" " ;
        Thread th;
        SqlBglanti3 bgl=new SqlBglanti3();
        public Frm3_ogretmen_giris()
        {
            InitializeComponent();
        }
        private void OpenNewForm()
        {
            Application.Run(new Frm3_ogretmen_detay());
        }
        private void OpenNewForm2()
        {
            Application.Run(new Frm3_sifre_alma());
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Kullanici_adi = txtBoxKulaniciAdi.Text;
            SqlCommand komut=new SqlCommand("select * from Tbl_ogretmen where OgretmenKullaniciAdi=@p1 and OgretmenSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",txtBoxKulaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtBoxSifre.Text);
            SqlDataReader dr=komut.ExecuteReader();
            if (dr.Read())
            {
               th = new Thread(OpenNewForm);
               th.SetApartmentState(ApartmentState.STA);
               th.Start();
               this.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            th = new Thread(OpenNewForm2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void Frm3_ogretmen_giris_Load(object sender, EventArgs e)
        {

        }
    }
}
