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
    public partial class Frm2_Sekreter_girisi : Form
    {
        public static string SekreterTc = " ";
        SqlBaglanti2 bgl = new SqlBaglanti2();
        Thread th;
        public Frm2_Sekreter_girisi()
        {
            InitializeComponent();
        }
        private void OpenNewForm()
        {
            Application.Run(new Frm2_Sekreter_detay());
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SekreterTc = MskBocTC.Text;
            SqlCommand komut=new SqlCommand("select * from Tbl_sekreter  where SekreterTc=@p1 and SekreterSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskBocTC.Text);
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
                MessageBox.Show("Kullanıcı adı veya sifreyi yanlış giriniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.baglanti().Close();


        }
    }
}
