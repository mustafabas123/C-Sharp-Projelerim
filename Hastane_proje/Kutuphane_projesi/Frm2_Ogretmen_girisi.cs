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
    public partial class Frm2_Ogretmen_girisi : Form
    {
        SqlBaglanti2 bgl=new SqlBaglanti2();
        Thread th;
        public static string OgretmenTc = " ";
        public Frm2_Ogretmen_girisi()
        {
            InitializeComponent();
        }
        private void OpenNewForm()
        {
            Application.Run(new Frm2_Ogretmen_detay());
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            OgretmenTc=MskBocTC.Text;
            SqlCommand komut=new SqlCommand("select * from Tbl_ogretmen where OgretmenTc=@p1 and OgretmenSifre=@p2",bgl.baglanti());
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
                MessageBox.Show("kullanıcı adı veya sifreyi yanlış girdiniz:", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.baglanti().Close();


        }

        private void Frm2_Ogretmen_girisi_Load(object sender, EventArgs e)
        {
            

        }
    }
}
