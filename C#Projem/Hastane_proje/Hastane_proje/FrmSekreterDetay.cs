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
    public partial class FrmSekreterDetay : Form
    {
        Thread th;
        SqlBaglanti bgl=new SqlBaglanti();  
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }

        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text =Frm_sekreter_giris.SekreterTc.ToString();
            //Ad soyad 
            SqlCommand komut1=new SqlCommand("select SekreterAdSoyad from Tbl_sekreter where SekreterTC=@p1",bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr1=komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblAdSoyad.Text=dr1[0].ToString();
            }
            bgl.baglanti().Close();

            //Branşları dataGride aktarma

            DataTable dt1=new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_brans", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
            bgl.baglanti().Close();

            //Doktorları dataGride Aktarma
            DataTable dt2=new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select (DoktorAd+' '+DoktorSoyad) as 'Doktorlar',DoktorBrans from Tbl_Doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            bgl.baglanti().Close();

            // Brasnları comboBox a aktarma
            SqlCommand komut2 = new SqlCommand("select BransAd from Tbl_brans", bgl.baglanti());
            SqlDataReader dr2=komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBoxBrans.Items.Add(dr2[0]);
            }



        }



        private void BtnKydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("insert into Tbl_randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@t1,@t2,@t3,@t4)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@t1", mskBoxTarih.Text);
            komut2.Parameters.AddWithValue("@t2",mskBoxSaat.Text);
            komut2.Parameters.AddWithValue("@t3", cmbBoxBrans.Text);
            komut2.Parameters.AddWithValue("@t4", cmbBoxDoktor.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Ouşturuldu.");
            

        }

        private void cmbBoxBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBoxDoktor.Items.Clear();
            //Doktorları getirme
            SqlCommand komut=new SqlCommand("select DoktorAd,DoktorSoyad from Tbl_doktorlar where DoktorBrans=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbBoxBrans.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                cmbBoxDoktor.Items.Add(dr[0]+" "+dr[1]);
            }
            bgl.baglanti().Close();

        }

        private void OpenNewForm()
        {
            Application.Run(new Frm_doktor_paneli());
        }
        private void OpenNewForm2()
        {
            Application.Run(new Frm_brans());
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

        }
        private void OpenNewForm3()
        {
            Application.Run(new Frm_randevu_listesi());
        }
        private void OpenNewForm4()
        {
            Application.Run(new Frm_duyurular());
        }
        private void BtnDoktor_Click(object sender, EventArgs e)
        {
            th = new Thread(OpenNewForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }

        private void BtnBrans_Click(object sender, EventArgs e)
        {
            th = new Thread(OpenNewForm2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }

        private void BtnRandevuListesi_Click(object sender, EventArgs e)
        {
            th = new Thread(OpenNewForm3);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            th = new Thread(OpenNewForm4);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbBoxDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
