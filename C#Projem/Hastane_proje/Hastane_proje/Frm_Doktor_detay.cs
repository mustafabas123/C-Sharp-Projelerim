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
    public partial class Frm_Doktor_detay : Form
    {
        Thread th;
        SqlBaglanti bgl=new SqlBaglanti();
        public string DoktorTC;
        public Frm_Doktor_detay()
        {
            InitializeComponent();
        }
        private void OpenNewForm()
        {
            Application.Run(new FrmDoktorBilgiDuzenle());
        }
        private void OpenNewForm2()
        {
            Application.Run(new Frm_duyurular());
        }

        private void Frm_Doktor_detay_Load(object sender, EventArgs e)
        {
            //Ad ve soyad çekme
            lblTC.Text=Frm_giris_doktor.DoktorTC.ToString();
            SqlCommand komut1=new SqlCommand("select DoktorAd,DoktorSoyad from Tbl_doktorlar where DoktorTC= @p1",bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr1=komut1.ExecuteReader();
            while (dr1.Read()) 
            {
                lblAdSoyad.Text = dr1[0]+" "+dr1[1];
            }
            // Randevular
            DataTable dt=new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_randevular where RandevuDoktor='" + lblAdSoyad.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;



        }

        private void btnBilgiDüzenle_Click(object sender, EventArgs e)
        {
            th = new Thread(OpenNewForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }

        private void BtnÇıkış_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            rchSikayet.Text=dataGridView1.Rows[secilen].Cells[7].Value.ToString();

        }

        private void Frm_Doktor_detay_Load_1(object sender, EventArgs e)
        {

        }
    }
}
