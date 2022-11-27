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
    public partial class Frm_giris_doktor : Form
    {
        Thread th;
        SqlBaglanti bgl=new SqlBaglanti();
        public Frm_giris_doktor()
        {
            InitializeComponent();
        }
        private void OpenNewForm()
        {
            Application.Run(new Frm_Doktor_detay());
        }
        public static string DoktorTC = " ";

        private void button1_Click(object sender, EventArgs e)
        {
            DoktorTC = mskTxtBoxTC.Text;
            SqlCommand komut=new SqlCommand("select * from Tbl_doktorlar where DoktorTC=@p1 and DoktorSifre=@p2",bgl.baglanti());
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
                MessageBox.Show("Kullanıcı adı veya sifre hatalidir","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            bgl.baglanti().Close();

        }
    }
}
