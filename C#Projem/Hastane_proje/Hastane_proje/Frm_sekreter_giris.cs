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
    public partial class Frm_sekreter_giris : Form
    {
        public static string SekreterTc = " ";
        SqlBaglanti bgl=new SqlBaglanti();
        Thread th;
        public Frm_sekreter_giris()
        {
            InitializeComponent();
        }
        private void OpenNewForm()
        {
            Application.Run(new FrmSekreterDetay());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SekreterTc=mskTxtBoxTC.Text;
            SqlCommand komut=new SqlCommand("select * from Tbl_sekreter where SekreterTC=@p1 and SekreterSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",mskTxtBoxTC.Text);
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
                MessageBox.Show("Kullanici adi veya sifreyi yanliş girdiniz","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private void Frm_sekreter_giris_Load(object sender, EventArgs e)
        {

        }
    }
}
